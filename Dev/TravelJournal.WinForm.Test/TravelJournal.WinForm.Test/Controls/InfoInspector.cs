using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelJournal.WinForm.Test.Controls
{
    public class DoubleBufferedListView : ListView
    {
        public DoubleBufferedListView()
            : base()
        {
            this.DoubleBuffered = true;
        }

    }

    public partial class InfoInspector : UserControl
    {
        private List<string> infoList = new List<string>();

        public InfoInspector()
        {
            InitializeComponent();
            // Rendering
            RenderListView();
        }

        private void RenderListView()
        {
            // Render column
            int columnWidth = this.Width;
            listView.Columns[0].Width = columnWidth / 2 -15;
            listView.Columns[1].Width = columnWidth / 2 -1;
            // Render sub item handler
            listView.DrawSubItem += (o, e) =>
            {
                Rectangle textBound = e.Bounds;
                textBound.Offset(4, 2);
                RectangleF shrinkBound = e.Bounds;
                shrinkBound.Inflate(-0.5F,-0.5F);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(48, 48, 48)), e.Bounds);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(18, 18, 18)), shrinkBound);
                e.Graphics.DrawString(e.SubItem.Text, new Font("Segoe UI Light", 10), new SolidBrush(Color.FromArgb(245, 245, 245)), textBound);
            };
            // Enable double buffer
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        public void UpdateInfo(SortedDictionary<string, string> infoDict)
        {
            listView.BeginUpdate();
            foreach (KeyValuePair<string, string> info in infoDict)
            {
                if (!infoList.Contains(info.Key))
                {
                    ListViewItem item = new ListViewItem(info.Key);
                    item.Name = info.Key;
                    item.SubItems.Add(info.Value);
                    listView.Items.Add(item);
                    infoList.Add(info.Key);
                }
                else
                {
                    listView.Items[info.Key].SubItems[1].Text = info.Value;
                }
            }
            listView.EndUpdate();
        }
    }
}
