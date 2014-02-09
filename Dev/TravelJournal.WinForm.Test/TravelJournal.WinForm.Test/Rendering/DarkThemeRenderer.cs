using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelJournal.WinForm.Test
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
            // Do not draw the annoying white line!
        }

    }

    internal class DarkThemeSystemToolStripRenderer : ToolStripSystemRenderer
    {
        public DarkThemeSystemToolStripRenderer() : base() { }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            // Make arrow white
            e.ArrowColor = Color.White;
            base.OnRenderArrow(e);
        }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Do not draw the annoying white line!
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
                return DarkThemeColor.DimDarkBlack;
            }
        }
        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return DarkThemeColor.DimDarkBlack;
            }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return DarkThemeColor.DimDarkBlack;
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
