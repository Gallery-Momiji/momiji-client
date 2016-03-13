namespace Momiji
{
    partial class frmGSManager
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
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblArtistID = new System.Windows.Forms.Label();
            this.lblArtistName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSDC = new System.Windows.Forms.CheckBox();
            this.btnGenBarcode = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtPricePerUnit = new System.Windows.Forms.TextBox();
            this.txtGivenStock = new System.Windows.Forms.TextBox();
            this.txtPieceTitle = new System.Windows.Forms.TextBox();
            this.btnGenID = new System.Windows.Forms.Button();
            this.txtPieceID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenCS = new System.Windows.Forms.Button();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.chkAPP = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.lstMerch.Size = new System.Drawing.Size(570, 381);
            this.lstMerch.TabIndex = 1;
            this.lstMerch.UseCompatibleStateImageBehavior = false;
            this.lstMerch.View = System.Windows.Forms.View.Details;
            this.lstMerch.SelectedIndexChanged += new System.EventHandler(this.lstMerch_SelectedIndexChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(598, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Artist ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(581, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Artist Name :";
            // 
            // lblArtistID
            // 
            this.lblArtistID.AutoSize = true;
            this.lblArtistID.Location = new System.Drawing.Point(655, 9);
            this.lblArtistID.Name = "lblArtistID";
            this.lblArtistID.Size = new System.Drawing.Size(35, 13);
            this.lblArtistID.TabIndex = 4;
            this.lblArtistID.Text = "label3";
            // 
            // lblArtistName
            // 
            this.lblArtistName.AutoSize = true;
            this.lblArtistName.Location = new System.Drawing.Point(655, 28);
            this.lblArtistName.Name = "lblArtistName";
            this.lblArtistName.Size = new System.Drawing.Size(35, 13);
            this.lblArtistName.TabIndex = 5;
            this.lblArtistName.Text = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSDC);
            this.groupBox1.Controls.Add(this.btnGenBarcode);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.txtPricePerUnit);
            this.groupBox1.Controls.Add(this.txtGivenStock);
            this.groupBox1.Controls.Add(this.txtPieceTitle);
            this.groupBox1.Controls.Add(this.btnGenID);
            this.groupBox1.Controls.Add(this.txtPieceID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(576, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 256);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Piece Info:";
            // 
            // chkSDC
            // 
            this.chkSDC.AutoSize = true;
            this.chkSDC.Location = new System.Drawing.Point(55, 132);
            this.chkSDC.Name = "chkSDC";
            this.chkSDC.Size = new System.Drawing.Size(113, 17);
            this.chkSDC.TabIndex = 16;
            this.chkSDC.Text = "Sell Display Copy?";
            this.chkSDC.UseVisualStyleBackColor = true;
            // 
            // btnGenBarcode
            // 
            this.btnGenBarcode.Enabled = false;
            this.btnGenBarcode.Image = global::Momiji.Properties.Resources.page_add;
            this.btnGenBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenBarcode.Location = new System.Drawing.Point(8, 218);
            this.btnGenBarcode.Name = "btnGenBarcode";
            this.btnGenBarcode.Size = new System.Drawing.Size(201, 23);
            this.btnGenBarcode.TabIndex = 15;
            this.btnGenBarcode.Text = "Generate Barcode";
            this.btnGenBarcode.UseVisualStyleBackColor = true;
            this.btnGenBarcode.Click += new System.EventHandler(this.btnGenBarcode_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::Momiji.Properties.Resources.table_delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(118, 188);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::Momiji.Properties.Resources.cancel;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(8, 188);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Momiji.Properties.Resources.table_add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(118, 159);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Image = global::Momiji.Properties.Resources.table_edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(8, 159);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtPricePerUnit
            // 
            this.txtPricePerUnit.Location = new System.Drawing.Point(91, 74);
            this.txtPricePerUnit.Name = "txtPricePerUnit";
            this.txtPricePerUnit.Size = new System.Drawing.Size(120, 20);
            this.txtPricePerUnit.TabIndex = 10;
            // 
            // txtGivenStock
            // 
            this.txtGivenStock.Location = new System.Drawing.Point(104, 102);
            this.txtGivenStock.Name = "txtGivenStock";
            this.txtGivenStock.Size = new System.Drawing.Size(107, 20);
            this.txtGivenStock.TabIndex = 8;
            // 
            // txtPieceTitle
            // 
            this.txtPieceTitle.Location = new System.Drawing.Point(73, 45);
            this.txtPieceTitle.Name = "txtPieceTitle";
            this.txtPieceTitle.Size = new System.Drawing.Size(138, 20);
            this.txtPieceTitle.TabIndex = 7;
            // 
            // btnGenID
            // 
            this.btnGenID.Image = global::Momiji.Properties.Resources.asterisk_yellow;
            this.btnGenID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenID.Location = new System.Drawing.Point(120, 14);
            this.btnGenID.Name = "btnGenID";
            this.btnGenID.Size = new System.Drawing.Size(91, 25);
            this.btnGenID.TabIndex = 6;
            this.btnGenID.Text = "Generate ID";
            this.btnGenID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenID.UseVisualStyleBackColor = true;
            this.btnGenID.Click += new System.EventHandler(this.btnGenID_Click);
            // 
            // txtPieceID
            // 
            this.txtPieceID.Location = new System.Drawing.Point(64, 17);
            this.txtPieceID.Name = "txtPieceID";
            this.txtPieceID.Size = new System.Drawing.Size(42, 20);
            this.txtPieceID.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Price Per Unit :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Piece Given Stock:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Piece Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Piece ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Momiji.Properties.Resources.cross;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(582, 356);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(208, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGenCS
            // 
            this.btnGenCS.Image = global::Momiji.Properties.Resources.page;
            this.btnGenCS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenCS.Location = new System.Drawing.Point(582, 329);
            this.btnGenCS.Name = "btnGenCS";
            this.btnGenCS.Size = new System.Drawing.Size(208, 23);
            this.btnGenCS.TabIndex = 8;
            this.btnGenCS.Text = "Generate Control Sheet";
            this.btnGenCS.UseVisualStyleBackColor = true;
            this.btnGenCS.Click += new System.EventHandler(this.btnGenCS_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sell Display Copy";
            this.columnHeader1.Width = 106;
            // 
            // chkAPP
            // 
            this.chkAPP.AutoSize = true;
            this.chkAPP.Location = new System.Drawing.Point(584, 45);
            this.chkAPP.Name = "chkAPP";
            this.chkAPP.Size = new System.Drawing.Size(169, 17);
            this.chkAPP.TabIndex = 9;
            this.chkAPP.Text = "Accredited Press Photography";
            this.chkAPP.UseVisualStyleBackColor = true;
            this.chkAPP.CheckedChanged += new System.EventHandler(this.chkAPP_CheckedChanged);
            // 
            // frmGSManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 381);
            this.Controls.Add(this.chkAPP);
            this.Controls.Add(this.btnGenCS);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblArtistName);
            this.Controls.Add(this.lblArtistID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMerch);
            this.Name = "frmGSManager";
            this.Text = "Gallery Store Manager";
            this.Load += new System.EventHandler(this.frmGSManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstMerch;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblArtistID;
        private System.Windows.Forms.Label lblArtistName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtPricePerUnit;
        private System.Windows.Forms.TextBox txtGivenStock;
        private System.Windows.Forms.TextBox txtPieceTitle;
        private System.Windows.Forms.Button btnGenID;
        private System.Windows.Forms.TextBox txtPieceID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnGenBarcode;
        private System.Windows.Forms.Button btnGenCS;
        private System.Windows.Forms.CheckBox chkSDC;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox chkAPP;
    }
}