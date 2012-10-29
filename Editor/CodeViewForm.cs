using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace ZGE
{
    public partial class CodeViewForm : Form
    {
        public CodeViewForm()
        {
            InitializeComponent();
            codeEditorControl.Document.HighlightingStrategy =
                        HighlightingStrategyFactory.CreateHighlightingStrategyForFile("dummy.cs");
        }

        public void SetText(string text)
        {
            codeEditorControl.Text = text;
        }

        // Use this event handler for the FormClosing event.
        private void XmlEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }
    }
}
