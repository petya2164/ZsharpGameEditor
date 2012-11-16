﻿using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class NumericUpDown : GUnit
    {
        public NumericUpDown(ZGE.Components.ZComponent parent)
            : base(parent)
        {
            Control.NumericUpDown ctrl = new Control.NumericUpDown(this);
            ctrl.SetBounds(10, 10, 50, 20);
            ctrl.Value = 50;
            ctrl.Max = 100;
            ctrl.Min = -100;
            ctrl.ValueChanged += OnValueChanged;
        }

        void OnValueChanged(GUIControl control)
        {
            UnitPrint(String.Format("NumericUpDown: ValueChanged: {0}", ((Control.NumericUpDown)control).Value));
        }
    }
}
