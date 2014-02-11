using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelJournal.WinForm.Simulator.Rendering
{
    internal class DarkThemeToolStripRenderer : ToolStripProfessionalRenderer
    {
        public DarkThemeToolStripRenderer() : base(new MyColors()) { }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            // Make arrow white
            e.ArrowColor = Color.White;
            base.OnRenderArrow(e);
        }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Draw drop down border only
            if(e.ToolStrip.IsDropDown) base.OnRenderToolStripBorder(e);
        }
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (!e.Vertical || (e.Item as ToolStripSeparator) == null)
                base.OnRenderSeparator(e);
            else
            {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                bounds.Y += 3;
                bounds.Height = Math.Max(0, bounds.Height - 6);
                if (bounds.Height >= 4) bounds.Inflate(0, -4);
                Pen pen = new Pen(Color.DimGray);
                int x = bounds.Width / 2;
                e.Graphics.DrawLine(pen, x, bounds.Top, x, bounds.Bottom - 1);
                pen.Dispose();
 
            }
        } 

    }

    internal class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get
            {
                return Color.DimGray;
            }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.DimGray;
            }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.DimGray;
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return DarkThemeColor.DarkBlack;
            }
        }
        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return DarkThemeColor.DarkBlack;
            }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return DarkThemeColor.DarkBlack;
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.Black;
            }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.Black;
            }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return DarkThemeColor.DimDarkBlack;
            }
        }


        public override Color ToolStripGradientBegin
        {
            get
            {
                return DarkThemeColor.DimDarkGray;
            }
        }
        public override Color ToolStripGradientMiddle
        {
            get
            {
                return DarkThemeColor.DimDarkGray;
            }
        }
        public override Color ToolStripGradientEnd
        {
            get
            {
                return DarkThemeColor.DimDarkGray;
            }
        }
        public override Color ToolStripBorder
        {
            get
            {
                return DarkThemeColor.DimDarkGray;
            }
        }

        public override Color ButtonPressedGradientBegin
        {
            get
            {
                return Color.DeepSkyBlue;
            }
        }
        public override Color ButtonPressedGradientMiddle
        {
            get
            {
                return Color.DeepSkyBlue;
            }
        }
        public override Color ButtonPressedGradientEnd
        {
            get
            {
                return Color.DeepSkyBlue;
            }
        }
        public override Color ButtonSelectedGradientBegin
        {
            get
            {
                return Color.DimGray;
            }
        }
        public override Color ButtonSelectedGradientMiddle
        {
            get
            {
                return Color.DimGray;
            }
        }
        public override Color ButtonSelectedGradientEnd
        {
            get
            {
                return Color.DimGray;
            }
        }

        public override Color ButtonCheckedGradientBegin
        {
            get
            {
                return Color.SteelBlue;
            }
        }
        public override Color ButtonCheckedGradientMiddle
        {
            get
            {
                return Color.SteelBlue;
            }
        }
        public override Color ButtonCheckedGradientEnd
        {
            get
            {
                return Color.SteelBlue;
            }
        }
    }
    
}
