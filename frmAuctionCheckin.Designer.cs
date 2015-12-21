namespace Momiji
{
    partial class frmAuctionCheckin
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
            this.lstMerch = new System.Windows.Forms.ListView();
            this.pieceID = new System.Windows.Forms.ColumnHeader();
            this.pieceTitle = new System.Windows.Forms.ColumnHeader();
            this.pieceMinbid = new System.Windows.Forms.ColumnHeader();
            this.pieceAAMB = new System.Windows.Forms.ColumnHeader();
            this.pieceQuickSale = new System.Windows.Forms.ColumnHeader();
            this.pieceMedium = new System.Windows.Forms.ColumnHeader();
            this.lblInstruction1 = new System.Windows.Forms.Label();
            this.chkListCorrect = new System.Windows.Forms.CheckBox();
            this.lblInstruction2 = new System.Windows.Forms.Label();
            this.chkArtSetup = new System.Windows.Forms.CheckBox();
            this.lblInstruction3 = new System.Windows.Forms.Label();
            this.chkBothSigned = new System.Windows.Forms.CheckBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblArtistID = new System.Windows.Forms.Label();
            this.lblANNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblArtistName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.picStop = new System.Windows.Forms.PictureBox();
            this.lblStop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picStop)).BeginInit();
            this.SuspendLayout();
            // 
            // lstMerch
            // 
            this.lstMerch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pieceID,
            this.pieceTitle,
            this.pieceMinbid,
            this.pieceAAMB,
            this.pieceQuickSale,
            this.pieceMedium});
            this.lstMerch.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstMerch.FullRowSelect = true;
            this.lstMerch.GridLines = true;
            this.lstMerch.LabelEdit = true;
            this.lstMerch.Location = new System.Drawing.Point(0, 0);
            this.lstMerch.MultiSelect = false;
            this.lstMerch.Name = "lstMerch";
            this.lstMerch.Size = new System.Drawing.Size(527, 260);
            this.lstMerch.TabIndex = 2;
            this.lstMerch.UseCompatibleStateImageBehavior = false;
            this.lstMerch.View = System.Windows.Forms.View.Details;
            // 
            // pieceID
            // 
            this.pieceID.Text = "Piece ID";
            // 
            // pieceTitle
            // 
            this.pieceTitle.Text = "Title of Piece";
            this.pieceTitle.Width = 95;
            // 
            // pieceMinbid
            // 
            this.pieceMinbid.Text = "Min. Bid";
            // 
            // pieceAAMB
            // 
            this.pieceAAMB.Text = "After Auction Min. Bid";
            this.pieceAAMB.Width = 120;
            // 
            // pieceQuickSale
            // 
            this.pieceQuickSale.Text = "Quick Sale";
            this.pieceQuickSale.Width = 110;
            // 
            // pieceMedium
            // 
            this.pieceMedium.Text = "Medium";
            this.pieceMedium.Width = 77;
            // 
            // lblInstruction1
            // 
            this.lblInstruction1.AutoSize = true;
            this.lblInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction1.Location = new System.Drawing.Point(533, 36);
            this.lblInstruction1.Name = "lblInstruction1";
            this.lblInstruction1.Size = new System.Drawing.Size(270, 15);
            this.lblInstruction1.TabIndex = 3;
            this.lblInstruction1.Text = "Check the list with the artist, is it correct?";
            // 
            // chkListCorrect
            // 
            this.chkListCorrect.AutoSize = true;
            this.chkListCorrect.Location = new System.Drawing.Point(536, 54);
            this.chkListCorrect.Name = "chkListCorrect";
            this.chkListCorrect.Size = new System.Drawing.Size(44, 17);
            this.chkListCorrect.TabIndex = 4;
            this.chkListCorrect.Text = "Yes";
            this.chkListCorrect.UseVisualStyleBackColor = true;
            // 
            // lblInstruction2
            // 
            this.lblInstruction2.AutoSize = true;
            this.lblInstruction2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction2.Location = new System.Drawing.Point(533, 86);
            this.lblInstruction2.Name = "lblInstruction2";
            this.lblInstruction2.Size = new System.Drawing.Size(265, 30);
            this.lblInstruction2.TabIndex = 5;
            this.lblInstruction2.Text = "Have you sent the artist with a colleague\r\nto set up their art?";
            // 
            // chkArtSetup
            // 
            this.chkArtSetup.AutoSize = true;
            this.chkArtSetup.Location = new System.Drawing.Point(536, 120);
            this.chkArtSetup.Name = "chkArtSetup";
            this.chkArtSetup.Size = new System.Drawing.Size(44, 17);
            this.chkArtSetup.TabIndex = 6;
            this.chkArtSetup.Text = "Yes";
            this.chkArtSetup.UseVisualStyleBackColor = true;
            // 
            // lblInstruction3
            // 
            this.lblInstruction3.AutoSize = true;
            this.lblInstruction3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction3.Location = new System.Drawing.Point(533, 152);
            this.lblInstruction3.Name = "lblInstruction3";
            this.lblInstruction3.Size = new System.Drawing.Size(260, 30);
            this.lblInstruction3.TabIndex = 7;
            this.lblInstruction3.Text = "Have both you and the artist signed the \r\ncontrol sheet?";
            // 
            // chkBothSigned
            // 
            this.chkBothSigned.AutoSize = true;
            this.chkBothSigned.Location = new System.Drawing.Point(536, 186);
            this.chkBothSigned.Name = "chkBothSigned";
            this.chkBothSigned.Size = new System.Drawing.Size(44, 17);
            this.chkBothSigned.TabIndex = 8;
            this.chkBothSigned.Text = "Yes";
            this.chkBothSigned.UseVisualStyleBackColor = true;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Image = global::Momiji.Properties.Resources.asterisk_yellow;
            this.btnCheckIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckIn.Location = new System.Drawing.Point(688, 225);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(115, 23);
            this.btnCheckIn.TabIndex = 9;
            this.btnCheckIn.Text = "Check In Artist";
            this.btnCheckIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::Momiji.Properties.Resources.report_go;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(536, 225);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(146, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Manage Merchandise";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblArtistID
            // 
            this.lblArtistID.AutoSize = true;
            this.lblArtistID.Location = new System.Drawing.Point(587, 9);
            this.lblArtistID.Name = "lblArtistID";
            this.lblArtistID.Size = new System.Drawing.Size(19, 13);
            this.lblArtistID.TabIndex = 10;
            this.lblArtistID.Text = "01";
            // 
            // lblANNo
            // 
            this.lblANNo.AutoSize = true;
            this.lblANNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblANNo.Location = new System.Drawing.Point(533, 9);
            this.lblANNo.Name = "lblANNo";
            this.lblANNo.Size = new System.Drawing.Size(56, 13);
            this.lblANNo.TabIndex = 12;
            this.lblANNo.Text = "Artist # :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(633, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Artist Name :";
            // 
            // lblArtistName
            // 
            this.lblArtistName.AutoSize = true;
            this.lblArtistName.Location = new System.Drawing.Point(719, 9);
            this.lblArtistName.Name = "lblArtistName";
            this.lblArtistName.Size = new System.Drawing.Size(53, 13);
            this.lblArtistName.TabIndex = 14;
            this.lblArtistName.Text = "John Doe";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Momiji.Properties.Resources.arrow_refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(688, 196);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 23);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Refresh Info";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // picStop
            // 
            this.picStop.Image = global::Momiji.Properties.Resources.stop;
            this.picStop.Location = new System.Drawing.Point(609, 25);
            this.picStop.Name = "picStop";
            this.picStop.Size = new System.Drawing.Size(133, 137);
            this.picStop.TabIndex = 16;
            this.picStop.TabStop = false;
            this.picStop.Visible = false;
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(558, 169);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(245, 24);
            this.lblStop.TabIndex = 17;
            this.lblStop.Text = "Artist already checked in!";
            this.lblStop.Visible = false;
            // 
            // frmAuctionCheckin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 260);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.picStop);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblArtistName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblANNo);
            this.Controls.Add(this.lblArtistID);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.chkBothSigned);
            this.Controls.Add(this.lblInstruction3);
            this.Controls.Add(this.chkArtSetup);
            this.Controls.Add(this.lblInstruction2);
            this.Controls.Add(this.chkListCorrect);
            this.Controls.Add(this.lblInstruction1);
            this.Controls.Add(this.lstMerch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAuctionCheckin";
            this.Text = "Artist Check In Form";
            this.Load += new System.EventHandler(this.frmAuctionCheckin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstMerch;
        public System.Windows.Forms.ColumnHeader pieceID;
        public System.Windows.Forms.ColumnHeader pieceTitle;
        public System.Windows.Forms.ColumnHeader pieceMinbid;
        private System.Windows.Forms.ColumnHeader pieceAAMB;
        private System.Windows.Forms.ColumnHeader pieceQuickSale;
        private System.Windows.Forms.ColumnHeader pieceMedium;
        private System.Windows.Forms.Label lblInstruction1;
        private System.Windows.Forms.CheckBox chkListCorrect;
        private System.Windows.Forms.Label lblInstruction2;
        private System.Windows.Forms.CheckBox chkArtSetup;
        private System.Windows.Forms.Label lblInstruction3;
        private System.Windows.Forms.CheckBox chkBothSigned;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblArtistID;
        private System.Windows.Forms.Label lblANNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblArtistName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox picStop;
        private System.Windows.Forms.Label lblStop;

    }
}