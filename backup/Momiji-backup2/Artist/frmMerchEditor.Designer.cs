namespace Momiji
{
    partial class frmMerchEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPieceID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPieceTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPieceMinimumBid = new System.Windows.Forms.TextBox();
            this.txtMedium = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblArtistID = new System.Windows.Forms.Label();
            this.lblArtistName = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreateSheet = new System.Windows.Forms.Button();
            this.txtQuickSale = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnControlSheetGen = new System.Windows.Forms.Button();
            this.chkNoQuickSale = new System.Windows.Forms.CheckBox();
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
            this.lstMerch.Size = new System.Drawing.Size(527, 401);
            this.lstMerch.TabIndex = 1;
            this.lstMerch.UseCompatibleStateImageBehavior = false;
            this.lstMerch.View = System.Windows.Forms.View.Details;
            this.lstMerch.SelectedIndexChanged += new System.EventHandler(this.lstMerch_SelectedIndexChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Piece ID";
            // 
            // txtPieceID
            // 
            this.txtPieceID.Location = new System.Drawing.Point(545, 81);
            this.txtPieceID.Name = "txtPieceID";
            this.txtPieceID.Size = new System.Drawing.Size(106, 20);
            this.txtPieceID.TabIndex = 2;
            this.txtPieceID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPieceID_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Title of Piece";
            // 
            // txtPieceTitle
            // 
            this.txtPieceTitle.Location = new System.Drawing.Point(545, 130);
            this.txtPieceTitle.Name = "txtPieceTitle";
            this.txtPieceTitle.Size = new System.Drawing.Size(234, 20);
            this.txtPieceTitle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Minimum Bid $";
            // 
            // txtPieceMinimumBid
            // 
            this.txtPieceMinimumBid.Location = new System.Drawing.Point(622, 159);
            this.txtPieceMinimumBid.Name = "txtPieceMinimumBid";
            this.txtPieceMinimumBid.Size = new System.Drawing.Size(157, 20);
            this.txtPieceMinimumBid.TabIndex = 5;
            this.txtPieceMinimumBid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPieceMinimumBid_KeyPress);
            // 
            // txtMedium
            // 
            this.txtMedium.Location = new System.Drawing.Point(545, 273);
            this.txtMedium.Name = "txtMedium";
            this.txtMedium.Size = new System.Drawing.Size(234, 20);
            this.txtMedium.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(542, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Medium";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Image = global::Momiji.Properties.Resources.table_edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(545, 299);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(66, 27);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Momiji.Properties.Resources.table_add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(545, 336);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 27);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Image = global::Momiji.Properties.Resources.asterisk_yellow;
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Location = new System.Drawing.Point(657, 77);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(122, 26);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Auto Generate ID";
            this.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(542, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Artist ID : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(542, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Artist Name : ";
            // 
            // lblArtistID
            // 
            this.lblArtistID.AutoSize = true;
            this.lblArtistID.Location = new System.Drawing.Point(602, 18);
            this.lblArtistID.Name = "lblArtistID";
            this.lblArtistID.Size = new System.Drawing.Size(73, 13);
            this.lblArtistID.TabIndex = 18;
            this.lblArtistID.Text = "%ARTISTID%";
            // 
            // lblArtistName
            // 
            this.lblArtistName.AutoSize = true;
            this.lblArtistName.Location = new System.Drawing.Point(619, 41);
            this.lblArtistName.Name = "lblArtistName";
            this.lblArtistName.Size = new System.Drawing.Size(93, 13);
            this.lblArtistName.TabIndex = 19;
            this.lblArtistName.Text = "%ARTISTNAME%";
            // 
            // btnClear
            // 
            this.btnClear.Image = global::Momiji.Properties.Resources.cancel;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(630, 299);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(66, 27);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::Momiji.Properties.Resources.cross;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(712, 299);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 27);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreateSheet
            // 
            this.btnCreateSheet.Enabled = false;
            this.btnCreateSheet.Image = global::Momiji.Properties.Resources.page_add;
            this.btnCreateSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateSheet.Location = new System.Drawing.Point(657, 336);
            this.btnCreateSheet.Name = "btnCreateSheet";
            this.btnCreateSheet.Size = new System.Drawing.Size(122, 27);
            this.btnCreateSheet.TabIndex = 13;
            this.btnCreateSheet.Text = "Create Bid Sheet";
            this.btnCreateSheet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateSheet.UseVisualStyleBackColor = true;
            this.btnCreateSheet.Click += new System.EventHandler(this.btnCreateSheet_Click);
            // 
            // txtQuickSale
            // 
            this.txtQuickSale.Location = new System.Drawing.Point(545, 227);
            this.txtQuickSale.Name = "txtQuickSale";
            this.txtQuickSale.Size = new System.Drawing.Size(106, 20);
            this.txtQuickSale.TabIndex = 7;
            this.txtQuickSale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(542, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Quick sale Price:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(545, 191);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(183, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Sell after auction at minimum bid?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnControlSheetGen
            // 
            this.btnControlSheetGen.Image = global::Momiji.Properties.Resources.page;
            this.btnControlSheetGen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnControlSheetGen.Location = new System.Drawing.Point(545, 370);
            this.btnControlSheetGen.Name = "btnControlSheetGen";
            this.btnControlSheetGen.Size = new System.Drawing.Size(234, 23);
            this.btnControlSheetGen.TabIndex = 25;
            this.btnControlSheetGen.Text = "Generate Control Sheet";
            this.btnControlSheetGen.UseVisualStyleBackColor = true;
            this.btnControlSheetGen.Click += new System.EventHandler(this.btnControlSheetGen_Click);
            // 
            // chkNoQuickSale
            // 
            this.chkNoQuickSale.AutoSize = true;
            this.chkNoQuickSale.Location = new System.Drawing.Point(657, 229);
            this.chkNoQuickSale.Name = "chkNoQuickSale";
            this.chkNoQuickSale.Size = new System.Drawing.Size(108, 17);
            this.chkNoQuickSale.TabIndex = 26;
            this.chkNoQuickSale.Text = "NO QUICK SALE";
            this.chkNoQuickSale.UseVisualStyleBackColor = true;
            this.chkNoQuickSale.CheckedChanged += new System.EventHandler(this.chkNoQuickSale_CheckedChanged);
            // 
            // frmMerchEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 401);
            this.Controls.Add(this.chkNoQuickSale);
            this.Controls.Add(this.btnControlSheetGen);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQuickSale);
            this.Controls.Add(this.btnCreateSheet);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblArtistName);
            this.Controls.Add(this.lblArtistID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMedium);
            this.Controls.Add(this.txtPieceMinimumBid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPieceTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPieceID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMerch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMerchEditor";
            this.Text = "Merchandise Editor";
            this.Load += new System.EventHandler(this.frmMerchEditor_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPieceID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPieceTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPieceMinimumBid;
        private System.Windows.Forms.TextBox txtMedium;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblArtistID;
        private System.Windows.Forms.Label lblArtistName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreateSheet;
        private System.Windows.Forms.TextBox txtQuickSale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnControlSheetGen;
        private System.Windows.Forms.CheckBox chkNoQuickSale;
    }
}