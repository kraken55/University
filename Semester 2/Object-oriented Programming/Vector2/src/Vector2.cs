using System;

namespace Vector2
{
    internal class Vector2
    {
        public int x { get; }
        public int y { get; }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static int operator *(Vector2 v1, Vector2 v2)
        {
            return (v1.x * v2.x + v1.y * v2.y);
        }

        public bool isPerpendicularTo(Vector2 v)
        {
            return (this * v == 0);
        }
    }
}