namespace TravelJournal.WinForm.Test
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelJournalClassificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.descriptionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.projectIconPictureBox = new System.Windows.Forms.PictureBox();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.projectDescriptionLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.descriptionFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(951, 24);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.travelJournalClassificationToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.projectToolStripMenuItem.Text = "PROJECT";
            this.projectToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.projectToolStripMenuItem_DropDownItemClicked);
            // 
            // travelJournalClassificationToolStripMenuItem
            // 
            this.travelJournalClassificationToolStripMenuItem.Name = "travelJournalClassificationToolStripMenuItem";
            this.travelJournalClassificationToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.travelJournalClassificationToolStripMenuItem.Tag = "TravelJournalGenerationSimulation";
            this.travelJournalClassificationToolStripMenuItem.Text = "Travel journal generation";
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.toolToolStripMenuItem.Text = "TOOL";
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.descriptionFlowLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.ForeColor = System.Drawing.Color.Black;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(951, 652);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // descriptionFlowLayoutPanel
            // 
            this.descriptionFlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.descriptionFlowLayoutPanel.Controls.Add(this.projectIconPictureBox);
            this.descriptionFlowLayoutPanel.Controls.Add(this.projectNameLabel);
            this.descriptionFlowLayoutPanel.Controls.Add(this.projectDescriptionLabel);
            this.descriptionFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.descriptionFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.descriptionFlowLayoutPanel.Name = "descriptionFlowLayoutPanel";
            this.descriptionFlowLayoutPanel.Size = new System.Drawing.Size(951, 42);
            this.descriptionFlowLayoutPanel.TabIndex = 2;
            // 
            // projectIconPictureBox
            // 
            this.projectIconPictureBox.BackgroundImage = global::TravelJournal.WinForm.Test.Properties.Resources.appbar_layer;
            this.projectIconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.projectIconPictureBox.Location = new System.Drawing.Point(6, 3);
            this.projectIconPictureBox.Margin = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.projectIconPictureBox.Name = "projectIconPictureBox";
            this.projectIconPictureBox.Size = new System.Drawing.Size(38, 38);
            this.projectIconPictureBox.TabIndex = 0;
            this.projectIconPictureBox.TabStop = false;
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameLabel.ForeColor = System.Drawing.Color.White;
            this.projectNameLabel.Location = new System.Drawing.Point(44, 0);
            this.projectNameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(147, 37);
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
            this.projectDescriptionLabel.Location = new System.Drawing.Point(197, 21);
            this.projectDescriptionLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.projectDescriptionLabel.Name = "projectDescriptionLabel";
            this.projectDescriptionLabel.Size = new System.Drawing.Size(142, 13);
            this.projectDescriptionLabel.TabIndex = 1;
            this.projectDescriptionLabel.Text = "This test project is about...";
            this.projectDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(951, 676);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TravelJournal.WinForm.Simulator";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.descriptionFlowLayoutPanel.ResumeLayout(false);
            this.descriptionFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel descriptionFlowLayoutPanel;
        private System.Windows.Forms.PictureBox projectIconPictureBox;
        private System.Windows.Forms.Label projectNameLabel;
        private System.Windows.Forms.Label projectDescriptionLabel;
        private System.Windows.Forms.ToolStripMenuItem travelJournalClassificationToolStripMenuItem;

    }
}

