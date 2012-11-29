using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZGE.Components;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using ICSharpCode.TextEditor;


namespace ZGE
{
    internal class Project
    {
        #region Fields
        public string filePath = null;
        //public string Name = null;
        
        // Code Editor status
        public CodeLike currentCode = null;
        public bool codeIsEvent = false;
        public ZNodeProperties codeProperties = null;
        public string codePropertyName = null;

        public ZApplication app = null;
        public XmlDocument xmlDoc = null;
        public ZTreeView treeView = null;
        public static Editor editor;
        public Dictionary<XmlNode, string> nodeMap = new Dictionary<XmlNode, string>();

        /// <summary>
        /// Fires when the XML is updated.
        /// </summary>
        public event EventHandler XMLChanged;
        #endregion

        public Project(string path)
        {
            filePath = path;
        }

        ~Project()
        {
            //if (treeView != null) treeView.SetProject(null);
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
        }

        private void OnXMLChanged()
        {
            // Fire content changed event 
            // to ensure all subscribers receive the changes
            if (XMLChanged != null)
            {
                XMLChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Returns the string representation of the XML.
        /// </summary>
        public string XMLText
        {
            get
            {
                if (xmlDoc != null && xmlDoc.DocumentElement != null)
                {
                    return xmlDoc.ToIndentedString();
                }
                else
                {
                    return "XML missing";
                }
            }
        }

        public string Name
        {
            get
            {
                if (app != null && app.Title != null) return app.Title;
                return "Untitled";
            }
        }

        public void UpdateAttribute(ZNodeProperties props, string propName, object newValue)
        {
            XmlNode xmlNode = props.xmlNode;
            if (xmlNode == null) return;
            XmlAttribute attribute = xmlNode.Attributes[propName];
            string str = Factory.Serialize(newValue);
            if (attribute == null)
            {
                XmlAttribute newAttribute = xmlNode.OwnerDocument.CreateAttribute(propName);
                newAttribute.Value = str;
                xmlNode.Attributes.Append(newAttribute);
            }
            else
                attribute.Value = str;
        }

        public void ClearCode()
        {
            currentCode = null;
            codeProperties = null;
            codePropertyName = null;
            codeIsEvent = false;
        }

        public void SetEventCode(ZComponent parent, string propertyName, TextEditorControl codeBox)
        {
            if (parent != null)
            {
                codeIsEvent = true;
                currentCode = app.FindEvent(parent, propertyName) as CodeLike;                
                // CodeTextChanged will do nothing since codeProperties and codePropertyName are null                 
                codeBox.Text = (currentCode != null) ? currentCode.Text : null;                
                codeProperties = parent.Tag as ZNodeProperties;
                codePropertyName = propertyName;                
            }                               
        }

        public void SetCode(CodeLike code, ZComponent parent, string propertyName)
        {
            codeIsEvent = false;
            currentCode = code;
            if (parent != null) codeProperties = parent.Tag as ZNodeProperties;
            codePropertyName = propertyName;
        }

        public void CodeChanged(string codeBoxText)
        {
            if (codeProperties != null && codePropertyName != null)
            {
                if (codeIsEvent && currentCode == null)
                    currentCode = new ZEvent(codeProperties.Component, codePropertyName);
                if (currentCode != null)
                {
                    //Console.WriteLine("Changing code text.");
                    currentCode.Text = codeBoxText;
                    SaveCodeText(codePropertyName, codeBoxText, codeProperties.xmlNode);
                    OnXMLChanged();
                }                     
            }
        }

        public void SaveCodeText(string propName, string newValue, XmlNode xmlNode)
        {
            bool found = false;
            XmlNode child = null;

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.Name == propName)
                {
                    child = childNode;
                    foreach (XmlCDataSection cData in childNode.ChildNodes)
                    {
                        cData.InnerText = newValue;
                        found = true;
                    }
                }
            }

            if (found == false)
            {
                if (child == null)
                {
                    // Create new child node
                    child = xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, propName, xmlNode.NamespaceURI);
                    string newGuid = Guid.NewGuid().ToString();
                    // Update the project nodemap
                    nodeMap[child] = newGuid;
                    // Assign new GUID to the code component
                    currentCode.GUID = newGuid;
                    xmlNode.AppendChild(child);
                }
                XmlNode cdata = xmlNode.OwnerDocument.CreateNode(XmlNodeType.CDATA, newValue, xmlNode.NamespaceURI);
                child.AppendChild(cdata);
                found = true;
            }
        }

