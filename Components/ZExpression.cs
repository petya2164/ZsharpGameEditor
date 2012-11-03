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
        public ZCode<ModelMethod> Expression;

        public ZExpression()
        {
            Expression = new ZCode<ModelMethod>(this);
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
        public Definition() { }
    }

    public class CustomCode : Definition
    {        
        public CustomCodeDefinition Code;

        public CustomCode()
        {
            Code = new CustomCodeDefinition(this);            
        }       
    }

    [ToolboxItem(false)]
    public class CodeLike
    {
        [Browsable(false)]
        public ZComponent Owner;
        public string Text;
        [Browsable(false)]
        public string GUID; //= Guid.NewGuid().ToString();        

        public CodeLike(ZComponent owner)
        {
            Owner = owner;
            ZComponent.App.AddCodeLike(this);
        }

        public override string ToString()
        {
            return @"//Code";
        }
    }

    [ToolboxItem(false)]
    public class CustomCodeDefinition : CodeLike
    {
        public CustomCodeDefinition(ZComponent owner): base(owner)
        {
        }
    }

    
    [ToolboxItem(false)]
    public class ZCode<T>: CodeLike
    {
        //public string Header;
        public T callback;

        public ZCode(ZComponent owner): base(owner)
        {            
        }
        

        /*public void Run(ZComponent caller)
        {
            Model currentModel = caller as Model;
            if (callback != null) callback(currentModel);
        }*/
    }
}
