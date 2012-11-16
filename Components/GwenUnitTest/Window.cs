﻿using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class Window : GUnit
    {
        private int m_WindowCount;
        private readonly Random rand;

        public Window(ZGE.Components.ZComponent parent)
            : base(parent)
        {
            rand = new Random();

            Control.Button button1 = new Control.Button(this);
            button1.SetText("Open a Window");
            button1.Clicked += OpenWindow;

            Control.Button button2 = new Control.Button(this);
            button2.SetText("Open a MessageBox");
            button2.Clicked += OpenMsgbox;
            Align.PlaceRightBottom(button2, button1, 10);

            m_WindowCount = 1;
        }

        void OpenWindow(GUIControl control)
        {
            Control.WindowControl window = new Control.WindowControl(GetCanvas(),"",false);
            window.Caption = String.Format("Window {0}", m_WindowCount);
            window.SetSize(rand.Next(200, 400), rand.Next(200, 400));
            window.SetPosition(rand.Next(700), rand.Next(400));

            m_WindowCount++;
        }

        void OpenMsgbox(GUIControl control)
        {
            MessageBox window = new MessageBox(GetCanvas(), 
                String.Format("Window {0}   MessageBox window = new MessageBox(GetCanvas(), String.Format(  MessageBox window = new MessageBox(GetCanvas(), String.Format(", m_WindowCount), "");
            window.SetPosition(rand.Next(700), rand.Next(400));

            m_WindowCount++;
        }
    }
}
