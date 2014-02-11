using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    internal class DarkThemeColor
    {
        static internal Color DimGray
        {
            get { return Color.FromArgb(64, 64, 64); }
        }

        static internal Color DimDarkGray
        {
            get { return Color.FromArgb(48, 48, 48); }
        }

        static internal Color DimLightBlack
        {
            get { return Color.FromArgb(38, 38, 38); }
        }

        static internal Color DimBlack
        {
            get { return Color.FromArgb(33, 33, 33); }
        }

        static internal Color DarkBlack
        {
            get { return Color.FromArgb(25, 25, 25); }
        }

        static internal Color DimDarkBlack
        {
            get { return Color.FromArgb(20, 20, 20); }
        }
    }
}
