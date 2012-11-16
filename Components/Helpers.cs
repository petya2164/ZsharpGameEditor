using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Input;

namespace ZGE.Components
{
    #region MouseDescriptor
    public class MouseDescriptor
    {
        public MouseDescriptor() { }

        readonly bool[] button_state = new bool[Enum.GetValues(typeof(MouseButton)).Length];
        //public int Clicks { get; }
        public MouseButton Button { get; set; }
        public int WheelDelta { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Gets a System.Boolean indicating the state of the specified MouseButton.
        /// </summary>
        /// <param name="button">The MouseButton to check.</param>
        /// <returns>True if the MouseButton is pressed, false otherwise.</returns>
        public bool this[MouseButton button]
        {
            get
            {
                return button_state[(int) button];
            }
            set
            {
                button_state[(int) button] = value;
            }
        }
    }
    #endregion

    #region MovingAverage
    public class MovingAverage
    {
        double[] values = new double[60];  // all 0's initially
        double sum = 0;
        int pos = 0;

        public MovingAverage() { }

        public void AddValue(double v)
        {
            sum -= values[pos];  // only need the array to subtract old value
            sum += v;
            values[pos] = v;
            pos = (pos + 1) % values.Length;
        }

        public double Average()
        {
            return sum / values.Length;
        }
    }
    #endregion
}
