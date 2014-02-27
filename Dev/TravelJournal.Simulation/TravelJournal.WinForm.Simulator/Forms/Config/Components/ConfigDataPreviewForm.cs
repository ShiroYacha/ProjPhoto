using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TravelJournal.WinForm.Simulator.Forms
{
    public partial class ConfigDataPreviewForm : Form
    {
        private const string tempPath = @"temp$.xml";
        private string browserPath;

        public ConfigDataPreviewForm()
        {
            InitializeComponent();
        }

        public void InjectData(ConfigDataBase data)
        {
            XmlSerialization.Serialize<ConfigDataBase>(tempPath, data);
            browserPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), tempPath);
        }

        private void ConfigDataPreviewForm_Load(object sender, EventArgs e)
        {
            webBrowser.Navigate(browserPath);
        }

        private void ConfigDataPreviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete(tempPath);
        }
    }
}
