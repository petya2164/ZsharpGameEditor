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
using System.Xml;
using ZSGameEditor.Properties;
using ZGE.Components;
using System.Reflection;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ZGE
{
    #region XmlNodePropertyChangedEventArgs
    /// <summary>
    /// Provides a data for TreeNodeProperties.XmlNodePropertyChanged event.  
    /// </summary>
    internal class XmlNodePropertyChangedEventArgs : EventArgs
    {
        public XmlNodePropertyChangedEventArgs(bool needCommit, string statusString, string propName)
            : base()
        {
            StatusString = statusString;
            NeedCommit = needCommit;
            PropName = propName;
        }

        public bool NeedCommit { get; private set; }
        public string PropName { get; private set; }
        public string StatusString { get; private set; }
    }
    #endregion
    internal delegate void XmlNodePropertyChangedEventHandler(Object sender, XmlNodePropertyChangedEventArgs e);

    #region PropertyChangedEvent
    public enum PropertyChangeAction
    {
        AttributeChanged,
        ElementNodeRenamed,
        CodeChanged
    }

    /// <summary>
    /// Provides a data for XmlNodeProperties.PropertyChanged event.
    /// </summary>
    /// <remarks>Used to pass information to the handler which 
    /// processes changes to the underlying object.
    /// </remarks>
    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangeAction Action { get; set; }
        public string PropName { get; private set; }
        public object NewValue { get; private set; }

        public PropertyChangedEventArgs(string propName, object newValue)
            : base()
        {
            PropName = propName;
            NewValue = newValue;
        }
    }

    /// <summary>
    /// Represents the method that will handle the CustomClass.PropertyChanged event    
    /// </summary>
    public delegate void PropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e);
    #endregion


    /// <summary>
    /// Implements middle layer between an XmlNode and XmlNodeProperties classes.
    /// It provides concrete XmlProperties object as a wrapper for XmlNode to be used in Property Editor control.
    /// Handles changes made to this wrapper back into XmlNode.
    /// </summary>
    internal class ZNodeProperties
    {
        
        // Properties holder for the XmlNode        
        //private ZCustomClass properties;
        // The underlying ZComponent
        internal object component;
        internal object parent_component;
        internal IList parent_list;
        // XmlNode represented by a TreeNode
        internal XmlNode xmlNode;
        internal TreeNode treeNode;
        // Xml operation status string 
        private string statusString;
       
        /// <summary>
        /// Occurs when XmlNode have been changed.
        /// </summary>
        public event XmlNodePropertyChangedEventHandler XmlNodePropertyChanged;        

        
        /// <summary>
        /// Initializes a new instance of the TreeNodeProperties with the given XmlNode. 
        /// </summary>
        public ZNodeProperties(object comp, object parent, object parentList, XmlNode node, TreeNode treeNode)
        {
            if (node == null) return;
            

            xmlNode = node;
            component = comp;
            if (parent != comp) // a component cannot be its own parent
                parent_component = parent;
            this.parent_list = parentList as IList;
            this.treeNode = treeNode;            
        }

        internal String DisplayName
        {
            get
            {
                string displayName = xmlNode.Name;
                XmlAttribute attribute = xmlNode.Attributes["Name"];
                if (attribute != null)
                    displayName = displayName + " - " + attribute.Value;
                return displayName;                
            }
        }
        
        /// <summary>
        /// Gets the XmlProperties object that represents current XmlNode.
        /// </summary>
        internal object Component
        {
            get 
            {
                return component; 
            }
        }

        /// <summary>
        /// Gets ZTreeView.TreeViewImagesList value used to display current XmlNode.
        /// </summary>
        public ZTreeView.TreeViewImagesList NodeImageIndex
        {
            get
            {
                if (xmlNode.Equals(xmlNode.OwnerDocument.DocumentElement))
                {
                    // root node
                    return ZTreeView.TreeViewImagesList.ImageIndexGroup;
                }
                else if (IsLeafNode(this.xmlNode))
                {
                    return ZTreeView.TreeViewImagesList.ImageIndexValue;
                }
                else
                {
                    return ZTreeView.TreeViewImagesList.ImageIndexNode;
                }
            }
        }

        /// <summary>
        /// Gets the value of Color type, used to display current XmlNode
        /// </summary>
        public System.Drawing.Color NodeForeColor
        {
            get
            {
                if (xmlNode.Equals(xmlNode.OwnerDocument.DocumentElement))
                {
                    // root node
                    return System.Drawing.Color.Green;
                }
                else if (IsLeafNode(this.xmlNode))
                {
                    return System.Drawing.Color.Black;
                }
                else
                {
                    return System.Drawing.Color.Blue;
                }
            }
        }
        
        /// <summary>
        /// Moves the source node to new location as child node.
        /// </summary>
        internal static bool MoveXmlNode(XmlNode sourceNode, XmlNode targetNode)
        {
            // unbind source node from parent node
            if (sourceNode == null || targetNode == null)
            {
                return false;
            }
            if (IsLeafNode(targetNode))
            {
            	// clear target node's text
				// targetNode.InnerText = null;
            }
            // finally - move sourceNode node to new location (will become a child of targetNode)
            targetNode.AppendChild(sourceNode);
            return true;
        }
        
        /// <summary>
        /// Indicates whether passed node is a Leaf node by testing it's child nodes' type.
        /// </summary>
        /// <returns>True if the node has child nodes of type Text, false if
        /// it has child nodes of type Element.
        ///</returns>
        private static bool IsLeafNode(XmlNode node)
        {            
            // Determines whether node has child elements 
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element)
                    return false;                
            }
            return true;
        }

        /// <summary>
        /// Appends new child node to the current xmlNode
        /// the appended node has default name and empty inner text.
        /// </summary>
        public ZNodeProperties AddNewChild(string childName, TreeNode newTreeNode)
        {
            bool needCommit = false;
            statusString = String.Empty;
            ZNodeProperties props = null;

            try
            {
                //  Create new leaf node
                XmlNode newXmlNode = xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, childName, xmlNode.NamespaceURI);
                xmlNode.AppendChild(newXmlNode);
                
                ZComponent parent = component as ZComponent;
                if (parent == null) parent = parent_component as ZComponent;  // component is a List
                ZComponent comp = Factory.CreateComponent(childName, null, parent, component as IList);
                props = new ZNodeProperties(comp, parent, component as IList, newXmlNode, newTreeNode);
                comp.Tag = props;
                needCommit = true;
            }
            catch (XmlException e)
            {
                statusString = e.Message;
            }

            if (XmlNodePropertyChanged != null)
            {
                XmlNodePropertyChanged(this, new XmlNodePropertyChangedEventArgs(needCommit, statusString, "Name"));
            }
            return props;
        }

        /// <summary>
        /// Deletes current xmlNode from the XmlDocument
        /// and from the tree view control.
        /// </summary>
        public void Delete()
        {
            bool needCommit = false;
            statusString = String.Empty;

            try
            {
                XmlNode nodeToDeleteFrom = xmlNode.ParentNode;
                if (nodeToDeleteFrom != null)
                {
                    nodeToDeleteFrom.RemoveChild(xmlNode);
                }
                needCommit = true;
                statusString = "XML node removed.";
            }
            catch (XmlException e)
            {
                statusString = e.Message;
            }

            if (XmlNodePropertyChanged != null)
            {
                XmlNodePropertyChanged(this, new XmlNodePropertyChangedEventArgs(needCommit, statusString, ""));
            }
        }

        public string SaveCodeText(string propName, string newValue, Dictionary<XmlNode, string> nodeMap)
        {
            string result = null;
            bool found = false;
            XmlNode child = null;

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.Name == propName)
                {
                    child = childNode;
                    foreach (XmlCDataSection cData in childNode.ChildNodes)
                    {
                        cData.InnerText = newValue;
                        found = true;
                    }
                }
            }

            if (found == false)
            {
                if (child == null)
                {
                    // Create new child node
                    child = xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, propName, xmlNode.NamespaceURI);
                    result = Guid.NewGuid().ToString();
                    // Update the project nodemap
                    nodeMap[child] = result;
                    xmlNode.AppendChild(child);
                }
                XmlNode cdata = xmlNode.OwnerDocument.CreateNode(XmlNodeType.CDATA, newValue, xmlNode.NamespaceURI);
                child.AppendChild(cdata);
                found = true;
            }

            return result;
        }

        /// <summary>
        /// If the node is a leaf node sets inner text to the NewValue.
        /// </summary>
        /// <param name="newValue">The new inner text for the node.</param>
        /// <returns>True if the value has been changed, false otherwise.</returns>
