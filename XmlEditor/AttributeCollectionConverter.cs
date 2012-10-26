//***************************************************************************
//
//    Copyright (c) Microsoft Corporation. All rights reserved.
//    This code is licensed under the Visual Studio SDK license terms.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//***************************************************************************

using System;
using System.ComponentModel;
using System.Globalization;
using ZSGameEditor.Properties;

namespace Microsoft.Samples.VisualStudio.SynchronousXmlDesigner.TreeXmlEditor
{
    /// <summary>
    /// Provides text representation for Array type.
    /// </summary>
    /// <remarks>Used to replace Actual Array type with user friendly string.</remarks>
    internal class AttributeCollectionConverter : TypeConverter
    {
        /// <summary>
        /// Provides text representation for Array type.
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context,
                                        CultureInfo culture,
                                        object value, 
                                        Type destType)
        {
            if (destType == typeof(string) && value is Array)
            {
                return Resources.XmlAttributesTypeString;
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
