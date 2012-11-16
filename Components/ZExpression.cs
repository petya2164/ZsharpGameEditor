using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ZGE.Components
{
    public class ZExpression : ZCommand
    {
        public delegate void ModelMethod(ZComponent caller);
        [CategoryAttribute("Expressions")]
        public ZCode<ModelMethod> Expression = new ZCode<ModelMethod>();

        public ZExpression(ZComponent parent)
            : base(parent)
        {            
            //Expression.Header = "public void #METHOD#()";
        }

        public override void Execute(ZComponent caller)
        {
            if (Expression != null && Expression.callback != null)
                Expression.callback(caller);
        }
    }

    // This is a dummy parent class for all "Definitions"
    public abstract class Definition : ZComponent
    {
        public Definition(ZComponent parent) : base(parent) { }
    }

    public class CustomCode : Definition
    {
        public CustomCodeDefinition Code = new CustomCodeDefinition();

        public CustomCode(ZComponent parent)
            : base(parent)
        {                        
        }       
    }

    [ToolboxItem(false)]
    public class CodeLike
    {
        //[Browsable(false)]
        //public ZComponent Owner;
        public string Text;
        [Browsable(false)]
        public string GUID; //= Guid.NewGuid().ToString();        

        public CodeLike()
        {
            //Owner = owner;
            ZComponent.App.AddCodeLike(this);
        }
        ~CodeLike()
        {
            if (ZComponent.App != null) ZComponent.App.RemoveCodeLike(this);
        }

        public override string ToString()
        {
            return @"//Code";
        }
    }

    [ToolboxItem(false)]
    public class CustomCodeDefinition : CodeLike
    {
        public CustomCodeDefinition()
        {
        }
    }

    
    [ToolboxItem(false)]
    public class ZCode<T>: CodeLike
    {
        //public string Header;
        public T callback;

        public ZCode()
        {            
        }
        

        /*public void Run(ZComponent caller)
        {
            Model currentModel = caller as Model;
            if (callback != null) callback(currentModel);
        }*/
    }
}
