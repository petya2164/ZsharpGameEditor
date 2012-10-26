#region --- License ---
/* Copyright (c) 2006, 2007 Stefanos Apostolopoulos
 * See license.txt for license info
 */
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using Bind.Structures;
using Delegate=Bind.Structures.Delegate;
using Enum=Bind.Structures.Enum;
using Type=Bind.Structures.Type;

namespace Bind.GL2
{
    class Generator : IBind
    {
        #region --- Fields ---

        protected static string glTypemap = "GL2/gl.tm";
        protected static string csTypemap = "csharp.tm";
        protected static string enumSpec = "GL2/enum.spec";
        protected static string enumSpecExt = "GL2/enumext.spec";
        protected static string glSpec = "GL2/gl.spec";
        protected static string glSpecExt = "";

        protected static string importsFile = "GLCore.cs";
        protected static string delegatesFile = "GLDelegates.cs";
        protected static string enumsFile = "GLEnums.cs";
        protected static string wrappersFile = "GL.cs";

        protected static string functionOverridesFile = "GL2/gloverrides.xml";

        protected static string loadAllFuncName = "LoadAll";

        protected static Regex enumToDotNet = new Regex("_[a-z|A-Z]?", RegexOptions.Compiled);

        protected static readonly char[] numbers = "0123456789".ToCharArray();
        //protected static readonly Dictionary<string, string> doc_replacements;
        #endregion

        #region --- Constructors ---

        public Generator()
        {
            if (Settings.Compatibility == Settings.Legacy.Tao)
            {
                Settings.OutputNamespace = "Tao.OpenGl";
                Settings.OutputClass = "Gl";
            }
            else
            {
                // Defaults
            }
        }

        #endregion

        #region public void Process()

        public virtual void Process()
        {
            // Matches functions that cannot have their trailing 'v' trimmed for CLS-Compliance reasons.
            // Built through trial and error :)
            //Function.endingsAddV =
            //    new Regex(@"(Coord1|Attrib(I?)1(u?)|Stream1|Uniform2(u?)|(Point|Convolution|Transform|Sprite|List|Combiner|Tex)Parameter|Fog(Coord)?.*|VertexWeight|(Fragment)?Light(Model)?|Material|ReplacementCodeu?b?|Tex(Gen|Env)|Indexu?|TextureParameter.v)",
            //    RegexOptions.Compiled);

            Type.Initialize(glTypemap, csTypemap);
            Enum.Initialize(enumSpec, enumSpecExt);
            Enum.GLEnums.Translate(new XPathDocument(Path.Combine(Settings.InputPath, functionOverridesFile)));
            Function.Initialize();
            Delegate.Initialize(glSpec, glSpecExt);

            WriteBindings(
                Delegate.Delegates,
                Function.Wrappers,
                Enum.GLEnums);
        }

        #endregion

        #region private void Translate()
#if false
        protected virtual void Translate()
        {
            Bind.Structures.Enum.GLEnums.Translate();
        }
#endif
        #endregion

        #region ISpecReader Members

        #region public virtual DelegateCollection ReadDelegates(StreamReader specFile)

