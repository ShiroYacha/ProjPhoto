using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelJournal.WinForm.Simulator.Rendering;

namespace TravelJournal.WinForm.Simulator.Forms
{
    public partial class ConfigForm<T> : Form where T : ConfigDataBase
    {
        private ConfigDataPreviewForm dataPreviewer;
        protected T data;
        private string extension;

        public ConfigForm()
        {
            InitializeComponent();
            // Rendering
            RenderMenu();
        }

        public T Data
        {
            get
            {
                return data;
            }
            set
            {
                OnDataSet(value);
            }
        }

        #region Private methods
        private void RenderMenu()
        {
            // Use the vs2013-like dark theme
            menuStrip.Renderer = new DarkThemeToolStripRenderer();
            // Render menu strip color
            menuStrip.BackColor = Color.FromArgb(48, 48, 48);
            // Define fore color
            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
            {
                menuItem.ForeColor = Color.White;
                foreach (ToolStripItem dropDownItem in menuItem.DropDownItems)
                {
                    dropDownItem.ForeColor = Color.White;
                    if (dropDownItem is ToolStripDropDownItem)
                        foreach (ToolStripItem drop2DownItem in ((ToolStripDropDownItem)dropDownItem).DropDownItems)
                            drop2DownItem.ForeColor = Color.White;
                }
            }
        }
        private void LaunchDataPreviewer()
        {
            dataPreviewer = new ConfigDataPreviewForm();
            dataPreviewer.InjectData(data as ConfigDataBase);
            dataPreviewer.ShowDialog();
        } 
        #endregion

        protected virtual void OnDataSet(T data)
        {
            this.data = data;
            this.data.DataChanging += this.OnDataChanging;
            this.data.DataChanged += this.OnDataChanged;
        }
        private void OnDataChanging(ConfigDataBase data) { OnDataChanging((T)data); }
        private void OnDataChanged(ConfigDataBase data) { OnDataChanged((T)data); }
        protected virtual void OnDataChanging(T data){ }
        protected virtual void OnDataChanged(T data) { }
        
        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchDataPreviewer();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                if (data == null)
                {
                    this.Close();
                    return;
                }
                this.Text = data.ConfigName;
                this.extension = data.Extension;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.Initialize();
        }

    }
}
