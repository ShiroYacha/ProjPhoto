using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Remoting;
using System.IO;

namespace TravelJournal.WinForm.Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Rendering
            RenderMenu();
            // Load default
            LoadProject("TravelJournalGenerationSimulation");
        }

        private void RenderMenu()
        {
            // Use the vs2013-like dark theme
            mainMenuStrip.Renderer = new DarkThemeToolStripRenderer();
            // Render menu strip color
            mainMenuStrip.BackColor = Color.FromArgb(64, 64, 64);
            // Define fore color
            foreach (ToolStripMenuItem menuItem in mainMenuStrip.Items)
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

        private void LoadProject(object projectTag)
        {
            ITestWindow testWindow = (Activator.CreateInstance("TravelJournal.WinForm.Test", "TravelJournal.WinForm.Test."+projectTag as string) as ObjectHandle).Unwrap() as ITestWindow;
            SetupProjectDescriptionBar(testWindow);
            SetupProjectWindow(testWindow);
        }

        private void SetupProjectDescriptionBar(ITestWindow window)
        {
            // Setup icon
            string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            folderPath = folderPath.Remove(folderPath.IndexOf("bin"));
            projectIconPictureBox.BackgroundImage = new Bitmap(string.Format("{0}\\Resources\\{1}",folderPath,window.TestIconPath));
            // Setup name label
            projectNameLabel.Text = window.TestName;
            // Setup description label
            projectDescriptionLabel.Text = window.TestDescription;
            
        }

        private void SetupProjectWindow(ITestWindow window)
        {
            // Empty control
            if(mainTableLayoutPanel.Controls.Count==2) mainTableLayoutPanel.Controls.RemoveAt(1);
            // Add control
            mainTableLayoutPanel.Controls.Add(window as Control);
        }

        private void projectToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LoadProject(e.ClickedItem.Tag);
        }
    }
}
