using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ZGE
{
    public class TextBoxStreamWriter : TextWriter
    {
        RichTextBox _output = null;
        StringBuilder sb;
        //char prev;

        public TextBoxStreamWriter(RichTextBox output)
        {
            _output = output;
            sb = new StringBuilder();
        }

        public override void Write(char value)
        {
            base.Write(value);
            if (_output == null) return;
            
            //_output.AppendText(value.ToString()); // When character data is written, append it to the text box.
            if (value != '\r')
                sb.Append(value);
                //_output.Text += value;
            if (value == '\n')
            {
                _output.AppendText(sb.ToString());
                _output.SelectionStart = _output.Text.Length;
                _output.ScrollToCaret();
                sb = new StringBuilder();
            }            
            //prev = value;
        }        

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}

