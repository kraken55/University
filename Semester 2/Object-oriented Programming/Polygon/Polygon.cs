using System;
using TextFile;

namespace Polygon
{
    class Polygon
    {
        public class FewVerticesException : Exception { }

        private readonly Point[] vertices;

        public int Sides
        {
            get { return vertices.Length; }
        }

        public Point this[int i]
        {
            get { return vertices[i]; }
            set { vertices[i] = value; }
        }

        public Polygon(int m)
        {
            if (m < 3)
            {
                throw new FewVerticesException();
            }

            vertices = new Point[m];
            for (int i = 0; i < m; i++)
            {
                vertices[i] = new Point();
            }
        }

        public static Polygon Create(TextFileReader reader, int sides)
        {
            Polygon p = new Polygon(sides);
            for (int i = 0; i < sides; i++)
            {
                reader.ReadDouble(out double x);
                reader.ReadDouble(out double y);
                p[i].setPoint(x, y);
            }

            return p;
        }

        public void Shift(Point e)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = vertices[i] + e;
            }
        }

        public Point Centroid()
        {
            Point centroid = new Point();
            foreach (Point vertex in vertices)
            {
                centroid += vertex;
            }
            centroid /= Sides;
            return centroid;
        }

        public override string ToString()
        {
            string str = "< ";
            foreach (Point vertex in vertices)
            {
                str += vertex.ToString();
            }
            str += " >";
            return str;
        }
    }
}