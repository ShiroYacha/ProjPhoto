namespace TravelJournal.WinForm.Simulator.Forms
{
    partial class TravelItineraryPlanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TravelItineraryPlanner));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.placeStartButton = new System.Windows.Forms.ToolStripButton();
            this.placeAnchorButton = new System.Windows.Forms.ToolStripButton();
            this.connectAnchorsButton = new System.Windows.Forms.ToolStripButton();
            this.setTimeIntervalButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.placeCameraSpotButton = new System.Windows.Forms.ToolStripButton();
            this.setCameraProbButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator2,
            this.placeStartButton,
            this.placeAnchorButton,
            this.connectAnchorsButton,
            this.setTimeIntervalButton,
            this.toolStripSeparator1,
            this.placeCameraSpotButton,
            this.setCameraProbButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(35, 366);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(33, 20);
            this.undoButton.Text = "toolStripButton1";
            this.undoButton.ToolTipText = "Undo action.";
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(33, 20);
            this.redoButton.Text = "toolStripButton1";
            this.redoButton.ToolTipText = "Undo action.";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(33, 6);
            // 
            // placeStartButton
            // 
            this.placeStartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.placeStartButton.Image = ((System.Drawing.Image)(resources.GetObject("placeStartButton.Image")));
            this.placeStartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.placeStartButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.placeStartButton.Name = "placeStartButton";
            this.placeStartButton.Size = new System.Drawing.Size(33, 20);
            this.placeStartButton.Text = "toolStripButton1";
            // 
            // placeAnchorButton
            // 
            this.placeAnchorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.placeAnchorButton.Image = ((System.Drawing.Image)(resources.GetObject("placeAnchorButton.Image")));
            this.placeAnchorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.placeAnchorButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.placeAnchorButton.Name = "placeAnchorButton";
            this.placeAnchorButton.Size = new System.Drawing.Size(33, 20);
            this.placeAnchorButton.Text = "toolStripButton1";
            // 
            // connectAnchorsButton
            // 
            this.connectAnchorsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectAnchorsButton.Image = ((System.Drawing.Image)(resources.GetObject("connectAnchorsButton.Image")));
            this.connectAnchorsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectAnchorsButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.connectAnchorsButton.Name = "connectAnchorsButton";
            this.connectAnchorsButton.Size = new System.Drawing.Size(33, 20);
            this.connectAnchorsButton.Text = "toolStripButton1";
            this.connectAnchorsButton.ToolTipText = "Close the itinerary loop.";
            // 
            // setTimeIntervalButton
            // 
            this.setTimeIntervalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setTimeIntervalButton.Image = ((System.Drawing.Image)(resources.GetObject("setTimeIntervalButton.Image")));
            this.setTimeIntervalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setTimeIntervalButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.setTimeIntervalButton.Name = "setTimeIntervalButton";
            this.setTimeIntervalButton.Size = new System.Drawing.Size(33, 20);
            this.setTimeIntervalButton.Text = "toolStripButton1";
            this.setTimeIntervalButton.ToolTipText = "Set time interval for anchors.";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(33, 6);
            // 
            // placeCameraSpotButton
            // 
            this.placeCameraSpotButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.placeCameraSpotButton.Image = ((System.Drawing.Image)(resources.GetObject("placeCameraSpotButton.Image")));
            this.placeCameraSpotButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.placeCameraSpotButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.placeCameraSpotButton.Name = "placeCameraSpotButton";
            this.placeCameraSpotButton.Size = new System.Drawing.Size(33, 20);
            this.placeCameraSpotButton.Text = "toolStripButton1";
            this.placeCameraSpotButton.ToolTipText = "Place a camera spot.";
            // 
            // setCameraProbButton
            // 
            this.setCameraProbButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setCameraProbButton.Image = ((System.Drawing.Image)(resources.GetObject("setCameraProbButton.Image")));
            this.setCameraProbButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setCameraProbButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.setCameraProbButton.Name = "setCameraProbButton";
            this.setCameraProbButton.Size = new System.Drawing.Size(33, 20);
            this.setCameraProbButton.Text = "toolStripButton1";
            this.setCameraProbButton.ToolTipText = "Close the itinerary loop.";
            // 
            // TravelItineraryPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 390);
            this.Controls.Add(this.toolStrip);
            this.Name = "TravelItineraryPlanner";
            this.Text = "TravelItineraryPlanner";
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton placeStartButton;
        private System.Windows.Forms.ToolStripButton placeAnchorButton;
        private System.Windows.Forms.ToolStripButton placeCameraSpotButton;
        private System.Windows.Forms.ToolStripButton setTimeIntervalButton;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton connectAnchorsButton;
        private System.Windows.Forms.ToolStripButton setCameraProbButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton redoButton;


    }
}