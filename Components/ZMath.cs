using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace ZGE.Components
{
    /// <summary>
    /// Utility functions.
    /// </summary>
    [HideComponent]
    public static class ZMath
    {
        static Random rnd = new Random();

        // Returns a random float in [0, 1)
        public static float Random()
        {
            return (float) rnd.NextDouble();
        }

        // Returns a random number in the range [-range..range).
        public static float Random(float range)
        {
            return -range + 2.0f * range * Random();
        }

        // Returns a random number in the range [from..to).
        public static float Random(float from, float to)
        {
            return from + (to - from) * Random();
        }

        // Returns a random vector in the specified range.
        public static Vector3 RandomVector(float xRange, float yRange, float zRange)
        {
            return new Vector3(Random(xRange), Random(yRange), Random(zRange));
        }

        public static int Round(float x)
        {
            return (int) Math.Round(x, MidpointRounding.AwayFromZero);
        }
        public static int Floor(float x)
        {
            return (int) Math.Floor(x);
        }
        public static int Ceil(float x)
        {
            return (int) Math.Ceiling(x);
        }

        public static int Clamp(int x, int min, int max)
        {
            if (x < min) return min;
            if (x > max) return max;
            return x;
        }

        public static float Clamp(float x, float min, float max)
        {
            if (x < min) return min;
            if (x > max) return max;
            return x;
        }

        public static float Lerp(float a, float b, float blend)
        {
            return blend * (b - a) + a;           
        }
    }
}
