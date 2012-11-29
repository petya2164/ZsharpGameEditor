using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ZGE.Components
{
//     [HideComponent]
//     public abstract class ZCommand : ZComponent
//     {
//         public ZCommand(ZComponent parent) : base(parent) { }
//         public abstract void Execute(ZComponent caller);
//     }
// 
//     [HideComponent]
//     public static class ZCommandListExtension
//     {
//         public static void ExecuteAll(this List<ZCommand> commands, ZComponent caller)
//         {
//             foreach (var comm in commands)
//                 if (comm.Enabled) comm.Execute(caller);
//         }
//     }
// 
//     // public delegate bool BoolModelMethod(Model model);
//     public class Repeat : ZCommand
//     {
//         public int Count;  //Set for a fixed nr of iterations
//         public delegate bool BoolMethod(ZComponent caller);
//         [CategoryAttribute("Expressions")]
//         public ZCode<BoolMethod> WhileExp = new ZCode<BoolMethod>();
// 
//         [Browsable(false)]
//         public List<ZCommand> OnIteration = new List<ZCommand>();
//         public int Iteration;
// 
//         public Repeat(ZComponent parent)
//             : base(parent)
//         {
//             //WhileExp.Header = "public bool #METHOD#()";            
//         }
// 
//         public override void Execute(ZComponent caller)
//         {
//             Iteration = 0;
//             if (Count > 0)
//             {
//                 for (int i = 0; i < Count; i++)
//                 {
//                     OnIteration.ExecuteAll(caller);
//                     Iteration++;
//                 }
//             }
//             else if (WhileExp != null && WhileExp.callback != null)
//             {
//                 while(WhileExp.callback(caller)==true)
//                 {
//                     OnIteration.ExecuteAll(caller);
//                     Iteration++;
//                 }
//             }
//         }
//     }
// 
//     public class Condition : ZCommand
//     {
//         public delegate bool BoolMethod(ZComponent caller);
//         [CategoryAttribute("Expressions")]
//         public ZCode<BoolMethod> Expression = new ZCode<BoolMethod>();
// 
//         [Browsable(false)]
//         public List<ZCommand> OnTrue = new List<ZCommand>();
//         [Browsable(false)]
//         public List<ZCommand> OnFalse = new List<ZCommand>();
// 
//         public Condition(ZComponent parent)
//             : base(parent)
//         {
//             //Expression.Header = "public bool #METHOD#()";            
//         }
// 
//         public override void Execute(ZComponent caller)
//         {
//             if (Expression != null && Expression.callback != null)
//             {
//                 if (Expression.callback(caller))
//                     OnTrue.ExecuteAll(caller);
//                 else
//                     OnFalse.ExecuteAll(caller);
//             }
//         }
//     }
// 
// 
//     public class KeyDown : ZCommand
//     {
//         public string Keys;
//         public double RepeatDelay;
// 
//         [Browsable(false)]
//         public List<ZCommand> OnDown = new List<ZCommand>();
//         [ReadOnlyAttribute(true)]
//         public int KeyIndex;
//         [ReadOnlyAttribute(true)]
//         public char Char;
//         [ReadOnlyAttribute(true)]
//         public double LastPressedAt;
// 
//         public KeyDown(ZComponent parent)
//             : base(parent)
//         {            
//         }
// 
//         public override void Execute(ZComponent caller)
//         {
//             if (Keys != null && Keys.Length > 0)
//             {
//                 // TODO: Enforce RepeatDelay
//                 for (int i = 0; i < Keys.Length; i++)
//                 {
//                     /*if (App.IsKeyDown(Keys[i]))
//                     {
//                         KeyIndex = i;
//                         OnPress.ExecuteAll(caller);
//                         LastPressedAt = App.Time;
//                         break;
//                     }*/
//                 }
//             }
// 
//         }
//     }
// 
//     //Force a component to refresh itself by calling .Change
//     public class RefreshContent : ZCommand
//     {
//         public ZComponent Component;
// 
//         public RefreshContent(ZComponent parent) : base(parent) { }
// 
//         public override void Execute(ZComponent caller)
//         {
//             INeedRefresh obj = Component as INeedRefresh;
//             if (obj != null) obj.Refresh();
//         }
//     }
// 
    public class ZTimer : ZComponent, IUpdateable
    {
        public double Interval;
        public int RepeatCount; 

        public delegate void EmptyHandler();
        [Browsable(false)]
        public event EmptyHandler OnTimer;
        [ReadOnlyAttribute(true)]
        public int Iteration;
        [ReadOnlyAttribute(true)]
        public double Time;
        [ReadOnlyAttribute(true)]
        public bool Stopped;

        public ZTimer(ZComponent parent): base(parent)
        {            
            Reset();
        }

        public void Reset()
        {
            Iteration = 0;
            Time = 0.0;
            Stopped = false;
        }

        public void Update()
        {
            if (Interval > 0.0f && Stopped == false)
            {
                Time += App.DeltaTime;
                while (Time >= Interval)
                {
                    Time -= Interval;
                    if (OnTimer != null) OnTimer();
                    Iteration++;
                    if (RepeatCount != 0)  // endless timer
                    {
                        Stopped = (Iteration > RepeatCount);
                    }
                }
            }
        }
    }
// 
//     public class CallComponent : ZCommand
//     {
//         public ZCommand Component;
// 
//         public CallComponent(ZComponent parent) : base(parent) { }
// 
//         public override void Execute(ZComponent caller)
//         {
//             if (Component != null)
//                 Component.Execute(caller);
//         }
//     }
}
