using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator.Controls
{
    public interface ITestProjectControl
    {
        string TestName { get; }
        string TestDescription { get; }
        void CloseDown();

    }
}
