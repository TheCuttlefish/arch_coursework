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
            return (point1 - point2).Length();
        }

        public static int RandomRange(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        public static float lerp(float v0, float v1, float t)
        {
            return v0 + t * (v1 - v0);
        }


    }
}
