using System;
using Gwen.Control;

namespace Gwen
{
    /// <summary>
    /// Utility class for manipulating control's position according to its parent. Rarely needed, use control.Dock.
    /// </summary>
    public static class Align
    {
        /// <summary>
        /// Centers the control inside its parent.
        /// </summary>
        /// <param name="control">Control to center.</param>
        public static void Center(GUIControl control)
        {
            GUIControl parent = control.ParentControl;
            if (parent == null) 
                return;
            control.SetPosition(
                parent.Padding.Left + (((parent.Width - parent.Padding.Left - parent.Padding.Right) - control.Width)/2),
                (parent.Height - control.Height)/2);
        }

        /// <summary>
        /// Moves the control to the left of its parent.
        /// </summary>
        /// <param name="control"></param>
        public static void AlignLeft(GUIControl control)
        {
            GUIControl parent = control.ParentControl;
            if (null == parent) return;

            control.SetPosition(parent.Padding.Left, control.Y);
        }

        /// <summary>
        /// Centers the control horizontally inside its parent.
        /// </summary>
        /// <param name="control"></param>
        public static void CenterHorizontally(GUIControl control)
        {
            GUIControl parent = control.ParentControl;
            if (null == parent) return;


            control.SetPosition(parent.Padding.Left + (((parent.Width - parent.Padding.Left - parent.Padding.Right) - control.Width) / 2), control.Y);
        }

        /// <summary>
        /// Moves the control to the right of its parent.
        /// </summary>
        /// <param name="control"></param>
        public static void AlignRight(GUIControl control)
        {
            GUIControl parent = control.ParentControl;
            if (null == parent) return;


            control.SetPosition(parent.Width - control.Width - parent.Padding.Right, control.Y);
        }

        /// <summary>
        /// Moves the control to the top of its parent.
        /// </summary>
        /// <param name="control"></param>
        public static void AlignTop(GUIControl control)
        {
            control.SetPosition(control.X, 0);
        }

        /// <summary>
        /// Centers the control vertically inside its parent.
        /// </summary>
        /// <param name="control"></param>
        public static void CenterVertically(GUIControl control)
        {
            GUIControl parent = control.ParentControl;
            if (null == parent) return;

            control.SetPosition(control.X, (parent.Height - control.Height) / 2);
        }

        /// <summary>
        /// Moves the control to the bottom of its parent.
        /// </summary>
        /// <param name="control"></param>
        public static void AlignBottom(GUIControl control)
        {
            GUIControl parent = control.ParentControl;
            if (null == parent) return;

            control.SetPosition(control.X, parent.Height - control.Height);
        }

        /// <summary>
        /// Places the control below other control (left aligned), taking margins into account.
        /// </summary>
        /// <param name="control">Control to place.</param>
        /// <param name="anchor">Anchor control.</param>
        /// <param name="spacing">Optional spacing.</param>
        public static void PlaceDownLeft(GUIControl control, GUIControl anchor, int spacing)
        {
            control.SetPosition(anchor.X, anchor.Bottom + spacing);
        }

        /// <summary>
        /// Places the control to the right of other control (bottom aligned), taking margins into account.
        /// </summary>
        /// <param name="control">Control to place.</param>
        /// <param name="anchor">Anchor control.</param>
        /// <param name="spacing">Optional spacing.</param>
        public static void PlaceRightBottom(GUIControl control, GUIControl anchor)
        {
            PlaceRightBottom(control, anchor, 0);
        }
        public static void PlaceRightBottom(GUIControl control, GUIControl anchor, int spacing)
        {
            control.SetPosition(anchor.Right + spacing, anchor.Y - control.Height + anchor.Height);
        }
    }
}
