using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ShapeLib
{
    [Serializable]
    public abstract class Shape
    {
        protected Rectangle bound;
        protected Color color;

        public Rectangle Bound
        {
            get { return bound; }
        }

        public Shape(Color color, Rectangle bound)
        {
            this.bound = bound;
            this.color = color;
        }
        
        public abstract void Paint(Graphics g);
        
    }

    [Serializable]
    public class EllipseShape : Shape
    {
        public EllipseShape(Color color, Rectangle bound)
            : base(color, bound)
        {
        }

        public override void Paint(Graphics g)
        {
            g.FillEllipse(new SolidBrush(color), bound);
        }

    }

    [Serializable]
    public class TriangleShape : Shape
    {
        public TriangleShape(Color color, Rectangle bound)
            : base(color, bound)
        {
        }

        public override void Paint(Graphics g)
        {
            g.FillPolygon(new SolidBrush(color), new Point[] {
                new Point((bound.Left + bound.Right) / 2, bound.Top),
                new Point(bound.Left, bound.Bottom),
                new Point(bound.Right, bound.Bottom) });
        }

    }

    [Serializable]
    public class RectangleShape : Shape
    {
        public RectangleShape(Color color, Rectangle rect)
            : base(color, rect)
        {
        }

        public override void Paint(Graphics g)
        {
            g.FillRectangle(new SolidBrush(color), bound);
        }
    }

}
