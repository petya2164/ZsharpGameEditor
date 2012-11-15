using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class GUnit : ControlBase
    {
        public UnitTest UnitTest;

        public GUnit(ControlBase parent) : base(parent)
        {
            
        }

        protected override bool OnMouseClickedLeft(int x, int y, bool down)
        {
            return false;
        }
        protected override bool OnMouseClickedRight(int x, int y, bool down)
        {
            return false;
        }
        protected override bool OnMouseMoved(int x, int y, int dx, int dy)
        {
            return false;
        }

        public void UnitPrint(String str)
        {
            if (UnitTest != null)
                UnitTest.PrintText(str);
        }
    }
}
