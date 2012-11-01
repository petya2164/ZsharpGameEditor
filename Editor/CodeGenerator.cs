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

        public void WriteCode(StringBuilder sb)
        {
            if (create)
                sb.IndentedLines("internal " + typeName + " " + name + " = new " + typeName + "();");
            else
                sb.IndentedLines("internal " + typeName + " " + name + ";");
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
                sb.IndentedLines("// Custom definitions");
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

        public CodeGenerator()
        {
        }

        public string GenerateCodeFromXml(XmlDocument xml, bool standalone)
        {
            XmlNode rootElement = xml.DocumentElement;
            StringBuilder sb = new StringBuilder();
            this.standalone = standalone;

            cu = new CompileUnit();
            cu.AddUsing("using System;");
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
            main.constructor.AddLine("if (createAll) InitializeComponents();");
            main.init = new Method("public void InitializeComponents()");
            main.init.AddLine("CreateNamedComponents();");
            main.createNamed = new Method("public void CreateNamedComponents()");

            types = Factory.GetTypesFromNamespace(Assembly.GetAssembly(typeof(ZApplication)), "ZGE.Components");
            Variable dummy = new Variable(typeof(ZApplication), "ZApplication", "this", false);
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

            cu.WriteCode(sb);
            // Save the file for debugging
            using (StreamWriter writer = new StreamWriter("DynamicGame.cs", false))
            {
                writer.Write(sb.ToString());
            }
            return sb.ToString();
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
                        if (type == typeof(string))
                            targetClass.init.AddLine(String.Format("{0}.{1} = \"{2}\";", obj.name, attribute.Name, val));
                        else if (type == typeof(bool))
                            targetClass.init.AddLine(String.Format("{0}.{1} = {2};", obj.name, attribute.Name, val.ToLowerInvariant()));
                        else if (type.IsPrimitive)  // a cast might be necessary (e.g. float)                        
                            targetClass.init.AddLine(String.Format("{0}.{1} = ({2}){3};", obj.name, attribute.Name, GetPlainTypeName(type), val));
                        else if (type.IsEnum)
                            targetClass.init.AddLine(String.Format("{0}.{1} = {2}.{3};", obj.name, attribute.Name, type.Name, val));
                        else if (type.IsSubclassOf(typeof(ZComponent))) // simple assignment to a named component
                            targetClass.init.AddLine(String.Format("{0}.{1} = {2};", obj.name, attribute.Name, val));
                        else if (type == typeof(Vector3) || type == typeof(Vector2)) // cast all constuctor parameters to float
                        {
                            string commaList = string.Join(", ", val.Split(' ').Select(it => "(float)" + it).ToArray());
                            targetClass.init.AddLine(String.Format("{0}.{1} = new {2}({3});", obj.name, attribute.Name, type.Name, commaList));
                        }
                        else if (type == typeof(Color))  // make a Color4 instead with float parameters
                        {
                            string commaList = string.Join(", ", val.Split(' ').Select(it => "(float)" + it).ToArray());

                            targetClass.init.AddLine(String.Format("{0}.{1} = new {2}({3});", obj.name, attribute.Name, "Color4", commaList));
                        }
                        else
                        {
                            string commaList = string.Join(", ", val.Split(' '));
                            targetClass.init.AddLine(String.Format("{0}.{1} = new {2}({3});", obj.name, attribute.Name, type.Name, commaList));
                        }
                    }
                    else
                        Console.WriteLine(" Field not found: {0}-{1}", attribute.Name, val);
                }
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
                targetClass.init.AddLine("");
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
                    if (model != null) //GameObject without a name
                    {
                        targetClass.init.AddLine(String.Format("var {0} = ({1}) {2}.Clone();", objName, typeName, model));
                    }
                    else
                        targetClass.init.AddLine(String.Format("var {0} = new {1}();", objName, typeName));
                }
                else
                {
                    string objName = attribute.Value;
                    if (typeName == "Model") typeName = objName + "Model";
                    obj = new Variable(type, typeName, objName, false);
                    targetClass.memberVars.Add(obj);
                    if (model != null) //GameObject with a name
                    {
                        targetClass.createNamed.AddLine(String.Format("{0} = ({1}) {2}.Clone();", objName, typeName, model));
                    }
                    else
                        targetClass.createNamed.AddLine(String.Format("{0} = new {1}();", objName, typeName));
                }

                ParseAttributes(targetClass, obj, xmlNode);
                targetClass.init.AddLine(String.Format("AddComponent({0});", obj.name));                
                if (targetList != null) // components in member lists are not considered children!
                {
                    //Console.WriteLine("Adding to list: {0}", parent_list.GetType().Name);                        
                    targetClass.init.AddLine(String.Format("{0}.{1}.Add({2});", parent.name, targetList, obj.name));
                }
                else if (parent != null)
                {
                    targetClass.init.AddLine(String.Format("{0}.Owner = {1};", obj.name, parent.name));
                    targetClass.init.AddLine(String.Format("{0}.Children.Add({1});", parent.name, obj.name));
                }
                
            }
            return obj;
        }

        private string GetPlainTypeName(Type type)
        {
            var typeRef = new CodeTypeReference(type);
            string name = compiler.GetTypeOutput(typeRef);
            return name.Split('.').Last();  //we don't want a fully qualified name
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
            //Console.WriteLine("Processing: {0}", xmlNode.Name);

            Variable obj = parent;
            string list = null;
            if (xmlNode.Name == "ZApplication")
            {
                ParseAttributes(ns.mainClass, parent, xmlNode);
            }
            else
            {
                // Check if this node is a List property of the parent
                FieldInfo fi = parent.type.GetField(xmlNode.Name, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                //if (pi != null) Console.WriteLine(" Parent property found: {0}", pi.PropertyType.Name);
                if (fi != null && fi.FieldType.Name.StartsWith("List"))
                {
                    //Console.WriteLine("List found: {0}", xmlNode.Name);
                    list = fi.Name;
                }
                // Check if this node is a CodeLike property of the parent
                else if (fi != null && typeof(CodeLike).IsAssignableFrom(fi.FieldType))
                {
                    Type type = fi.FieldType;
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
                        ns.mainClass.init.AddLine(String.Format("{0}.{1}.callback = {2}.{3};", parent.name, fi.Name, targetClass.variable, methodName));
                    }
                    if (standalone == false) //no need for the code text in a standalone build
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

        public string GenerateGameCode(ZApplication app, Dictionary<CodeLike, string> codeMap)
        {

            StringBuilder str = new StringBuilder();

            str.AppendLine(
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZGE.Components;
using OpenTK;
// User-defined using statements

namespace ZGE
{
    // Model classes");

            Indenter.tabs = 1;
            // Enumerate the model classes
            foreach (var comp in app.GetComponents(typeof(Model)))
            {
                //if (comp.GetType() == typeof(GameObject)) continue;
                Model model = comp as Model;
                if (model == null) continue;
                str.IndentedLines(String.Format("public class {0}: Model", model.Name + "_Model"));
                str.IndentedLines("{");
                //Indenter.tabs = 2;
                //User-defined definitions

                //Include ZExpressions as methods
                //Find children of type CodeLike


                str.IndentedLines("}");
            }



            str.AppendLine(@"    
    // The main Application class
    public class DynamicGame: ZApplication
    {
        // Named components");

            Indenter.tabs = 2;
            foreach (var comp in app.GetNamedComponents())
            {
                str.IndentedLines(String.Format("public {0} {1};", comp.GetType().Name, comp.Name));
            }

            str.AppendLine(@"
        // Constructor
        public DynamicGame(bool createAll)
        {
            if (createAll)
                InitializeComponents();
        }

        public void InitializeComponents()
        {
            //Create all the components and their children");

            //Use the XML here

            Indenter.tabs = 2;
            str.IndentedLines("}\n");

            /*int i = 0;
            // Enumerate code components            
            for (i = 0; i < app.codeList.Count; i++)
            {
                string methodName = String.Format("Method_{0}", i);
                if (codeMap != null) codeMap[app.codeList[i]] = methodName;
                Indenter.tabs = 2;
                str.IndentedLines("public void " + methodName + "(Model model)\n{");
                Indenter.tabs = 3;
                str.IndentedLines(app.codeList[i].Text);
                Indenter.tabs = 2;
                str.IndentedLines("}");
            } */

            str.AppendLine(@"
     }
}");
            return str.ToString();
        }


        public ZApplication CreateApplication(XmlDocument xml, bool standalone, bool firstBuild)
        {
            //Dictionary<CodeLike, string> codeMap = new Dictionary<CodeLike, string>();
            //string str = GenerateGameCode(app, codeMap);

            // Save the file for debugging
            //using (StreamWriter writer = new StreamWriter("DynamicGame.cs", false))
            //{
            //    writer.Write(str);
            //}

            string code = GenerateCodeFromXml(xml, standalone);

            var res = BuildAssembly("dummy", code, true);
            if (res.Errors.HasErrors)
            {
                return null;
            }
            else
            {
                // If there weren't any errors get an instance of "DynamicGame"           

                var type = res.CompiledAssembly.GetType("ZGE.DynamicGame");
                var app = (ZApplication) Activator.CreateInstance(type, new object[] { firstBuild });
                if (app != null)
                {
                    // Bind generated methods to the corresponding code components
                    Console.WriteLine("New Application created.");
                    /*foreach (var pair in codeMap)
                    {                        
                        MethodInfo mi = type.GetMethod(pair.Value);
                        if (mi != null)
                        {
                            Console.WriteLine("Setting callback: " + pair.Value);
                            pair.Key.callback = (ZCode.ModelMethod) Delegate.CreateDelegate(typeof(ZCode.ModelMethod), behavior, mi);
                        }
                    }*/
                    return app;
                }
            }
            return null;
        }

        public CompilerResults BuildAssembly(string exe, string code, bool inMemory)
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
