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
    /// Provides a data for TreeNodeProperties.XmlNodePropertyChanged event.  
    /// </summary>
    internal class XmlNodePropertyChangedEventArgs : EventArgs
    {
        #region Fields
        //Sets the status flag of the Xml document update request
        private bool needCommit;
        //The status message of last Xml operations
        private string statusString;
        #endregion // Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the XmlNodePropertyChangedEventArgs class. 
        /// </summary>
        protected XmlNodePropertyChangedEventArgs()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the XmlNodePropertyChangedEventArgs class 
        /// with the specified need commit and status string.
        /// </summary>
        /// <param name="needCommit">Indicates that the changes should be reflected to tree view.</param>
        /// <param name="statusString">The status message of last Xml operation.</param>
        public XmlNodePropertyChangedEventArgs(bool needCommit, string statusString)
            : base()
        {
            this.statusString = statusString;
            this.needCommit = needCommit;
        }
        #endregion // Constructors

        #region Properties
        /// <summary>
        /// Gets the status flag indicating that XmlDocument have changed and 
        /// the clients should reflect this change.
        /// </summary>
        public bool NeedCommit
        {
            get { return needCommit; }
        }

        /// <summary>
        /// The status message of last Xml operation.
        /// </summary>
        public string StatusString
        {
            get { return statusString; }
        }

        #endregion // Properties
    }
}