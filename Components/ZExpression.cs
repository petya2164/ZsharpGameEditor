using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ZGE.Components
{
//     public class ZExpression : ZCommand
//     {
//         public delegate void ModelMethod(ZComponent caller);
//         [CategoryAttribute("Expressions")]
//         public ZCode<ModelMethod> Expression = new ZCode<ModelMethod>();
// 
//         public ZExpression(ZComponent parent)
//             : base(parent)
//         {            
//             //Expression.Header = "public void #METHOD#()";
//         }
// 
//         public override void Execute(ZComponent caller)
//         {
//             if (Expression != null && Expression.callback != null)
//                 Expression.callback(caller);
//         }
//     }

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

    
    public class CodeLike
    {
        //[Browsable(false)]
        //public ZComponent Owner;
        public string Text;
        [Browsable(false)]
        public string GUID; //= Guid.NewGuid().ToString();        

        public override string ToString()
        {
            if (Text == null || Text.Length == 0)
                return null;
            else
                return @"//Code";
        }
    }

    
    public class CustomCodeDefinition : CodeLike
    {
        public CustomCodeDefinition()
        {
        }
    }

    // This attribute keeps certain components in
    [AttributeUsage(AttributeTargets.Field)]
    public class MethodSignature : Attribute
    {
        public string Signature { get; private set; }

//         public MethodSignature()
//         {
//             Signature = "MISSING";
//         }

        public MethodSignature(string signature)
        {
            Signature = signature;
        }
    }

    public class VirtualMethod : CodeLike
    {
        //public string Signature;

        public VirtualMethod()
        {
            //Signature = signature;
        }
        public override string ToString()
        {
            if (Text == null || Text.Length == 0)
                return null;
            else
                return @"//Method";
        }
    }

    public class ZEvent : CodeLike
    {
        public ZComponent Owner;
        public string EventName;

        public ZEvent(ZComponent owner, string eventName)
        {
            Owner = owner;
            EventName = eventName;
            ZComponent.App.AddEvent(this);
        }
        
        ~ZEvent()
        {
            if (ZComponent.App != null) ZComponent.App.RemoveEvent(this);
        }
        public override string ToString()
        {
            if (Text == null || Text.Length == 0)
                return null;
            else
                return @"//Event";
        }
    }


    
    /*public class ZCode<T>: CodeLike
    {
        //public string Header;
        public T callback;

        public ZCode()
        {            
        }        
    }*/
}
