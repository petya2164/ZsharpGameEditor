using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ZGE.Components
{
    [HideComponent]
    public abstract class ZCommand : ZComponent
    {
        public abstract void Execute(ZComponent caller);
    }

    [HideComponent]
    public static class ZCommandListExtension
    {
        public static void ExecuteAll(this List<ZCommand> commands, ZComponent caller)
        {
            foreach (var comm in commands)
                if (comm.Enabled) comm.Execute(caller);
        }
    }

    // public delegate bool BoolModelMethod(Model model);
    public class Repeat : ZCommand
    {
        public int Count;  //Set for a fixed nr of iterations
        public delegate bool BoolMethod(ZComponent caller);
        [CategoryAttribute("Expressions")]
        public ZCode<BoolMethod> WhileExp = new ZCode<BoolMethod>();

        [Browsable(false)]
        public List<ZCommand> OnIteration = new List<ZCommand>();
        public int Iteration;

        public Repeat()
        {
            //WhileExp.Header = "public bool #METHOD#()";            
        }

        public override void Execute(ZComponent caller)
        {
            Iteration = 0;
            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    OnIteration.ExecuteAll(caller);
                    Iteration++;
                }
            }
            else if (WhileExp != null && WhileExp.callback != null)
            {
                while(WhileExp.callback(caller)==true)
                {
                    OnIteration.ExecuteAll(caller);
                    Iteration++;
                }
            }
        }
    }

    public class Condition : ZCommand
    {
        public delegate bool BoolMethod(ZComponent caller);
        [CategoryAttribute("Expressions")]
        public ZCode<BoolMethod> Expression = new ZCode<BoolMethod>();

        [Browsable(false)]
        public List<ZCommand> OnTrue = new List<ZCommand>();
        [Browsable(false)]
        public List<ZCommand> OnFalse = new List<ZCommand>();

        public Condition()
        {
            //Expression.Header = "public bool #METHOD#()";            
        }

        public override void Execute(ZComponent caller)
        {
            if (Expression != null && Expression.callback != null)
            {
                if (Expression.callback(caller))
                    OnTrue.ExecuteAll(caller);
                else
                    OnFalse.ExecuteAll(caller);
            }
        }
    }


    public class KeyDown : ZCommand
    {
        public string Keys;
        public double RepeatDelay;

        [Browsable(false)]
        public List<ZCommand> OnDown = new List<ZCommand>();
        [ReadOnlyAttribute(true)]
        public int KeyIndex;
        [ReadOnlyAttribute(true)]
        public char Char;
        [ReadOnlyAttribute(true)]
        public double LastPressedAt; 

        public KeyDown()
        {            
        }

        public override void Execute(ZComponent caller)
        {
            if (Keys != null && Keys.Length > 0)
            {
                // TODO: Enforce RepeatDelay
                for (int i = 0; i < Keys.Length; i++)
                {
                    /*if (App.IsKeyDown(Keys[i]))
                    {
                        KeyIndex = i;
                        OnPress.ExecuteAll(caller);
                        LastPressedAt = App.Time;
                        break;
                    }*/
                }
            }

        }
    }

    //Force a component to refresh itself by calling .Change
    public class RefreshContent : ZCommand
    {
        public ZComponent Component;

        public RefreshContent() { }

        public override void Execute(ZComponent caller)
        {
            INeedRefresh obj = Component as INeedRefresh;
            if (obj != null) obj.Refresh();
        }
    }

    public class ZTimer : ZCommand
    {
        public double Interval;
        public int RepeatCount; 

        [Browsable(false)]
        public List<ZCommand> OnTimer = new List<ZCommand>();
        [ReadOnlyAttribute(true)]
        public int Iteration;
        [ReadOnlyAttribute(true)]
        public double Time;
        [ReadOnlyAttribute(true)]
        public bool Stopped;

        public ZTimer()
        {            
            Reset();
        }

        public void Reset()
        {
            Iteration = 0;
            Time = 0.0f;
            Stopped = false;
        }

        public override void Execute(ZComponent caller)
        {
            if (Interval > 0.0f && Stopped == false)
            {
                Time += App.DeltaTime;
                if (Time >= Interval)
                {
                    Time -= Interval;
                    OnTimer.ExecuteAll(caller);
                    Iteration++;
                    if (RepeatCount != -1)
                    {
                        Stopped = (Iteration > RepeatCount);
                    }
                }
            }
        }
    }

    public class CallComponent : ZCommand
    {
        public ZCommand Component;

        public CallComponent() { }

        public override void Execute(ZComponent caller)
        {
            if (Component != null)
                Component.Execute(caller);
        }
    }
}
