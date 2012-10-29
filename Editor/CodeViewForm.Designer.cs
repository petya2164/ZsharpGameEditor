namespace ZGE
{
    partial class CodeViewForm
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
            this.codeEditorControl = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // codeEditorControl
            // 
            this.codeEditorControl.ConvertTabsToSpaces = true;
            this.codeEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorControl.IsReadOnly = false;
            this.codeEditorControl.Location = new System.Drawing.Point(0, 0);
            this.codeEditorControl.Name = "codeEditorControl";
            this.codeEditorControl.ShowVRuler = false;
            this.codeEditorControl.Size = new System.Drawing.Size(807, 758);
            this.codeEditorControl.TabIndex = 0;
            this.codeEditorControl.VRulerRow = 60;
            // 
            // XmlEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.AutoScrollMinSize = new System.Drawing.Size(30, 30);
            this.ClientSize = new System.Drawing.Size(807, 758);
            this.Controls.Add(this.codeEditorControl);
            this.Name = "XmlEditorForm";
            this.Text = "Project code";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XmlEditorForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl codeEditorControl;
    }
}