        public virtual DelegateCollection ReadDelegates(StreamReader specFile)
        {
            Console.WriteLine("Reading function specs.");

            DelegateCollection delegates = new DelegateCollection();

            XPathDocument function_overrides = new XPathDocument(Path.Combine(Settings.InputPath, functionOverridesFile));

            do
            {
                string line = NextValidLine(specFile);
                if (String.IsNullOrEmpty(line))
                    break;

                while (line.Contains("(") && !specFile.EndOfStream)
                {
                    // Get next OpenGL function

                    Delegate d = new Delegate();

                    // Get function name:
                    d.Name = line.Split(Utilities.Separators, StringSplitOptions.RemoveEmptyEntries)[0];

                    do
                    {
                        // Get function parameters and return value

                        line = specFile.ReadLine();
                        List<string> words = new List<string>(
                            line.Replace('\t', ' ').Split(Utilities.Separators, StringSplitOptions.RemoveEmptyEntries)
                        );

                        if (words.Count == 0)
                            break;

                        // Identify line:
                        switch (words[0])
                        {
                            case "return":  // Line denotes return value
                                d.ReturnType.CurrentType = words[1];
                                break;

                            case "param":   // Line denotes parameter
                                Parameter p = new Parameter();

                                p.Name = Utilities.Keywords.Contains(words[1]) ? "@" + words[1] : words[1];
                                p.CurrentType = words[2];
                                p.Pointer += words[4].Contains("array") ? 1 : 0;
                                p.Pointer += words[4].Contains("reference") ? 1 : 0;
                                if (p.Pointer != 0 && words.Count > 5 && words[5].Contains("[1]"))
                                    p.ElementCount = 1;
                                p.Flow = words[3] == "in" ? FlowDirection.In : FlowDirection.Out;

                                d.Parameters.Add(p);
                                break;

                            // GetTexParameterIivEXT and GetTexParameterIuivEXT define two(!) versions (why?)
                            case "version": // Line denotes function version (i.e. 1.0, 1.2, 1.5)
                                d.Version = words[1];
                                break;

                            case "category":
                                d.Category = words[1];
                                break;
                        }
                    }
                    while (!specFile.EndOfStream);

                    d.Translate(function_overrides);

                    delegates.Add(d);
                }
            }
            while (!specFile.EndOfStream);

            return delegates;
        }

        #endregion

        #region public virtual EnumCollection ReadEnums(StreamReader specFile)

        public virtual EnumCollection ReadEnums(StreamReader specFile)
        {
            Trace.WriteLine("Reading opengl enumerant specs.");
            Trace.Indent();

            EnumCollection enums = new EnumCollection();

            // complete_enum contains all opengl enumerants.
            Enum complete_enum = new Enum();
            complete_enum.Name = Settings.CompleteEnumName;

            do
            {
                string line = NextValidLine(specFile);
                if (String.IsNullOrEmpty(line))
                    break;

                line = line.Replace('\t', ' ');

                // We just encountered the start of a new enumerant:
                while (!String.IsNullOrEmpty(line) && line.Contains("enum"))
                {
                    string[] words = line.Split(Utilities.Separators, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length == 0)
                        continue;

                    // Declare a new enumerant
                    Enum e = new Enum();
                    e.Name = Char.IsDigit(words[0][0]) ? Settings.ConstantPrefix + words[0] : words[0];

                    // And fill in the values for this enumerant
                    do
                    {
                        line = NextValidLine(specFile);

                        if (String.IsNullOrEmpty(line) || line.StartsWith("#"))
                            continue;

                        if (line.Contains("enum:") || specFile.EndOfStream)
                            break;

                        line = line.Replace('\t', ' ');
                        words = line.Split(Utilities.Separators, StringSplitOptions.RemoveEmptyEntries);

                        if (words.Length == 0)
                            continue;

                        // If we reach this point, we have found a new value for the current enumerant
                        Constant c = new Constant();
                        if (line.Contains("="))
                        {
                            // Trim the name's prefix, but only if not in Tao compat mode.
                            if (Settings.Compatibility == Settings.Legacy.Tao)
                            {
                            }
                            else
                            {
                                if (words[0].StartsWith(Settings.ConstantPrefix))
                                    words[0] = words[0].Substring(Settings.ConstantPrefix.Length);

                                if (Char.IsDigit(words[0][0]))
                                    words[0] = Settings.ConstantPrefix + words[0];
                            }

                            c.Name = words[0];
                            c.Value = words[2];
                        }
                        else if (words[0] == "use")
                        {
                            // Trim the prefix.
                            if (words[2].StartsWith(Settings.ConstantPrefix))
                                words[2] = words[2].Substring(Settings.ConstantPrefix.Length);

                            // If the remaining string starts with a digit, we were wrong above.
                            // Re-add the "GL_"
                            if (Char.IsDigit(words[2][0]))
                                words[2] = Settings.ConstantPrefix + words[2];

                            c.Name = words[2];
                            c.Reference = words[1];
                            c.Value = words[2];
                        }
                        else
                        {
                            // Typical cause is hand-editing the specs and forgetting to add an '=' sign.
                            throw new InvalidOperationException(String.Format(
                                "[Error] Invalid constant definition: \"{0}\"", line));
                        }

                        //if (!String.IsNullOrEmpty(c.Name) && !e.Members.Contains.Contains(c))
                        //SpecTranslator.Merge(e.Members, c);
                        if (!e.ConstantCollection.ContainsKey(c.Name))
                            e.ConstantCollection.Add(c.Name, c);
                        else
                            Trace.WriteLine(String.Format(
                                "Spec error: Constant {0} defined twice in enum {1}, discarding last definition.",
                                c.Name, e.Name));

                        // Insert the current constant in the list of all constants.
                        //SpecTranslator.Merge(complete_enum.Members, c);
                        complete_enum = Utilities.Merge(complete_enum, c);
                    }
                    while (!specFile.EndOfStream);

                    // At this point, the complete value list for the current enumerant has been read, so add this
                    // enumerant to the list.
                    //e.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "public enum " + e.Name));
                    //e.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, "public enum " + e.Name));

                    // (disabled) Hack - discard Boolean enum, it fsucks up the fragile translation code ahead.
                    //if (!e.Name.Contains("Bool"))
                    //Utilities.Merge(enums, e);

                    //e.Translate();

                    if (!enums.ContainsKey(e.Name))
                        enums.Add(e.Name, e);
                    else
                    {
                        // The enum already exists, merge constants.
                        foreach (Constant t in e.ConstantCollection.Values)
                            Utilities.Merge(enums[e.Name], t);
                    }
                }
            }
            while (!specFile.EndOfStream);

            enums.Add(complete_enum.Name, complete_enum);

            Trace.Unindent();

            return enums;
        }

