using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace GameEngine
{
    public static class Mathf
    {
        public static double Distance(Vector2 point1, Vector2 point2)
        {
            return (point1 - point2).Length();
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomRange(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        public static Vector2 LerpVector2(Vector2 from, Vector2 to, float steps)
        {
            return from -= (to - from) / steps;
        }


    }
}
