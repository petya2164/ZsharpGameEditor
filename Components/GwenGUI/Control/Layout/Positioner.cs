﻿using System;

namespace Gwen.Control.Layout
{
    /// <summary>
    /// Helper control that positions its children in a specific way.
    /// </summary>
    public class Positioner : ControlBase
    {
        private Pos m_Pos;

        /// <summary>
        /// Children position.
        /// </summary>
        public Pos Pos { get { return m_Pos; } set { m_Pos = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Positioner"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public Positioner(ControlBase parent) : base(parent)
        {
            Pos = Pos.Left | Pos.Top;
        }

        /// <summary>
        /// Function invoked after layout.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void PostLayout(Skin.Base skin)
        {
            foreach (ControlBase child in Children) // ok?
            {
                child.SetPosition(m_Pos, 0, 0);
            }
        }
    }

    /// <summary>
    /// Helper class that centers all its children.
    /// </summary>
    public class Center : Positioner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Center"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public Center(ControlBase parent) : base(parent)
        {
            Pos = Pos.Center;
        }
    }
}
