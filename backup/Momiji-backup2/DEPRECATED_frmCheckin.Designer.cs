namespace Momiji
{
    partial class DEPRECATED_frmCheckin
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstMerch = new System.Windows.Forms.ListView();
            this.pieceID = new System.Windows.Forms.ColumnHeader();
            this.pieceTitle = new System.Windows.Forms.ColumnHeader();
            this.pieceMinbid = new System.Windows.Forms.ColumnHeader();
            this.pieceAAMB = new System.Windows.Forms.ColumnHeader();
            this.pieceQuickSale = new System.Windows.Forms.ColumnHeader();
            this.pieceMedium = new System.Windows.Forms.ColumnHeader();
            this.btnEditArtist = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstGSMerch = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.btnReload = new System.Windows.Forms.Button();
            this.chkService = new System.Windows.Forms.CheckBox();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstMerch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(679, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Control Sheet";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.lstMerch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMerch.FullRowSelect = true;
            this.lstMerch.GridLines = true;
            this.lstMerch.LabelEdit = true;
            this.lstMerch.Location = new System.Drawing.Point(3, 3);
            this.lstMerch.MultiSelect = false;
            this.lstMerch.Name = "lstMerch";
            this.lstMerch.Size = new System.Drawing.Size(673, 281);
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
            // btnEditArtist
            // 
            this.btnEditArtist.Image = global::Momiji.Properties.Resources.table_edit;
            this.btnEditArtist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditArtist.Location = new System.Drawing.Point(147, 320);
            this.btnEditArtist.Name = "btnEditArtist";
            this.btnEditArtist.Size = new System.Drawing.Size(128, 23);
            this.btnEditArtist.TabIndex = 7;
            this.btnEditArtist.Text = "Edit Artist";
            this.btnEditArtist.UseVisualStyleBackColor = true;
            this.btnEditArtist.Click += new System.EventHandler(this.btnEditArtist_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Momiji.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(4, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Image = global::Momiji.Properties.Resources.door_in;
            this.btnCheckIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckIn.Location = new System.Drawing.Point(555, 320);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(128, 23);
            this.btnCheckIn.TabIndex = 5;
            this.btnCheckIn.Text = "Confirm Check-IN";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(687, 313);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstGSMerch);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(679, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gallery Store";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstGSMerch
            // 
            this.lstGSMerch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lstGSMerch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGSMerch.FullRowSelect = true;
            this.lstGSMerch.GridLines = true;
            this.lstGSMerch.Location = new System.Drawing.Point(3, 3);
            this.lstGSMerch.MultiSelect = false;
            this.lstGSMerch.Name = "lstGSMerch";
            this.lstGSMerch.Size = new System.Drawing.Size(673, 281);
            this.lstGSMerch.TabIndex = 2;
            this.lstGSMerch.UseCompatibleStateImageBehavior = false;
            this.lstGSMerch.View = System.Windows.Forms.View.Details;
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
            // btnReload
            // 
            this.btnReload.Image = global::Momiji.Properties.Resources.arrow_refresh;
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReload.Location = new System.Drawing.Point(281, 320);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(128, 23);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload Info";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // chkService
            // 
            this.chkService.AutoSize = true;
            this.chkService.Location = new System.Drawing.Point(429, 324);
            this.chkService.Name = "chkService";
            this.chkService.Size = new System.Drawing.Size(107, 17);
            this.chkService.TabIndex = 9;
            this.chkService.Text = "Service Fee($10)";
            this.chkService.UseVisualStyleBackColor = true;
            // 
            // frmCheckin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 348);
            this.Controls.Add(this.chkService);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnEditArtist);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmCheckin";
            this.Text = "Artist Check IN";
            this.Load += new System.EventHandler(this.frmCheckin_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnEditArtist;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ListView lstMerch;
        public System.Windows.Forms.ColumnHeader pieceID;
        public System.Windows.Forms.ColumnHeader pieceTitle;
        public System.Windows.Forms.ColumnHeader pieceMinbid;
        private System.Windows.Forms.ColumnHeader pieceAAMB;
        private System.Windows.Forms.ColumnHeader pieceQuickSale;
        private System.Windows.Forms.ColumnHeader pieceMedium;
        private System.Windows.Forms.ListView lstGSMerch;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.CheckBox chkService;
    }
}