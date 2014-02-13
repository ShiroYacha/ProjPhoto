namespace TravelJournal.WinForm.Simulator.Forms
{
    partial class TravelItineraryPlanner : ConfigFormTravelItineraryData
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
            this.clearMarkersButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.setTimeIntervalImage = new System.Windows.Forms.ToolStripLabel();
            this.setTimeIntervalTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.setCameraNumImage = new System.Windows.Forms.ToolStripLabel();
            this.setCameraNumTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.connectAnchorsButton = new System.Windows.Forms.ToolStripButton();
            this.travelMapPlayer = new TravelJournal.WinForm.Simulator.Controls.TravelMapPlayer();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator2,
            this.placeStartButton,
            this.placeAnchorButton,
            this.clearMarkersButton,
            this.toolStripSeparator3,
            this.setTimeIntervalImage,
            this.setTimeIntervalTextBox,
            this.setCameraNumImage,
            this.setCameraNumTextBox,
            this.toolStripSeparator1,
            this.connectAnchorsButton,
            this.refreshButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(680, 30);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 27);
            this.undoButton.Text = "toolStripButton1";
            this.undoButton.ToolTipText = "Undo action.";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(23, 27);
            this.redoButton.Text = "toolStripButton1";
            this.redoButton.ToolTipText = "Undo action.";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // placeStartButton
            // 
            this.placeStartButton.Checked = true;
            this.placeStartButton.CheckOnClick = true;
            this.placeStartButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.placeStartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.placeStartButton.Image = ((System.Drawing.Image)(resources.GetObject("placeStartButton.Image")));
            this.placeStartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.placeStartButton.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.placeStartButton.Name = "placeStartButton";
            this.placeStartButton.Size = new System.Drawing.Size(23, 27);
            this.placeStartButton.Text = "toolStripButton1";
            this.placeStartButton.Click += new System.EventHandler(this.placeStartButton_Click);
            // 
            // placeAnchorButton
            // 
            this.placeAnchorButton.CheckOnClick = true;
            this.placeAnchorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.placeAnchorButton.Image = ((System.Drawing.Image)(resources.GetObject("placeAnchorButton.Image")));
            this.placeAnchorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.placeAnchorButton.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.placeAnchorButton.Name = "placeAnchorButton";
            this.placeAnchorButton.Size = new System.Drawing.Size(23, 27);
            this.placeAnchorButton.Text = "toolStripButton1";
            this.placeAnchorButton.Click += new System.EventHandler(this.placeAnchorButton_Click);
            // 
            // clearMarkersButton
            // 
            this.clearMarkersButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearMarkersButton.Image = ((System.Drawing.Image)(resources.GetObject("clearMarkersButton.Image")));
            this.clearMarkersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearMarkersButton.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.clearMarkersButton.Name = "clearMarkersButton";
            this.clearMarkersButton.Size = new System.Drawing.Size(23, 27);
            this.clearMarkersButton.Text = "toolStripButton1";
            this.clearMarkersButton.ToolTipText = "Clear the anchors and camera spots.";
            this.clearMarkersButton.Click += new System.EventHandler(this.clearMarkersButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // setTimeIntervalImage
            // 
            this.setTimeIntervalImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setTimeIntervalImage.Image = ((System.Drawing.Image)(resources.GetObject("setTimeIntervalImage.Image")));
            this.setTimeIntervalImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setTimeIntervalImage.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.setTimeIntervalImage.Name = "setTimeIntervalImage";
            this.setTimeIntervalImage.Size = new System.Drawing.Size(16, 27);
            this.setTimeIntervalImage.Text = "toolStripButton1";
            this.setTimeIntervalImage.ToolTipText = "Set time interval for anchors.";
            // 
            // setTimeIntervalTextBox
            // 
            this.setTimeIntervalTextBox.AutoSize = false;
            this.setTimeIntervalTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.setTimeIntervalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setTimeIntervalTextBox.ForeColor = System.Drawing.Color.White;
            this.setTimeIntervalTextBox.Margin = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.setTimeIntervalTextBox.Name = "setTimeIntervalTextBox";
            this.setTimeIntervalTextBox.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.setTimeIntervalTextBox.Size = new System.Drawing.Size(38, 23);
            this.setTimeIntervalTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.setTimeIntervalTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.setTimeIntervalTextBox_Validating);
            // 
            // setCameraNumImage
            // 
            this.setCameraNumImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setCameraNumImage.Image = ((System.Drawing.Image)(resources.GetObject("setCameraNumImage.Image")));
            this.setCameraNumImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setCameraNumImage.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.setCameraNumImage.Name = "setCameraNumImage";
            this.setCameraNumImage.Size = new System.Drawing.Size(16, 27);
            this.setCameraNumImage.Text = "toolStripButton1";
            this.setCameraNumImage.ToolTipText = "Set the number of photo to be taken at camera spot.";
            // 
            // setCameraNumTextBox
            // 
            this.setCameraNumTextBox.AutoSize = false;
            this.setCameraNumTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.setCameraNumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setCameraNumTextBox.ForeColor = System.Drawing.Color.White;
            this.setCameraNumTextBox.Margin = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.setCameraNumTextBox.Name = "setCameraNumTextBox";
            this.setCameraNumTextBox.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.setCameraNumTextBox.Size = new System.Drawing.Size(38, 23);
            this.setCameraNumTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.setCameraNumTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.setCameraNumTextBox_Validating);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // connectAnchorsButton
            // 
            this.connectAnchorsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectAnchorsButton.Image = ((System.Drawing.Image)(resources.GetObject("connectAnchorsButton.Image")));
            this.connectAnchorsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectAnchorsButton.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.connectAnchorsButton.Name = "connectAnchorsButton";
            this.connectAnchorsButton.Size = new System.Drawing.Size(23, 27);
            this.connectAnchorsButton.Text = "toolStripButton1";
            this.connectAnchorsButton.ToolTipText = "Close the itinerary loop.";
            this.connectAnchorsButton.Click += new System.EventHandler(this.connectAnchorsButton_Click);
            // 
            // travelMapPlayer
            // 
            this.travelMapPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.travelMapPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travelMapPlayer.Location = new System.Drawing.Point(0, 54);
            this.travelMapPlayer.Name = "travelMapPlayer";
            this.travelMapPlayer.Size = new System.Drawing.Size(680, 360);
            this.travelMapPlayer.TabIndex = 3;
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(23, 27);
            this.refreshButton.Text = "toolStripButton1";
            this.refreshButton.ToolTipText = "Close the itinerary loop.";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // TravelItineraryPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 414);
            this.Controls.Add(this.travelMapPlayer);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "TravelItineraryPlanner";
            this.Text = "TravelItineraryPlanner";
            this.Load += new System.EventHandler(this.TravelItineraryPlanner_Load);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.Controls.SetChildIndex(this.travelMapPlayer, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton placeStartButton;
        private System.Windows.Forms.ToolStripButton placeAnchorButton;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton connectAnchorsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton redoButton;
        private Controls.TravelMapPlayer travelMapPlayer;
        private System.Windows.Forms.ToolStripTextBox setTimeIntervalTextBox;
        private System.Windows.Forms.ToolStripLabel setTimeIntervalImage;
        private System.Windows.Forms.ToolStripLabel setCameraNumImage;
        private System.Windows.Forms.ToolStripTextBox setCameraNumTextBox;
        private System.Windows.Forms.ToolStripButton clearMarkersButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton refreshButton;


    }
}