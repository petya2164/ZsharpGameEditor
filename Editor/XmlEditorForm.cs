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
    public partial class XmlEditorForm : Form
    {
        public XmlEditorForm()
        {
            InitializeComponent();
            xmlEditorControl.Document.HighlightingStrategy =
                        HighlightingStrategyFactory.CreateHighlightingStrategyForFile("dummy.xml");
        }

        public void SetText(string text)
        {
            xmlEditorControl.Text = text;
        }

        // Use this event handler for the FormClosing event.
        private void XmlEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }
    }
}
