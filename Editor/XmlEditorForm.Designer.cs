namespace ZGE
{
    partial class XmlEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xmlEditorControl = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // xmlEditorControl
            // 
            this.xmlEditorControl.ConvertTabsToSpaces = true;
            this.xmlEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlEditorControl.IsReadOnly = false;
            this.xmlEditorControl.Location = new System.Drawing.Point(0, 0);
            this.xmlEditorControl.Name = "xmlEditorControl";
            this.xmlEditorControl.ShowVRuler = false;
            this.xmlEditorControl.Size = new System.Drawing.Size(807, 758);
            this.xmlEditorControl.TabIndex = 0;
            this.xmlEditorControl.VRulerRow = 60;
            // 
            // XmlEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.AutoScrollMinSize = new System.Drawing.Size(30, 30);
            this.ClientSize = new System.Drawing.Size(807, 758);
            this.Controls.Add(this.xmlEditorControl);
            this.Name = "XmlEditorForm";
            this.Text = "XML Project File";
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl xmlEditorControl;
    }
}