        #endregion

        #region public virtual Dictionary<string, string> ReadTypeMap(StreamReader specFile)

        public virtual Dictionary<string, string> ReadTypeMap(StreamReader specFile)
        {
            Console.WriteLine("Reading opengl types.");
            Dictionary<string, string> GLTypes = new Dictionary<string, string>();

            if (specFile == null)
                return GLTypes;

            do
            {
                string line = specFile.ReadLine();

                if (String.IsNullOrEmpty(line) || line.StartsWith("#"))
                    continue;

                string[] words = line.Split(" ,*\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (words[0].ToLower() == "void")
                {
                    // Special case for "void" -> "". We make it "void" -> "void"
                    GLTypes.Add(words[0], "void");
                }
                else if (words[0] == "VoidPointer" || words[0] == "ConstVoidPointer")
                {
                    // "(Const)VoidPointer" -> "void*"
                    GLTypes.Add(words[0], "void*");
                }
                else if (words[0] == "CharPointer" || words[0] == "charPointerARB")
                {
                    // The typematching logic cannot handle pointers to pointers, e.g. CharPointer* -> char** -> string* -> string[].
                    // Hence we give it a push.
                    // Note: When both CurrentType == "String" and Pointer == true, the typematching is hardcoded to use
                    // String[] or StringBuilder[].
                    GLTypes.Add(words[0], "String");
                }
                /*else if (words[0].Contains("Pointer"))
                {
                    GLTypes.Add(words[0], words[1].Replace("Pointer", "*"));
                }*/
                else if (words[1].Contains("GLvoid"))
                {
                    GLTypes.Add(words[0], "void");
                }
                else
                {
                    GLTypes.Add(words[0], words[1]);
                }
            }
            while (!specFile.EndOfStream);

            return GLTypes;
        }

        #endregion

        #region public virtual Dictionary<string, string> ReadCSTypeMap(StreamReader specFile)

        public virtual Dictionary<string, string> ReadCSTypeMap(StreamReader specFile)
        {
            Dictionary<string, string> CSTypes = new Dictionary<string, string>();
            Console.WriteLine("Reading C# types.");

            while (!specFile.EndOfStream)
            {
                string line = specFile.ReadLine();
                if (String.IsNullOrEmpty(line) || line.StartsWith("#"))
                    continue;

                string[] words = line.Split(" ,\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (words.Length < 2)
                    continue;

                if (((Settings.Compatibility & Settings.Legacy.NoBoolParameters) != Settings.Legacy.None) && words[1] == "bool")
                    words[1] = "Int32";

                CSTypes.Add(words[0], words[1]);
            }

            return CSTypes;
        }

        #endregion

        #region private string NextValidLine(StreamReader sr)

        private string NextValidLine(StreamReader sr)
        {
            string line;

            do
            {
                if (sr.EndOfStream)
                    return null;

                line = sr.ReadLine().Trim();

                if (String.IsNullOrEmpty(line) ||
                    line.StartsWith("#") ||                 // Disregard comments.
                    line.StartsWith("passthru") ||          // Disregard passthru statements.
                    line.StartsWith("required-props:") ||
                    line.StartsWith("param:") ||
                    line.StartsWith("dlflags:") ||
                    line.StartsWith("glxflags:") ||
                    line.StartsWith("vectorequiv:") ||
                    //line.StartsWith("category:") ||
                    line.StartsWith("version:") ||
                    line.StartsWith("glxsingle:") ||
                    line.StartsWith("glxropcode:") ||
                    line.StartsWith("glxvendorpriv:") ||
                    line.StartsWith("glsflags:") ||
                    line.StartsWith("glsopcode:") ||
                    line.StartsWith("glsalias:") ||
                    line.StartsWith("wglflags:") ||
                    line.StartsWith("extension:") ||
                    line.StartsWith("alias:") ||
                    line.StartsWith("offset:"))
                    continue;

                return line;
            }
            while (true);
        }

        #endregion

        #endregion

        #region ISpecWriter Members

        #region void WriteBindings

        public void WriteBindings(DelegateCollection delegates, FunctionCollection functions, EnumCollection enums)
        {
            Console.WriteLine("Writing bindings to {0}", Settings.OutputPath);
            if (!Directory.Exists(Settings.OutputPath))
                Directory.CreateDirectory(Settings.OutputPath);

            string temp_enums_file = Path.GetTempFileName();
            string temp_delegates_file = Path.GetTempFileName();
            string temp_core_file = Path.GetTempFileName();
            string temp_wrappers_file = Path.GetTempFileName();

            // Enums
            using (BindStreamWriter sw = new BindStreamWriter(temp_enums_file))
            {
                WriteLicense(sw);
                
                sw.WriteLine("using System;");
                sw.WriteLine();

                if ((Settings.Compatibility & Settings.Legacy.NestedEnums) != Settings.Legacy.None)
                {
                    sw.WriteLine("namespace {0}", Settings.OutputNamespace);
                    sw.WriteLine("{");
                    sw.Indent();
                    sw.WriteLine("static partial class {0}", Settings.OutputClass);
                }
                else
                    sw.WriteLine("namespace {0}", Settings.EnumsOutput);

                sw.WriteLine("{");

                sw.Indent();
                WriteEnums(sw, Enum.GLEnums);
                sw.Unindent();

                if ((Settings.Compatibility & Settings.Legacy.NestedEnums) != Settings.Legacy.None)
                {
                    sw.WriteLine("}");
                    sw.Unindent();
                }

                sw.WriteLine("}");
            }

            // Delegates
            using (BindStreamWriter sw = new BindStreamWriter(temp_delegates_file))
            {
                WriteLicense(sw);
                sw.WriteLine("namespace {0}", Settings.OutputNamespace);
                sw.WriteLine("{");
                sw.Indent();

                sw.WriteLine("using System;");
                sw.WriteLine("using System.Text;");
                sw.WriteLine("using System.Runtime.InteropServices;");

                sw.WriteLine("#pragma warning disable 0649");
                WriteDelegates(sw, Delegate.Delegates);

                sw.Unindent();
                sw.WriteLine("}");
            }

            // Core
            using (BindStreamWriter sw = new BindStreamWriter(temp_core_file))
            {
                WriteLicense(sw);
                sw.WriteLine("namespace {0}", Settings.OutputNamespace);
                sw.WriteLine("{");
                sw.Indent();
                //specWriter.WriteTypes(sw, Bind.Structures.Type.CSTypes);
                sw.WriteLine("using System;");
                sw.WriteLine("using System.Text;");
                sw.WriteLine("using System.Runtime.InteropServices;");

                WriteImports(sw, Delegate.Delegates);

                sw.Unindent();
                sw.WriteLine("}");
            }

            // Wrappers
            using (BindStreamWriter sw = new BindStreamWriter(temp_wrappers_file))
            {
                WriteLicense(sw);
                sw.WriteLine("namespace {0}", Settings.OutputNamespace);
                sw.WriteLine("{");
                sw.Indent();

                sw.WriteLine("using System;");
                sw.WriteLine("using System.Text;");
                sw.WriteLine("using System.Runtime.InteropServices;");

                WriteWrappers(sw, Function.Wrappers, Type.CSTypes);

                sw.Unindent();
                sw.WriteLine("}");
            }

            string output_enums = Path.Combine(Settings.OutputPath, enumsFile);
            string output_delegates = Path.Combine(Settings.OutputPath, delegatesFile);
            string output_core = Path.Combine(Settings.OutputPath, importsFile);
            string output_wrappers = Path.Combine(Settings.OutputPath, wrappersFile);
            
            if (File.Exists(output_enums)) File.Delete(output_enums);
            if (File.Exists(output_delegates)) File.Delete(output_delegates);
            if (File.Exists(output_core)) File.Delete(output_core);
            if (File.Exists(output_wrappers)) File.Delete(output_wrappers);

            File.Move(temp_enums_file, output_enums);
            File.Move(temp_delegates_file, output_delegates);
            File.Move(temp_core_file, output_core);
            File.Move(temp_wrappers_file, output_wrappers);
        }

        #endregion

        #region void WriteDelegates

        public virtual void WriteDelegates(BindStreamWriter sw, DelegateCollection delegates)
        {
            Trace.WriteLine(String.Format("Writing delegates to:\t{0}.{1}.{2}", Settings.OutputNamespace, Settings.OutputClass, Settings.DelegatesClass));

            sw.WriteLine("#pragma warning disable 3019");   // CLSCompliant attribute
            sw.WriteLine("#pragma warning disable 1591");   // Missing doc comments

            sw.WriteLine();
            sw.WriteLine("partial class {0}", Settings.OutputClass);
            sw.WriteLine("{");
            sw.Indent();

            sw.WriteLine("internal static partial class {0}", Settings.DelegatesClass);
            sw.WriteLine("{");
            sw.Indent();

            foreach (Delegate d in delegates.Values)
            {
                sw.WriteLine("[System.Security.SuppressUnmanagedCodeSecurity()]");
                sw.WriteLine("internal {0};", d.ToString());
                sw.WriteLine("internal {0}static {1} {2}{1};",   //  = null
                    d.Unsafe ? "unsafe " : "",
                    d.Name,
                    Settings.FunctionPrefix);
            }

            sw.Unindent();
            sw.WriteLine("}");

            sw.Unindent();
            sw.WriteLine("}");
        }

        #endregion

        #region void WriteImports

        public virtual void WriteImports(BindStreamWriter sw, DelegateCollection delegates)
        {
            Trace.WriteLine(String.Format("Writing imports to:\t{0}.{1}.{2}", Settings.OutputNamespace, Settings.OutputClass, Settings.ImportsClass));

            sw.WriteLine("#pragma warning disable 3019");   // CLSCompliant attribute
            sw.WriteLine("#pragma warning disable 1591");   // Missing doc comments

            sw.WriteLine();
            sw.WriteLine("partial class {0}", Settings.OutputClass);
            sw.WriteLine("{");
            sw.Indent();
            sw.WriteLine();
            sw.WriteLine("internal static partial class {0}", Settings.ImportsClass);
            sw.WriteLine("{");
            sw.Indent();
            //sw.WriteLine("static {0}() {1} {2}", Settings.ImportsClass, "{", "}");    // Disable BeforeFieldInit
            sw.WriteLine();
            foreach (Delegate d in delegates.Values)
            {
                sw.WriteLine("[System.Security.SuppressUnmanagedCodeSecurity()]");
                sw.WriteLine(
                    "[System.Runtime.InteropServices.DllImport({0}.Library, EntryPoint = \"{1}{2}\"{3})]",
                    Settings.OutputClass,
                    Settings.FunctionPrefix,
                    d.Name,
                    d.Name.EndsWith("W") || d.Name.EndsWith("A") ? ", CharSet = CharSet.Auto" : ", ExactSpelling = true"
                );
                sw.WriteLine("internal extern static {0};", d.DeclarationString());
            }
            sw.Unindent();
            sw.WriteLine("}");
            sw.Unindent();
            sw.WriteLine("}");
        }

        #endregion

        #region void WriteWrappers

        public void WriteWrappers(BindStreamWriter sw, FunctionCollection wrappers, Dictionary<string, string> CSTypes)
        {
            Trace.WriteLine(String.Format("Writing wrappers to:\t{0}.{1}", Settings.OutputNamespace, Settings.OutputClass));

            sw.WriteLine("#pragma warning disable 3019");   // CLSCompliant attribute
            sw.WriteLine("#pragma warning disable 1591");   // Missing doc comments
            sw.WriteLine("#pragma warning disable 1572");   // Wrong param comments
            sw.WriteLine("#pragma warning disable 1573");   // Missing param comments

            sw.WriteLine();
            sw.WriteLine("partial class {0}", Settings.OutputClass);
            sw.WriteLine("{");

            sw.Indent();
            //sw.WriteLine("static {0}() {1} {2}", className, "{", "}");    // Static init in GLHelper.cs
            sw.WriteLine();

            int current = 0;
            foreach (string key in wrappers.Keys)
            {
                if (((Settings.Compatibility & Settings.Legacy.NoSeparateFunctionNamespaces) == Settings.Legacy.None) && key != "Core")
                {
                    if (!Char.IsDigit(key[0]))
                    {
                        sw.WriteLine("public static partial class {0}", key);
                    }
                    else
                    {
                        // Identifiers cannot start with a number:
                        sw.WriteLine("public static partial class {0}{1}", Settings.ConstantPrefix, key);
                    }
                    sw.WriteLine("{");
                    sw.Indent();
                }

                wrappers[key].Sort();
                foreach (Function f in wrappers[key])
                {
                    current = WriteWrapper(sw, current, f);
                }

                if (((Settings.Compatibility & Settings.Legacy.NoSeparateFunctionNamespaces) == Settings.Legacy.None) && key != "Core")
                {
                    sw.Unindent();
                    sw.WriteLine("}");
                    sw.WriteLine();
                }
            }
            sw.Unindent();
            sw.WriteLine("}");
        }

        private static int WriteWrapper(BindStreamWriter sw, int current, Function f)
        {
            if ((Settings.Compatibility & Settings.Legacy.NoDocumentation) == 0)
            {
                Console.WriteLine("Creating docs for #{0} ({1})", current++, f.Name);
                WriteDocumentation(sw, f);
            }
            WriteMethod(sw, f);
            return current;
        }

        private static void WriteMethod(BindStreamWriter sw, Function f)
        {
            if (!f.CLSCompliant)
            {
                sw.WriteLine("[System.CLSCompliant(false)]");
            }
            sw.WriteLine("[AutoGenerated(Category = \"{0}\", Version = \"{1}\", EntryPoint = \"{2}\")]",
                f.Category, f.Version, Settings.FunctionPrefix + f.WrappedDelegate.Name);
            sw.WriteLine("public static");
            sw.Write(f);
            sw.WriteLine();
        }

        private static void WriteDocumentation(BindStreamWriter sw, Function f)
        {
            try
            {
                string path = Path.Combine(Settings.DocPath, Settings.FunctionPrefix + f.WrappedDelegate.Name + ".xml");
                if (!File.Exists(path))
                    path = Path.Combine(Settings.DocPath, Settings.FunctionPrefix +
                        f.TrimmedName + ".xml");

                if (!File.Exists(path))
                    path = Path.Combine(Settings.DocPath, Settings.FunctionPrefix + f.TrimmedName.TrimEnd(numbers) + ".xml");

                if (File.Exists(path))
                {
                    DocProcessor doc_processor = new DocProcessor(Path.Combine(Settings.DocPath, Settings.DocFile));
                    sw.WriteLine(doc_processor.ProcessFile(path));
                }
            }
            catch (FileNotFoundException)
            { }
        }

        #endregion

        #region void WriteTypes

        public void WriteTypes(BindStreamWriter sw, Dictionary<string, string> CSTypes)
        {
            sw.WriteLine();
            foreach (string s in CSTypes.Keys)
            {
                sw.WriteLine("using {0} = System.{1};", s, CSTypes[s]);
            }
        }

        #endregion

        #region void WriteEnums

        public void WriteEnums(BindStreamWriter sw, EnumCollection enums)
        {
            //sw.WriteLine("#pragma warning disable 3009");   // CLSCompliant attribute
            //sw.WriteLine("#pragma warning disable 3003");   // CLSCompliant attribute
            sw.WriteLine("#pragma warning disable 1591");   // Missing doc comments
            sw.WriteLine();

            if ((Settings.Compatibility & Settings.Legacy.NestedEnums) != Settings.Legacy.None)
                Trace.WriteLine(String.Format("Writing enums to:\t{0}.{1}.{2}", Settings.OutputNamespace, Settings.OutputClass, Settings.NestedEnumsClass));
            else
                Trace.WriteLine(String.Format("Writing enums to:\t{0}", Settings.EnumsOutput));

            if ((Settings.Compatibility & Settings.Legacy.ConstIntEnums) == Settings.Legacy.None)
            {
                if ((Settings.Compatibility & Settings.Legacy.NestedEnums) != Settings.Legacy.None &&
                    !String.IsNullOrEmpty(Settings.NestedEnumsClass))
                {
                    sw.WriteLine("public class Enums");
                    sw.WriteLine("{");
                    sw.Indent();
                }

                foreach (Enum e in enums.Values)
                {
                    //if (e.Name.StartsWith("BufferTarget")) Trace.WriteLine(String.Format(" WRITING ENUM: {0}", e.Name));
                    sw.Write(e);
                    sw.WriteLine();
                }

                if ((Settings.Compatibility & Settings.Legacy.NestedEnums) != Settings.Legacy.None &&
                    !String.IsNullOrEmpty(Settings.NestedEnumsClass))
                {
                    sw.Unindent();
                    sw.WriteLine("}");
                }
            }
            else
            {
                // Tao legacy mode: dump all enums as constants in GLClass.
                foreach (Constant c in enums[Settings.CompleteEnumName].ConstantCollection.Values)
                {
                    // Print constants avoiding circular definitions
                    if (c.Name != c.Value)
                    {
                        sw.WriteLine(String.Format(
                            "public const int {0} = {2}((int){1});",
                            c.Name.StartsWith(Settings.ConstantPrefix) ? c.Name : Settings.ConstantPrefix + c.Name,
                            Char.IsDigit(c.Value[0]) ? c.Value : c.Value.StartsWith(Settings.ConstantPrefix) ? c.Value : Settings.ConstantPrefix + c.Value,
                            c.Unchecked ? "unchecked" : ""));
                    }
                    else
                    {
                    }
                }
            }
        }

        #endregion

        #region void WriteLicense

        public void WriteLicense(BindStreamWriter sw)
        {
            sw.WriteLine(File.ReadAllText(Path.Combine(Settings.InputPath, Settings.LicenseFile)));
            sw.WriteLine();
        }

        #endregion

        #endregion
    }
}
