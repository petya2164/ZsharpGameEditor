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
        public string Name = null;
        // Code Editor status
        public CodeLike currentCode = null;
        public ZNodeProperties codeProperties = null;
        public string codePropertyName = null;
        public ZApplication app = null;
        public XmlDocument xmlDoc = null;
        public ZTreeView treeView = null;
        public Dictionary<XmlNode, string> nodeMap = new Dictionary<XmlNode, string>();

        public Project(string path)
        {
            filePath = path;
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
        }

        public void SetName()
        {
            if (app != null) Name = app.Title;
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
                codeProperties.PropertyHolderChanged(this, ev);
            }
        }

        public static Project CreateProject(string filePath, ZTreeView treeView, CodeGenerator codeGen)
        {
            Project project = new Project(filePath);
            project.LoadXml();
            project.BuildApplication(codeGen);
            if (treeView != null) project.FillTreeView(treeView);
            project.SetName();

            return project;
        }

        public void Rebuild(ZTreeView treeView, CodeGenerator codeGen)
        {
            app = null;
            BuildApplication(codeGen);
            if (treeView != null)
                FillTreeView(treeView);
            SetName();            
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
                if (parent is ZComponent && fi != null && fi.FieldType.Name.StartsWith("List"))
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
    }
}
