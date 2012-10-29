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

namespace ZGE
{
    public static class Indenter
    {
        public static int tabs = 0;

        public static void IndentedLines(this StringBuilder sb, String text)
        {
            string indent = new string(' ', tabs * 4);
            foreach (var line in text.Split('\n'))
                sb.AppendLine(indent + line.Trim());
        }
    }

    public class CodeGenerator
    {
        private string executable;
        private Process run;

        public CodeGenerator()
        {
        }        

        public void GenerateGameFromXml(XmlNode rootElement)
        {

        }

        public string GenerateGameCode(ZApplication app, Dictionary<ZCode, string> codeMap)
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
            foreach (var comp in app.typeMap[typeof(Model)])
            {
                if (comp.GetType() == typeof(GameObject)) continue;
                Model model = comp as Model;
                if (model == null) continue;                
                str.IndentedLines(String.Format("public class {0}: Model", model.Name+"_Model"));
                str.IndentedLines("{");
                //Indenter.tabs = 2;
                //User-defined definitions

                //Include ZExpressions as methods
                //Find children of type ZCode
                str.IndentedLines("}");
            }

            

            str.AppendLine(@"    
    // The main Application class
    public class DynamicGame: ZApplication
    {
        // Named components");

            Indenter.tabs = 2;            
            foreach (var kvp in app.nameMap)
            {
                str.IndentedLines(String.Format("public {0} {1};",kvp.Value.GetType().Name,kvp.Value.Name));
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

            int i = 0;

            // Enumerate code components            
            for (i = 0; i < app.code.Count; i++)
            {
                string methodName = String.Format("Method_{0}", i);
                if (codeMap != null) codeMap[app.code[i]] = methodName;
                Indenter.tabs = 2;
                str.IndentedLines("public void " + methodName + "(Model model)\n{");
                Indenter.tabs = 3;
                str.IndentedLines(app.code[i].Text);
                Indenter.tabs = 2;
                str.IndentedLines("}");
            }                     

            str.AppendLine(@"
     }
}");
            return str.ToString();
        }            


        public bool GenerateGameAssembly(ZApplication app)
        {
            Dictionary<ZCode, string> codeMap = new Dictionary<ZCode, string>();
            string str = GenerateGameCode(app, codeMap);            
            
            // Save the file for debugging
            using (StreamWriter writer = new StreamWriter("DynamicGame.cs", false))
            {
                writer.Write(str);                
            }

            // Generate AppBehavior class

           
            var res = BuildAssembly("dummy", str, true);
            if (res.Errors.HasErrors)
            {                
                Console.WriteLine("Errors during compile:\n");

                foreach (CompilerError error in res.Errors)
                {
                    Console.WriteLine(error.ToString());
                }
                
                return false;
            }
            else
            {
                // If there weren't any errors get an instance of "DynamicGame"           

                var type = res.CompiledAssembly.GetType("ZGE.DynamicGame");
                var behavior = Activator.CreateInstance(type, new object[] { false });
                if (behavior != null)
                {
                    // Bind generated methods to the corresponding code components
                    Console.WriteLine("New behavior created.");
                    foreach (var pair in codeMap)
                    {                        
                        MethodInfo mi = type.GetMethod(pair.Value);
                        if (mi != null)
                        {
                            Console.WriteLine("Setting callback: " + pair.Value);
                            pair.Key.callback = (ZCode.ModelMethod) Delegate.CreateDelegate(typeof(ZCode.ModelMethod), behavior, mi);
                        }
                    }                    
                }

                return true;
            }            
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

            return cr;
        }

        /// <summary>
        /// Here we build the executable and then run it. We make sure to not start
        /// two of the same process.
        /// </summary>
        public void Run()
        {
            if ((run == null) || (run.HasExited))
            {

                run = new Process();
                run.StartInfo.FileName = executable;
                run.Start();

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
