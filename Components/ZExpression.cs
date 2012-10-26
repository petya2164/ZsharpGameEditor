using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ZGE.Components
{
    public class ZExpression : ZCommand
    {
        public ZCode Expression;

        public ZExpression()
        {
        }

        public override void Execute(ZComponent caller)
        {
            if (Expression != null)
                Expression.Run(caller);
        }
    }

    // TODO: Make it generic
    [ToolboxItem(false)]
    public class ZCode
    {
        public string Text;

        public delegate void ModelMethod(Model model);
        public ModelMethod callback;

        public ZCode()
        {
            ZComponent.App.AddCode(this);
        }

        public string ToString()
        {
            return @"//Code";
        }

        public void Run(ZComponent caller)
        {
            Model currentModel = caller as Model;
            if (callback != null) callback(currentModel);
        }
    }
}
