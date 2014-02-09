namespace TravelJournal.WinForm.Test.Controls
{
    partial class InfoInspector
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
            this.listView = new DoubleBufferedListView();
            this.DataHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DataHeader,
            this.ContextHeader});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.ForeColor = System.Drawing.Color.White;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(0);
            this.listView.Name = "listView";
            this.listView.OwnerDraw = true;
            this.listView.Scrollable = false;
            this.listView.Size = new System.Drawing.Size(275, 358);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // DataHeader
            // 
            this.DataHeader.Text = "Data";
            this.DataHeader.Width = 138;
            // 
            // ContextHeader
            // 
            this.ContextHeader.Text = "Context";
            this.ContextHeader.Width = 248;
            // 
            // InfoInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.DoubleBuffered = true;
            this.Name = "InfoInspector";
            this.Size = new System.Drawing.Size(275, 358);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedListView listView;
        private System.Windows.Forms.ColumnHeader DataHeader;
        private System.Windows.Forms.ColumnHeader ContextHeader;
    }
}
