﻿using System;
using System.Drawing;
using Gwen.Control;

namespace Gwen.DragDrop
{
    public class Package
    {
        public String Name;
        public object UserData;
        public bool IsDraggable;
        public GUIControl DrawControl;
        public Point HoldOffset;
    }
}
