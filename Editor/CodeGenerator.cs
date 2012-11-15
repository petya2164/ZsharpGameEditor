using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZGE.Components;
using System.Xml;
using System.IO;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using System.Diagnostics;
using System.CodeDom;
using System.Drawing;
using OpenTK;
using System.Windows.Forms;
using System.Collections;



namespace ZGE
{
    public static class Indenter
    {
        public static int tabs = 0;

        public static void IndentedLines(this StringBuilder sb, String text)
        {
            string indent = new string(' ', tabs * 4);
            if (text.Contains("@\"")) //no splitting for verbatim strings
                sb.AppendLine(indent + text);
            else
                foreach (var line in text.Split('\n'))
                    sb.AppendLine(indent + line.TrimEnd());
        }
    }

    class Variable
    {
        public string typeName;
        public string name;
        public Type type;
        public bool create;

        public Variable(Type type, string typeName, string name, bool create)
        {
            this.type = type;
            this.name = name;
            this.typeName = typeName;
            this.create = create;
        }

        public virtual void WriteCode(StringBuilder sb)
        {
            if (create)
                sb.IndentedLines("internal " + typeName + " " + name + " = new " + typeName + "();");
            else
                sb.IndentedLines("internal " + typeName + " " + name + ";");
        }
    }

    class StaticVariable: Variable
    {
        public StaticVariable(Type type, string typeName, string name, bool create):
            base(type, typeName, name, create)
        {            
        }

        public override void WriteCode(StringBuilder sb)
        {
            if (create)
                sb.IndentedLines("internal static " + typeName + " " + name + " = new " + typeName + "();");
            else
                sb.IndentedLines("internal static " + typeName + " " + name + ";");
        }
    }

    class Method
    {
        string header;
        public List<string> body = new List<string>();

        public Method(string header)
        {
            this.header = header;
        }
        public void AddLine(string line)
        {
            body.Add(line);
        }

        public void WriteCode(StringBuilder sb)
        {
            Indenter.tabs = 2;
            sb.IndentedLines(header);
            sb.IndentedLines("{");
            Indenter.tabs = 3;
            foreach (var line in body)
                sb.IndentedLines(line);
            Indenter.tabs = 2;
            sb.IndentedLines("}");
        }
    }

    class Class
    {
        public string name;
        public string baseClass;
        public string variable;
        public Type type;
        public List<Variable> memberVars = new List<Variable>();
        public List<string> definitions = new List<string>();
        public Method constructor;
        public Method init;
        public Method createNamed;
        public Method restore;
        public List<Method> methods = new List<Method>();
        int objID = 0;
        int methodID = 0;

        public Class(Type type, string name, string baseClass, string variable)
        {
            this.type = type;
            this.name = name;
            this.baseClass = baseClass;
            this.variable = variable;
        }

        public string GetNextObjectName()
        {
            string objName = "obj" + objID.ToString();
            objID++;
            return objName;
        }

        public string GetNextMethodName()
        {
            string name = "Method" + methodID.ToString();
            methodID++;
            return name;
        }

        public void WriteCode(StringBuilder sb)
        {
            Indenter.tabs = 1;
            if (baseClass != null && baseClass.Length > 0)
                sb.IndentedLines("public class " + name + " : " + baseClass);
            else
                sb.IndentedLines("public class " + name);
            sb.IndentedLines("{");
            Indenter.tabs = 2;
            if (memberVars.Count > 0)
            {
                sb.IndentedLines("// Member variables");
                foreach (var mem in memberVars)
                    mem.WriteCode(sb);
                sb.AppendLine("");
            }
            if (definitions.Count > 0)
            {
                sb.IndentedLines("// Custom code");
                foreach (var df in definitions)
                    sb.IndentedLines(df);
                sb.AppendLine("");
            }
            sb.IndentedLines("// Constructor");
            if (constructor != null) constructor.WriteCode(sb);
            sb.AppendLine("");
            if (createNamed != null)
            {
                sb.IndentedLines("// CreateNamedComponents");
                createNamed.WriteCode(sb);
                sb.AppendLine("");
            }
            if (init != null)
            {
                sb.IndentedLines("// InitializeComponents");
                init.WriteCode(sb);
                sb.AppendLine("");
            }
            if (restore != null)
            {
                sb.IndentedLines("// RestoreComponents");
                restore.WriteCode(sb);
                sb.AppendLine("");
            }
            sb.IndentedLines("// Methods");
            foreach (var met in methods)
            {
                met.WriteCode(sb);
                if (!object.ReferenceEquals(met, methods.Last())) sb.AppendLine("");
            }
            Indenter.tabs = 1;
            sb.IndentedLines("}");
        }
    }

