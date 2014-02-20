namespace TravelJournal.WinForm.Simulator.Controls
{
    partial class ServerConnectivityViewer
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
            TravelJournal.WinForm.Simulator.Controls.ChartPen chartPen5 = new TravelJournal.WinForm.Simulator.Controls.ChartPen();
            TravelJournal.WinForm.Simulator.Controls.ChartPen chartPen6 = new TravelJournal.WinForm.Simulator.Controls.ChartPen();
            TravelJournal.WinForm.Simulator.Controls.ChartPen chartPen7 = new TravelJournal.WinForm.Simulator.Controls.ChartPen();
            TravelJournal.WinForm.Simulator.Controls.ChartPen chartPen8 = new TravelJournal.WinForm.Simulator.Controls.ChartPen();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bottomTitleLabel = new System.Windows.Forms.Label();
            this.flowPerfChart = new TravelJournal.WinForm.Simulator.Controls.PerfChart();
            this.delayPerfChart = new TravelJournal.WinForm.Simulator.Controls.PerfChart();
            this.upperTitleLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.bottomTitleLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowPerfChart, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.delayPerfChart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.upperTitleLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(813, 477);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // bottomTitleLabel
            // 
            this.bottomTitleLabel.AutoSize = true;
            this.bottomTitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.bottomTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomTitleLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.bottomTitleLabel.Location = new System.Drawing.Point(0, 240);
            this.bottomTitleLabel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.bottomTitleLabel.Name = "bottomTitleLabel";
            this.bottomTitleLabel.Size = new System.Drawing.Size(813, 16);
            this.bottomTitleLabel.TabIndex = 3;
            this.bottomTitleLabel.Text = "Upload/download status";
            this.bottomTitleLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // flowPerfChart
            // 
            this.flowPerfChart.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.flowPerfChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPerfChart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.flowPerfChart.Location = new System.Drawing.Point(0, 258);
            this.flowPerfChart.Margin = new System.Windows.Forms.Padding(0);
            this.flowPerfChart.Name = "flowPerfChart";
            this.flowPerfChart.PerfChartStyle.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen1.Width = 1F;
            this.flowPerfChart.PerfChartStyle.AvgLinePen = chartPen1;
            this.flowPerfChart.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.flowPerfChart.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            chartPen2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen2.Width = 1F;
            this.flowPerfChart.PerfChartStyle.ChartLinePen = chartPen2;
            chartPen3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen3.Width = 1F;
            this.flowPerfChart.PerfChartStyle.HorizontalGridPen = chartPen3;
            this.flowPerfChart.PerfChartStyle.ShowAverageLine = true;
            this.flowPerfChart.PerfChartStyle.ShowHorizontalGridLines = true;
            this.flowPerfChart.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen4.Width = 1F;
            this.flowPerfChart.PerfChartStyle.VerticalGridPen = chartPen4;
            this.flowPerfChart.ScaleMode = TravelJournal.WinForm.Simulator.Controls.ScaleMode.Absolute;
            this.flowPerfChart.Size = new System.Drawing.Size(813, 219);
            this.flowPerfChart.TabIndex = 1;
            this.flowPerfChart.TimerInterval = 100;
            this.flowPerfChart.TimerMode = TravelJournal.WinForm.Simulator.Controls.TimerMode.Disabled;
            // 
            // delayPerfChart
            // 
            this.delayPerfChart.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.delayPerfChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delayPerfChart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.delayPerfChart.Location = new System.Drawing.Point(0, 20);
            this.delayPerfChart.Margin = new System.Windows.Forms.Padding(0);
            this.delayPerfChart.Name = "delayPerfChart";
            this.delayPerfChart.PerfChartStyle.AntiAliasing = true;
            chartPen5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen5.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen5.Width = 1F;
            this.delayPerfChart.PerfChartStyle.AvgLinePen = chartPen5;
            this.delayPerfChart.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.delayPerfChart.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            chartPen6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen6.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen6.Width = 1F;
            this.delayPerfChart.PerfChartStyle.ChartLinePen = chartPen6;
            chartPen7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen7.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen7.Width = 1F;
            this.delayPerfChart.PerfChartStyle.HorizontalGridPen = chartPen7;
            this.delayPerfChart.PerfChartStyle.ShowAverageLine = true;
            this.delayPerfChart.PerfChartStyle.ShowHorizontalGridLines = true;
            this.delayPerfChart.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartPen8.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen8.Width = 1F;
            this.delayPerfChart.PerfChartStyle.VerticalGridPen = chartPen8;
            this.delayPerfChart.ScaleMode = TravelJournal.WinForm.Simulator.Controls.ScaleMode.Absolute;
            this.delayPerfChart.Size = new System.Drawing.Size(813, 218);
            this.delayPerfChart.TabIndex = 0;
            this.delayPerfChart.TimerInterval = 100;
            this.delayPerfChart.TimerMode = TravelJournal.WinForm.Simulator.Controls.TimerMode.Disabled;
            // 
            // upperTitleLabel
            // 
            this.upperTitleLabel.AutoSize = true;
            this.upperTitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.upperTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upperTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperTitleLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.upperTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.upperTitleLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.upperTitleLabel.Name = "upperTitleLabel";
            this.upperTitleLabel.Size = new System.Drawing.Size(813, 18);
            this.upperTitleLabel.TabIndex = 2;
            this.upperTitleLabel.Text = "Client -> Service connectivity mesure (latency)";
            this.upperTitleLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ServerConnectivityViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ServerConnectivityViewer";
            this.Size = new System.Drawing.Size(813, 477);
            this.Load += new System.EventHandler(this.ServerConnectivityViewer_Load);
            this.Leave += new System.EventHandler(this.ServerConnectivityViewer_Leave);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private PerfChart delayPerfChart;
        private PerfChart flowPerfChart;
        private System.Windows.Forms.Label upperTitleLabel;
        private System.Windows.Forms.Label bottomTitleLabel;






    }
}
