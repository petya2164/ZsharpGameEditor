using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
//using System.Runtime.Serialization.Formatters.Soap;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Drawing;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Loader
{
    /// <summary>
    /// Inherits from CodeDomDesignerLoader. It can generate C# or VB code
    /// for a HostSurface. This loader does not support parsing a 
    /// C# or VB file.
    /// </summary>
    public class CodeDomHostLoader
    {
        CSharpCodeProvider _csCodeProvider = new CSharpCodeProvider();
        CodeCompileUnit codeCompileUnit = null;
        CodeGen cg = null;
        TypeResolutionService _trs = null;
        private string executable;
        private Process run;

        public CodeDomHostLoader()
        {
            _trs = new TypeResolutionService();
        }

        /// <summary>
        /// Bootstrap method - loads a blank Form
        /// </summary>
        /// <returns></returns>
        protected CodeCompileUnit Parse()
        {
            CodeCompileUnit ccu = null;

            //DesignSurface ds = new DesignSurface();
            //ds.BeginLoad(typeof(Form));
            //IDesignerHost idh = (IDesignerHost)ds.GetService(typeof(IDesignerHost));
            //idh.RootComponent.Site.Name = "Form1";

            cg = new CodeGen();
            ccu = cg.GetCodeCompileUnit();

            AssemblyName[] names = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            for (int i = 0; i < names.Length; i++)
            {
                Assembly assembly = Assembly.Load(names[i]);
                ccu.ReferencedAssemblies.Add(assembly.Location);
            }

            codeCompileUnit = ccu;
            return ccu;
        }

        /// <summary>
        /// When the Loader is Flushed this method is called. The base class
        /// (CodeDomDesignerLoader) creates the CodeCompileUnit. We
        /// simply cache it and use this when we need to generate code from it.
        /// To generate the code we use CodeProvider.
        /// </summary>
        protected void Write(CodeCompileUnit unit)
        {
            codeCompileUnit = unit;
        }



        #region Public methods

        /// <summary>
        /// Flushes the host and returns the updated CodeCompileUnit
        /// </summary>
        /// <returns></returns>
        public CodeCompileUnit GetCodeCompileUnit()
        {
            //Flush();
            return codeCompileUnit;
        }

        /// <summary>
        /// This method writes out the contents of our designer in C# and VB.
        /// It generates code from our codeCompileUnit using CodeRpovider
        /// </summary>
        public string GetCode(string context)
        {
            //Flush();

            CodeGeneratorOptions o = new CodeGeneratorOptions();

            o.BlankLinesBetweenMembers = true;
            o.BracingStyle = "C";
            o.ElseOnClosing = false;
            o.IndentString = "    ";
            if (context == "C#")
            {
                StringWriter swCS = new StringWriter();
                CSharpCodeProvider cs = new CSharpCodeProvider();

                cs.GenerateCodeFromCompileUnit(codeCompileUnit, swCS, o);
                string code = swCS.ToString();
                swCS.Close();
                return code;
            }
            else if (context == "VB")
            {
                StringWriter swVB = new StringWriter();
                VBCodeProvider vb = new VBCodeProvider();

                vb.GenerateCodeFromCompileUnit(codeCompileUnit, swVB, o);
                string code = swVB.ToString();
                swVB.Close();
                return code;
            }

            return String.Empty;
        }


        #endregion

        #region Build and Run

        /// <summary>
        /// Called when we want to build an executable. Returns true if we succeeded.
        /// </summary>
        public bool Build()
        {
            //Flush();

            // If we haven't already chosen a spot to write the executable to,
            // do so now.
            if (executable == null)
            {
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.DefaultExt = "exe";
                dlg.Filter = "Executables|*.exe";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    executable = dlg.FileName;
                }
            }

            if (executable != null)
            {
                // We need to collect the parameters that our compiler will use.
                CompilerParameters cp = new CompilerParameters();
                AssemblyName[] assemblyNames = Assembly.GetEntryAssembly().GetReferencedAssemblies();

                foreach (AssemblyName an in assemblyNames)
                {
                    Assembly assembly = Assembly.Load(an);
                    cp.ReferencedAssemblies.Add(assembly.Location);
                }

                cp.GenerateExecutable = true;
                cp.OutputAssembly = executable;
                cp.CompilerOptions = "/optimize /target:winexe";

                // Remember our main class is not Form, but Form1 (or whatever the user calls it)!
                //cp.MainClass = "DesignerHostSample." + this.LoaderHost.RootComponent.Site.Name;

                CSharpCodeProvider cc = new CSharpCodeProvider();
                CompilerResults cr = cc.CompileAssemblyFromDom(cp, codeCompileUnit);

                if (cr.Errors.HasErrors)
                {
                    string errors = "";

                    foreach (CompilerError error in cr.Errors)
                    {
                        errors += error.ErrorText + "\n";
                    }

                    MessageBox.Show(errors, "Errors during compile.");
                }

                return !cr.Errors.HasErrors;
            }

            return false;
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

        #endregion

    }// class
}// namespace
