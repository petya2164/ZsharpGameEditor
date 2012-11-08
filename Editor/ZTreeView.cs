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

namespace ZGE
{
    /// <summary>
    /// Represents XmlDocument in a TreeView.
    /// </summary>
    public partial class ZTreeView : TreeView
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


        // Source document
        internal XmlDocument xmlDocument = new XmlDocument();
        // Status string
        private string statusString;

        // Set to false if user clicked on the item in order to select it, 
        // is used to skip the editing of the tree node label, 
        // set to true if user clicked on the currently selected item in order to initiate
        // the editing of the tree node label
        //private bool suppressLabelEdit;

        // Store the last selected tree node item
        //private TreeNode mouseDownNode;
        private TreeNode prevDropNode = null;
        public enum DropSide { Top, Inside, Bottom };
        private DropSide prevDropSide = DropSide.Top;

        internal Project project;
        internal void SetProject(Project project)
        {
            this.project = project;
        }


        /// <summary>
        /// Initializes a new instance of the TreeViewEditor class.
        /// </summary>
        public ZTreeView()
        {
            InitializeComponent();
            //this.xmlDocument.PreserveWhitespace = true;
            this.ImageList = CreateImageList();
        }

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


        /*internal ZNodeProperties ZNodePropertiesForSelectedNode
        {
            get
            {
                TreeNode node = SelectedNode;
                ZNodeProperties nodeProperties = node.Tag as ZNodeProperties;
                if (nodeProperties != null)
                {
                    return nodeProperties;
                }
                return null;
            }
        }*/

        /// <summary>
        /// Provides array list of XmlProperties for selected node.
        /// </summary>
        /// <returns></returns>
        public object SelectedComponent
        {
            get
            {
                TreeNode node = SelectedNode;
                if (node == null || node.Tag == null) return null;
                ZNodeProperties nodeProperties = node.Tag as ZNodeProperties;
                if (nodeProperties != null)
                    return nodeProperties.Component;

                return null;
            }
        }


        #region Events
        /// <summary>
        /// Fires when the status string changes.
        /// </summary>
        public event EventHandler StatusStringChanged;
        /// <summary>
        /// Fires when properties set for selected node is changed.
        /// </summary>
        public event EventHandler SelectedNodeChanged;
        /// <summary>
        /// Fires when properties window is called from context menu.
        /// </summary>
        //public event EventHandler PropertiesWindowActivated;
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
        /// Begins Label edit on "F2" KeyUp event of the TreeViewEditor.
        /// </summary>
        private void TreeViewEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (project == null) return;
            if (e.KeyCode == Keys.Delete && e.Shift)
            {
                if (SelectedNode != null && project.CanBeDeleted(SelectedNode))
                    project.DeleteElement_Click(this, new EventArgs());
            }

