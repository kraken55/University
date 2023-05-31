namespace Polygon
{
    class Point
    {
        public double x, y;

        public Point(double x = 0.0, double y = 0.0)
        {
            this.x = x;
            this.y = y;
        }

        public void setPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static Point operator /(Point a, double n)
        {
            return new Point(a.x / n, a.y / n);
        }

        public override string ToString()
        {
            return string.Format($"({this.x:0.0#}, {this.y:0.0#})");
        }
    }
}