        public static Project CreateProject(string filePath, ZTreeView treeView, CodeGenerator codeGen)
        {
            Project project = new Project(filePath);
            project.LoadXml();
            project.BuildApplication(codeGen);
            if (treeView != null) project.FillTreeView(treeView);

            return project;
        }

        public void Reset(ZTreeView treeView, CodeGenerator codeGen)
        {
            app = null;
            BuildApplication(codeGen);
            if (treeView != null) FillTreeView(treeView);
        }

        public void BuildApplication(CodeGenerator codeGen)
        {
            if (xmlDoc == null) return;
            app = codeGen.CreateApplication(xmlDoc, true);
            if (app != null) app.Load(); // load the app to create its components
            nodeMap = codeGen.nodeMap;  // we need the GUIDs in the nodeMap for recompilation
        }

        public bool RecompileApplication(CodeGenerator codeGen, ZTreeView treeView)
        {
            if (xmlDoc == null || app == null) return false;
            ZApplication newApp = codeGen.RecompileApplication(xmlDoc, nodeMap, app);
            if (newApp != null)
            {
                app = newApp;
                
                //if (treeView != null) FillTreeView(treeView);

                return true;
            }
            return false;
        }

        public void FillTreeView(ZTreeView treeView)
        {
            this.treeView = treeView;
            treeView.SetProject(this);

            treeView.Nodes.Clear();

            XmlNode rootElement = xmlDoc.DocumentElement;
            if (rootElement != null)
                ProcessNode(app, null, 0, treeView.Nodes, rootElement);

            if (treeView != null)
            {
                treeView.xmlDocument = xmlDoc;
                treeView.ExpandAll();
                treeView.Invalidate();
            }
        }

        public bool IsCompatibleType(ZComponent comp, XmlNode xmlNode)
        {
            Type type = comp.GetType();
            if (type.Name == xmlNode.Name) return true;
            if (xmlNode.Name == "Model" || xmlNode.Name == "GameObject")
            {
                if (typeof(Model).IsAssignableFrom(type)) return true;
            }
            return false;
        }

