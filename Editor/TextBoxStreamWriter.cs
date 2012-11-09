using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ZGE
{
    public class TextBoxStreamWriter : TextWriter
    {
        RichTextBox output = null;
        StringBuilder sb;
        //char prev;

        public TextBoxStreamWriter(RichTextBox outputControl)
        {
            this.output = outputControl;
            sb = new StringBuilder();
        }

        public override void Write(char value)
        {
            base.Write(value);
            if (output == null) return;
            
            //_output.AppendText(value.ToString()); // When character data is written, append it to the text box.
            if (value != '\r')
                sb.Append(value);
                //_output.Text += value;
            if (value == '\n')
            {
                if (output.InvokeRequired) //console.writeline was called from another thread
                {
                    string line = sb.ToString(); // save the string to be used in the main thread
                    output.Invoke((MethodInvoker) delegate { output.AppendText(line); });
                    sb = new StringBuilder();
                }
                else
                {
                    output.AppendText(sb.ToString());
                    output.SelectionStart = output.Text.Length;
                    output.ScrollToCaret();  //autoscroll to the end
                    sb = new StringBuilder();
                }
                
            }            
            //prev = value;
        }        

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}

