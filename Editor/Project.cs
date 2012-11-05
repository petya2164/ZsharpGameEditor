using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZGE.Components;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using System.Reflection;


namespace ZGE
{
    internal class Project
    {
        public string filePath = null;
        //public string Name = null;
        // Code Editor status
        public CodeLike currentCode = null;
        public ZNodeProperties codeProperties = null;
        public string codePropertyName = null;
        public ZApplication app = null;
        public XmlDocument xmlDoc = null;
        public ZTreeView treeView = null;
        public static Editor editor;
        public Dictionary<XmlNode, string> nodeMap = new Dictionary<XmlNode, string>();

        public Project(string path)
        {
            filePath = path;
        }

        ~Project()
        {
            if (treeView != null)
                treeView.SetProject(null);
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
        }

        public string Name 
        {
            get
            {                
                if (app != null && app.Title != null) return app.Title;
                return "Untitled";
            }            
        }

        public void ClearCode()
        {
            currentCode = null;
            codeProperties = null;
            codePropertyName = null;
        }

        public void SetCode(CodeLike code, ZComponent parent, string propertyName)
        {
            currentCode = code;
            if (parent != null)
                codeProperties = parent.Tag as ZNodeProperties;
            codePropertyName = propertyName;
        }

        public void CodeChanged(string codeBoxText)
        {
            if (currentCode != null && codeProperties != null && codePropertyName != null)
            {
                currentCode.Text = codeBoxText;
                PropertyChangedEventArgs ev = new PropertyChangedEventArgs(codePropertyName, codeBoxText);
                ev.Action = PropertyChangeAction.CodeChanged;
                string newGuid = codeProperties.SaveCodeText(codePropertyName, codeBoxText, nodeMap);
                if (newGuid != null) currentCode.GUID = newGuid;
                //codeProperties.PropertyHolderChanged(this, ev);
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

        public void Rebuild(ZTreeView treeView, CodeGenerator codeGen)
        {
            app = null;
            BuildApplication(codeGen);
            if (treeView != null)
                FillTreeView(treeView);                       
        }

        public void BuildApplication(CodeGenerator codeGen)
        {
            if (xmlDoc == null) return;
            app = codeGen.CreateApplication(xmlDoc, true);
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
                FieldInfo fi = parent.GetType().GetField(xmlNode.Name, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                //if (pi != null) Console.WriteLine(" Parent property found: {0}", pi.PropertyType.Name);
                if (parent is ZComponent && fi != null && typeof(IList).IsAssignableFrom(fi.FieldType))
                {
                    //Console.WriteLine("List found: {0}", xmlNode.Name);
                    list = (IList) fi.GetValue(parent);
                }
                // Check if this node is a ZCode property of the parent
                else if (parent is ZComponent && fi != null && typeof(CodeLike).IsAssignableFrom(fi.FieldType))
                {                    
                    return next_index; //no TreeNode should be created for this
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
                            next_index = index+1;
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
            //object target = (list != null) ? list : (object) comp;
            ZNodeProperties props = new ZNodeProperties((object) list ?? (object) comp, parent, parent_list, xmlNode, treeNode);
            if (list == null) comp.Tag = props;

            if (treeView != null)
            {
                treeNode.Tag = props;
                ZTreeView.HighlightTreeNode(treeNode, props);
                props.XmlNodePropertyChanged += new XmlNodePropertyChangedEventHandler(treeView.XmlPropertiesUpdatedHandler);
            }
            return next_index;
        }

        public bool CanBeDeleted(TreeNode clickedNode)
        {
            if (treeView == null) return false;
            ZNodeProperties props = clickedNode.Tag as ZNodeProperties;
            if (props == null) return false;
            Type type = props.component.GetType();           

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

        public void FillContextMenu(TreeNode clickedNode, ContextMenuStrip xmlContextMenu)
        {
            if (treeView == null) return;
            xmlContextMenu.Items.Clear();
            ZNodeProperties props = clickedNode.Tag as ZNodeProperties;
            if (props == null) return;

            Type type = props.component.GetType();

            List<Type> list = new List<Type>();
            ToolStripMenuItem mainItem = null;
            if (props.component == app.Scene)
            {
                // Add gameobjects
                list = GetDerivedTypes(app.GetType().Assembly, typeof(Model));
                mainItem = new ToolStripMenuItem("Add GameObject", null);
                xmlContextMenu.Items.Add(mainItem);
                // Add group                
                ToolStripMenuItem groupItem = new ToolStripMenuItem("Add Group", null, this.AddChildElement_Click);
                groupItem.Tag = typeof(Group);
                xmlContextMenu.Items.Add(groupItem);
                
            }
            else if (typeof(IList).IsAssignableFrom(type))
            {
                // Determine what type of components can be added to the generic list
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type baseType = type.GetGenericArguments()[0];
                    list = GetDerivedTypes(typeof(ZComponent).Assembly, baseType);
                    mainItem = new ToolStripMenuItem("Add "+baseType.Name, null);
                    xmlContextMenu.Items.Add(mainItem);
                }
            }
            else if (type == typeof(Group))
            {
                // Any ZComponent can be added to a group
                list = GetDerivedTypes(typeof(ZComponent).Assembly, typeof(ZComponent));
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
                xmlContextMenu.Items.Add("Delete component", null, treeView.DeleteElement_Click);
            }          
        }

        public void DeleteComponent(ZNodeProperties props)
        {
            ZComponent comp = props.component as ZComponent;
            if (comp == null) return;

            nodeMap.Remove(props.xmlNode);
           
            ZComponent.App.RemoveComponent(comp);     // remove the old component
            // We should always set the Owner <= old Owner has been copied to newObj

            if (comp.OwnerList != null)  // delete reference from OwnerList            
                comp.OwnerList.Remove(comp);
            else if (comp.Owner != null) // delete reference from Owner's Children            
                comp.Owner.Children.Remove(comp);                
            comp.Owner = null;
            
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
            props.component = null;
        }

        public ZComponent CreateComponent(Type type, ZComponent parent, IList parent_list)
        {
            if (app == null) return null;
            ZComponent comp = null;
            if (type != null)
            {
                //Console.WriteLine("Creating instance of: {0}", type.FullName);
                comp = (ZComponent) Activator.CreateInstance(type);
                app.AddComponent(comp);
                if (parent != null)
                {
                    comp.Owner = parent;
                    if (parent_list != null)
                    {
                        comp.OwnerList = parent_list;
                        parent_list.Add(comp);
                        // components in member lists are not considered children!
                    }
                    else
                        parent.Children.Add(comp);
                }                
            }
            return comp;
        }

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

                ZComponent parent = parentProps.component as ZComponent;
                if (parent == null) parent = parentProps.parent_component as ZComponent;  // component is a List
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
                    comp = CreateComponent(childType, parent, parentProps.component as IList);          

                    if (childNodeName == "Model")
                    {
                        Model model = comp as Model;
                        if (model != null) model.GUID = currentGuid;

                        XmlAttribute nameAttribute = newXmlNode.OwnerDocument.CreateAttribute("Name");
                        nameAttribute.Value = modelName;
                        newXmlNode.Attributes.Append(nameAttribute);
                        model.Name = modelName;
                        newTreeNode.Name = String.Format("{0} - {1}", childNodeName, modelName); 
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
                ZNodeProperties props = new ZNodeProperties(comp, parent, parentProps.component as IList, newXmlNode, newTreeNode);
                comp.Tag = props;            
                newTreeNode.Tag = props;                
                props.XmlNodePropertyChanged += new XmlNodePropertyChangedEventHandler(treeView.XmlPropertiesUpdatedHandler);

                ZTreeView.HighlightTreeNode(newTreeNode, props);
                ZTreeView.HighlightTreeNode(parentNode, parentProps);
                parentNode.Expand();
                newTreeNode.Expand();
                treeView.SelectedNode = newTreeNode;

                // Tree node properties have been updated
                // Force parent to reload them to the PropertyBrowser
                treeView.OnPropertiesChanged();
                treeView.Invalidate();
                Console.WriteLine("Component added: {0}", childType.Name);                
                treeView.StatusString = "Child node added";
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
