﻿#region --- License ---
/* Copyright (c) 2006, 2007 Stefanos Apostolopoulos
 * See license.txt for license info
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;

namespace Bind.Structures
{
    public class Type : IComparable<Type>
    {
        internal static Dictionary<string, string> GLTypes;
        internal static Dictionary<string, string> CSTypes;

        private static bool typesLoaded;

        string current_qualifier = "", previous_qualifier = "";

        #region internal static void Initialize(string glTypes, string csTypes)
        
        internal static void Initialize(string glTypes, string csTypes)
        {
            if (!typesLoaded)
            {
                if (GLTypes == null)
                {
                    using (StreamReader sr = Utilities.OpenSpecFile(Settings.InputPath, glTypes))
                    {
                        GLTypes = MainClass.Generator.ReadTypeMap(sr);
                    }
                }
                if (CSTypes == null)
                {
                    using (StreamReader sr = Utilities.OpenSpecFile(Settings.InputPath, csTypes))
                    {
                        CSTypes = MainClass.Generator.ReadCSTypeMap(sr);
                    }
                }
                typesLoaded = true;
            }
        }
        
        #endregion

        #region --- Constructors ---
        
        public Type()
        {
        }

        public Type(Type t)
        {
            if (t != null)
            {
                QualifiedType = t.QualifiedType; // Covers current type and qualifier
                PreviousType = t.PreviousType;
                PreviousQualifier = t.PreviousQualifier;
                WrapperType = t.WrapperType;
                Array = t.Array;
                Pointer = t.Pointer;
                Reference = t.Reference;
                ElementCount = t.ElementCount;
            }
        }
        
        #endregion

        public string CurrentQualifier
        {
            get { return current_qualifier; }
            set { PreviousQualifier = CurrentQualifier; current_qualifier = value; }
        }

        public string PreviousQualifier
        {
            get { return previous_qualifier; }
            private set { previous_qualifier = value; }
        }

        public string QualifiedType {
            get
            {
                if (!String.IsNullOrEmpty(CurrentQualifier))
                    return String.Format("{0}.{1}", CurrentQualifier, CurrentType);
                else
                    return CurrentType;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException();

                int qualifier_end = value.LastIndexOf('.');
                if (qualifier_end > -1)
                {
                    CurrentQualifier = value.Substring(0, qualifier_end);
                    CurrentType = value.Substring(qualifier_end + 1);
                }
                else
                {
                    CurrentType = value;
                }
            }
        }

        #region public string CurrentType

        string type;
        /// <summary>
        /// Gets the type of the parameter.
        /// </summary>
        public virtual string CurrentType
        {
            //get { return _type; }
            get
            {
                if (((Settings.Compatibility & Settings.Legacy.TurnVoidPointersToIntPtr) != Settings.Legacy.None) && Pointer != 0 && type.Contains("void"))
                    return "IntPtr";

                return type;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException();

                if (!String.IsNullOrEmpty(type))
                    PreviousType = type;
                if (!String.IsNullOrEmpty(value))
                    type = value.Trim();

                while (type.EndsWith("*"))
                {
                    type = type.Substring(0, type.Length - 1);
                    Pointer++;
                }
            }
        }

        #endregion

        #region public string PreviousType

        private string _previous_type;

        public string PreviousType
        {
            get { return _previous_type; }
            private set { _previous_type = value; }
        }

        #endregion

        #region public bool Reference

        bool reference;

        public bool Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        #endregion

        #region public int Array

        int array;

        public int Array
        {
            get { return array; }
            set { array = value > 0 ? value : 0; }
        }

        #endregion

        #region public int ElementCount

        int element_count;

        // If the type is an array and ElementCount > 0, then ElemenCount defines the expected array length.
        public int ElementCount
        {
            get { return element_count; }
            set { element_count = value > 0 ? value : 0; }
        }

        #endregion

        #region public int Pointer

        int pointer;

        public int Pointer
        {
            get { return pointer; }
            set { pointer = value > 0 ? value : 0; }
        }

        #endregion

        // Returns true if parameter is an enum.
        public bool IsEnum
        {
            get
            {
                return Enum.GLEnums.ContainsKey(CurrentType) ||
                    Enum.AuxEnums.ContainsKey(CurrentType);
            }
        }

        #region IndirectionLevel

        // Gets the the level of indirection for this type. For example,
        // type 'foo' has indirection level = 0, while 'ref foo*[]' has
        // an indirection level of 3.
        public int IndirectionLevel
        {
            get { return Pointer + Array + (Reference ? 1 : 0); }
        }

        #endregion

        #region public bool CLSCompliant

        public bool CLSCompliant
        {
            get
            {
                bool compliant = true;
                
                switch (CurrentType.ToLower())
                {
                    case "sbyte":
                    case "ushort":
                    case "uint":
                    case "ulong":
                    case "uintptr":
                    case "uint16":
                    case "uint32":
                    case "uint64":
                         compliant = false;
                        break;
                
                    default:
                        compliant = Pointer == 0;
                       break;
                }

                return compliant;
                
                /*
                if (Pointer != 0)
                {
                    compliant &= CurrentType.Contains("IntPtr");    // IntPtr's are CLSCompliant.
                    // If the NoPublicUnsageFunctions is set, the pointer will be CLSCompliant.
                    compliant |= (Settings.Compatibility & Settings.Legacy.NoPublicUnsafeFunctions) != Settings.Legacy.None;
                }
                return compliant;
                */
                //return compliant && (!Pointer || CurrentType.Contains("IntPtr"));
                //return compliant && !(Pointer && ((Settings.Compatibility & Settings.Legacy.NoPublicUnsafeFunctions) == Settings.Legacy.None));
                
                /*
                 * return !(
                    (Pointer && ((Settings.Compatibility & Settings.Legacy.NoPublicUnsafeFunctions) == Settings.Legacy.None ) ||
                    CurrentType.Contains("UInt") ||
                    CurrentType.Contains("SByte")));
                */

                /*(Type.Contains("GLu") && !Type.Contains("GLubyte")) ||
                Type == "GLbitfield" ||
                Type.Contains("GLhandle") ||
                Type.Contains("GLhalf") ||
                Type == "GLbyte");*/
            }
        }

        #endregion

        #region public bool Unsigned

        public bool Unsigned
        {
            get
            {
                return (CurrentType.Contains("UInt") || CurrentType.Contains("Byte"));
            }
        }

        #endregion

        #region public WrapperTypes WrapperType

        private WrapperTypes _wrapper_type = WrapperTypes.None;

        public WrapperTypes WrapperType
        {
            get { return _wrapper_type; }
            set { _wrapper_type = value; }
        }

        #endregion

        #region public string GetCLSCompliantType()

        public string GetCLSCompliantType()
        {
            if (!CLSCompliant)
            {
                if (Pointer != 0 && Settings.Compatibility == Settings.Legacy.Tao)
                    return "IntPtr";

                switch (CurrentType)
                {
                    case "UInt16":
                    case "ushort":
                        return "Int16";
                    case "UInt32":
                    case "uint":
                        return "Int32";
                    case "UInt64":
                    case "ulong":
                        return "Int64";
                    case "SByte":
                    case "sbyte":
                        return "Byte";
                    case "UIntPtr":
                        return "IntPtr";
                }
            }

            return CurrentType;
        }

        #endregion

        #region public override string ToString()
        
        public override string ToString()
        {
            return QualifiedType;
        }
        
        #endregion

        #region public virtual void Translate(XPathNavigator overrides, string category)

        public virtual void Translate(XPathNavigator overrides, string category)
        {
            Enum @enum;
            string s;

            // Try to find out if it is an enum. If the type exists in the normal GLEnums list, use this.
            // Otherwise, try to find it in the aux enums list. If it exists in neither, it is not an enum.
            // Special case for Boolean - it is an enum, but it is dumb to use that instead of the 'bool' type.
            bool normal = false;
            bool aux = false;
            normal = Enum.GLEnums.TryGetValue(CurrentType, out @enum);
            if (!normal)
                aux = Enum.AuxEnums != null && Enum.AuxEnums.TryGetValue(CurrentType, out @enum);

            // Translate enum types
            if ((normal || aux) && @enum.Name != "GLenum" && @enum.Name != "Boolean")
            {
                if ((Settings.Compatibility & Settings.Legacy.ConstIntEnums) != Settings.Legacy.None)
                    QualifiedType = "int";
                else
                {
#warning "Unecessary code"
                    if (normal)
                        QualifiedType = CurrentType.Insert(0, String.Format("{0}.", Settings.EnumsOutput));
                    else if (aux)
                        QualifiedType = CurrentType.Insert(0, String.Format("{0}.", Settings.EnumsAuxOutput));
                }
            }
            else if (GLTypes.TryGetValue(CurrentType, out s))
            {
                // Check if the parameter is a generic GLenum. If it is, search for a better match,
                // otherwise fallback to Settings.CompleteEnumName (named 'All' by default).
                if (s.Contains("GLenum") /*&& !String.IsNullOrEmpty(category)*/)
                {
                    if ((Settings.Compatibility & Settings.Legacy.ConstIntEnums) != Settings.Legacy.None)
                    {
                        QualifiedType = "int";
                    }
                    else
                    {
                        // Better match: enum.Name == function.Category (e.g. GL_VERSION_1_1 etc)
                        if (Enum.GLEnums.ContainsKey(category))
                        {
                            QualifiedType = String.Format("{0}.{1}", Settings.EnumsOutput, Enum.TranslateName(category));
                        }
                        else
                        {
                            QualifiedType = String.Format("{0}.{1}", Settings.EnumsOutput, Settings.CompleteEnumName);
                        }
                    }
                }
                else
                {
                    // A few translations for consistency
                    switch (CurrentType.ToLower())
                    {
                        case "string": QualifiedType = "String"; break;
                    }

#warning "Stale code"
                    // This is not enum, default translation:
                    if (CurrentType == "PIXELFORMATDESCRIPTOR" || CurrentType == "LAYERPLANEDESCRIPTOR" ||
                        CurrentType == "GLYPHMETRICSFLOAT")
                    {
                        if (Settings.Compatibility == Settings.Legacy.Tao)
                            CurrentType = CurrentType.Insert(0, "Gdi.");
                        else
                        {
                            if (CurrentType == "PIXELFORMATDESCRIPTOR")
                                CurrentType = "PixelFormatDescriptor";
                            else if (CurrentType == "LAYERPLANEDESCRIPTOR")
                                CurrentType = "LayerPlaneDescriptor";
                            else if (CurrentType == "GLYPHMETRICSFLOAT")
                                CurrentType = "GlyphMetricsFloat";
                        }
                    }
                    else if (CurrentType == "XVisualInfo")
                    {
                        //p.Pointer = false;
                        //p.Reference = true;
                    }
                    else
                        QualifiedType = s;
                }
            }

            CurrentType =
                CSTypes.ContainsKey(CurrentType) ?
                CSTypes[CurrentType] : CurrentType;

            // Make sure that enum parameters follow enum overrides, i.e.
            // if enum ErrorCodes is overriden to ErrorCode, then parameters
            // of type ErrorCodes should also be overriden to ErrorCode.
            XPathNavigator enum_override = overrides.SelectSingleNode(String.Format("/overrides/replace/enum[@name='{0}']/name", CurrentType));
            if (enum_override != null)
            {
                // For consistency - many overrides use string instead of String.
                if (enum_override.Value == "string")
                    QualifiedType = "String";
                else if (enum_override.Value == "StringBuilder")
                    QualifiedType = "StringBuilder";
                else
                    CurrentType = enum_override.Value;
            }

            if (CurrentType == "IntPtr" && String.IsNullOrEmpty(PreviousType))
                Pointer = 0;
        }

        #endregion

        #region IComparable<Type> Members

        public int CompareTo(Type other)
        {
            // Make sure that Pointer parameters are sorted last to avoid bug [#1098].
            // The rest of the comparisons are not important, but they are there to
            // guarantee a stable order between program executions.
            int result = this.CurrentType.CompareTo(other.CurrentType);
            if (result == 0)
                result = Pointer.CompareTo(other.Pointer);
            if (result == 0)
                result = Reference.CompareTo(other.Reference);
            if (result == 0)
                result = Array.CompareTo(other.Array);
            if (result == 0)
                result = CLSCompliant.CompareTo(other.CLSCompliant);
            if (result == 0)
                result = ElementCount.CompareTo(other.ElementCount);
            return result;
        }

        #endregion
    }
}
