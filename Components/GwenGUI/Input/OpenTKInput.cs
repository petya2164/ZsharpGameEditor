﻿using System;
using Gwen.Control;
using OpenTK.Input;
using OpenTK;

namespace Gwen.Input
{
    public class OpenTKInput
    {

        #region Properties

        private Canvas m_Canvas = null;

        private int m_MouseX = 0;
        private int m_MouseY = 0;

        bool m_AltGr = false;

        #endregion

        #region Constructors
        public OpenTKInput()
        {
            //window.KeyPress += KeyPress;
        }

        #endregion

       #region Methods
        public void Initialize(Canvas c)
        {
            m_Canvas = c;
        }

        /// <summary>
        /// Translates control key's OpenTK key code to GWEN's code.
        /// </summary>
        /// <param name="key">OpenTK key code.</param>
        /// <returns>GWEN key code.</returns>
        private Key TranslateKeyCode(global::OpenTK.Input.Key key)
        {
            switch (key)
            {
                case global::OpenTK.Input.Key.BackSpace: return Key.Backspace;
                case global::OpenTK.Input.Key.Enter: return Key.Return;
                case global::OpenTK.Input.Key.Escape: return Key.Escape;
                case global::OpenTK.Input.Key.Tab: return Key.Tab;
                case global::OpenTK.Input.Key.Space: return Key.Space;
                case global::OpenTK.Input.Key.Up: return Key.Up;
                case global::OpenTK.Input.Key.Down: return Key.Down;
                case global::OpenTK.Input.Key.Left: return Key.Left;
                case global::OpenTK.Input.Key.Right: return Key.Right;
                case global::OpenTK.Input.Key.Home: return Key.Home;
                case global::OpenTK.Input.Key.End: return Key.End;
                case global::OpenTK.Input.Key.Delete: return Key.Delete;
                case global::OpenTK.Input.Key.LControl:
                    this.m_AltGr = true;
                    return Key.Control;
                case global::OpenTK.Input.Key.LAlt: return Key.Alt;
                case global::OpenTK.Input.Key.LShift: return Key.Shift;
                case global::OpenTK.Input.Key.RControl: return Key.Control;
                case global::OpenTK.Input.Key.RAlt: 
                    if (this.m_AltGr)
                    {
                        this.m_Canvas.Input_Key(Key.Control, false);
                    }
                    return Key.Alt;
                case global::OpenTK.Input.Key.RShift: return Key.Shift;
                
            }
            return Key.Invalid;
        }

        /// <summary>
        /// Translates alphanumeric OpenTK key code to character value.
        /// </summary>
        /// <param name="key">OpenTK key code.</param>
        /// <returns>Translated character.</returns>
        private static char TranslateChar(global::OpenTK.Input.Key key)
        {
            if (key >= global::OpenTK.Input.Key.A && key <= global::OpenTK.Input.Key.Z)
                return (char)('a' + ((int)key - (int) global::OpenTK.Input.Key.A));
            return ' ';
        }

        public bool ProcessMouseMessage(EventArgs args)
        {
            if (null == m_Canvas) return false;

            if (args is MouseMoveEventArgs)
            {
                MouseMoveEventArgs ev = args as MouseMoveEventArgs;
                int dx = ev.X - m_MouseX;
                int dy = ev.Y - m_MouseY;

                m_MouseX = ev.X;
                m_MouseY = ev.Y;

                return m_Canvas.Input_MouseMoved(m_MouseX, m_MouseY, dx, dy);
            }

            if (args is MouseButtonEventArgs)
            {
                MouseButtonEventArgs ev = args as MouseButtonEventArgs;
                return m_Canvas.Input_MouseButton((int) ev.Button, ev.IsPressed);
            }

            if (args is MouseWheelEventArgs)
            {
                MouseWheelEventArgs ev = args as MouseWheelEventArgs;
                return m_Canvas.Input_MouseWheel(ev.Delta*60);
            }

            return false;
        }


        public bool ProcessKeyDown(EventArgs args)
        {
            KeyboardKeyEventArgs ev = args as KeyboardKeyEventArgs;
            char ch = TranslateChar(ev.Key);

            if (InputHandler.DoSpecialKeys(m_Canvas, ch))
                return false;
            /*
            if (ch != ' ')
            {
                m_Canvas.Input_Character(ch);
            }
            */
            Key iKey = TranslateKeyCode(ev.Key);

            return m_Canvas.Input_Key(iKey, true);
        }

        public bool ProcessKeyUp(EventArgs args)
        {
            KeyboardKeyEventArgs ev = args as KeyboardKeyEventArgs;

            char ch = TranslateChar(ev.Key);

            Key iKey = TranslateKeyCode(ev.Key);

            return m_Canvas.Input_Key(iKey, false);
        }

        public void KeyPress(object sender, KeyPressEventArgs e)
        {
            m_Canvas.Input_Character(e.KeyChar);   
        }

        #endregion
    }
}
