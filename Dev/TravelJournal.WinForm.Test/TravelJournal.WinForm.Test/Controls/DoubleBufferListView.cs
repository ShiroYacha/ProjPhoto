﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelJournal.WinForm.Test
{
    public class DoubleBufferedListView : ListView
    {
        public DoubleBufferedListView()
            : base()
        {
            this.DoubleBuffered = true;
        }

    }
}
