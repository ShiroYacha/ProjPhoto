using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GenericUndoRedo;
using System.Drawing.Drawing2D;
using ShapeLib;

namespace UndoRedoByActionDemo
{
    public partial class Form1 : Form
    {
        private ShapePool shapepool = new ShapePool();
        private Point mouseDownPoint;
        private UndoRedoHistory<ShapePool> history;

        public Form1()
        {
            history = new UndoRedoHistory<ShapePool>(shapepool);
            InitializeComponent();
        }

        private void Colors_Click(object sender, EventArgs e)
        {
            redToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;

            ((ToolStripMenuItem)sender).Checked = true;
        }

        private void Shapes_Click(object sender, EventArgs e)
        {
            ellipseToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                history.Do(new AddShapeMemento());
                shapepool.Add(GetShape(e));
            }
            else if (e.Button == MouseButtons.Right)
            {
                List<Shape> toBeRemoved = new List<Shape>();
                Rectangle rect = GetRect(e);
                foreach (Shape s in shapepool)
                {
                    if (rect.Contains(s.Bound))
                        toBeRemoved.Add(s);
                }
                if (toBeRemoved.Count > 0)
                {
                    history.BeginCompoundDo();
                    foreach (Shape s in toBeRemoved)
                    {
                        int index = shapepool.IndexOf(s);
                        history.Do(new RemoveShapeMemento(index, s));
                        shapepool.RemoveAt(index);
                    }
                    history.EndCompoundDo();
                }
            }
            Invalidate();
        }

        private Shape GetShape(MouseEventArgs e)
        {
            Color color = Color.Black;
            Rectangle rect = GetRect(e);
            if (redToolStripMenuItem.Checked)
                color = Color.Red;
            else if (blueToolStripMenuItem.Checked)
                color = Color.Blue;
            else if (greenToolStripMenuItem.Checked)
                color = Color.Green;
            Shape shape;
            if (ellipseToolStripMenuItem.Checked)
                shape = new EllipseShape(color, rect);
            else if (triangleToolStripMenuItem.Checked)
                shape = new TriangleShape(color, rect);
            else
                shape = new RectangleShape(color, rect);
            return shape;
        }

        private Rectangle GetRect(MouseEventArgs e)
        {
            Rectangle rect = new Rectangle(
                Math.Min(e.X, mouseDownPoint.X), Math.Min(e.Y, mouseDownPoint.Y),
                Math.Abs(e.X - mouseDownPoint.X), Math.Abs(e.Y - mouseDownPoint.Y));
            return rect;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Graphics g = CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(BackColor);
                PaintClient(g);
                Pen pen = new Pen(Color.DarkBlue);
                pen.DashStyle = DashStyle.Dash;
                g.DrawRectangle(pen, GetRect(e));
                if (e.Button == MouseButtons.Left)
                {
                    GetShape(e).Paint(g);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            PaintClient(e.Graphics);
        }

        private void PaintClient(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            shapepool.Paint(g);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (history.CanUndo)
            {
                history.Undo();
                Invalidate();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (history.CanRedo)
            {
                history.Redo();
                Invalidate();
            }
        }

        private void editToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = history.CanUndo;
            redoToolStripMenuItem.Enabled = history.CanRedo;
        }
    }
}