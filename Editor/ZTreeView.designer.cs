namespace ZGE
{
    public partial class ZTreeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ContextMenuStrip xmlContextMenu;

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
            this.SuspendLayout();
            // 
            // xmlContextMenu
            // 
            this.xmlContextMenu.Name = "XmlContextMenu";
            this.xmlContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // ZTreeView
            // 
            this.AllowDrop = true;
            this.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HideSelection = false;
            this.Location = new System.Drawing.Point(4, 30);
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
            this.ResumeLayout(false);

        }

        #endregion
    }
}
