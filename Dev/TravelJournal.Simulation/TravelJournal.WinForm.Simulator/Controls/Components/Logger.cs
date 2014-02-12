using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace TravelJournal.WinForm.Simulator.Controls
{
    public enum LogType{Info=0,Error=1,Warning=2};
    public partial class Logger : UserControl,ITestControl
    {
        public Logger()
        {
            InitializeComponent();
            // Rendering
            RenderListView();
        }

        private void RenderListView()
        {
            // Render column
            int columnWidth = listView.Width;
            listView.Columns[0].Width = (int)(columnWidth * 0.1);
            listView.Columns[1].Width = (int)(columnWidth *0.5);
            listView.Columns[2].Width = (int)(columnWidth *0.3);
            listView.Columns[3].Width = (int)(columnWidth);
            // Render header
            listView.DrawColumnHeader += (o, e) =>
            {
                Rectangle textBound = e.Bounds;
                textBound.Offset(4, 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), e.Bounds);
                e.Graphics.DrawString(e.Header.Text, new Font("Segoe UI Light", 10), new SolidBrush(Color.FromArgb(245, 245, 245)), textBound);
            };
            // Render sub item handler
            listView.DrawSubItem += (o, e) =>
            {
                Rectangle textBound = e.Bounds;
                textBound.Offset(4, 2);
                RectangleF shrinkBound = e.Bounds;
                shrinkBound.Inflate(-0.5F, -0.5F);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(48, 48, 48)), e.Bounds);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(18, 18, 18)), shrinkBound);
                e.Graphics.DrawString(e.SubItem.Text, new Font("Segoe UI Light", 9), new SolidBrush((Color)(e.Item.Tag??Color.FromArgb(245,245,245))), textBound);
            };
            // Enable double buffer
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        public void Log(LogType type,string log,string callerName, string callerFilePath,  int callerLine)
        {
            listView.BeginUpdate();
            ListViewItem item = new ListViewItem(DateTime.Now.ToLongTimeString());
            switch(type)
            {
                case LogType.Warning:
                    item.Tag = Color.Yellow;
                    break;
                case LogType.Error:
                    item.Tag = Color.OrangeRed;
                    break;
                default: break;
            }
            item.SubItems.Add(string.Format("{0} :({1})",callerFilePath.Remove(0,callerFilePath.LastIndexOf(@"\")),callerLine));
            item.SubItems.Add(callerName);
            item.SubItems.Add(log);
            listView.Items.Add(item);
            listView.EnsureVisible(listView.Items.Count - 1);
            listView.EndUpdate();
        }

        public void Initialize()
        {
            listView.Items.Clear();
        }
    }
}