    class Namespace
    {
        public string name;
        public Class mainClass;
        public List<Class> helperClasses = new List<Class>();

        public Namespace(string name)
        {
            this.name = name;
        }

        public void WriteCode(StringBuilder sb)
        {
            Indenter.tabs = 0;
            sb.AppendLine("namespace " + name);
            sb.AppendLine("{");
            foreach (var hc in helperClasses)
            {
                hc.WriteCode(sb);
                sb.AppendLine("");
            }
            mainClass.WriteCode(sb);
            Indenter.tabs = 0;
            sb.IndentedLines("}");
        }
    }

    class CompileUnit
    {
        public List<string> usingStatements = new List<string>();
        public List<Namespace> namespaces = new List<Namespace>();

        public CompileUnit() { }

        public void AddUsing(string ns)
        {
            usingStatements.Add(ns);
        }

        public void WriteCode(StringBuilder sb)
        {
            Indenter.tabs = 0;
            foreach (var us in usingStatements)
                sb.IndentedLines(us);
            sb.AppendLine("");
            foreach (var ns in namespaces)
                ns.WriteCode(sb);
        }

        public string GetFullCode()
        {
            StringBuilder sb = new StringBuilder();
            WriteCode(sb);
            return sb.ToString();
        }
    }

    class UnresolvedField
    {
        public Class targetClass { get; set; }
        public string objName { get; set; }
        public string objTypeName { get; set; }
        public string fieldName { get; set; }
        public string value { get; set; }        
    }

    public class CodeGenerator
    {
        private string executable;
        private Process run;
        CompileUnit cu;
        Namespace ns;
        List<Type> types;
        CSharpCodeProvider compiler = new CSharpCodeProvider();
        bool standalone;
        bool fullBuild;
        public Dictionary<XmlNode, string> nodeMap = new Dictionary<XmlNode, string>();
        public static Editor editor;
        List<UnresolvedField> unresolved = new List<UnresolvedField>();

        public CodeGenerator()
        {
        }

        public string GenerateCodeFromXml(XmlDocument xml, bool standalone, bool fullBuild, Dictionary<XmlNode, string> nodeMap)
        {
            XmlNode rootElement = xml.DocumentElement;
            
            if (standalone && fullBuild == false) fullBuild = true; // no incremental build for standalone
            this.standalone = standalone;
            this.fullBuild = fullBuild;

            if (standalone == false) // no need for XmlNode->GUID mapping at standalone builds
            {
                if (nodeMap == null)
                    this.nodeMap = new Dictionary<XmlNode, string>();
                else
                    this.nodeMap = nodeMap;
            }

            cu = new CompileUnit();
            cu.AddUsing("using System;");
            cu.AddUsing("using System.Collections;");
            cu.AddUsing("using System.Collections.Generic;");
            cu.AddUsing("using System.Text;");
            cu.AddUsing("using System.Drawing;");
            cu.AddUsing("using OpenTK;");
            cu.AddUsing("using OpenTK.Graphics;");
            cu.AddUsing("using OpenTK.Graphics.OpenGL;");
            cu.AddUsing("using ZGE.Components;");
            //if (standalone == false)
            //    cu.AddUsing("using System.ComponentModel");

            ns = new Namespace("ZGE");
            cu.namespaces.Add(ns);
            Class main = new Class(typeof(ZApplication), "DynamicGame", "ZApplication", "this");
            ns.mainClass = main;
            main.constructor = new Method("public DynamicGame(bool createAll)");
            if (fullBuild)
            {
                main.constructor.AddLine("if (createAll) InitializeComponents();");
                main.init = new Method("public void InitializeComponents()");
                main.init.AddLine("CreateNamedComponents();");
                main.createNamed = new Method("public void CreateNamedComponents()");
            }
            else
            {                
                main.restore = new Method("public void RestoreComponents(ZApplication oldApp)");
                main.restore.AddLine("CodeGenerator.Restore(this, oldApp);");                
            }
            

            types = Factory.GetTypesFromNamespace(Assembly.GetAssembly(typeof(ZApplication)), "ZGE.Components");
            Variable dummy = new Variable(typeof(ZApplication), "DynamicGame", "this", false);
            if (rootElement != null)
                ProcessNode(main, dummy, null, rootElement);

            if (standalone)
            {
                Method mm = new Method("[STAThread]\npublic static void Main()");
                main.methods.Add(mm);
                mm.AddLine("ZApplication app = new DynamicGame(true);");
                mm.AddLine("using (Standalone game = new Standalone(app))");
                mm.AddLine("{");
                mm.AddLine("    game.Run(app.UpdateFrequency);");
                mm.AddLine("}");
            }            

            string code = cu.GetFullCode();
            // Save the file for debugging
            using (StreamWriter writer = new StreamWriter("DynamicGame.cs", false))
            {
                writer.Write(code);
            }
            return code;
        }

