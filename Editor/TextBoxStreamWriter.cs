using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ZGE
{
    public class TextBoxStreamWriter : TextWriter
    {
        RichTextBox _output = null;
        //char prev;

        public TextBoxStreamWriter(RichTextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            
            //_output.AppendText(value.ToString()); // When character data is written, append it to the text box.
            if (value != '\r')
                _output.Text += value;
            if (value == '\n')
            {
                _output.SelectionStart = _output.Text.Length;
                _output.ScrollToCaret();
            }            
            //prev = value;
        }        

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}

