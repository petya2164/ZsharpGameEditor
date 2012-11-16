﻿using System;
using System.Drawing;
using Gwen.Control;
using Gwen.Input;

namespace Gwen.ControlInternal
{
    /// <summary>
    /// Base for controls that can be dragged by mouse.
    /// </summary>
    public class Dragger : GUIControl
    {
        protected bool m_Held;
        protected Point m_HoldPos;
        protected GUIControl m_Target;

        internal GUIControl Target { get { return m_Target; } set { m_Target = value; } }

        /// <summary>
        /// Indicates if the control is being dragged.
        /// </summary>
        public bool IsHeld { get { return m_Held; } }

        /// <summary>
        /// Event invoked when the control position has been changed.
        /// </summary>
        public event GwenEventHandler Dragged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dragger"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public Dragger(ZGE.Components.ZComponent parent) : base(parent)
        {
            MouseInputEnabled = true;
            m_Held = false;
        }

        /// <summary>
        /// Handler invoked on mouse click (left) event.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="down">If set to <c>true</c> mouse button is down.</param>
        protected override bool OnMouseClickedLeft(int x, int y, bool down)
        {
            if (null == m_Target) return true;

            if (down)
            {
                m_Held = true;
                m_HoldPos = m_Target.CanvasPosToLocal(new Point(x, y));
                InputHandler.MouseFocus = this;
            }
            else
            {
                m_Held = false;

                InputHandler.MouseFocus = null;
            }
            return true;
        }

        /// <summary>
        /// Handler invoked on mouse moved event.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="dx">X change.</param>
        /// <param name="dy">Y change.</param>
        protected override bool OnMouseMoved(int x, int y, int dx, int dy)
        {
            if (null == m_Target) return true;
            if (!m_Held) return true;

            Point p = new Point(x - m_HoldPos.X, y - m_HoldPos.Y);

            // Translate to parent
            if (m_Target.ParentControl != null)
                p = m_Target.ParentControl.CanvasPosToLocal(p);

            //m_Target->SetPosition( p.x, p.y );
            m_Target.MoveTo(p.X, p.Y);
            if (Dragged != null)
                Dragged.Invoke(this);
            return true;
        }

        /// <summary>
        /// Renders the control using specified skin.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void Render(Skin.Base skin)
        {
            
        }
    }
}
