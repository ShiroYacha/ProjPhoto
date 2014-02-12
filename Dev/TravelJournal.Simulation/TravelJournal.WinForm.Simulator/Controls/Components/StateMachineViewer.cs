using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TravelJournal.WinForm.Simulator.Controls
{
    public partial class StateMachineViewer : UserControl,ITestControl
    {
        private List<State> states = new List<State>();
        private Size viewerSize = new Size(10,10);

        private float playBoardWidth;
        private float playBoardHeight;
        private float widthStep;
        private float heightStep;

        public Size ViewerSize
        {
            get { return viewerSize; }
            set 
            {
                viewerSize = value; 
                playBoardWidth = pictureBox.Width;
                playBoardHeight = pictureBox.Height;
                widthStep = playBoardWidth / viewerSize.Width;
                heightStep = playBoardHeight / viewerSize.Height;
            }
        }

        public StateMachineViewer()
        {
            InitializeComponent();
            // Add paint handler
            pictureBox.Paint += pictureBox_Paint;
            this.Height = this.Width;
        }

        public StateMachineViewer AddState(State state)
        {
            states.Add(state);
            return this;
        }

        public void NavigateToState(int id)
        {
            foreach (State state in states)
                if (state.ID == id)
                    state.IsActive = true;
                else
                    state.IsActive = false;
            // Refresh
            pictureBox.Invalidate();
        }

        #region Render state machine
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (State state in states)
            {
                Pen statePen = new Pen(Brushes.White, 3);
                Brush stateBrush = Brushes.White;
                Brush stateActiveBrush = Brushes.DodgerBlue;
                Pen transitionPen = new Pen(Brushes.Gray, 3);
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4);
                transitionPen.StartCap = LineCap.Round;
                transitionPen.CustomEndCap = bigArrow;
                // Draw state
                float radius = Math.Min(widthStep / 2, heightStep / 2);
                PointF center = GetCenter(state);
                RectangleF rect = new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2);
                if (state.IsActive) e.Graphics.FillEllipse(stateActiveBrush, rect);
                e.Graphics.DrawEllipse(statePen, rect);
                // Draw transition arrow
                if (state.ToStates != null)
                    foreach (State toState in state.ToStates)
                        DrawTransitionArrow(e.Graphics, transitionPen, center, GetCenter(toState), radius);
                // Draw ID
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(state.ID.ToString(), this.Font, stateBrush, rect, sf);
            }
        }
        private Point GetCenter(State state)
        {
            return new Point((int)(widthStep * (state.Column + 0.5f)), (int)(heightStep * (state.Row + 0.5f)));
        }
        private void DrawTransitionArrow(Graphics g, Pen transitionPen, PointF start, PointF end, float radius)
        {
            double tangent = (end.Y - start.Y) / (end.X - start.X);
            double theta = Math.Atan((tangent));
            PointF realStart;
            PointF realEnd;
            float modRadius = radius + 3;
            if (tangent > 0 || Double.IsInfinity(tangent))
            {
                realStart = new PointF((float)(start.X + modRadius * Math.Cos(theta)), (float)(start.Y + modRadius * Math.Sin(theta)));
                realEnd = new PointF((float)(end.X - radius * Math.Cos(theta)), (float)(end.Y - radius * Math.Sin(theta)));
            }
            else
            {
                realStart = new PointF((float)(start.X - modRadius * Math.Cos(theta)), (float)(start.Y - modRadius * Math.Sin(theta)));
                realEnd = new PointF((float)(end.X + radius * Math.Cos(theta)), (float)(end.Y + radius * Math.Sin(theta)));
            }
            g.DrawLine(transitionPen, realStart, realEnd);
        } 
        #endregion

        public void Initialize()
        {
            states.Clear();
            pictureBox.Invalidate();
        }
    }

    public class State
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public List<State> ToStates { get; set; }
    }
}
