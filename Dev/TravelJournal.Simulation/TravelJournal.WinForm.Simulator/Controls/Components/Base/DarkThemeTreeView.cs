using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelJournal.WinForm.Simulator.Rendering;

namespace TravelJournal.WinForm.Simulator.Controls
{
    public class DarkThemeTreeView : TreeView
    {
        public DarkThemeTreeView()
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.Font = new Font(new FontFamily("Candara"), 10.2f);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            TreeNodeStates state = e.State;
            Font font = this.Font;
            Color fore = Color.White;
            // Rectangle resizedBound
            Size textActualSize = TextRenderer.MeasureText(e.Node.Text, font);
            Rectangle resizedBound = new Rectangle(e.Bounds.X, e.Bounds.Y, textActualSize.Width, e.Bounds.Height);
            if (e.Node == e.Node.TreeView.SelectedNode)
            {
                fore = Color.Black;
                ControlPaint.DrawFocusRectangle(e.Graphics, resizedBound, fore, Color.DeepSkyBlue);
                e.Graphics.FillRectangle(new SolidBrush(Color.DodgerBlue), resizedBound);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, resizedBound, fore, Color.DeepSkyBlue, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(24,24,24)), resizedBound);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, resizedBound, fore, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DarkThemeTreeView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ResumeLayout(false);
        }

    }
}
