using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZGE.Components;

namespace ZGE
{
    class Project
    {
        public string filePath = null;
        // Code Editor status
        public ZCode currentCode = null;
        public ZNodeProperties codeProperties = null;
        public string codePropertyName = null;

        public Project(string path)
        {
            filePath = path;
        }

        public void ClearCode()
        {
            currentCode = null;
            codeProperties = null;
            codePropertyName = null;
        }

        public void SetCode(ZCode code, ZComponent parent, string propertyName)
        {
            currentCode = code;
            if (parent != null)
                codeProperties = parent.Tag as ZNodeProperties;
            codePropertyName = propertyName;
        }

        public void CodeChanged(string codeBoxText)
        {
            if (currentCode != null && codeProperties != null && codePropertyName != null)
            {
                currentCode.Text = codeBoxText;
                PropertyChangedEventArgs ev = new PropertyChangedEventArgs(codePropertyName, codeBoxText);
                ev.Action = PropertyChangeAction.CodeChanged;
                codeProperties.PropertyHolderChanged(this, ev);
            }
        }
    }
}
