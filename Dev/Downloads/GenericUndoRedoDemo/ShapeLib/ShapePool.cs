using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShapeLib
{
    [Serializable]
    public class ShapePool : IEnumerable<Shape>
    {
        List<Shape> shapes = new List<Shape>();

        public void Paint(System.Drawing.Graphics graphics)
        {
            foreach (Shape s in shapes)
            {
                s.Paint(graphics);
            }
        }

        public Shape this[int index]
        {
            get { return shapes[index]; }
        }

        public void Add(Shape shape)
        {
            shapes.Add(shape);
        }

        public void Insert(int index, Shape shape)
        {
            shapes.Insert(index, shape);
        }

        public void RemoveAt(int index)
        {
            shapes.RemoveAt(index);
        }

        public int IndexOf(Shape shape)
        {
            return shapes.IndexOf(shape);
        }

        public int Count
        {
            get { return shapes.Count; }
        }

        #region IEnumerable<Shape> Members

        public IEnumerator<Shape> GetEnumerator()
        {
            return shapes.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
