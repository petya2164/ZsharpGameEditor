﻿using System;
using ZGE.Components;

namespace Gwen.Control.Property
{
    /// <summary>
    /// Text property.
    /// </summary>
    [HideComponent]
    public class Text : PropertyBase
    {
        protected readonly TextBox m_TextBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public Text(Control.GUIControl parent) : base(parent)
        {
            m_TextBox = new TextBox(this);
            m_TextBox.Dock = Pos.Fill;
            m_TextBox.ShouldDrawBackground = false;
            m_TextBox.TextChanged += OnValueChanged;
        }

        /// <summary>
        /// Property value.
        /// </summary>
        public override string Value
        {
            get { return m_TextBox.Text; }
            set { base.Value = value; }
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="value">Value to set.</param>
        /// <param name="fireEvents">Determines whether to fire "value changed" event.</param>
        public override void SetValue(string value, bool fireEvents)
        {
            m_TextBox.SetText(value, fireEvents);
        }

        /// <summary>
        /// Indicates whether the property value is being edited.
        /// </summary>
        public override bool IsEditing
        {
            get { return m_TextBox.HasFocus; }
        }

        /// <summary>
        /// Indicates whether the control is hovered by mouse pointer.
        /// </summary>
        public override bool IsHovered
        {
            get { return base.IsHovered | m_TextBox.IsHovered; }
        }
    }
}
