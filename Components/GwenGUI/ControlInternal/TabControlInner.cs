using System;
using Gwen.Control;

namespace Gwen.ControlInternal
{
    /// <summary>
    /// Inner panel of tab control.
    /// </summary>
    public class TabControlInner : GUIControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabControlInner"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        internal TabControlInner(ZGE.Components.ZComponent parent) : base(parent)
        {
        }

        /// <summary>
        /// Renders the control using specified skin.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void Render(Skin.Base skin)
        {
            skin.DrawTabControl(this);
        }
    }
}
