using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZGE.Components;
using System.Xml;
using Loader;
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

        public bool GenerateGameCode(ZApplication app)
        {
            
            StringBuilder str = new StringBuilder();

            str.AppendLine(
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZGE.Components;
using OpenTK;

namespace ZGE
{
    // Model classes

    class DynamicGame: ZComponent
    {
        // Named components");


            str.AppendLine(@"
        // Constructor
        public DynamicGame(bool createAll)
        {
            
        }");

            int i = 0;
            
            // Enumerate code components
            Dictionary<ZCode, string> codeMap = new Dictionary<ZCode, string>();
            for (i = 0; i < app.code.Count; i++)
            {
                string methodName = String.Format("Method_{0}", i);
                codeMap[app.code[i]] = methodName;
                Indenter.tabs = 2;
                str.IndentedLines("public void " + methodName + "(Model model)\n{");
                Indenter.tabs = 3;
                str.IndentedLines(app.code[i].Text);
                Indenter.tabs = 2;
                str.IndentedLines("}");
            }                        
                            
            //model.Rotation += new Vector3(0, 180.0f * (float) App.DeltaTime, 0);            
                        
            str.AppendLine(@"
     }
}");

            using (StreamWriter writer = new StreamWriter("DynamicGame.cs", false))
            {
                writer.Write(str.ToString());                
            }


            // Generate AppBehavior class

           
            var res = BuildAssembly("dummy", str.ToString(), true);
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