//         private bool ChangeElementNodeText(string propName, string newValue)
//         {
//             //Console.WriteLine("ChangeElementNodeText");
//             bool found = false;
//             XmlNode child = null;
// 
//             foreach (XmlNode childNode in xmlNode.ChildNodes)
//             {
//                 if (childNode.Name == propName)
//                 {
//                     child = childNode;
//                     foreach (XmlCDataSection cData in childNode.ChildNodes)
//                     {
//                         cData.InnerText = newValue;
//                         found = true;
//                     }
//                 }
//             }
// 
//             // Need to create the childNode and the CDATA section
//             if (found == false)
//             {
//                 //Console.WriteLine("Child node missing: Code text cannot be saved to XML.");
//                 if (child == null)
//                 {
//                     //  Create new child node
//                     child = xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, propName, xmlNode.NamespaceURI);
//                     xmlNode.AppendChild(child);
//                 }
//                 XmlNode cdata = xmlNode.OwnerDocument.CreateNode(XmlNodeType.CDATA, newValue, xmlNode.NamespaceURI);
//                 child.AppendChild(cdata);
//                 found = true;
//             }        
// 
//             return found;
//         }

        /// <summary>
        /// Updates the collection of attributes for current XmlNode 
        /// with the collection taken from this.Properties.Attributes business object.
        /// This method is called when the collection changes:
        /// new attributes are added or attributes have been removed 
        /// from the collection through the Property grid.
        /// </summary>
        /*private void UpdateAttributes()
        {
            xmlNode.Attributes.RemoveAll();

            foreach (CustomProperty prop in properties)
            {
                if (prop.Name == "Type" || prop.Name == "Code") continue;
                XmlAttribute newAttribute = xmlNode.OwnerDocument.CreateAttribute(prop.Name);
                newAttribute.Value = prop.Value.ToString();
                xmlNode.Attributes.Append(newAttribute);
            }
        }*/

        private void UpdateAttribute(string propName, object newValue)
        {
            XmlAttribute attribute = xmlNode.Attributes[propName];
            string str = Factory.Serialize(newValue);
            if (attribute == null)
            {
                XmlAttribute newAttribute = xmlNode.OwnerDocument.CreateAttribute(propName);
                newAttribute.Value = str;
                xmlNode.Attributes.Append(newAttribute);
            }
            else
                attribute.Value = str;

            /*if (component != null && component is ZComponent)
            {
                PropertyInfo pi = component.GetType().GetProperty(propName, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                if (pi != null)
                    pi.SetValue(component, newValue, null);
            }*/            
        }

        /// <summary>
        /// Renames the xmlNode node
        /// </summary>
        /// <param name="newName">new name for the node</param>
        private void RenameNode(string newName)
        {
            XmlNode newXmlNode = xmlNode.OwnerDocument.CreateNode(xmlNode.NodeType, newName, xmlNode.NamespaceURI);
//             while (((XmlElement)xmlNode).HasAttributes)
//             {
//                 //((XmlElement)newXmlNode).SetAttributeNode(((XmlElement)xmlNode).RemoveAttributeNode(((XmlElement)xmlNode).Attributes[0]));
//             }
            foreach (XmlAttribute attribute in xmlNode.Attributes)
            {
                XmlAttribute newAttribute = xmlNode.OwnerDocument.CreateAttribute(attribute.Name);
                newAttribute.Value = attribute.Value;
                newXmlNode.Attributes.Append(newAttribute);               
            }

            while (xmlNode.HasChildNodes)
            {
                newXmlNode.AppendChild(xmlNode.FirstChild);
            }

            xmlNode.ParentNode.ReplaceChild(newXmlNode, xmlNode);
            xmlNode = newXmlNode;
        }

       
        /// <summary>
        /// Initializes the properties data with XmlNode's data. 
        /// Fills in all necessary fields and collections, adds necessary event handlers.
        /// </summary>
        //internal void ConstructProperties()
        //{
            // properties have already been constructed
            /*if (properties != null)
            {
                //UpdateProperties();
                return;
            }

            properties = new ZCustomClass();

            if (component != null)
            {
                properties.Add(new CustomProperty("Type", component.GetType().Name, typeof(string), true, true));
                if (component is ZComponent)
                foreach (PropertyInfo pi in component.GetType().GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance))
                {
                    if (pi.GetCustomAttributes(typeof(BrowsableAttribute), true).Length == 0)
                        properties.Add(new CustomProperty(pi.Name, pi.GetValue(component,null), pi.PropertyType, false, true));
                }
                properties.OnPropertyChanged += new PropertyChangedEventHandler(this.PropertyHolderChanged);
            }*/            

            /*properties.Add(new CustomProperty("Type", xmlNode.Name, typeof(string), true, true));
            properties.OnPropertyChanged += new PropertyChangedEventHandler(this.PropertyHolderChanged);

            if (IsLeafNode(xmlNode) && xmlNode.InnerText != "")
            {
                properties.Add(new CustomProperty("Code", xmlNode.InnerText, typeof(string), false, true));                
            }
            
            // Add attributes to the properties
            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    properties.Add(new CustomProperty(attribute.Name, attribute.Value, typeof(string), false, true));                    
                }
            }*/
        //}

        /// <summary>
        /// Updates the properties of the node (if child nodes have been added or deleted).
        /// </summary>
        /*private void UpdateProperties()
        {
            XmlNodeProperties newProperties = null;
            bool isLeafNode = IsLeafNode(xmlNode);

            // Create new properties if necessary
            if (isLeafNode && properties.GetType() != typeof(XmlLeafNodeProperties))
            {
                newProperties = new XmlLeafNodeProperties(properties);
            }
            else if (!isLeafNode && properties.GetType() == typeof(XmlLeafNodeProperties))
            {
                newProperties = new XmlNodeProperties(properties);
            }

            // Update properties
            if (newProperties != null)
            {
                properties = newProperties;
            }
        }*/
       

        
        /// <summary>
        /// Event handler - invoked if one of the properties is changed from
        /// the property grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">holds action that caused event to fire and 
        /// information necessary to update xml document</param>
        internal void PropertyHolderChanged(Object sender, PropertyChangedEventArgs e)
        {
            bool needCommit = true;
            statusString = "Property changed.";

            switch (e.Action)
            {
                //case PropertyChangeAction.ElementNodeRenamed:
                //    RenameNode(e.NewValue);
                //    break;
                case PropertyChangeAction.CodeChanged:
                    //needCommit = ChangeElementNodeText(e.PropName, e.NewValue.ToString());
                    break;
                case PropertyChangeAction.AttributeChanged:
                    UpdateAttribute(e.PropName, e.NewValue);
                    break;
                default:
                    needCommit = false;
                    break;
            }

            if (XmlNodePropertyChanged != null)
            {
                XmlNodePropertyChanged(this, new XmlNodePropertyChangedEventArgs(needCommit, statusString, e.PropName));
            }
        }
    }
}
