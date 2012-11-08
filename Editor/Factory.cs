using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZGE.Components;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.Collections;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using System.IO;

namespace ZGE
{
    class Unresolved
    {
        public ZComponent comp { get; set; }
        public FieldInfo prop { get; set; }
        public string value { get; set; }
    }
    
    static class Factory
    {
        static ZTreeView _treeView;        
        static List<Type> _types;
        static List<Unresolved> _unresolved;

        static Factory()
        {
            _types = GetTypesFromNamespace(Assembly.GetAssembly(typeof(ZApplication)), "ZGE.Components");
        }

        // Extension method for printing XmlDocument with a decent formatting
        public static string ToIndentedString(this XmlDocument doc)
        {
            string result;
            Encoding utf8noBOM = new UTF8Encoding(false);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = utf8noBOM;
            settings.Indent = true;
            settings.IndentChars = "  ";
            settings.NewLineChars = "\r\n";
            settings.NewLineHandling = NewLineHandling.Replace;
            
            using (MemoryStream output = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(output, settings))
                {
                    doc.Save(writer);
                }
                result = Encoding.UTF8.GetString(output.ToArray());
            }
            return result;
        }

        public static List<Type> GetTypesFromNamespace(Assembly assembly,
                                               String myNamespace)
        {
            return assembly.GetTypes().Where(type => type.Namespace == myNamespace).ToList();

        }

        public static Project CreateProject(string filePath, ZTreeView treeView)
        {
            Project project = new Project(filePath);
            project.LoadXml();
            project.app = Load(project.xmlDoc, treeView);             

            return project;
        }


        public static ZApplication Load(XmlDocument xmlDocument, ZTreeView treeView)
        {
            _treeView = treeView;
            if (treeView != null) treeView.Nodes.Clear();            

            ZApplication app = new ZApplication();            
            _unresolved = new List<Unresolved>();

            XmlNode rootElement = xmlDocument.DocumentElement;
            if (rootElement != null)
            {                
                if (treeView != null)                
                    ProcessNode(app, null, treeView.Nodes, rootElement);
                else
                    ProcessNode(app, null, null, rootElement);
            }
            foreach(var unres in _unresolved)
            {
                ZComponent target = ZComponent.App.Find(unres.value);
                if (target != null)                                   
                    unres.prop.SetValue(unres.comp, target);                
                else
                    Console.WriteLine("Unresolved field: {0} - {1}", unres.prop.FieldType.Name, unres.value);
            }
            _unresolved.Clear();
            if (treeView != null)
            {
                treeView.xmlDocument = xmlDocument;
                treeView.ExpandAll();
                treeView.Invalidate();
            }

            return app;
        }

