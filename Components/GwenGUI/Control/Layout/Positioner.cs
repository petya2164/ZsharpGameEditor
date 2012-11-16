using System;
using ZGE.Components;

namespace Gwen.Control.Layout
{
    /// <summary>
    /// Helper control that positions its children in a specific way.
    /// </summary>
    [HideComponent]
    public class Positioner : GUIControl
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
        public Positioner(ZGE.Components.ZComponent parent) : base(parent)
        {
            Pos = Pos.Left | Pos.Top;
        }

        /// <summary>
        /// Function invoked after layout.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void PostLayout(Skin.Base skin)
        {
            foreach (GUIControl child in Children) // ok?
            {
                child.SetPosition(m_Pos, 0, 0);
            }
        }
    }

    /// <summary>
    /// Helper class that centers all its children.
    /// </summary>
    [HideComponent]
    public class Center : Positioner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Center"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public Center(ZGE.Components.ZComponent parent) : base(parent)
        {
            Pos = Pos.Center;
        }
    }
}
