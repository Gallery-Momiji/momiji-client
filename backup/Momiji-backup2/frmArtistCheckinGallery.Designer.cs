namespace Momiji
{
    partial class frmArtistCheckinGallery
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
            this.lblArtistName = new System.Windows.Forms.Label();
            this.lblArtistID = new System.Windows.Forms.Label();
            this.lstMerch = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMatch = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBinder = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkGSCS = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.lblStop = new System.Windows.Forms.Label();
            this.picStop = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblANNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picStop)).BeginInit();
            this.SuspendLayout();
            // 
            // lblArtistName
            // 
            this.lblArtistName.AutoSize = true;
            this.lblArtistName.Location = new System.Drawing.Point(760, 9);
            this.lblArtistName.Name = "lblArtistName";
            this.lblArtistName.Size = new System.Drawing.Size(35, 13);
            this.lblArtistName.TabIndex = 10;
            this.lblArtistName.Text = "label3";
            this.lblArtistName.Click += new System.EventHandler(this.lblArtistName_Click);
            // 
            // lblArtistID
            // 
            this.lblArtistID.AutoSize = true;
            this.lblArtistID.Location = new System.Drawing.Point(635, 9);
            this.lblArtistID.Name = "lblArtistID";
            this.lblArtistID.Size = new System.Drawing.Size(35, 13);
            this.lblArtistID.TabIndex = 9;
            this.lblArtistID.Text = "label3";
            // 
            // lstMerch
            // 
            this.lstMerch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader1});
            this.lstMerch.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstMerch.FullRowSelect = true;
            this.lstMerch.GridLines = true;
            this.lstMerch.Location = new System.Drawing.Point(0, 0);
            this.lstMerch.MultiSelect = false;
            this.lstMerch.Name = "lstMerch";
            this.lstMerch.Size = new System.Drawing.Size(570, 268);
            this.lstMerch.TabIndex = 6;
            this.lstMerch.UseCompatibleStateImageBehavior = false;
            this.lstMerch.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Piece ID";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Piece Title";
            this.columnHeader6.Width = 108;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Piece Given Stock";
            this.columnHeader7.Width = 102;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Piece Stock";
            this.columnHeader8.Width = 76;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Piece Price-Per-Unit";
            this.columnHeader9.Width = 107;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sell Display Copy";
            this.columnHeader1.Width = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(576, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 30);
            this.label3.TabIndex = 11;
            this.label3.Text = "Have you confirmed with the artist that our \r\ninformation matches theirs?";
            // 
            // chkMatch
            // 
            this.chkMatch.AutoSize = true;
            this.chkMatch.Location = new System.Drawing.Point(579, 87);
            this.chkMatch.Name = "chkMatch";
            this.chkMatch.Size = new System.Drawing.Size(44, 17);
            this.chkMatch.TabIndex = 12;
            this.chkMatch.Text = "Yes";
            this.chkMatch.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(576, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "Have all prints been put in a binder \r\nand identified?";
            // 
            // chkBinder
            // 
            this.chkBinder.AutoSize = true;
            this.chkBinder.Location = new System.Drawing.Point(579, 141);
            this.chkBinder.Name = "chkBinder";
            this.chkBinder.Size = new System.Drawing.Size(44, 17);
            this.chkBinder.TabIndex = 14;
            this.chkBinder.Text = "Yes";
            this.chkBinder.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(576, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 30);
            this.label5.TabIndex = 15;
            this.label5.Text = "Have you and the artist signed the Gallery \r\nStore Control Sheet?";
            // 
            // chkGSCS
            // 
            this.chkGSCS.AutoSize = true;
            this.chkGSCS.Location = new System.Drawing.Point(579, 194);
            this.chkGSCS.Name = "chkGSCS";
            this.chkGSCS.Size = new System.Drawing.Size(44, 17);
            this.chkGSCS.TabIndex = 16;
            this.chkGSCS.Text = "Yes";
            this.chkGSCS.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Momiji.Properties.Resources.arrow_refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(728, 202);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 23);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Refresh Info";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::Momiji.Properties.Resources.report_go;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(576, 231);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(146, 23);
            this.btnEdit.TabIndex = 19;
            this.btnEdit.Text = "Manage Merchandise";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Image = global::Momiji.Properties.Resources.asterisk_yellow;
            this.btnCheckIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckIn.Location = new System.Drawing.Point(728, 231);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(115, 23);
            this.btnCheckIn.TabIndex = 18;
            this.btnCheckIn.Text = "Check In Artist";
            this.btnCheckIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(587, 179);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(245, 24);
            this.lblStop.TabIndex = 22;
            this.lblStop.Text = "Artist already checked in!";
            this.lblStop.Visible = false;
            // 
            // picStop
            // 
            this.picStop.Image = global::Momiji.Properties.Resources.stop;
            this.picStop.Location = new System.Drawing.Point(638, 35);
            this.picStop.Name = "picStop";
            this.picStop.Size = new System.Drawing.Size(133, 137);
            this.picStop.TabIndex = 21;
            this.picStop.TabStop = false;
            this.picStop.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(676, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Artist Name :";
            // 
            // lblANNo
            // 
            this.lblANNo.AutoSize = true;
            this.lblANNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblANNo.Location = new System.Drawing.Point(576, 9);
            this.lblANNo.Name = "lblANNo";
            this.lblANNo.Size = new System.Drawing.Size(56, 13);
            this.lblANNo.TabIndex = 23;
            this.lblANNo.Text = "Artist # :";
            // 
            // frmArtistCheckinGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 268);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblANNo);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.picStop);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.chkGSCS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkBinder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkMatch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblArtistName);
            this.Controls.Add(this.lblArtistID);
            this.Controls.Add(this.lstMerch);
            this.Name = "frmArtistCheckinGallery";
            this.Text = "Artist Gallery Store Check In";
            this.Load += new System.EventHandler(this.frmArtistCheckinGallery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArtistName;
        private System.Windows.Forms.Label lblArtistID;
        private System.Windows.Forms.ListView lstMerch;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkMatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBinder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkGSCS;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.PictureBox picStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblANNo;
    }
}