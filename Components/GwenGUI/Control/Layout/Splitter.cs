using System;
using ZGE.Components;

namespace Gwen.Control.Layout
{
    /// <summary>
    /// Base splitter class.
    /// </summary>
    [HideComponent]
    public class Splitter : GUIControl
    {
        private readonly GUIControl[] m_Panel;
        private readonly bool[] m_Scale;

        /// <summary>
        /// Initializes a new instance of the <see cref="Splitter"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public Splitter(ZGE.Components.ZComponent parent) : base(parent)
        {
            m_Panel = new GUIControl[2];
            m_Scale = new bool[2];
            m_Scale[0] = true;
            m_Scale[1] = true;
        }

        /// <summary>
        /// Sets the contents of a splitter panel.
        /// </summary>
        /// <param name="panelIndex">Panel index (0-1).</param>
        /// <param name="panel">Panel contents.</param>
        /// <param name="noScale">Determines whether the content is to be scaled.</param>
        public void SetPanel(int panelIndex, GUIControl panel, bool noScale)
        {
            if (panelIndex < 0 || panelIndex > 1)
                throw new ArgumentException("Invalid panel index", "panelIndex");

            m_Panel[panelIndex] = panel;
            m_Scale[panelIndex] = !noScale;

            if (null != m_Panel[panelIndex])
            {
                m_Panel[panelIndex].ParentControl = this;
            }
        }

        /// <summary>
        /// Gets the contents of a secific panel.
        /// </summary>
        /// <param name="panelIndex">Panel index (0-1).</param>
        /// <returns></returns>
        GUIControl GetPanel(int panelIndex)
        {
            if (panelIndex < 0 || panelIndex > 1)
                throw new ArgumentException("Invalid panel index", "panelIndex");
            return m_Panel[panelIndex];
        }

        /// <summary>
        /// Lays out the control's interior according to alignment, padding, dock etc.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void Layout(Skin.Base skin)
        {
            LayoutVertical(skin);
        }

        protected virtual void LayoutVertical(Skin.Base skin)
        {
            int w = Width;
            int h = Height;

            if (m_Panel[0] != null)
            {
                Margin m = m_Panel[0].Margin;
                if (m_Scale[0])
                    m_Panel[0].SetBounds(m.Left, m.Top, w - m.Left - m.Right, (h*0.5f) - m.Top - m.Bottom);
                else
                    m_Panel[0].SetPosition(Pos.Center, 0, (int) (h*-0.25f));
            }

            if (m_Panel[1] != null)
            {
                Margin m = m_Panel[1].Margin;
                if (m_Scale[1])
                    m_Panel[1].SetBounds(m.Left, m.Top + (h*0.5f), w - m.Left - m.Right, (h*0.5f) - m.Top - m.Bottom);
                else
                    m_Panel[1].SetPosition(Pos.Center, 0, (int) (h*0.25f));
            }
        }

        protected virtual void LayoutHorizontal(Skin.Base skin)
        {
            throw new NotImplementedException();
        }
    }
}
