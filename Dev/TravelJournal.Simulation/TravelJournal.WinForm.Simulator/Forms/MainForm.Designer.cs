namespace TravelJournal.WinForm.Simulator.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelJournalClassificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.descriptionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.projectDescriptionLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.descriptionFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(1268, 28);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.travelJournalClassificationToolStripMenuItem});
            this.projectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.projectToolStripMenuItem.Text = "PROJECT";
            this.projectToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.projectToolStripMenuItem_DropDownItemClicked);
            // 
            // travelJournalClassificationToolStripMenuItem
            // 
            this.travelJournalClassificationToolStripMenuItem.Name = "travelJournalClassificationToolStripMenuItem";
            this.travelJournalClassificationToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.travelJournalClassificationToolStripMenuItem.Tag = "TravelJournalGenerationSimulation";
            this.travelJournalClassificationToolStripMenuItem.Text = "Travel journal generation";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.settingsToolStripMenuItem.Text = "SETTINGS";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsSToolStripMenuItem_Click);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mainTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.descriptionFlowLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.ForeColor = System.Drawing.Color.Black;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 30);
            this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1268, 802);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // descriptionFlowLayoutPanel
            // 
            this.descriptionFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.descriptionFlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.descriptionFlowLayoutPanel.Controls.Add(this.projectNameLabel);
            this.descriptionFlowLayoutPanel.Controls.Add(this.projectDescriptionLabel);
            this.descriptionFlowLayoutPanel.Location = new System.Drawing.Point(0, 7);
            this.descriptionFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.descriptionFlowLayoutPanel.Name = "descriptionFlowLayoutPanel";
            this.descriptionFlowLayoutPanel.Size = new System.Drawing.Size(1268, 58);
            this.descriptionFlowLayoutPanel.TabIndex = 2;
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameLabel.ForeColor = System.Drawing.Color.White;
            this.projectNameLabel.Location = new System.Drawing.Point(11, 0);
            this.projectNameLabel.Margin = new System.Windows.Forms.Padding(11, 0, 4, 0);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(187, 46);
            this.projectNameLabel.TabIndex = 0;
            this.projectNameLabel.Text = "TestProject";
            this.projectNameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // projectDescriptionLabel
            // 
            this.projectDescriptionLabel.AutoSize = true;
            this.projectDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.projectDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectDescriptionLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.projectDescriptionLabel.Location = new System.Drawing.Point(206, 15);
            this.projectDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.projectDescriptionLabel.Name = "projectDescriptionLabel";
            this.projectDescriptionLabel.Size = new System.Drawing.Size(168, 19);
            this.projectDescriptionLabel.TabIndex = 1;
            this.projectDescriptionLabel.Text = "This test project is about...";
            this.projectDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1268, 832);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TravelJournal.WinForm.Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.descriptionFlowLayoutPanel.ResumeLayout(false);
            this.descriptionFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel descriptionFlowLayoutPanel;
        private System.Windows.Forms.Label projectNameLabel;
        private System.Windows.Forms.Label projectDescriptionLabel;
        private System.Windows.Forms.ToolStripMenuItem travelJournalClassificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

    }
}

