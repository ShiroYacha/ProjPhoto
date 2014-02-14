namespace TravelJournal.WinForm.Simulator
{
    partial class TravelJournalGenerationSimulation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TravelJournalGenerationSimulation));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.connectButton = new System.Windows.Forms.ToolStripButton();
            this.settingButton = new System.Windows.Forms.ToolStripButton();
            this.testButton = new System.Windows.Forms.ToolStripButton();
            this.separator = new System.Windows.Forms.ToolStripSeparator();
            this.designButton = new System.Windows.Forms.ToolStripButton();
            this.playButton = new System.Windows.Forms.ToolStripButton();
            this.pauseButton = new System.Windows.Forms.ToolStripButton();
            this.resetButton = new System.Windows.Forms.ToolStripButton();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.stateMachineViewer = new TravelJournal.WinForm.Simulator.Controls.StateMachineViewer();
            this.infoInspector = new TravelJournal.WinForm.Simulator.Controls.InfoInspector();
            this.rightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logger = new TravelJournal.WinForm.Simulator.Controls.Logger();
            this.travelMapPlayer = new TravelJournal.WinForm.Simulator.Controls.TravelMapPlayer();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.leftTableLayoutPanel.SuspendLayout();
            this.rightTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.Black;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectButton,
            this.settingButton,
            this.testButton,
            this.toolStripSeparator1,
            this.designButton,
            this.separator,
            this.playButton,
            this.pauseButton,
            this.resetButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1267, 43);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // connectButton
            // 
            this.connectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectButton.Image = ((System.Drawing.Image)(resources.GetObject("connectButton.Image")));
            this.connectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectButton.Margin = new System.Windows.Forms.Padding(15, 5, 0, 5);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(23, 33);
            this.connectButton.Text = "toolStripButton1";
            // 
            // settingButton
            // 
            this.settingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingButton.Image = ((System.Drawing.Image)(resources.GetObject("settingButton.Image")));
            this.settingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingButton.Margin = new System.Windows.Forms.Padding(15, 5, 0, 5);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(23, 33);
            this.settingButton.Text = "toolStripButton1";
            this.settingButton.Click += new System.EventHandler(this.settingButton_Click);
            // 
            // testButton
            // 
            this.testButton.CheckOnClick = true;
            this.testButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.testButton.Image = ((System.Drawing.Image)(resources.GetObject("testButton.Image")));
            this.testButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.testButton.Margin = new System.Windows.Forms.Padding(15, 5, 0, 5);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(23, 33);
            this.testButton.Text = "toolStripButton1";
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.Color.RoyalBlue;
            this.separator.ForeColor = System.Drawing.Color.RoyalBlue;
            this.separator.Margin = new System.Windows.Forms.Padding(15, 5, 0, 5);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(6, 33);
            // 
            // designButton
            // 
            this.designButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.designButton.Image = ((System.Drawing.Image)(resources.GetObject("designButton.Image")));
            this.designButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.designButton.Margin = new System.Windows.Forms.Padding(15, 5, 0, 5);
            this.designButton.Name = "designButton";
            this.designButton.Size = new System.Drawing.Size(23, 33);
            this.designButton.Text = "toolStripButton1";
            this.designButton.Click += new System.EventHandler(this.designButton_Click);
            // 
            // playButton
            // 
            this.playButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
            this.playButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playButton.Margin = new System.Windows.Forms.Padding(15, 3, 0, 4);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(23, 36);
            this.playButton.Text = "toolStripButton1";
            // 
            // pauseButton
            // 
            this.pauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseButton.Image")));
            this.pauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseButton.Margin = new System.Windows.Forms.Padding(15, 5, 0, 5);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(23, 33);
            this.pauseButton.Text = "toolStripButton1";
            // 
            // resetButton
            // 
            this.resetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetButton.Margin = new System.Windows.Forms.Padding(15, 5, 0, 5);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(23, 33);
            this.resetButton.Text = "toolStripButton1";
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 348F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.leftTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.rightTableLayoutPanel, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 43);
            this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1267, 702);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // leftTableLayoutPanel
            // 
            this.leftTableLayoutPanel.ColumnCount = 1;
            this.leftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftTableLayoutPanel.Controls.Add(this.stateMachineViewer, 0, 0);
            this.leftTableLayoutPanel.Controls.Add(this.infoInspector, 0, 1);
            this.leftTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.leftTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.leftTableLayoutPanel.Name = "leftTableLayoutPanel";
            this.leftTableLayoutPanel.RowCount = 2;
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftTableLayoutPanel.Size = new System.Drawing.Size(344, 702);
            this.leftTableLayoutPanel.TabIndex = 0;
            // 
            // stateMachineViewer
            // 
            this.stateMachineViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.stateMachineViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stateMachineViewer.Location = new System.Drawing.Point(0, 0);
            this.stateMachineViewer.Margin = new System.Windows.Forms.Padding(0);
            this.stateMachineViewer.Name = "stateMachineViewer";
            this.stateMachineViewer.Size = new System.Drawing.Size(344, 330);
            this.stateMachineViewer.TabIndex = 1;
            this.stateMachineViewer.ViewerSize = new System.Drawing.Size(10, 10);
            // 
            // infoInspector
            // 
            this.infoInspector.AutoSize = true;
            this.infoInspector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoInspector.Location = new System.Drawing.Point(0, 334);
            this.infoInspector.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.infoInspector.Name = "infoInspector";
            this.infoInspector.Size = new System.Drawing.Size(344, 368);
            this.infoInspector.TabIndex = 2;
            // 
            // rightTableLayoutPanel
            // 
            this.rightTableLayoutPanel.ColumnCount = 1;
            this.rightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightTableLayoutPanel.Controls.Add(this.logger, 0, 1);
            this.rightTableLayoutPanel.Controls.Add(this.travelMapPlayer, 0, 0);
            this.rightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTableLayoutPanel.Location = new System.Drawing.Point(348, 0);
            this.rightTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rightTableLayoutPanel.Name = "rightTableLayoutPanel";
            this.rightTableLayoutPanel.RowCount = 2;
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.rightTableLayoutPanel.Size = new System.Drawing.Size(919, 702);
            this.rightTableLayoutPanel.TabIndex = 1;
            // 
            // logger
            // 
            this.logger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logger.Location = new System.Drawing.Point(0, 459);
            this.logger.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.logger.Name = "logger";
            this.logger.Size = new System.Drawing.Size(919, 243);
            this.logger.TabIndex = 0;
            // 
            // travelMapPlayer
            // 
            this.travelMapPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.travelMapPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travelMapPlayer.Location = new System.Drawing.Point(0, 0);
            this.travelMapPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.travelMapPlayer.Name = "travelMapPlayer";
            this.travelMapPlayer.Size = new System.Drawing.Size(919, 455);
            this.travelMapPlayer.TabIndex = 1;
            this.travelMapPlayer.Load += new System.EventHandler(this.travelMapPlayer_Load);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.RoyalBlue;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(15, 5, 0, 5);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // TravelJournalGenerationSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TravelJournalGenerationSimulation";
            this.Size = new System.Drawing.Size(1267, 745);
            this.Load += new System.EventHandler(this.TravelJournalGenerationSimulation_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.leftTableLayoutPanel.ResumeLayout(false);
            this.leftTableLayoutPanel.PerformLayout();
            this.rightTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel leftTableLayoutPanel;
        private Controls.StateMachineViewer stateMachineViewer;
        private Controls.InfoInspector infoInspector;
        private System.Windows.Forms.TableLayoutPanel rightTableLayoutPanel;
        private Controls.Logger logger;
        private Controls.TravelMapPlayer travelMapPlayer;
        private System.Windows.Forms.ToolStripButton connectButton;
        private System.Windows.Forms.ToolStripButton testButton;
        private System.Windows.Forms.ToolStripButton designButton;
        private System.Windows.Forms.ToolStripSeparator separator;
        private System.Windows.Forms.ToolStripButton playButton;
        private System.Windows.Forms.ToolStripButton pauseButton;
        private System.Windows.Forms.ToolStripButton resetButton;
        private System.Windows.Forms.ToolStripButton settingButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

    }
}
