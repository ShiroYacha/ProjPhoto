namespace TravelJournal.WinForm.Test
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
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statusTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.stateMachineViewer = new TravelJournal.WinForm.Test.Controls.StateMachineViewer();
            this.infoInspector = new TravelJournal.WinForm.Test.Controls.InfoInspector();
            this.logger = new TravelJournal.WinForm.Test.Controls.Logger();
            this.travelMapPlayer = new TravelJournal.WinForm.Test.Controls.TravelMapPlayer();
            this.mainTableLayoutPanel.SuspendLayout();
            this.statusTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.statusTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(950, 605);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // statusTableLayoutPanel
            // 
            this.statusTableLayoutPanel.ColumnCount = 1;
            this.statusTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.statusTableLayoutPanel.Controls.Add(this.stateMachineViewer, 0, 0);
            this.statusTableLayoutPanel.Controls.Add(this.infoInspector, 0, 1);
            this.statusTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.statusTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.statusTableLayoutPanel.Name = "statusTableLayoutPanel";
            this.statusTableLayoutPanel.RowCount = 2;
            this.statusTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.statusTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.statusTableLayoutPanel.Size = new System.Drawing.Size(258, 605);
            this.statusTableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.logger, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.travelMapPlayer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(261, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 605);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // stateMachineViewer
            // 
            this.stateMachineViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.stateMachineViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stateMachineViewer.Location = new System.Drawing.Point(0, 0);
            this.stateMachineViewer.Margin = new System.Windows.Forms.Padding(0);
            this.stateMachineViewer.Name = "stateMachineViewer";
            this.stateMachineViewer.Size = new System.Drawing.Size(258, 238);
            this.stateMachineViewer.TabIndex = 1;
            // 
            // infoInspector
            // 
            this.infoInspector.AutoSize = true;
            this.infoInspector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoInspector.Location = new System.Drawing.Point(0, 241);
            this.infoInspector.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.infoInspector.Name = "infoInspector";
            this.infoInspector.Size = new System.Drawing.Size(258, 364);
            this.infoInspector.TabIndex = 2;
            // 
            // logger
            // 
            this.logger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logger.Location = new System.Drawing.Point(0, 407);
            this.logger.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.logger.Name = "logger";
            this.logger.Size = new System.Drawing.Size(689, 198);
            this.logger.TabIndex = 0;
            // 
            // travelMapPlayer
            // 
            this.travelMapPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.travelMapPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travelMapPlayer.Location = new System.Drawing.Point(0, 0);
            this.travelMapPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.travelMapPlayer.Name = "travelMapPlayer";
            this.travelMapPlayer.Size = new System.Drawing.Size(689, 404);
            this.travelMapPlayer.TabIndex = 1;
            // 
            // TravelJournalGenerationSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.mainTableLayoutPanel);
            this.DoubleBuffered = true;
            this.Name = "TravelJournalGenerationSimulation";
            this.Size = new System.Drawing.Size(950, 605);
            this.Load += new System.EventHandler(this.TravelJournalGenerationSimulation_Load);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.statusTableLayoutPanel.ResumeLayout(false);
            this.statusTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel statusTableLayoutPanel;
        private Controls.StateMachineViewer stateMachineViewer;
        private Controls.InfoInspector infoInspector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.Logger logger;
        private Controls.TravelMapPlayer travelMapPlayer;
    }
}