            //             if (e.KeyCode == Keys.F2)
            //             {
            //                 if (this.SelectedNode != null && !this.SelectedNode.IsEditing && this.SelectedNode.Tag is ZNodeProperties)
            //                 {
            //                     suppressLabelEdit = false;
            //                     this.SelectedNode.BeginEdit();
            //                 }
            //             }
        }

        private void TreeViewEditor_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            if (project == null) return;
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                TreeNode node = e.Item as TreeNode;
                if (node != null)
                {
                    // If a node can be deleted, then it can be dragged as well
                    if (project != null && project.CanBeDeleted(node))
                    {
                        prevDropNode = null;
                        //this.SelectedNode = node;
                        //OnSelectedNodeChanged();
                        DoDragDrop(e.Item, DragDropEffects.Move);
                    }
                }
            }
        }

        private void TreeViewEditor_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // assign drag effect
            e.Effect = e.AllowedEffect;
        }

        private bool IsDragAllowed(TreeNode dragNode, TreeNode dropNode, DropSide dropSide)
        {
            // Deny drag and drop when
            //  destinationNode is the same as source 
            //  destination node is a parent of a source node
            //  destination and source node belong to the different TreeViews
            if (dragNode == null || dropNode == null || dragNode == dropNode
                || (dragNode.Parent != null && dragNode.Parent == dropNode)
                || dragNode.TreeView != dropNode.TreeView)
            {
                return false;
            }
            if (project != null && project.IsDragAllowed(dragNode, dropNode, dropSide == DropSide.Inside))
                return true;
            return false;
        }

        /// <summary>
        /// Process the DragOver node in order to determine whether drop action as appropriate
        /// </summary>
        private void TreeViewEditor_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.None; // By default, drag and drop is denied
            if (project == null) return;

            TreeView senderTreeView = sender as TreeView;
            if (senderTreeView != this) return;

            // Determine source and destination nodes
            Point pt = PointToClient(new Point(e.X, e.Y));
            TreeNode dropNode = GetNodeAt(pt);
            if (dropNode == null) return;

            if (e.Data.GetDataPresent("System.Drawing.Design.ToolboxItem", false))
            {
                ToolboxItem source = e.Data.GetData("System.Drawing.Design.ToolboxItem") as ToolboxItem;

                if (source != null && dropNode != null)
                {
                    // Drop is available - highlight destination node
                    this.SelectedNode = dropNode;
                    if (project.IsChildElementAllowed(dropNode, source.TypeName))
                    {
                        if (this.SelectedNode != null)
                            this.SelectedNode.Expand();
                        e.Effect = DragDropEffects.Copy;
                    }
                }
                //e.Effect = DragDropEffects.None;

            }
            // Fired continuously while a tree node is dragged. We need to override this to 
            // provide appropriate feedback
            else if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode dragNode = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
                if (dragNode == null) return;
                int OffsetY = pt.Y - dropNode.Bounds.Top;
                bool isList = project.IsList(dropNode);
                bool isGroup = project.IsGroup(dropNode);                

                if (isList) // Adding a child is the only option for a list
                {
                    if (IsDragAllowed(dragNode, dropNode, DropSide.Inside))
                    {
                        e.Effect = DragDropEffects.Move;
                        if (dropNode != prevDropNode || prevDropSide != DropSide.Inside)
                        {
                            prevDropNode = dropNode;
                            prevDropSide = DropSide.Inside;
                            DrawAddToFolderPlaceholder(dropNode);
                        }
                    }
                }
                else if (isGroup) // There are 3 options for a Group
                {
                    if (OffsetY < (dropNode.Bounds.Height / 3)) // top third
                    {
                        if (IsDragAllowed(dragNode, dropNode, DropSide.Top))
                        {
                            e.Effect = DragDropEffects.Move;
                            if (prevDropNode != dropNode || prevDropSide != DropSide.Top)
                            {
                                prevDropNode = dropNode;
                                prevDropSide = DropSide.Top;
                                DrawLeafTopPlaceholders(dropNode);
                            }
                        }
                    }
                    // It is not allowed to drag a node just below an expanded Group node
                    else if (OffsetY > (2 * dropNode.Bounds.Height / 3) && dropNode.IsExpanded == false) // bottom third
                    {
                        if (IsDragAllowed(dragNode, dropNode, DropSide.Bottom))
                        {
                            e.Effect = DragDropEffects.Move;
                            if (prevDropNode != dropNode || prevDropSide != DropSide.Bottom)
                            {
                                prevDropNode = dropNode;
                                prevDropSide = DropSide.Bottom;
                                DrawLeafBottomPlaceholders(dropNode);
                            }
                        }
                    }
                    else // middle => Add dragComp as a child
                    {
                        if (IsDragAllowed(dragNode, dropNode, DropSide.Inside))
                        {
                            e.Effect = DragDropEffects.Move;
                            if (dropNode != prevDropNode || prevDropSide != DropSide.Inside)
                            {
                                prevDropNode = dropNode;
                                prevDropSide = DropSide.Inside;
                                DrawAddToFolderPlaceholder(dropNode);
                            }
                        }
                    }
                }
                else // 2 options for an ordinary component: Top or Bottom
                {
                    if (IsDragAllowed(dragNode, dropNode, DropSide.Top))
                    {
                        e.Effect = DragDropEffects.Move;
                        if (OffsetY < (dropNode.Bounds.Height / 2)) // top half
                        {
                            if (prevDropNode != dropNode || prevDropSide != DropSide.Top)
                            {
                                prevDropNode = dropNode;
                                prevDropSide = DropSide.Top;
                                DrawLeafTopPlaceholders(dropNode);
                            }
                        }
                        else  // bottom half
                        {
                            if (prevDropNode != dropNode || prevDropSide != DropSide.Bottom)
                            {
                                prevDropNode = dropNode;
                                prevDropSide = DropSide.Bottom;
                                DrawLeafBottomPlaceholders(dropNode);
                            }
                        }
                    }
                }

                if (e.Effect == DragDropEffects.None)
                {
                    // Need to clear the drop markers, but only once to avoid flickering!
                    if (prevDropNode != null)
                    {
                        prevDropNode = null;
                        Refresh();
                    }
                }


                // Determine source and destination nodes
                //                 Point pt = senderTreeView.PointToClient(new Point(e.X, e.Y));
                //                 TreeNode sourceTreeNode = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
                //                 TreeNode destinationTreeNode = senderTreeView.GetNodeAt(pt);
                // 
                //                 // Deny drag and drop when
                //                 //  destinationNode is the same as source 
                //                 //  destination node is a parent of a source node
                //                 //  destination and source node belong to the different TreeViews
                //                 if (sourceTreeNode == null || destinationTreeNode == null
                //                     || sourceTreeNode == destinationTreeNode
                //                     || (sourceTreeNode.Parent != null && sourceTreeNode.Parent == destinationTreeNode)
                //                     || sourceTreeNode.TreeView != destinationTreeNode.TreeView)
                //                 {
                //                     e.Effect = DragDropEffects.None;
                //                     return;
                //                 }
                // 
                //                 // if destination node lies in a subtree of source node - restrict drop action to avoid circles
                //                 TreeNode checkParentNode = destinationTreeNode.Parent;
                //                 while (checkParentNode != null)
                //                 {
                //                     if (checkParentNode == sourceTreeNode)
                //                     {
                //                         e.Effect = DragDropEffects.None;
                //                         return;
                //                     }
                //                     checkParentNode = checkParentNode.Parent;
                //                 }
                // 
                //                 // Drop is available - highlight destination node
                //                 this.SelectedNode = destinationTreeNode;
                //                 if (this.SelectedNode != null)
                //                 {
                //                     this.SelectedNode.Expand();
                //                 }
                // 
                //                 // determine a type of drug and drop action (move or copy)
                //                 if ((e.KeyState & 8) == 8)
                //                 {
                //                     // CTRL Keystate for copy
                //                     e.Effect = DragDropEffects.Copy;
                //                 }
                //                 else
                //                 {
                //                     e.Effect = DragDropEffects.Move;
                //                 }
            }
            //scrolling code
            int delta = Height - pt.Y;
            if ((delta < Height / 2) && (delta > 0))
            {
                TreeNode tn = GetNodeAt(pt);
                if (tn.NextVisibleNode != null)
                    tn.NextVisibleNode.EnsureVisible();
            }
            if ((delta > Height / 2) && (delta < Height))
            {
                TreeNode tn = GetNodeAt(pt);
                if (tn.PrevVisibleNode != null)
                    tn.PrevVisibleNode.EnsureVisible();
            }
        }

        /// <summary>
        /// Simple DragNDrop - move the node to new location
        /// </summary>
        private void TreeViewEditor_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (project == null) return;
            StatusString = "DragDrop started";
            TreeView senderTreeView = sender as TreeView;
            if (senderTreeView != this) return;

            Point pt = PointToClient(new Point(e.X, e.Y));
            TreeNode dropNode = GetNodeAt(pt);
            if (dropNode == null) return;

            if (e.Data.GetDataPresent("System.Drawing.Design.ToolboxItem", false))
            {
                StatusString = "Data is not TreeNode";
                if (e.Data.GetDataPresent("System.Drawing.Design.ToolboxItem"))
                {
                    StatusString = "Data is ToolboxItem";
                    ToolboxItem source = e.Data.GetData("System.Drawing.Design.ToolboxItem") as ToolboxItem;

                    if (source == null || dropNode == null)
                    {
                        StatusString = "Missing source or dest";
                        return;
                    }                   
                    project.AddChildElement(dropNode, source.TypeName);
                }
            }
            else if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode dragNode = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
                if (dragNode == null) return;
                if (prevDropNode == dropNode && e.Effect == DragDropEffects.Move)
                {
                    project.MoveComponent(dragNode, dropNode, prevDropSide);
                }
                if (prevDropNode != null)
                {
                    prevDropNode = null;
                    Refresh();
                }
            }





            // perform XML operation: prepare properties objects
            /*ZNodeProperties sourceNodeProperties = sourceTreeNode.Tag as ZNodeProperties;
            ZNodeProperties destinationNodePropeties = destinationTreeNode.Tag as ZNodeProperties;

            if (sourceNodeProperties != null && destinationNodePropeties != null)
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

                if (ZNodeProperties.MoveXmlNode(newXmlNode, destinationNodePropeties.xmlNode))
                {
                    // update TreeView according to changes in XmlDocument
                    PopulateTreeNode(destinationTreeNode);

                    if (e.Effect == DragDropEffects.Move)
                    {
                        TreeNode oldParentNode = sourceTreeNode.Parent;
                        sourceTreeNode.Remove();
                        HighlightTreeNode(oldParentNode, oldParentNode.Tag as ZNodeProperties);
                    }
                    OnPropertiesChanged();
                    OnContentChanged();
                }
            }*/
        }

        #region Helper Methods
        private void DrawLeafTopPlaceholders(TreeNode NodeOver)
        {
            Graphics g = CreateGraphics();

            int NodeOverImageWidth = ImageList.Images[NodeOver.ImageIndex].Size.Width + 8;
            int LeftPos = NodeOver.Bounds.Left - NodeOverImageWidth;
            int RightPos = Width - 4;

            Point[] LeftTriangle = new Point[5]{
												   new Point(LeftPos, NodeOver.Bounds.Top - 4),
												   new Point(LeftPos, NodeOver.Bounds.Top + 4),
												   new Point(LeftPos + 4, NodeOver.Bounds.Y),
												   new Point(LeftPos + 4, NodeOver.Bounds.Top - 1),
												   new Point(LeftPos, NodeOver.Bounds.Top - 5)};

            Point[] RightTriangle = new Point[5]{
													new Point(RightPos, NodeOver.Bounds.Top - 4),
													new Point(RightPos, NodeOver.Bounds.Top + 4),
													new Point(RightPos - 4, NodeOver.Bounds.Y),
													new Point(RightPos - 4, NodeOver.Bounds.Top - 1),
													new Point(RightPos, NodeOver.Bounds.Top - 5)};

            Refresh();
            g.FillPolygon(Brushes.Black, LeftTriangle);
            g.FillPolygon(Brushes.Black, RightTriangle);
            g.DrawLine(new Pen(Color.Black, 2), new Point(LeftPos, NodeOver.Bounds.Top), new Point(RightPos, NodeOver.Bounds.Top));

        }

        private void DrawLeafBottomPlaceholders(TreeNode NodeOver)
        {
            Graphics g = CreateGraphics();

            int NodeOverImageWidth = ImageList.Images[NodeOver.ImageIndex].Size.Width + 8;
            // Once again, we are not dragging to node over, draw the placeholder using the ParentDragDrop bounds
            int LeftPos, RightPos;

            LeftPos = NodeOver.Bounds.Left - NodeOverImageWidth;
            RightPos = Width - 4;

            Point[] LeftTriangle = new Point[5]{
												   new Point(LeftPos, NodeOver.Bounds.Bottom - 4),
												   new Point(LeftPos, NodeOver.Bounds.Bottom + 4),
												   new Point(LeftPos + 4, NodeOver.Bounds.Bottom),
												   new Point(LeftPos + 4, NodeOver.Bounds.Bottom - 1),
												   new Point(LeftPos, NodeOver.Bounds.Bottom - 5)};

            Point[] RightTriangle = new Point[5]{
													new Point(RightPos, NodeOver.Bounds.Bottom - 4),
													new Point(RightPos, NodeOver.Bounds.Bottom + 4),
													new Point(RightPos - 4, NodeOver.Bounds.Bottom),
													new Point(RightPos - 4, NodeOver.Bounds.Bottom - 1),
													new Point(RightPos, NodeOver.Bounds.Bottom - 5)};

            Refresh();
            g.FillPolygon(Brushes.Black, LeftTriangle);
            g.FillPolygon(Brushes.Black, RightTriangle);
            g.DrawLine(new Pen(Color.Black, 2), new Point(LeftPos, NodeOver.Bounds.Bottom), new Point(RightPos, NodeOver.Bounds.Bottom));
        }


        private void DrawAddToFolderPlaceholder(TreeNode NodeOver)
        {
            Graphics g = CreateGraphics();
            int RightPos = NodeOver.Bounds.Right + 6;
            Point[] RightTriangle = new Point[5]{
													new Point(RightPos, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2) + 4),
													new Point(RightPos, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2) + 4),
													new Point(RightPos - 4, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2)),
													new Point(RightPos - 4, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2) - 1),
													new Point(RightPos, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2) - 5)};

            Refresh();
            g.FillPolygon(Brushes.Black, RightTriangle);
        }
        #endregion


        /// <summary>
        /// Event handler - deletes the selected node
        /// </summary>
        /*public void DeleteElement_Click(object sender, EventArgs e)
        {
            TreeNode treeNodeToDelete = SelectedNode;
            TreeNode parentNode = treeNodeToDelete.Parent;

            ZNodeProperties props = treeNodeToDelete.Tag as ZNodeProperties;

            if (props != null)
            {
                if (project != null) project.DeleteComponent(props);
                props.Delete();
                treeNodeToDelete.Remove();

                // Update parent node properties and type
                if (parentNode.Nodes.Count == 0)
                {
                    ZNodeProperties parentProps = (ZNodeProperties) parentNode.Tag;
                    //parentProperties.ConstructProperties();

                    HighlightTreeNode(parentNode, parentProps);
                }
                SelectedNode = parentNode;

                // Tree node properties have been updated
                // Force parent to reload them to the PropertyBrowser
                //OnPropertiesChanged();
            }
            Invalidate();
        }*/

        /// <summary>
        /// This method creates new tree node and appends 
        /// new xml node to the underlying xml document.
        /// </summary>
        /// <param name="parentNode">Parent Tree node to add a child to.</param>
        /*private void AddChildNode(TreeNode parentNode, String childName)
        {
            StatusString = "Adding child node...";
            ZNodeProperties parentNodeProperties = parentNode.Tag as ZNodeProperties;
            TreeNode newTreeNode = new TreeNode(childName);
            ZNodeProperties newNodeProperties = null;

            if (parentNodeProperties != null)
            {
                newNodeProperties = parentNodeProperties.AddNewChild(childName, newTreeNode);

                if (newNodeProperties != null)
                {
                    newTreeNode.Tag = newNodeProperties;
                    newNodeProperties.XmlNodePropertyChanged += new XmlNodePropertyChangedEventHandler(this.XmlPropertiesUpdatedHandler);
                    parentNode.Nodes.Add(newTreeNode);

                    // Update parent node properties and type
                    //parentNodeProperties.ConstructProperties();

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

        }*/

        /// <summary>
        /// FineTune displaying TreeNode with ImageList and ForeColor properties
        /// based on XmlNode's NodeType and Children Nodes Type/Count.
        /// </summary>
        internal static void HighlightTreeNode(TreeNode treeNode, ZNodeProperties treeNodeProperties)
        {
            if (treeNode != null && treeNodeProperties != null)
            {
                treeNode.ForeColor = treeNodeProperties.NodeForeColor;
                treeNode.ImageIndex = treeNode.SelectedImageIndex = (int) treeNodeProperties.NodeImageIndex;
            }
        }




        /// <summary>
        /// Event handler - expose properties of the selected node to the
        /// property grid
        /// </summary>
        private void TreeViewEditor_AfterSelectNode(object sender, TreeViewEventArgs e)
        {
            OnSelectedNodeChanged();
        }

        /// <summary>
        /// Updates Event handler.
        /// </summary>
        private void TreeViewEditor_Leave(object sender, EventArgs e)
        {
            //OnPropertiesChanged();
        }

        /// <summary>
        /// Shows the ContextMenu for SelectedNode
        /// </summary>
        private void TreeViewEditor_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ZTreeView tree = sender as ZTreeView;

            if (e.Button == MouseButtons.Right)
            {
                TreeNode clickedNode = tree.GetNodeAt(e.Location);

                // if node contain reference to ZNodeProperties object, than we can start context menu
                if (clickedNode != null && clickedNode.Tag is ZNodeProperties)
                {
                    tree.SelectedNode = clickedNode;

                    if (project != null)
                        project.FillContextMenu(clickedNode, xmlContextMenu);

                    if (xmlContextMenu.Items.Count > 0)
                        xmlContextMenu.Show(this, e.Location.X, e.Location.Y);
                }
            }
        }

        /// <summary>
        /// Process calculation of suppress_label_edit private field.
        /// If mouse down occurred on Selected node - we allow label edit mode
        /// by assigning suppress_label_edit = false.
        /// </summary>
        private void TreeViewEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SelectedNode = this.GetNodeAt(e.X, e.Y);

            /*if (mouseDownNode == null)
            {
                return;
            }

            // If the node is already selected, prepare to start editing its label
            if (this.SelectedNode != null && this.SelectedNode == mouseDownNode && this.SelectedNode.Tag is ZNodeProperties)
            {
                // Reset LabelEdit property
                this.LabelEdit = true;
                suppressLabelEdit = false;
            }
            else
            {
                suppressLabelEdit = true;
            }*/
        }

        /// <summary>
        /// This method is called when it is neccessary to notify
        /// parent that property grid should be updated by
        /// properties of the selected item.
        /// </summary>
        internal void OnSelectedNodeChanged()
        {
            // Fire properties set changed event
            if (SelectedNodeChanged != null)
            {
                SelectedNodeChanged(this, new EventArgs());
            }
        }

        TreeNode FindNodeWithTag(TreeNodeCollection nodes, object tag)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag == tag)
                    return node;

                TreeNode candidate = FindNodeWithTag(node.Nodes, tag);

                if (candidate != null)
                    return candidate;
            }

            return null;
        }


        /// <summary>
        /// Handles the XmlNodePropertyChanged event of selected TreeNode (with underlying XmlNode).
        /// Commits changes to the TreeView. 
        /// Raises the ContentChanged event so to notifies the subscribers that
        /// document content have been changed.
        /// </summary>
        /// <param name="sender">ZNodeProperties structure which has been modified.</param>
        /// <param name="e">event argument (not used).</param>
        internal void UpdateNodeText(ZNodeProperties props)
        {
            // Modifications through properties: use selected node as default
            TreeNode treeNode = SelectedNode;
            if (treeNode.Tag != props)
            {
                Console.WriteLine("TreeNode tag mismatch");
                treeNode = FindNodeWithTag(Nodes, props);
            }

            if (treeNode != null && props.DisplayName.CompareTo(treeNode.Text) != 0)
            {
                // Rename tree node
                treeNode.Text = props.DisplayName;
                Invalidate();
            }
            //StatusString = e.StatusString;
        }


        # region Obsolete
        /// <summary>
        /// Cancels Label editing if suppress_label_edit private field is true.
        /// </summary>
        private void TreeViewEditor_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = true;
            //e.CancelEdit = suppressLabelEdit;
        }

        /// <summary>
        /// Performs validation of LableEdit.
        /// If New Label is valid, process rename corresponding XmlNode.
        /// </summary>
        private void TreeViewEditor_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // Return if editing was cancelled
            //             if (e.CancelEdit == true)
            //             {
            //                 return;
            //             }
            // 
            //             // If the name hasn't changed, or is empty, don't restore the original name
            //             if (e.Label == null || e.Label == this.SelectedNode.Text)
            //             {
            //                 e.CancelEdit = true;
            //                 return;
            //             }
            // 
            //             if (e.Label.Length > 0)
            //             {
            //                 // Validate proposed label change
            //                 try
            //                 {
            //                     // Check the name conformance to the w3c rules
            //                     XmlConvert.VerifyName(e.Label);
            //                     RenameNode(e.Node, e.Label);
            //                 }
            //                 catch (XmlException xmlException)
            //                 {
            //                     // Cancel the label edit action, inform the user, and 
            //                     // place the node in edit mode again.
            //                     e.CancelEdit = true;
            // 
            //                     // process MessageBoxOptions
            //                     Control parent = this;
            // 
            //                     while (parent != null && parent.RightToLeft == RightToLeft.Inherit)
            //                     {
            //                         parent = parent.Parent;
            //                     }
            // 
            //                     MessageBoxOptions options = parent.RightToLeft == RightToLeft.Yes ?
            //                         MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign :
            //                         (MessageBoxOptions) 0;
            // 
            //                     MessageBox.Show("Invalid name" + "\n" + xmlException.Message, "Name error",
            //                                 MessageBoxButtons.OK, MessageBoxIcon.Error,
            //                                 MessageBoxDefaultButton.Button1, options);
            //                     e.Node.BeginEdit();
            //                 }
            //             }
            //             else
            //             {
            //                 // Cancel the label edit action, inform the user, and 
            //                 // place the node in edit mode again.
            //                 e.CancelEdit = true;
            // 
            //                 // specify MessageBoxOptions 
            //                 Control parent = this;
            //                 while (parent != null && parent.RightToLeft == RightToLeft.Inherit)
            //                 {
            //                     parent = parent.Parent;
            //                 }
            //                 MessageBoxOptions options = (MessageBoxOptions) 0;
            //                 if (parent != null)
            //                 {
            //                     options = parent.RightToLeft == RightToLeft.Yes ?
            //                             (MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign) :
            //                             options;
            //                 }
            // 
            //                 MessageBox.Show("Invalid name" + "\n" + "Name cannot be blank", "Name error",
            //                     MessageBoxButtons.OK, MessageBoxIcon.Error,
            //                     MessageBoxDefaultButton.Button1, options);
            //                 e.Node.BeginEdit();
            //             }
        }

        private void RenameNode(TreeNode treeNode, string newName)
        {
            Console.WriteLine("Rename not supported.");
            /*ZNodeProperties properties = treeNode.Tag as ZNodeProperties;

            if (properties != null)
            {
                properties.Properties.SetValue("Type", newName);
                SelectedNode = treeNode;

                // Tree node properties have been updated
                // Force parent to reload them to the PropertyBrowser
                OnPropertiesChanged();
            }*/
        }

        /// <summary>
        /// Loads XML from string.
        /// </summary>
        /// <param name="value">string to load XML from.</param>
        public void LoadXml(string value)
        {
            // Check xml string is not null
            /*if (value == null)
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
            }*/
        }

        /// <summary>
        /// Populates TreeNode based on stored ZNodeProperties object.
        /// Calls overloaded version of the function.
        /// </summary>
        /// <param name="treeNode">TreeNode to be populated</param>
        private void PopulateTreeNode(TreeNode treeNode)
        {
            /*if (treeNode != null && treeNode.Tag is ZNodeProperties)
            {
                PopulateTreeNode(treeNode, ((ZNodeProperties)treeNode.Tag).xmlNode);
            }*/
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
            /*if (treeNode == null || xmlNode == null)
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
            // construct ZNodeProperties object for the TreeNode and assign it to Tag property
            ZNodeProperties props = new ZNodeProperties(xmlNode);
            treeNode.Tag = props;
            HighlightTreeNode(treeNode, props);
            props.XmlNodePropertyChanged += new XmlNodePropertyChangedEventHandler(this.XmlPropertiesUpdatedHandler);*/
        }
        #endregion

    }
}
