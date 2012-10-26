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

namespace Microsoft.Samples.VisualStudio.SynchronousXmlDesigner.TreeXmlEditor
{
    /// <summary>
    /// Represents the method that will handle the TreeNodeProperties.XmlNodePropertyChanged of a TreeNodeProperties.  
    /// </summary>
    internal delegate void XmlNodePropertyChangedEventHandler(Object sender, XmlNodePropertyChangedEventArgs e);
}