        private void ParseAttributes(Class targetClass, Variable obj, XmlNode xmlNode)
        {
            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    //if (attribute.Name == "Name") continue;
                    if (xmlNode.Name == "GameObject" && attribute.Name == "Model") continue;
                    string val = attribute.Value;
                    FieldInfo fi = obj.type.GetField(attribute.Name, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                    if (fi != null)
                    {
                        Type type = fi.FieldType;
                        SetAttribute(targetClass, type, val, obj.name, attribute.Name);
                    }
                    else
                    {
                        // These components might have custom fields (those will be resolved after compilation)
                        if (xmlNode.Name == "ZApplication" || xmlNode.Name == "Model" || xmlNode.Name == "GameObject")
                        {
                            unresolved.Add(new UnresolvedField { targetClass = targetClass, objName = obj.name, 
                                                                 objTypeName = obj.typeName, fieldName = attribute.Name, value = val });
                        }
                        else                                                  
                            Console.WriteLine(" Field not found: {0} - {1}", attribute.Name, val);
                    }
                }
            }
        }

        private void FixUnresolvedAttribute(UnresolvedField field, Assembly assembly)
        {
            Type objType = assembly.GetType("ZGE." + field.objTypeName);
            if (objType == null)
            {
                Console.WriteLine(" Cannot find custom type: {0}", field.objTypeName);
                return;
            }
            FieldInfo fi = objType.GetField(field.fieldName, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
            if (fi != null)
            {
                Type type = fi.FieldType;
                SetAttribute(field.targetClass, type, field.value, field.objName, field.fieldName);
            }
            else
            {
                Console.WriteLine(" Custom field not found: {0} - {1}", field.fieldName, field.value);
            }
        }

        private void SetAttribute(Class targetClass, Type type, string val, string objName, string fieldName)
        {
            if (type == typeof(string))
                targetClass.init.AddLine(String.Format("{0}.{1} = \"{2}\";", objName, fieldName, val));
            else if (type == typeof(bool))
                targetClass.init.AddLine(String.Format("{0}.{1} = {2};", objName, fieldName, val.ToLowerInvariant()));
            else if (type.IsPrimitive)  // a cast might be necessary (e.g. float)                        
                targetClass.init.AddLine(String.Format("{0}.{1} = ({2}){3};", objName, fieldName, GetPlainTypeName(type), val));
            else if (type.IsEnum)
                targetClass.init.AddLine(String.Format("{0}.{1} = {2}.{3};", objName, fieldName, type.Name, val));
            else if (type.IsSubclassOf(typeof(ZComponent))) // simple assignment to a named component
                targetClass.init.AddLine(String.Format("{0}.{1} = {2};", objName, fieldName, val));
            else if (type == typeof(Vector3) || type == typeof(Vector2)) // cast all constuctor parameters to float
            {
                string commaList = string.Join(", ", val.Split(' ').Select(it => "(float)" + it).ToArray());
                targetClass.init.AddLine(String.Format("{0}.{1} = new {2}({3});", objName, fieldName, type.Name, commaList));
            }
            else if (type == typeof(Color))  // make a Color4 instead with float parameters
            {
                string commaList = string.Join(", ", val.Split(' ').Select(it => "(float)" + it).ToArray());
                targetClass.init.AddLine(String.Format("{0}.{1} = new {2}({3});", objName, fieldName, "Color4", commaList));
            }
            else
            {
                string commaList = string.Join(", ", val.Split(' '));
                targetClass.init.AddLine(String.Format("{0}.{1} = new {2}({3});", objName, fieldName, type.Name, commaList));
            }
        }

        private Variable InitComponent(Class targetClass, string typeName, XmlNode xmlNode, Variable parent, string targetList)
        {
            var type = types.Find(it => it.Name == typeName);
            Variable obj = null;
            string model = null;
            if (typeName == "GameObject")
            {
                XmlAttribute attribute = xmlNode.Attributes["Model"];
                if (attribute != null)
                {
                    model = attribute.Value;
                    typeName = attribute.Value + "Model";
                    type = typeof(Model);
                }
                else
                {
                    Console.WriteLine("Cannot instantiate GameObject without a Model!");
                    return null;
                }
            }

            if (type != null)
            {
                if (fullBuild) targetClass.init.AddLine("");
                XmlAttribute attribute = xmlNode.Attributes["Name"];
                if (attribute == null)
                {
                    string objName = targetClass.GetNextObjectName();
                    obj = new Variable(type, typeName, objName, false);
                    if (typeName == "Model")
                    {
                        Console.WriteLine("Cannot process Model without a name!");
                        return null;
                    }
                    if (fullBuild)
                    {
                        if (model != null) //GameObject without a name, it has to be CLONED
                        {
                            targetClass.init.AddLine(String.Format("var {0} = ({1}) {2}.Clone();", objName, typeName, model));
                        }
                        else
                            targetClass.init.AddLine(String.Format("var {0} = new {1}();", objName, typeName));
                    }                    
                }
                else
                {
                    string objName = attribute.Value;
                    if (typeName == "Model") typeName = objName + "Model";
                    obj = new Variable(type, typeName, objName, false);
                    targetClass.memberVars.Add(obj);
                    if (fullBuild)
                    {
                        if (model != null) //GameObject with a name, it has to be CLONED
                        {
                            targetClass.createNamed.AddLine(String.Format("{0} = ({1}) {2}.Clone();", objName, typeName, model));
                        }
                        else
                            targetClass.createNamed.AddLine(String.Format("{0} = new {1}();", objName, typeName));
                    }
                    else if (xmlNode.Name == "Model") 
                    {
                        targetClass.restore.AddLine("");
                        targetClass.restore.AddLine(String.Format("{0} = new {1}();", objName, typeName));
                        string currentGuid = "";
                        nodeMap.TryGetValue(xmlNode, out currentGuid);
                        targetClass.restore.AddLine(String.Format("CodeGenerator.Restore({0}, oldApp.FindPrototype(\"{1}\"));", objName, currentGuid));
                        // Re-create all GameObjects in the scene by cloning the Model prototypes
                        targetClass.restore.AddLine(String.Format("foreach (Model gameObj in oldApp.FindGameObjects(\"{0}\"))", currentGuid));
                        targetClass.restore.AddLine("{");
                        //targetClass.restore.AddLine("Console.WriteLine(\"GO found: {0} - {1}\", gameObj.GetType().Name, gameObj.Name);");
                        targetClass.restore.AddLine(String.Format("    var temp = {0}.Clone() as Model;", objName));
                        targetClass.restore.AddLine(String.Format("    CodeGenerator.Restore(temp, gameObj);"));
                        targetClass.restore.AddLine(String.Format("    if (oldApp.SelectedObject == gameObj) this.SelectedObject = temp;"));
                        targetClass.restore.AddLine("}");
                    }                    
                }

                if (fullBuild)
                {
                    ParseAttributes(targetClass, obj, xmlNode);
                    //targetClass.init.AddLine(String.Format("AddComponent({0});", obj.name));
                    if (standalone == false) // assign GUIDs to Model components
                    {
                        if (xmlNode.Name == "Model")
                        {
                            string currentGuid = "";
                            nodeMap.TryGetValue(xmlNode, out currentGuid);
                            targetClass.createNamed.AddLine(String.Format("{0}.GUID = \"{1}\";", obj.name, currentGuid));
                        }
                    }                    
                    if (parent != null)
                    {
                        // We always need an Owner
                        targetClass.init.AddLine(String.Format("{0}.Owner = {1};", obj.name, parent.name));

                        if (targetList != null) // components in member lists are not considered children!
                        {
                            //Console.WriteLine("Adding to list: {0}", parent_list.GetType().Name);
                            targetClass.init.AddLine(String.Format("{0}.OwnerList = (IList) {1}.{2};", obj.name, parent.name, targetList));
                            targetClass.init.AddLine(String.Format("{0}.{1}.Add({2});", parent.name, targetList, obj.name));
                        }
                        else
                        {
                            //targetClass.init.AddLine(String.Format("{0}.Owner = {1};", obj.name, parent.name));
                            targetClass.init.AddLine(String.Format("{0}.Children.Add({1});", parent.name, obj.name));
                        }
                    }
                }               
            }
            return obj;
        }

        private string GetPlainTypeName(Type type)
        {
            var typeRef = new CodeTypeReference(type);
            string name = compiler.GetTypeOutput(typeRef);
            return (type.IsGenericType) ? name : name.Split('.').Last();  //we don't want a fully qualified name
        }

        private string GetMethodHeader(string methodName, Type delegateType, bool isStatic)
        {
            string header = "public ";
            if (isStatic) header += "static ";
            MethodInfo method = delegateType.GetMethod("Invoke");

            header += GetPlainTypeName(method.ReturnType) + " " + methodName + "(";
            List<string> paramList = new List<string>();
            foreach (ParameterInfo param in method.GetParameters())
            {
                paramList.Add(GetPlainTypeName(param.ParameterType) + " " + param.Name);
            }
            header += string.Join(", ", paramList.ToArray()) + ")";

            return header;
        }

        private void ProcessNode(Class targetClass, Variable parent, string targetList, XmlNode xmlNode)
        {
            if (xmlNode == null) return;
            if (standalone == false) // generate GUID for each xmlnode
                if (nodeMap.ContainsKey(xmlNode) == false) nodeMap[xmlNode] = Guid.NewGuid().ToString();
            //Console.WriteLine("Processing: {0}", xmlNode.Name);

            Variable obj = parent;
            string list = null;
            if (xmlNode.Name == "ZApplication")
            {
                if (fullBuild) ParseAttributes(ns.mainClass, parent, xmlNode);
            }
            else
            {
                // Check if this node is a List property of the parent
                FieldInfo fi = parent.type.GetField(xmlNode.Name, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                //if (pi != null) Console.WriteLine(" Parent property found: {0}", pi.PropertyType.Name);
                if (fi != null && typeof(IList).IsAssignableFrom(fi.FieldType))
                {
                    //Console.WriteLine("List found: {0}", xmlNode.Name);
                    list = fi.Name;
                }
                // Check if this node is a CodeLike property of the parent
                else if (fi != null && typeof(CodeLike).IsAssignableFrom(fi.FieldType))
                {
                    Type type = fi.FieldType;
                    string currentGuid = "";
                    if (standalone == false) nodeMap.TryGetValue(xmlNode, out currentGuid);
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ZCode<>))
                    {
                        string methodName = targetClass.GetNextMethodName();
                        bool isStatic = (targetClass.baseClass == "Model");
                        string header = GetMethodHeader(methodName, type.GetGenericArguments()[0], isStatic);
                        Method met = new Method(header);
                        targetClass.methods.Add(met);
                        if (isStatic)
                        {
                            //Automatically cast the caller to the type of the Model class
                            met.AddLine(String.Format("{0} model = caller as {0};", targetClass.name));
                        }
                        met.AddLine(xmlNode.InnerText);
                        // BIND THE CALLBACK
                        if (fullBuild)
                            ns.mainClass.init.AddLine(String.Format("{0}.{1}.callback = {2}.{3};", parent.name, fi.Name, targetClass.variable, methodName));
                        else
                        {
                            string exprName = ns.mainClass.GetNextObjectName();
                            ns.mainClass.restore.AddLine("");
                            ns.mainClass.restore.AddLine(String.Format("var {0} = oldApp.FindCodeLike(\"{1}\") as {2};", exprName, currentGuid, GetPlainTypeName(type)));
                            ns.mainClass.restore.AddLine(String.Format("if ({0} != null) {0}.callback = {1}.{2};", exprName, targetClass.variable, methodName));
                        }
                    }
                    if (type == typeof(CustomCodeDefinition)) // handle custom code definitions
                    {
                        targetClass.definitions.Add(xmlNode.InnerText);
                    }
                    if (standalone == false && fullBuild == true) // assign the GUIDs to the CodeLike components
                    {                        
                        ns.mainClass.init.AddLine(String.Format("{0}.{1}.GUID = \"{2}\";", parent.name, fi.Name, currentGuid));
                    }
                    // if not shader
                    if (standalone == false && fullBuild == true) // no need for the code text in a standalone build
                    {
                        string escaped = xmlNode.InnerText.Replace("\"", "\"\"");  // escape inner strings " -> ""
                        ns.mainClass.init.AddLine(String.Format("{0}.{1}.Text = @\"{2}\";", parent.name, fi.Name, escaped));
                    }
                    //Console.WriteLine("Code Text:\n{0}", code.Text);                    
                    return; //no TreeNode should be created for this
                }
                else
                {
                    obj = InitComponent(ns.mainClass, xmlNode.Name, xmlNode, parent, targetList);
                    if (obj == null)
                    {
                        Console.WriteLine("SKIPPING subtree - Cannot find type: {0}", xmlNode.Name);
                        return;
                    }
                    if (xmlNode.Name == "Model")
                    {
                        string modelName = obj.name + "Model";
                        Class model = new Class(typeof(Model), modelName, "Model", modelName);

                        model.constructor = new Method("public " + modelName + "()");
                        var staticApp = new StaticVariable(typeof(ZApplication), "DynamicGame", "App", false);
                        model.memberVars.Add(staticApp);
                        ns.mainClass.constructor.AddLine(String.Format("{0}.App = this;", modelName));

                        //model.constructor.AddLine("InitializeComponents();");
                        //model.init = new Method("public void InitializeComponents()");
                        //model.init.AddLine("CreateNamedComponents();");
                        //model.createNamed = new Method("public void CreateNamedComponents()");
                        ns.helperClasses.Add(model);
                        targetClass = model;
                    }
                }
            }
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element)
                {
                    ProcessNode(targetClass, obj, list, childNode);
                }
            }            
        }

        /*private static void FindFields(IList<FieldInfo> fields, Type t)
        {
            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;

            fields.AddRange(t.GetFields(flags));            

            var baseType = t.BaseType;
            if (baseType != null)
                FindFields(fields, baseType);
        }*/


        public static void MemberwiseCopy(ZComponent newObj, Type newType, ZComponent oldObj, Type oldType)
        {
            foreach (FieldInfo dest in newType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                //if (dest.Name == "ID") continue;
                // Check if this node is a List property of the parent
                FieldInfo src = oldType.GetField(dest.Name, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                
                if (src != null && src.FieldType == dest.FieldType)
                {
                    //Console.WriteLine("Setting Field of {0}: {1} {2}->{3}", dest.DeclaringType.Name, dest.Name, src.FieldType.Name, dest.FieldType.Name);
                    dest.SetValue(newObj, src.GetValue(oldObj));
                }
                //else
                //    Console.WriteLine("Field not found: {0} {1}->{2}", dest.Name, (src != null) ? src.FieldType.Name : "NONE", dest.FieldType.Name);
            }
            // Walk the type hierarchy recursively in order to copy the private fields in the base classes as well
            if (newType.BaseType != typeof(Object) && oldType.BaseType != typeof(Object))
            {
                // The type of newObj might be higher in the hierarchy (e.g. SomeModel vs. Model)
                // We need to level the playing field
                if (newType.BaseType.Name == oldType.Name)
                    MemberwiseCopy(newObj, newType.BaseType, oldObj, oldType);
                else
                    MemberwiseCopy(newObj, newType.BaseType, oldObj, oldType.BaseType);
            }
        }


        public static void Restore(ZComponent newObj, ZComponent oldObj)
        {
            if (newObj == null || oldObj == null) return;
            //Console.WriteLine("Restore: {0}({1}) -> {2}({3})", oldObj.GetType().Name, oldObj.Name ?? "", newObj.GetType().Name, newObj.Name ?? "");

            MemberwiseCopy(newObj, newObj.GetType(), oldObj, oldObj.GetType());

            // A reference to oldObj should be updated to newObj in its Children
            foreach (ZComponent child in newObj.Children)
            {
                if (child.Owner == oldObj) child.Owner = newObj;
            }

            // If it is NOT a ZApplication
            if (typeof(ZApplication).IsAssignableFrom(newObj.GetType()) == false)
            {
                ZComponent.App.RemoveComponent(oldObj);     // remove the old component
                //ZComponent.App.AddNewComponent(newObj);        // add the new component
                
                // We should always set the Owner <= old Owner has been copied to newObj
                
                if (newObj.OwnerList != null)  // replace old object in OwnerList
                {
                    //newObj.OwnerList = oldObj.OwnerList;
                    int idx = newObj.OwnerList.IndexOf(oldObj);
                    if (idx != -1) newObj.OwnerList[idx] = newObj;
                }
                else if (newObj.Owner != null) // replace old object among Owner's Children
                {
                    int idx = newObj.Owner.Children.IndexOf(oldObj);
                    if (idx != -1) newObj.Owner.Children[idx] = newObj;
                }
                oldObj.Owner = null;
                

                if (typeof(Model).IsAssignableFrom(newObj.GetType()))
                {
                    ZComponent.App.RemoveModel(oldObj as Model);
                    Model newMod = newObj as Model;
                    // Find named reference in App (only necessary for GameObjects)
                    if (newMod != null && newMod.Prototype == false && newMod.HasName())
                    {
                        FieldInfo fi = ZComponent.App.GetType().GetField(newMod.Name, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        if (fi != null && fi.FieldType == newObj.GetType())
                        {
                            //Console.WriteLine("Setting named reference {0} / {1}", fi.Name, fi.FieldType.Name);
                            fi.SetValue(ZComponent.App, newObj);
                        }
                    }
                    // Clear the static DynamicGame reference 'App' in the old model classes
                    // It is enough to do this for the prototypes (there is one prototype for each class)
                    // If we don't null this, the old application will never be finalized
                    if (newMod.Prototype)
                    {
                        FieldInfo fi = oldObj.GetType().GetField("App", BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                        if (fi != null)
                        {
                            //Console.WriteLine("Setting named reference {0} / {1}", fi.Name, fi.FieldType.Name);
                            fi.SetValue(oldObj, null);
                        }
                    }
                }
            }           
            
            // Correct the Treeview tags
            ZNodeProperties props = newObj.Tag as ZNodeProperties;
            if (props != null)
            {
                props.Component = newObj;          

                TreeNode treeNode = props.treeNode;
                if (treeNode != null)
                    foreach (TreeNode childNode in treeNode.Nodes)
                    {
                        ZNodeProperties props1 = childNode.Tag as ZNodeProperties;
                        // Clear the reference to oldObj in the ZNodeProperties of all children / member lists
                        if (props1 != null && props1.Parent == oldObj)
                        {
                            props1.Parent = newObj;                            
                        }
                        /*foreach (TreeNode grandchildNode in childNode.Nodes)
                        {
                            ZNodeProperties props2 = grandchildNode.Tag as ZNodeProperties;
                            if (props2 != null && props2.parent_component == oldObj)
                            {
                                props2.parent_component = newObj;
                                // oldObj can also be the Owner of its grandchildren (in various member lists)
                                // this reference must be updated to newObj 
                                ZComponent grandchild = props2.component as ZComponent;
                                if (grandchild != null && grandchild.Owner == oldObj) grandchild.Owner = newObj;
                            }
                        }*/
                    }
            }

            // oldObj can also be the Owner of its grandchildren (in various member lists)
            // the Owner reference must be updated to newObj in all components 
            foreach(ZComponent comp in ZComponent.App.GetAllComponents())
                if (comp.Owner == oldObj) comp.Owner = newObj;


            // If the oldObj was selected in the editor, then we have to replace it with newObj 
            if (editor.SelectedComponent == oldObj)
            {
                editor.SelectedComponent = newObj;
                //Console.WriteLine("SelectedComponent changed to {0}", newObj.GetType().AssemblyQualifiedName);
            }                       
        }

        // This is used for on-the-fly code compilation (similar to an incremental build)
        internal ZApplication RecompileApplication(XmlDocument xmlDoc, Dictionary<XmlNode, string> nodeMap, ZApplication oldApp)
        {
            if (xmlDoc == null || oldApp == null) return null;
            
            string code = GenerateCodeFromXml(xmlDoc, false, false, nodeMap);

            var res = BuildAssembly("dummy", code, true);
            if (res.Errors.HasErrors)
            {
                return null;
            }
            else
            {
//                 foreach (Model gameObj in project.app.modelList)
//                 {
//                     Console.WriteLine("GO found: {0} - {1} Proto: {2} {3}", gameObj.GetType().Name, gameObj.Name, gameObj.Prototype.ToString(), gameObj.GUID);                
//                 }


                // If there weren't any errors, create an instance of "DynamicGame"
                var type = res.CompiledAssembly.GetType("ZGE.DynamicGame");
                var app = (ZApplication) Activator.CreateInstance(type, new object[] { false });
                if (app != null)
                {                      
                    ZComponent.App = app;  // Just to make sure
                    MethodInfo mi = type.GetMethod("RestoreComponents");
                    if (mi != null)
                    {                        
                        mi.Invoke(app, new object[] { oldApp });
                        Console.WriteLine("ZApplication recompiled, components updated.");
                    }
                    else
                        Console.WriteLine("The \"RestoreComponents\" method is missing, components cannot be updated :(");

                    return app;                   

                    /*foreach (var pair in codeMap)
                    {                        
                        MethodInfo mi = type.GetMethod(pair.Value);
                        if (mi != null)
                        {
                            // Bind generated methods to the corresponding code components
                            Console.WriteLine("Setting callback: " + pair.Value);
                            pair.Key.callback = (ZCode.ModelMethod) Delegate.CreateDelegate(typeof(ZCode.ModelMethod), behavior, mi);
                        }
                    }*/                    
                }
                else
                    Console.WriteLine("Recompiled ZApplication cannot be instantiated :(");
            }
            return null;
        }        
            
        public ZApplication CreateApplication(XmlDocument xml, bool fullBuild)
        {
            var res = BuildApplication(xml, false, fullBuild, null);
            if (res == null) return null;

            // If there weren't any errors, get an instance of "DynamicGame"
            var type = res.CompiledAssembly.GetType("ZGE.DynamicGame");
            var app = (ZApplication) Activator.CreateInstance(type, new object[] { fullBuild });
            if (app != null)
            {                    
                Console.WriteLine("New ZApplication created.");                    
                return app;
            }
            else
            {
                Console.WriteLine("New ZApplication cannot be instantiated :(");         
                return null;
            }           
        }

        public bool BuildStandaloneApplication(XmlDocument xml, string exePath)
        {
            var res = BuildApplication(xml, true, true, exePath);
            return (res != null);                           
        }


        private CompilerResults BuildApplication(XmlDocument xml, bool standalone, bool fullBuild, string exePath)
        {
            unresolved = new List<UnresolvedField>();
            string code = GenerateCodeFromXml(xml, standalone, fullBuild, null);

            bool inMemory = !standalone;
            // Do an inMemory build first if there are unresolved custom fields 
            if (unresolved.Count > 0 && standalone) inMemory = true;

            CompilerResults res = BuildAssembly(exePath ?? "dummy", code, inMemory);
            if (res.Errors.HasErrors)
                return null;

            // Try to fix unresolved custom fields with a rebuild
            if (unresolved.Count > 0)
            {
                foreach (UnresolvedField field in unresolved)
                    FixUnresolvedAttribute(field, res.CompiledAssembly);                

                unresolved.Clear();
                code = cu.GetFullCode();
                // Rebuild the assembly with the fixed code
                res = BuildAssembly(exePath ?? "dummy", code, !standalone);
                if (res.Errors.HasErrors)
                    return null;
            }
            return res;
        }

        private CompilerResults BuildAssembly(string exe, string code, bool inMemory)
        {
            // We need to collect the parameters that our compiler will use.
            CompilerParameters cp = new CompilerParameters();

            AssemblyName[] assemblyNames = Assembly.GetEntryAssembly().GetReferencedAssemblies();

            foreach (AssemblyName an in assemblyNames)
            {
                Assembly assembly = Assembly.Load(an);
                cp.ReferencedAssemblies.Add(assembly.Location);
                //Console.WriteLine("Assembly: " + assembly.Location);
            }

            if (inMemory)
            {
                cp.GenerateInMemory = true;
                cp.GenerateExecutable = false;
                //cp.OutputAssembly = "temp.dll";
                cp.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                // TODO: Cut the references for standalone builds
                //cp.ReferencedAssemblies.Add(assembly.Location);  //OpenTK
                //cp.ReferencedAssemblies.Add(assembly.Location);  //Components

                executable = exe;
                cp.OutputAssembly = executable;
                cp.GenerateExecutable = true;
                cp.GenerateInMemory = false;
                cp.CompilerOptions = "/optimize /target:winexe";
            }

            Dictionary<string, string> providerOptions = new Dictionary<string, string>();
            providerOptions.Add("CompilerVersion", "v3.5");

            CSharpCodeProvider cc = new CSharpCodeProvider(providerOptions);
            CompilerResults cr = cc.CompileAssemblyFromSource(cp, code);
            //CompilerResults cr = cc.CompileAssemblyFromDom(cp, codeCompileUnit);

            if (cr.Errors.HasErrors)
            {
                if (!inMemory) executable = null; //standalone build failed
                Console.WriteLine("Errors during compile:\n");

                foreach (CompilerError error in cr.Errors)
                {
                    Console.WriteLine(error.ToString());
                }
            }

            return cr;
        }

        /// <summary>
        /// Here we build the executable and then run it. We make sure to not start
        /// two of the same process.
        /// </summary>
        public void Run(EventHandler onStart, EventHandler onExit)
        {
            if (executable == null) return;
            if ((run == null) || (run.HasExited))
            {

                run = new Process();
                run.StartInfo.FileName = executable;
                run.EnableRaisingEvents = true;
                if (onExit != null)
                    run.Exited += onExit;                
                run.Start();
                if (onStart != null)
                    onStart(this, null);
                
            }
        }        

        /// <summary>
        /// Just in case the red X in the upper right isn't good enough,
        /// we can kill our process here.
        /// </summary>
        public void Stop()
        {
            if ((run != null) && (!run.HasExited))
            {
                run.Kill();
            }
        }
    }
}