        private static void SetFields(ZComponent comp, XmlNode xmlNode)
        {
            Type type = comp.GetType();
            // Add attributes to the properties
            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    string val = attribute.Value;
                    FieldInfo fi = type.GetField(attribute.Name, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                    if (fi != null)
                    {
                        //Console.WriteLine(" Field found: {0}", attribute.Name);
                        
                        object obj = Deserialize(val, fi.FieldType);
                        if (obj != null)
                            fi.SetValue(comp, obj);
                        /*else if (typeof(ZCode).IsAssignableFrom(fi.FieldType))  //CODE CANNOT BE STORED AS A PROPERTY
                        {
                            ZCode code = (ZCode)Activator.CreateInstance(fi.FieldType);
                            code.Text = val;
                            code.Owner = comp;
                            //Console.WriteLine("Code Text:\n{0}", code.Text);
                            fi.SetValue(comp, code);
                            //ZComponent.App.AddComponent(code);
                        }*/
                        else if (fi.FieldType.IsSubclassOf(typeof(ZComponent)))
                        {
                            _unresolved.Add(new Unresolved { comp = comp, prop = fi, value = val });
                        }
                        else
                            Console.WriteLine(" Unsupported field: {0}-{1}", attribute.Name, val);
                    }
                    else
                        Console.WriteLine(" Field not found: {0}-{1}", attribute.Name, val);
                    //properties.Add(new CustomProperty(attribute.Name, attribute.Value, typeof(string), false, true));
                }
            }
        }

        public static ZComponent CreateComponent(string typeName, XmlNode xmlNode, ZComponent parent, IList parent_list)
        {
            var type = _types.Find(it => it.Name == typeName);
            ZComponent comp = null;
            if (type != null)
            {
                //Console.WriteLine("Creating instance of: {0}", type.FullName);
                comp = (ZComponent) Activator.CreateInstance(type);
                ZComponent.App.AddComponent(comp);
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
                if (xmlNode != null)
                    SetFields(comp, xmlNode);                
            }
            return comp;
        }

        private static void ProcessNode(ZComponent parent, IList parent_list, TreeNodeCollection parent_nodes, XmlNode xmlNode)
        {
            if (xmlNode == null) return;
            //Console.WriteLine("Processing: {0}", xmlNode.Name);

            ZComponent comp = parent;
            IList list = null;
            if (xmlNode.Name == "ZApplication")
            {
                SetFields(comp, xmlNode);
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
                    CodeLike code = (CodeLike) fi.GetValue(parent); // Activator.CreateInstance(fi.FieldType);
                    code.Text = xmlNode.InnerText;
                    //code.Owner = parent;
                    Console.WriteLine("Code Text:\n{0}", code.Text);
                    fi.SetValue(comp, code);
                    //ZComponent.App.AddComponent(code);
                    return; //no TreeNode should be created for this
                }
                else
                {
                    comp = CreateComponent(xmlNode.Name, xmlNode, parent, parent_list);
                    if (comp == null)
                    {
                        Console.WriteLine("SKIPPING subtree - Cannot find type: {0}", xmlNode.Name);
                        return;
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
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element)
                {                   
                    if (treeNode != null)
                        ProcessNode(comp, list, treeNode.Nodes, childNode);
                    else
                        ProcessNode(comp, list, null, childNode);
                }
            }
            // construct ZNodeProperties object for the TreeNode and assign it to Tag property
            object target = (list != null) ? list : (object)comp;
            ZNodeProperties props = new ZNodeProperties(target, parent, parent_list, xmlNode, treeNode);
            if (list == null) comp.Tag = props;

            if (_treeView != null)
            {
                treeNode.Tag = props;
                ZTreeView.HighlightTreeNode(treeNode, props);
                //props.XmlNodePropertyChanged += new XmlNodePropertyChangedEventHandler(_treeView.UpdateNodeText);
            }
        }

        public static object Deserialize(string val, Type type)
        {
            object ret = null;
            if (type == typeof(string)) return val;
            else if (type == typeof(int)) return int.Parse(val);
            else if (type == typeof(double)) return double.Parse(val);
            else if (type == typeof(float)) return float.Parse(val);
            else if (type == typeof(bool)) return bool.Parse(val);
            else if (type.IsEnum) return Enum.Parse(type, val);
            else if (type == typeof(Vector3))
            {
                string[] ar = val.Split(' ');
                if (ar.Length == 3)
                {
                    Vector3 v = new Vector3(float.Parse(ar[0]), float.Parse(ar[1]), float.Parse(ar[2]));
                    return v;
                }                
            }
            else if (type == typeof(Vector2))
            {
                string[] ar = val.Split(' ');
                if (ar.Length == 2)
                {
                    Vector2 v = new Vector2(float.Parse(ar[0]), float.Parse(ar[1]));
                    return v;
                }
            }
            else if (type == typeof(Color))
            {
                string[] ar = val.Split(' ');
                if (ar.Length == 4)
                {
                    Color4 c = new Color4(float.Parse(ar[0]), float.Parse(ar[1]), float.Parse(ar[2]), float.Parse(ar[3]));
                    return (Color) c;
                }                
            }
            return ret;
        }

        public static string Serialize(object obj)
        {
            Type type = obj.GetType();
            if (type.IsSubclassOf(typeof(ZComponent)))
            {
                ZComponent comp = obj as ZComponent;
                if (comp.Name == null || comp.Name.Length == 0)
                    throw new ArgumentNullException("Cannot serialize reference to unnamed component!");
                    
                return comp.Name;
            }
            else if (type == typeof(Vector3))
            {
                Vector3 v = (Vector3)obj;
                return String.Format("{0} {1} {2}", v.X, v.Y, v.Z);
            }
            else if (type == typeof(Vector2))
            {
                Vector2 v = (Vector2) obj;
                return String.Format("{0} {1}", v.X, v.Y);
            }
            else if (type == typeof(Color))
            {
                Color4 c = new Color4((Color)obj);
                return String.Format("{0} {1} {2} {3}", c.R, c.G, c.B, c.A);
            }
            
            return obj.ToString();            
        }

    }
}
