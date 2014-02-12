using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    public interface IConfigData
    {
        event Action<IConfigData> OnDataChanged;
        event Action<IConfigData> OnDataChanging;
        string ConfigName { get;}
        string Extension { get; }
    }
}
