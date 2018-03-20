using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public static class Mathf
    {
        public static double Distance(Vector2 point1, Vector2 point2)
        {
            double a = (double)(point2.X - point1.X);
            double b = (double)(point2.Y - point1.Y);

            return Math.Sqrt(a * a + b * b);
        }

        public static float lerp(float v0, float v1, float t)
        {
            return v0 + t * (v1 - v0);
        }
    }
}
