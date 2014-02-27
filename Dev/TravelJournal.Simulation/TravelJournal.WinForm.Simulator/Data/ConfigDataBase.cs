using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    [DataContract]
    public abstract class ConfigDataBase
    {
        public event Action<ConfigDataBase> DataChanged;
        public event Action<ConfigDataBase> DataChanging;

        protected ConfigDataBase()
        {
            Initialize();
        }

        #region Protected members
        protected void OnDataChanged()
        {
            if (DataChanged != null)
                DataChanged(this);
        }
        protected void OnDataChanging()
        {
            if (DataChanging != null)
                DataChanging(this);
        } 
        #endregion

        #region Public abstract members
        public abstract string ConfigName { get; }
        public abstract string ExtensionFilter { get; }
        public abstract Dictionary<string, object> Display();
        public abstract void Initialize(); 
        #endregion
    }
}