        private int ProcessNode(ZComponent parent, IList parent_list, int next_index, TreeNodeCollection parent_nodes, XmlNode xmlNode)
        {
            //if (xmlNode == null) return;
            //Console.WriteLine("Processing: {0}", xmlNode.Name);

            ZComponent comp = parent;
            IList list = null;
            if (xmlNode.Name == "ZApplication")
            {
                //SetFields(comp, xmlNode);                
            }
            else
            {
                // Check if this node is a List property of the parent
                FieldInfo fi = CodeGenerator.GetField(parent.GetType(), xmlNode.Name);
                //if (pi != null) Console.WriteLine(" Parent property found: {0}", pi.PropertyType.Name);
                if (fi != null && typeof(IList).IsAssignableFrom(fi.FieldType))
                {
                    //Console.WriteLine("List found: {0}", xmlNode.Name);
                    list = (IList) fi.GetValue(parent);
                }
                    // Check if this node is an event of the parent
                else if (fi != null && typeof(Delegate).IsAssignableFrom(fi.FieldType))
                {
                    return next_index; //no TreeNode was created for this event
                }
                // Check if this node is a ZCode property of the parent
                else if (fi != null && typeof(CodeLike).IsAssignableFrom(fi.FieldType))
                {
                    return next_index; //no TreeNode was created for this CodeLike component
                }
                else
                {
                    // Find the component in the list or among the children
                    comp = null;
                    IList findList = (IList) parent.Children;
                    if (parent_list != null) findList = parent_list; // parent_list has the priority

                    for (int index = next_index; index < findList.Count; index++)
                    {
                        ZComponent candidate = findList[index] as ZComponent;
                        if (IsCompatibleType(candidate, xmlNode))
                        {
                            comp = candidate;
                            next_index = index + 1;
                            break;
                        }
                    }

                    if (comp == null)
                    {
                        Console.WriteLine("SKIPPING subtree - Cannot find matching component: {0}", xmlNode.Name);
                        return next_index;
                    }
                }
            }

            TreeNode treeNode = null;
            if (parent_nodes != null)
            {
                string displayName = xmlNode.Name;
                XmlAttribute attribute = xmlNode.Attributes["Name"];
                if (attribute != null)
                    displayName = displayName + " - " + attribute.Value;

                treeNode = new TreeNode(displayName);
                parent_nodes.Add(treeNode);

                // clear subtree
                if (treeNode != null) treeNode.Nodes.Clear();
            }

            // recursively build SubTree
            int i = 0;
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element)
                {
                    i = ProcessNode(comp, list, i, treeNode.Nodes, childNode);
                }
            }
            // construct ZNodeProperties object for the TreeNode and assign it to Tag property
            object target = (object) list ?? (object) comp;
            object parentObj = (object) parent_list ?? (object) parent;
            ZNodeProperties props = new ZNodeProperties(target, parentObj, xmlNode, treeNode);
            if (list == null) comp.Tag = props;

            if (treeView != null)
            {
                treeNode.Tag = props;
                ZTreeView.HighlightTreeNode(treeNode, props);
                //props.XmlNodePropertyChanged += new XmlNodePropertyChangedEventHandler(treeView.UpdateNodeText);
            }
            return next_index;
        }

        internal bool IsList(TreeNode dropNode)
        {
            if (treeView == null) return false;
            ZNodeProperties props = dropNode.Tag as ZNodeProperties;
            if (props == null) return false;
            if (props.List is IList) return true;
            return false;
        }

        internal bool IsGroup(TreeNode dropNode)
        {
            if (treeView == null) return false;
            ZNodeProperties props = dropNode.Tag as ZNodeProperties;
            if (props == null) return false;
            if (props.Component is Group) return true;
            return false;
        }

        public bool IsDragAllowed(TreeNode dragNode, TreeNode dropNode, bool asChild)
        {
            if (treeView == null || app == null) return false;
            ZNodeProperties dragProps = dragNode.Tag as ZNodeProperties;
            if (dragProps == null) return false;
            ZNodeProperties dropProps = dropNode.Tag as ZNodeProperties;
            if (dropProps == null) return false;

            // No dropping on the application node directly
            if (dropProps.Component == app) return false;


            if (asChild) // adding to a list or group
            {
                // Accept GameObjects as children
                if (dropProps.List == app.Scene)
                {
                    Model model = dragProps.Component as Model;
                    if (model != null && model.Prototype == false)
                        return true;
                }

                // Is dropNode a suitable container (list or group) for dragNode?
                if (IsChildElementAllowed(dropNode, dragProps.Component.GetType()))
                    return true;
            }
            else // adding as a sibling of dropNode
            {
                ZComponent dropComp = dropProps.Component;
                // Is dropNode's OwnerList a suitable container for dragNode?
                if (dropComp != null)
                {
                    if (dropComp.OwnerList is IList)
                    {
                        // Determine what type of components can be added to the generic list
                        Type listType = dropComp.OwnerList.GetType();
                        if (listType.IsGenericType)
                        {
                            Type baseType = listType.GetGenericArguments()[0];
                            if (baseType.IsAssignableFrom(dragProps.Component.GetType())) return true;
                        }

                        // Accept GameObject siblings
                        if (dropComp.OwnerList == app.Scene)
                        {
                            Model model = dragProps.Component as Model;
                            if (model != null && model.Prototype == false)
                                return true;
                        }
                    }
                    if (dropComp.Owner is Group)
                        return true;
                }
            }

            return false;
        }

        public void MoveComponent(TreeNode dragNode, TreeNode dropNode, ZGE.ZTreeView.DropSide dropSide)
        {
            if (treeView == null || app == null) return;
            ZNodeProperties dragProps = dragNode.Tag as ZNodeProperties;
            if (dragProps == null) return;
            ZNodeProperties dropProps = dropNode.Tag as ZNodeProperties;
            if (dropProps == null) return;
            ZComponent dragComp = dragProps.Component;
            if (dragComp == null) return;

            // Remove dragComp references at its previous location
            dragComp.SetOwner(null, null);      // delete references from OwnerList or from Owner's Children
            
            // Remove dragNode from the treeview
            dragNode.Remove();

            if (dropSide == ZGE.ZTreeView.DropSide.Inside) // adding to a list or group
            {
                // Add dragComp reference to its new parent/OwnerList
                ZComponent parent = dropProps.Component;
                if (parent == null) parent = dropProps.Parent as ZComponent;  // component is a List
                dragComp.SetOwner(parent, dropProps.List);

                // Perform Xml operation
                dropProps.xmlNode.AppendChild(dragProps.xmlNode);

                // Move dragNode to be a child of dropNode in the treeview                
                dropNode.Expand();                
                dropNode.Nodes.Add(dragNode);
            }
            else // adding as a sibling of dropNode
            {
                ZComponent dropComp = dropProps.Component;
                if (dropComp == null) return;                

                int plus = 0;  // index before dropComp
                if (dropSide == ZGE.ZTreeView.DropSide.Bottom) plus = 1; // index after dropComp
                int index;

                dragComp.ReplaceOwner(dropComp.Owner);
                if (dropComp.OwnerList is IList)
                {
                    dragComp.OwnerList = dropComp.OwnerList;
                    index = dropComp.OwnerList.IndexOf(dropComp);
                    if (index != -1) dropComp.OwnerList.Insert(index + plus, dragComp);
                }
                else //if (dropComp.Owner is Group)
                {
                    index = dropComp.Owner.Children.IndexOf(dropComp);
                    if (index != -1) dropComp.Owner.Children.Insert(index + plus, dragComp);
                }

                //Adjust node position in the treeview
                TreeNode parentNode = dropNode.Parent;
                if (parentNode == null) return;
                XmlNode xmlParent = dropProps.xmlNode.ParentNode;
                if (xmlParent == null) return;

                index = parentNode.Nodes.IndexOf(dropNode);
                if (index != -1) parentNode.Nodes.Insert(index + plus, dragNode);

                // Perform Xml operation
                if (dropSide == ZGE.ZTreeView.DropSide.Top)
                {
                    xmlParent.InsertBefore(dragProps.xmlNode, dropProps.xmlNode);
                }
                else if (dropSide == ZGE.ZTreeView.DropSide.Bottom)
                {
                    xmlParent.InsertAfter(dragProps.xmlNode, dropProps.xmlNode);
                }
            }

            treeView.SelectedNode = dragNode;
            OnXMLChanged();
        }

        public bool CanBeDeleted(TreeNode clickedNode)
        {
            if (treeView == null) return false;
            ZNodeProperties props = clickedNode.Tag as ZNodeProperties;
            if (props == null || props.Component == null) return false;
            Type type = props.Component.GetType();

            // The application and member lists cannot be deleted
            if (clickedNode.Level > 0 && !typeof(IList).IsAssignableFrom(type))
                return true;

            return false;
        }

        public static List<Type> GetDerivedTypes(Assembly assembly, Type ancestor)
        {
            //var assembly = Assembly.GetAssembly(typeof(ZComponent)); 
            //string ns = "ZGE.Components";            
            return assembly.GetTypes().Where(type => ancestor.IsAssignableFrom(type)).ToList();
        }

        public static List<Type> GetDerivedTypes(Type mainType, Type ancestor)
        {
            var assembly = Assembly.GetAssembly(mainType); 
            var exclude = new List<string> {"Gwen.UnitTest", "Gwen.ControlInternal"};
                    //exclude this namespace
            
            return assembly.GetTypes().Where(type => !exclude.Contains(type.Namespace) && Editor.IsToolboxItem(type) && ancestor.IsAssignableFrom(type)).ToList();
        }

        public bool IsChildElementAllowed(TreeNode destNode, string childTypeName)
        {
            if (app == null || treeView == null || destNode == null || childTypeName == null) return false;
            Type type = typeof(ZComponent).Assembly.GetType(childTypeName);
            if (type == null) return false;
            return IsChildElementAllowed(destNode, type);
        }

        public bool IsChildElementAllowed(TreeNode destNode, Type childType)
        {
            if (app == null || treeView == null || destNode == null || childType == null) return false;
            ZNodeProperties props = destNode.Tag as ZNodeProperties;
            if (props == null) return false;

            if (props.List == app.Scene)
            {
                // TODO: Allow more scene elements here 
                if (typeof(Group).IsAssignableFrom(childType)) return true;
                // TODO: A Model prototype should not be allowed here
                //if (childType.IsSubclassOf(Model)) return true;
            }
            else if (props.List is IList)
            {
                // Determine what type of components can be added to the generic list
                Type listType = props.List.GetType();
                if (listType.IsGenericType)
                {
                    Type baseType = listType.GetGenericArguments()[0];
                    if (baseType.IsAssignableFrom(childType)) return true;
                }
            }
            else if (props.Component is Group)
            {
                // Any ZComponent can be added to a group
                return true;
            }
            return false;
        }

        public void FillContextMenu(TreeNode clickedNode, ContextMenuStrip xmlContextMenu)
        {
            if (app == null || treeView == null) return;
            //Console.WriteLine("FillContextMenu  reference {0} / {1}", fi.Name, fi.FieldType.Name);
            ZNodeProperties props = clickedNode.Tag as ZNodeProperties;
            //Console.WriteLine("FillContextMenu {0} ", clickedNode.Text);
            if (props == null) Console.WriteLine("FillContextMenu null props");
            if (props == null) return;           

            List<Type> list = new List<Type>();
            ToolStripMenuItem mainItem = null;
            if (props.List == app.Scene)
            {
                // Add gameobjects
                list = GetDerivedTypes(app.GetType(), typeof(Model));
                mainItem = new ToolStripMenuItem("Add GameObject", null);
                xmlContextMenu.Items.Add(mainItem);
                // Add group                
                ToolStripMenuItem groupItem = new ToolStripMenuItem("Add Group", null, this.AddChildElement_Click);
                groupItem.Tag = typeof(Group);
                xmlContextMenu.Items.Add(groupItem);

            }
            else if (props.List is IList)
            {
                // Determine what type of components can be added to the generic list
                Type listType = props.List.GetType();               
                if (listType.IsGenericType)
                {
                    Type baseType = listType.GetGenericArguments()[0];
                    list = GetDerivedTypes(typeof(ZComponent), baseType);
                    mainItem = new ToolStripMenuItem("Add " + baseType.Name, null);
                    xmlContextMenu.Items.Add(mainItem);
                }
            }
            else if (props.Component is Group)
            {
                // Any ZComponent can be added to a group
                list = GetDerivedTypes(typeof(ZComponent), typeof(ZComponent));
                //list = GetDerivedTypes(app.GetType().Assembly, typeof(ZComponent));
                mainItem = new ToolStripMenuItem("Add Component", null);
                xmlContextMenu.Items.Add(mainItem);
            }

            if (mainItem != null && list.Count > 0)
            {
                list.Sort((a, b) => a.Name.CompareTo(b.Name));
                foreach (Type child in list)
                {
                    if (child.IsAbstract) continue;
                    ToolStripMenuItem item = new ToolStripMenuItem(child.Name, null, this.AddChildElement_Click);
                    item.Tag = child;
                    mainItem.DropDownItems.Add(item);
                }
            }

            // The application and member lists cannot be deleted
            if (CanBeDeleted(clickedNode))
            {
                if (xmlContextMenu.Items.Count > 0) xmlContextMenu.Items.Add(new ToolStripSeparator());
                xmlContextMenu.Items.Add("Delete component", null, this.DeleteElement_Click);
            }
        }

        // Called by ContextMenu items
        public void DeleteElement_Click(object sender, EventArgs e)
        {
            if (treeView == null) return;
            TreeNode treeNodeToDelete = treeView.SelectedNode;
            if (treeNodeToDelete == null) return;
            TreeNode parentNode = treeNodeToDelete.Parent;
            if (parentNode == null) return;

            ZNodeProperties props = treeNodeToDelete.Tag as ZNodeProperties;

            if (props != null)
            {
                DeleteComponent(props);
                XmlNode nodeToDeleteFrom = props.xmlNode.ParentNode;
                if (nodeToDeleteFrom != null)
                    nodeToDeleteFrom.RemoveChild(props.xmlNode);

                treeNodeToDelete.Remove();

                treeView.SelectedNode = parentNode;
                treeView.Invalidate();
                OnXMLChanged();
            }
        }

        public void DeleteComponent(ZNodeProperties props)
        {
            ZComponent comp = props.Component;
            if (comp == null) return;

            nodeMap.Remove(props.xmlNode);

            ZComponent.App.RemoveComponent(comp);     // remove the old component
            // We should always set the Owner <= old Owner has been copied to newObj

            comp.SetOwner(null, null);   // delete references from OwnerList or from Owner's Children  

            // If the comp was selected in the editor, then clear that reference
            if (editor.SelectedComponent == comp)
                editor.SelectedComponent = null;
            if (app.SelectedObject == comp)
                app.SelectedObject = null;

            // Delete named references from the app
            if (comp.HasName())
            {
                FieldInfo fi = app.GetType().GetField(comp.Name, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (fi != null && fi.FieldType == comp.GetType())
                {
                    Console.WriteLine("Nulling named reference {0} / {1}", fi.Name, fi.FieldType.Name);
                    fi.SetValue(app, null);
                }
            }
            if (typeof(Model).IsAssignableFrom(comp.GetType()))
            {
                Model newMod = comp as Model;
                ZComponent.App.RemoveModel(newMod);
                // Refresh scene treeview in the editor (only necessary for GameObjects)
                //if (newMod != null && newMod.Prototype == false)
                //editor.RefreshSceneTreeview();                
            }
            props.Component = null;
            if (comp.HasName())
                Console.WriteLine("Component deleted: {0}", comp.Name);
            else
                Console.WriteLine("Component deleted.");
        }

        public ZComponent CreateComponent(Type type, ZComponent parent, IList parent_list)
        {
            if (app == null) return null;
            ZComponent comp = null;
            if (type != null)
            {
                //Console.WriteLine("Creating instance of: {0}", type.FullName);
                comp = (ZComponent) Activator.CreateInstance(type, new object[] { parent });                
                comp.SetOwner(parent, parent_list);
            }
            return comp;
        }

        

        // Called by ContextMenu items
        private void AddChildElement_Click(object sender, EventArgs e)
        {
            if (treeView == null) return;
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;
            Type childType = item.Tag as Type;
            if (childType == null) return;
            //Console.WriteLine("Add child called {0}", childType.Name);
            TreeNode parentNode = treeView.SelectedNode;
            if (parentNode != null)
                AddChildElement(parentNode, childType);
        }

        // Called by DragDrop in treeView
        public void AddChildElement(TreeNode parentNode, string childTypeName)
        {
            Type type = typeof(ZComponent).Assembly.GetType(childTypeName);
            if (type != null)
                AddChildElement(parentNode, type);
        }


        public void AddChildElement(TreeNode parentNode, Type childType)
        {
            if (treeView == null || parentNode == null || childType == null) return;
            Console.WriteLine("Add child called {0}", childType.Name);
            ZNodeProperties parentProps = parentNode.Tag as ZNodeProperties;
            if (parentProps == null) return;
            string childNodeName = childType.Name;
            if (childType.BaseType == typeof(Model)) // this is a GameObject
                childNodeName = "GameObject";

            try
            {
                string modelName = null;
                if (childNodeName == "Model")
                {
                    DialogResult res = DialogHelper.InputBox("Model name", "Enter Model name:", ref modelName);
                    if (res == DialogResult.Cancel || modelName.Length == 0 || app.Find(modelName) != null)
                    {
                        Console.WriteLine("Invalid model name: \"{0}\"", modelName);
                        return;
                    }
                }

                XmlNode xmlNode = parentProps.xmlNode;
                //  Create new leaf node
                XmlNode newXmlNode = xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, childNodeName, xmlNode.NamespaceURI);
                string currentGuid = Guid.NewGuid().ToString();
                nodeMap[newXmlNode] = currentGuid;
                xmlNode.AppendChild(newXmlNode);

                TreeNode newTreeNode = new TreeNode(childNodeName);
                parentNode.Nodes.Add(newTreeNode);

                ZComponent parent = parentProps.Component;
                if (parent == null) parent = parentProps.Parent as ZComponent;  // component is a List
                ZComponent comp = null;

                if (childType.BaseType == typeof(Model)) // this is a GameObject
                {
                    // clone the corresponding Model
                    Model prototype = app.FindPrototypeByType(childType);
                    if (prototype == null)
                    {
                        Console.WriteLine("Cannot find prototype for {0}", childType.Name);
                        return;
                    }
                    comp = prototype.CreateClone(parent);

                    // assign Model attribute to the XmlNode
                    XmlAttribute newAttribute = newXmlNode.OwnerDocument.CreateAttribute("Model");
                    newAttribute.Value = prototype.Name;
                    newXmlNode.Attributes.Append(newAttribute);

                    //editor.RefreshSceneTreeview();
                }
                else
                {
                    comp = CreateComponent(childType, parent, parentProps.List);

                    if (childNodeName == "Model")
                    {
                        Model model = comp as Model;
                        if (model != null) model.GUID = currentGuid;

                        XmlAttribute nameAttribute = newXmlNode.OwnerDocument.CreateAttribute("Name");
                        nameAttribute.Value = modelName;
                        newXmlNode.Attributes.Append(nameAttribute);
                        model.Name = modelName;
                        newTreeNode.Text = String.Format("{0} - {1}", childNodeName, modelName);
                    }

                    // create child XML nodes for generic member lists                    
                    foreach (FieldInfo fi in comp.GetType().GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance))
                    {
                        // Check if this field is a List
                        //if (fi.FieldType.IsGenericType && fi.FieldType.GetGenericTypeDefinition() == typeof(List<>))
                        if (fi != null && typeof(IList).IsAssignableFrom(fi.FieldType) && fi.Name != "Children" && fi.Name != "OwnerList")
                        {
                            Console.WriteLine("List node created: {0}", fi.Name);
                            XmlNode childXmlNode = newXmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, fi.Name, newXmlNode.NamespaceURI);
                            newXmlNode.AppendChild(childXmlNode);
                            nodeMap[childXmlNode] = Guid.NewGuid().ToString();
                        }
                    }
                }

                // build subtree for member lists
                int i = 0;
                foreach (XmlNode childNode in newXmlNode.ChildNodes)
                {
                    if (childNode.NodeType == XmlNodeType.Element)
                    {
                        i = ProcessNode(comp, null, i, newTreeNode.Nodes, childNode);
                    }
                }

                // construct ZNodeProperties object for the TreeNode and assign it to Tag property
                object parentObj = (object) parentProps.List ?? (object) parent;
                ZNodeProperties props = new ZNodeProperties(comp, parentObj , newXmlNode, newTreeNode);
                comp.Tag = props;
                newTreeNode.Tag = props;
                //props.XmlNodePropertyChanged += new XmlNodePropertyChangedEventHandler(treeView.UpdateNodeText);

                ZTreeView.HighlightTreeNode(newTreeNode, props);
                ZTreeView.HighlightTreeNode(parentNode, parentProps);                
                parentNode.Expand();
                newTreeNode.Expand();
                treeView.SelectedNode = newTreeNode;

                // Tree node properties have been updated
                // Force parent to reload them to the PropertyBrowser
                //treeView.OnPropertiesChanged();
                treeView.Invalidate();
                Console.WriteLine("Component added: {0}", childType.Name);
                treeView.StatusString = "Child node added";
                OnXMLChanged();
                // Recompilation is necessary if a new Model was added
                if (childNodeName == "Model")
                    if (editor != null) editor.compileCodeBtn_Click(this, null);
            }
            catch (Exception ex)
            {
                treeView.StatusString = "Exception occurred: " + ex.Message;
                Console.WriteLine(ex.ToString());
            }
        }




    }
}
