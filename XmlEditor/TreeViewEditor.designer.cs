namespace Microsoft.Samples.VisualStudio.SynchronousXmlDesigner.TreeXmlEditor
{
    public partial class TreeViewEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ContextMenuStrip xmlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addChildElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem deleteElementToolStripMenuItem;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.xmlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addChildElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.showPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmlContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // xmlContextMenu
            // 
            this.xmlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChildElementToolStripMenuItem,
            this.deleteElementToolStripMenuItem,
            this.toolStripSeparator,
            this.showPropertiesToolStripMenuItem});
            this.xmlContextMenu.Name = "XmlContextMenu";
            this.xmlContextMenu.Size = new System.Drawing.Size(172, 76);
            this.xmlContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.xmlContextMenu_Opening);
            // 
            // addChildElementToolStripMenuItem
            // 
            this.addChildElementToolStripMenuItem.Name = "addChildElementToolStripMenuItem";
            this.addChildElementToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addChildElementToolStripMenuItem.Text = "Add child element";
            this.addChildElementToolStripMenuItem.Click += new System.EventHandler(this.AddChildElementToolStripMenuItem_Click);
            // 
            // deleteElementToolStripMenuItem
            // 
            this.deleteElementToolStripMenuItem.Name = "deleteElementToolStripMenuItem";
            this.deleteElementToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteElementToolStripMenuItem.Text = "Delete element";
            this.deleteElementToolStripMenuItem.Click += new System.EventHandler(this.deleteElementToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(168, 6);
            // 
            // showPropertiesToolStripMenuItem
            // 
            this.showPropertiesToolStripMenuItem.Name = "showPropertiesToolStripMenuItem";
            this.showPropertiesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showPropertiesToolStripMenuItem.Text = "Properties";
            this.showPropertiesToolStripMenuItem.Click += new System.EventHandler(this.showPropertiesToolStripMenuItem_Click);
            // 
            // TreeViewEditor
            // 
            this.AllowDrop = true;
            this.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HideSelection = false;
            this.LabelEdit = true;
            this.Location = new System.Drawing.Point(4, 30);
            this.Name = "XmlTreeViewEditor";
            this.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeViewEditor_AfterLabelEdit);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeViewEditor_DragDrop);
            this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewEditor_AfterSelectNode);
            this.Leave += new System.EventHandler(this.TreeViewEditor_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewEditor_MouseDown);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TreeViewEditor_DragEnter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TreeViewEditor_KeyUp);
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewEditor_NodeMouseClick);
            this.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeViewEditor_BeforeLabelEdit);
            this.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TreeViewEditor_ItemDrag);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeViewEditor_DragOver);
            this.xmlContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
