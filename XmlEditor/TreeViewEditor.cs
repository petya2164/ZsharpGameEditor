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
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using ZSGameEditor.Properties;
using System.Drawing.Design;

namespace Microsoft.Samples.VisualStudio.SynchronousXmlDesigner.TreeXmlEditor
{
    /// <summary>
    /// Represents XmlDocument in a TreeView.
    /// </summary>
    public partial class TreeViewEditor : TreeView
    {
        /// <summary>
        /// Enumeration that used for ImageIndex property of TreeNodes.
        /// </summary>
        internal enum TreeViewImagesList
        {
            ImageIndexNode,
            ImageIndexAttribute,
            ImageIndexValue,
            ImageIndexGroup,
            ImageIndexError
        };

        #region Fields
        // Source document
        private XmlDocument xmlDocument = new XmlDocument();
        // Status string
        private string statusString;

        #region Node label edit and validation
        // Set to false if user clicked on the item in order to select it, 
        // is used to skip the editing of the tree node label, 
        // set to true if user clicked on the currently selected item in order to initiate
        // the editing of the tree node label
        private bool suppressLabelEdit;
        // Store the last selected tree node item
        private TreeNode mouseDownNode;
        #endregion

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TreeViewEditor class.
        /// </summary>
        public TreeViewEditor()
        {
            InitializeComponent();
            this.xmlDocument.PreserveWhitespace = true;
            this.ImageList = CreateImageList();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Status string of the control.
        /// </summary>
        public string StatusString
        {
            get
            {
                return statusString; 
            }
            set 
            {
                if (value != statusString)
                {
                    statusString = value;
                    if (StatusStringChanged != null)
                    {
                        StatusStringChanged(this, new EventArgs());
                    }
                }
            }
        }

        /// <summary>
        /// Returns current XML string representation of the tree.
        /// </summary>
        public string Content
        {
            get
            {
                if (xmlDocument.DocumentElement != null)
                {
                    return xmlDocument.InnerXml;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Provides array list of XmlProperties for selected node.
        /// </summary>
        /// <returns></returns>
        public ArrayList PropertiesForSelectedNode
        {
            get
            {
                ArrayList listObjects = new ArrayList();

                TreeNode node = SelectedNode;

                TreeNodeProperties treeNodeProperties = node.Tag as TreeNodeProperties;
                if (treeNodeProperties != null)
                {
                    var props = treeNodeProperties.Properties;
                    if (props != null)
                    {
                        listObjects.Add(props);
                    }
                }
                return listObjects;
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Fires when the status string changes.
        /// </summary>
        public event EventHandler StatusStringChanged;
        /// <summary>
        /// Fires when the content is updated by control.
        /// </summary>
        public event EventHandler ContentChanged;
        /// <summary>
        /// Fires when properties set for selected node is changed.
        /// </summary>
        public event EventHandler PropertiesSetChanged;
        /// <summary>
        /// Fires when properties window is called from context menu.
        /// </summary>
        public event EventHandler PropertiesWindowActivated;
        #endregion

        
        /// <summary>
        /// Create Image List for TreeView items.
        /// </summary>
        /// <returns></returns>
        private static ImageList CreateImageList()
        {
            ImageList imgList = new ImageList();
            imgList.Images.Add(Resources.xmlnode);
            imgList.Images.Add(Resources.xmlatt);
            imgList.Images.Add(Resources.xmlval);
            imgList.Images.Add(Resources.xmlgrp);
            imgList.Images.Add(Resources.xmlerr);
            return imgList;
        }

       
        /// <summary>
        /// Process calculation of suppress_label_edit private field.
        /// If mouse down occurred on Selected node - we allow label edit mode
        /// by assigning suppress_label_edit = false.
        /// </summary>
        private void TreeViewEditor_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownNode = this.GetNodeAt(e.X, e.Y);

            if (mouseDownNode == null)
            {
                return;
            }

            // If the node is already selected, prepare to start editing its label
            if (this.SelectedNode != null && this.SelectedNode == mouseDownNode && this.SelectedNode.Tag is TreeNodeProperties)
            {
                // Reset LabelEdit property
                this.LabelEdit = true;
                suppressLabelEdit = false;
            }
            else
            {
                suppressLabelEdit = true;
            }
        }

        /// <summary>
        /// Cancels Label editing if suppress_label_edit private field is true.
        /// </summary>
        private void TreeViewEditor_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = suppressLabelEdit;
        }

        /// <summary>
        /// Performs validation of LableEdit.
        /// If New Label is valid, process rename corresponding XmlNode.
        /// </summary>
        private void TreeViewEditor_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // Return if editing was cancelled
            if (e.CancelEdit == true)
            {
                return;
            }

            // If the name hasn't changed, or is empty, don't restore the original name
            if (e.Label == null || e.Label == this.SelectedNode.Text)
            {
                e.CancelEdit = true;
                return;
            }

            if (e.Label.Length > 0)
            {
                // Validate proposed label change
                try
                {
                    // Check the name conformance to the w3c rules
                    XmlConvert.VerifyName(e.Label);
                    RenameNode(e.Node, e.Label);
                }
                catch (XmlException xmlException)
                {
                    // Cancel the label edit action, inform the user, and 
                    // place the node in edit mode again.
                    e.CancelEdit = true;

                    // process MessageBoxOptions
                    Control parent = this;

                    while (parent != null && parent.RightToLeft == RightToLeft.Inherit) 
                    {
                        parent = parent.Parent;
                    }

                    MessageBoxOptions options = parent.RightToLeft == RightToLeft.Yes ?
                        MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign :
                        (MessageBoxOptions) 0;

                    MessageBox.Show(Resources.InvalidNodeName + "\n" + xmlException.Message, Resources.MessageBoxCaptionLabelEditError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1, options);
                    e.Node.BeginEdit();
                }
            }
            else
            {
                // Cancel the label edit action, inform the user, and 
                // place the node in edit mode again.
                e.CancelEdit = true;

                // specify MessageBoxOptions 
                Control parent = this;
                while (parent != null && parent.RightToLeft == RightToLeft.Inherit)
                {
                    parent = parent.Parent;
                }
                MessageBoxOptions options = (MessageBoxOptions)0;
                if (parent != null)
                {
                    options = parent.RightToLeft == RightToLeft.Yes ?
                            (MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign): 
                            options;
                }

                MessageBox.Show(Resources.InvalidNodeName + "\n" + Resources.InvalidNodeNameEmpty, Resources.MessageBoxCaptionLabelEditError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, options);
                e.Node.BeginEdit();
            }
        }

        /// <summary>
        /// Begins Label edit on "F2" KeyUp event of the TreeViewEditor.
        /// </summary>
        private void TreeViewEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (this.SelectedNode != null && !this.SelectedNode.IsEditing && this.SelectedNode.Tag is TreeNodeProperties)
                {
                    suppressLabelEdit = false;
                    this.SelectedNode.BeginEdit();
                }
            }
        }

        private void TreeViewEditor_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy );
            }
        }

        private void TreeViewEditor_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // assign drag effect
            e.Effect = e.AllowedEffect;
        }

        /// <summary>
        /// Process the DragOver node in order to determine whether drop action as appropriate
        /// </summary>
        private void TreeViewEditor_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeView senderTreeView = sender as TreeView;
            if (senderTreeView == null)
            {
                return;
            }

            if (e.Data.GetDataPresent("System.Drawing.Design.ToolboxItem", false))
            {
                // Determine source and destination nodes
                Point pt = senderTreeView.PointToClient(new Point(e.X, e.Y));
                //TreeNode sourceTreeNode = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
                TreeNode destinationTreeNode = senderTreeView.GetNodeAt(pt);

                // Drop is available - highlight destination node
                this.SelectedNode = destinationTreeNode;
                if (this.SelectedNode != null)
                {
                    this.SelectedNode.Expand();
                }
                e.Effect = DragDropEffects.Copy;
                return;
            }

            // Fired continuously while a tree node is dragged. We need to override this to 
            // provide appropriate feedback
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                // Determine source and destination nodes
                Point pt = senderTreeView.PointToClient(new Point(e.X, e.Y));
				TreeNode sourceTreeNode = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
				TreeNode destinationTreeNode = senderTreeView.GetNodeAt(pt);

				// Deny drag and drop when
				//  destinationNode is the same as source 
				//  destination node is a parent of a source node
				//  destination and source node belong to the different TreeViews
                if (sourceTreeNode == null || destinationTreeNode == null 
                    || sourceTreeNode == destinationTreeNode
                    || (sourceTreeNode.Parent != null && sourceTreeNode.Parent == destinationTreeNode)
                	|| sourceTreeNode.TreeView != destinationTreeNode.TreeView)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                // if destination node lies in a subtree of source node - restrict drop action to avoid circles
                TreeNode checkParentNode = destinationTreeNode.Parent;
                while (checkParentNode != null)
                {
                    if (checkParentNode == sourceTreeNode)
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                    checkParentNode = checkParentNode.Parent;
                }

                // Drop is available - highlight destination node
                this.SelectedNode = destinationTreeNode;
            	if (this.SelectedNode!= null )
            	{
            		this.SelectedNode.Expand();
            	}

                // determine a type of drug and drop action (move or copy)
                if ((e.KeyState & 8) == 8)
                {
                    // CTL Keystate for copy
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        /// <summary>
        /// Simple DragNDrop - move the node to new location
        /// </summary>
        private void TreeViewEditor_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            StatusString = "DragDrop started";
            TreeView senderTreeView = sender as TreeView;
        	if (senderTreeView == null)
        	{
                StatusString = "sender is not treeview";
        		return;
        	}

            Point pt = senderTreeView.PointToClient(new Point(e.X, e.Y));
            TreeNode destinationTreeNode = senderTreeView.GetNodeAt(pt);

            if ( ! e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
        	{
                StatusString = "Data is not TreeNode";
                if (e.Data.GetDataPresent("System.Drawing.Design.ToolboxItem"))
                {
                    StatusString = "Data is ToolboxItem";
                    ToolboxItem source = e.Data.GetData("System.Drawing.Design.ToolboxItem") as ToolboxItem;                   

                    if (source == null || destinationTreeNode == null)
                    {
                        StatusString = "Missing source or dest";
                        return;
                    }
                    AddChildNode(destinationTreeNode, source.DisplayName);
                }
                return;
        	}        	
        	
        	TreeNode sourceTreeNode = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;

        	// Deny drag and drop when
        	//  destinationNode is the same as source 
        	//  destination node is a parent of a source node
        	//  destination and source node belong to the different TreeViews
        	if (sourceTreeNode == null || destinationTreeNode == null
        	    || sourceTreeNode == destinationTreeNode
        	    || (sourceTreeNode.Parent != null && sourceTreeNode.Parent == destinationTreeNode)
        	    || sourceTreeNode.TreeView != destinationTreeNode.TreeView)
        	{
        		return;
        	}

        	// perform XML operation: prepare properties objects
        	TreeNodeProperties sourceNodeProperties = sourceTreeNode.Tag as TreeNodeProperties;
        	TreeNodeProperties destinationNodePropeties = destinationTreeNode.Tag as TreeNodeProperties;

        	if (sourceNodeProperties != null && destinationNodePropeties!= null)
        	{
        		// Perform Xml operation
        		XmlNode newXmlNode = null;

        		if (e.Effect == DragDropEffects.Copy)
        		{
        			newXmlNode = sourceNodeProperties.xmlNode != null ? sourceNodeProperties.xmlNode.Clone() : null;
        		}
        		else if (e.Effect == DragDropEffects.Move)
        		{
        			newXmlNode = sourceNodeProperties.xmlNode;
        		}

        		if (TreeNodeProperties.MoveXmlNode(newXmlNode, destinationNodePropeties.xmlNode))
        		{
        			// update TreeView according to changes in XmlDocument
        			PopulateTreeNode(destinationTreeNode);
                    	
        			if (e.Effect == DragDropEffects.Move)
        			{
        				TreeNode oldParentNode = sourceTreeNode.Parent;
        				sourceTreeNode.Remove();
        				HighlightTreeNode(oldParentNode, oldParentNode.Tag as TreeNodeProperties);
        			}
        			OnPropertiesChanged();
        			OnContentChanged();
        		}
        	}
        }
        

        /// <summary>
        /// Loads XML from string.
        /// </summary>
        /// <param name="value">string to load XML from.</param>
        public void LoadXml(string value)
        {
            // Check xml string is not null
            if (value == null)
            {
                return;
            }

            try
            {
                this.Nodes.Clear();
                xmlDocument.LoadXml(value);
                XmlNode rootElement = xmlDocument.DocumentElement;
                if (rootElement != null)
                { 
                    TreeNode rootNode = new TreeNode(rootElement.Name);
                    this.Nodes.Add(rootNode);
                    PopulateTreeNode(rootNode, rootElement);
                }
                ExpandAll();
                StatusString = String.Empty;
            }
            catch (XmlException exception)
            {
                this.Nodes.Clear(); 
                StatusString = exception.Message;
                throw (exception);
            }
            finally
            {
                Invalidate();
            }
        }
        
        /// <summary>
        /// Populates TreeNode based on stored TreeNodeProperties object.
        /// Calls overloaded version of the function.
        /// </summary>
        /// <param name="treeNode">TreeNode to be populated</param>
        private void PopulateTreeNode(TreeNode treeNode)
        {
            if (treeNode != null && treeNode.Tag is TreeNodeProperties)
            {
                PopulateTreeNode(treeNode, ((TreeNodeProperties)treeNode.Tag).xmlNode);
            }
        }

        /// <summary>
        /// Initialises given TreeNode with XmlNode properties,
        /// builds subtree recursively,
        /// set's TreeNode's fore color and icon.
        /// </summary>
        /// <param name="treeNode">The TreeNode to be populated.</param>
        /// <param name="xmlNode">The XmlNode that will be bounded to the TreeNode.</param>
        private void PopulateTreeNode(TreeNode treeNode, XmlNode xmlNode)
        {
            if (treeNode == null || xmlNode == null)
            {
                return;
            }

            // clear subtree
            treeNode.Nodes.Clear();
            // recursively build SubTree
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element)
                {
                    string displayName = childNode.Name;
                    foreach (XmlAttribute attribute in childNode.Attributes)
                    {
                        if (attribute.Name == "Name") displayName = displayName + " - " + attribute.Value;
                    }
                    TreeNode newTreeNode = new TreeNode(displayName);
                    treeNode.Nodes.Add(newTreeNode);
                    PopulateTreeNode(newTreeNode, childNode);
                }
            }
            // construct TreeNodeProperties object for the TreeNode and assign it to Tag property
            TreeNodeProperties props = new TreeNodeProperties(xmlNode);
            treeNode.Tag = props;
            HighlightTreeNode(treeNode, props);
            props.XmlNodePropertyChanged += new XmlNodePropertyChangedEventHandler(this.XmlPropertiesUpdatedHandler);
        }

    	
    	
        /// <summary>
        /// This method creates new tree node and appends 
        /// new xml node to the underlying xml document.
        /// </summary>
        /// <param name="parentNode">Parent Tree node to add a child to.</param>
        private void AddChildNode(TreeNode parentNode, String childName)
        {
            StatusString = "Adding child node...";
            TreeNodeProperties parentNodeProperties = parentNode.Tag as TreeNodeProperties;
            TreeNode newTreeNode = new TreeNode(childName);
            TreeNodeProperties newNodeProperties = null;

            if (parentNodeProperties != null)
            {
                newNodeProperties = parentNodeProperties.AddNewChild(childName);
                
                if (newNodeProperties != null)
                {
                    newTreeNode.Tag = newNodeProperties;
                    newNodeProperties.XmlNodePropertyChanged += new XmlNodePropertyChangedEventHandler(this.XmlPropertiesUpdatedHandler);
                    parentNode.Nodes.Add(newTreeNode);

                    // Update parent node properties and type
                    parentNodeProperties.ConstructProperties();

                    HighlightTreeNode(parentNode, parentNodeProperties);
                    HighlightTreeNode(newTreeNode, newNodeProperties);

                    parentNode.Expand();
                    this.SelectedNode = newTreeNode;

                    // Tree node properties have been updated
                    // Force parent to reload them to the PropertyBrowser
                    OnPropertiesChanged();
                }
            }
            StatusString = "Child node added";
            Invalidate();
            
        }

        /// <summary>
        /// FineTune displaying TreeNode with ImageList and ForeColor properties
        /// based on XmlNode's NodeType and Children Nodes Type/Count.
        /// </summary>
        private static void HighlightTreeNode(TreeNode treeNode, TreeNodeProperties treeNodeProperties)
        {
            if (treeNode != null && treeNodeProperties != null)
            {
                treeNode.ForeColor = treeNodeProperties.NodeForeColor;
                treeNode.ImageIndex = treeNode.SelectedImageIndex = (int)treeNodeProperties.NodeImageIndex;
            }
        }



        
        /// <summary>
        /// Handles the XmlNodePropertyChanged event of selected TreeNode (with underlying XmlNode).
        /// Commits changes to the TreeView. 
        /// Raises the ContentChanged event so to notifies the subscribers that
        /// document content have been changed.
        /// </summary>
        /// <param name="sender">TreeNodeProperties structure which has been modified.</param>
        /// <param name="e">event argument (not used).</param>
        private void XmlPropertiesUpdatedHandler(object sender, XmlNodePropertyChangedEventArgs e)
        {
            if (e.NeedCommit)
            {
                // Modifications through properties are only available for selected node
                TreeNode treeNode = SelectedNode;
                TreeNodeProperties properties = (TreeNodeProperties)sender;

                if (properties.DisplayName.CompareTo(treeNode.Text) != 0)
                {
                    // Rename tree node
                    treeNode.Text = properties.DisplayName;
                    Invalidate();
                }

                OnContentChanged();
            }

            StatusString = e.StatusString;
        }

        /// <summary>
        /// Event handler - expose properties of the selected node to the
        /// property grid
        /// </summary>
        private void TreeViewEditor_AfterSelectNode(object sender, TreeViewEventArgs e)
        {
            OnPropertiesChanged();
        }

        /// <summary>
        /// Updates Event handler.
        /// </summary>
        private void TreeViewEditor_Leave(object sender, EventArgs e)
        {
            OnPropertiesChanged();
        }

        /// <summary>
        /// Shows the ContextMenu for SelectedNode
        /// </summary>
        private void TreeViewEditor_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeViewEditor tree = sender as TreeViewEditor;

            if (e.Button == MouseButtons.Right)
            {
                TreeNode clickedNode = tree.GetNodeAt(e.Location);
                deleteElementToolStripMenuItem.Visible = true;

                // if node contain reference to TreeNodeProperties object, than we can start context menu
                if (clickedNode != null && clickedNode.Tag is TreeNodeProperties)
                {
                    tree.SelectedNode = clickedNode;

                    if (clickedNode.Level == 0)
                    {
                        deleteElementToolStripMenuItem.Visible = false;
                    }
                    xmlContextMenu.Show(this, e.Location.X, e.Location.Y);
                }
            }
        }

        /// <summary>
        /// Event handler - add child node to the selected node
        /// </summary>
        private void AddChildElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode parentNode = SelectedNode;
            AddChildNode(parentNode, Resources.DefaultChildName);
        }

        /// <summary>
        /// Event handler - deletes the selected node
        /// </summary>
        private void deleteElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNodeToDelete = SelectedNode;
            TreeNode parentNode = treeNodeToDelete.Parent;

            TreeNodeProperties properties = treeNodeToDelete.Tag as TreeNodeProperties;

            if (properties != null)
            {
                properties.Delete();
                treeNodeToDelete.Remove();


                // Update parent node properties and type
                if (parentNode.Nodes.Count == 0)
                {
                    TreeNodeProperties parentProperties = (TreeNodeProperties)parentNode.Tag;
                    parentProperties.ConstructProperties();

                    HighlightTreeNode(parentNode, parentProperties);
                }
                SelectedNode = parentNode;

                // Tree node properties have been updated
                // Force parent to reload them to the PropertyBrowser
                OnPropertiesChanged();
            }
            Invalidate();
        }

        /// <summary>
        /// Event handler - add sibling node to the selected node
        /// </summary>
        private void showPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnPropertiesWindowActivated();
        }

        private void OnPropertiesWindowActivated()
        {
            // Fire properties set changed event
            if (PropertiesWindowActivated != null)
            {
                PropertiesWindowActivated(this, new EventArgs());
            }
        }

        private void RenameNode(TreeNode treeNode, string newName)
        {
            TreeNodeProperties properties = treeNode.Tag as TreeNodeProperties;

            if (properties != null)
            {
                properties.Properties.SetValue("Type", newName);
                SelectedNode = treeNode;

                // Tree node properties have been updated
                // Force parent to reload them to the PropertyBrowser
                OnPropertiesChanged();
            }
        }
         
        /// <summary>
        /// This method is called when it is neccessary to notify
        /// parent that property grid should be updated by
        /// properties of the selected item.
        /// </summary>
        private void OnPropertiesChanged ()
        {
            // Fire properties set changed event
            if (PropertiesSetChanged != null)
            {
                PropertiesSetChanged(this, new EventArgs());
            }
        }
        
        private void OnContentChanged()
        {
            // Fire content changed event 
            // to ensure all subscribers receive the changes
            if (ContentChanged != null)
            {
                ContentChanged(this, new EventArgs());
            }
        }       
        

        private void xmlContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        
    }
}
