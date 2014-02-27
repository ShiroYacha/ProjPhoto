namespace TravelJournal.WinForm.Simulator.Controls.Components
{
    partial class ConnectionViewer
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
            TravelJournal.WinForm.Simulator.Controls.ChartPen chartPen1 = new TravelJournal.WinForm.Simulator.Controls.ChartPen();
            TravelJournal.WinForm.Simulator.Controls.ChartPen chartPen2 = new TravelJournal.WinForm.Simulator.Controls.ChartPen();
            TravelJournal.WinForm.Simulator.Controls.ChartPen chartPen3 = new TravelJournal.WinForm.Simulator.Controls.ChartPen();
            TravelJournal.WinForm.Simulator.Controls.ChartPen chartPen4 = new TravelJournal.WinForm.Simulator.Controls.ChartPen();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.perfChart = new TravelJournal.WinForm.Simulator.Controls.PerfChart();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.perfChart, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(495, 328);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(221, 15);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Latency monitor (max/mean in seconds)";
            // 
            // perfChart
            // 
            this.perfChart.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.perfChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perfChart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.perfChart.Location = new System.Drawing.Point(3, 18);
            this.perfChart.Name = "perfChart";
            this.perfChart.PerfChartStyle.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen1.Width = 1F;
            this.perfChart.PerfChartStyle.AvgLinePen = chartPen1;
            this.perfChart.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.perfChart.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            chartPen2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen2.Width = 1F;
            this.perfChart.PerfChartStyle.ChartLinePen = chartPen2;
            chartPen3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen3.Width = 1F;
            this.perfChart.PerfChartStyle.HorizontalGridPen = chartPen3;
            this.perfChart.PerfChartStyle.ShowAverageLine = true;
            this.perfChart.PerfChartStyle.ShowHorizontalGridLines = true;
            this.perfChart.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen4.Width = 1F;
            this.perfChart.PerfChartStyle.VerticalGridPen = chartPen4;
            this.perfChart.ScaleMode = TravelJournal.WinForm.Simulator.Controls.ScaleMode.Absolute;
            this.perfChart.Size = new System.Drawing.Size(489, 307);
            this.perfChart.TabIndex = 1;
            this.perfChart.TimerInterval = 100;
            this.perfChart.TimerMode = TravelJournal.WinForm.Simulator.Controls.TimerMode.Disabled;
            // 
            // ConnectionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConnectionViewer";
            this.Size = new System.Drawing.Size(495, 328);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private PerfChart perfChart;
        private System.Windows.Forms.Label titleLabel;
    }
}
