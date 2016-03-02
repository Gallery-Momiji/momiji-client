namespace Momiji
{
    partial class frmAuctionSale
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.aID = new System.Windows.Forms.ColumnHeader();
            this.pTitle = new System.Windows.Forms.ColumnHeader();
            this.pID = new System.Windows.Forms.ColumnHeader();
            this.piecePrice = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.btnPaid = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.aID,
            this.pTitle,
            this.pID,
            this.piecePrice});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(423, 383);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // aID
            // 
            this.aID.Text = "ArtistID";
            this.aID.Width = 66;
            // 
            // pTitle
            // 
            this.pTitle.Text = "Piece Title";
            this.pTitle.Width = 223;
            // 
            // pID
            // 
            this.pID.Text = "PieceID";
            this.pID.Width = 70;
            // 
            // piecePrice
            // 
            this.piecePrice.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Highlight this box and scan:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(435, 26);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(196, 20);
            this.txtID.TabIndex = 4;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Now tell me how much it sold for:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(435, 66);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(196, 20);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Image = global::Momiji.Properties.Resources.page_add;
            this.btnAddToList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddToList.Location = new System.Drawing.Point(435, 93);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(90, 23);
            this.btnAddToList.TabIndex = 7;
            this.btnAddToList.Text = "Add to list";
            this.btnAddToList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::Momiji.Properties.Resources.cancel;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(531, 93);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Fields";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total : $";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(486, 121);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(145, 20);
            this.txtTotal.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Paid :  $";
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(486, 147);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(145, 20);
            this.txtPaid.TabIndex = 12;
            this.txtPaid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPaid_KeyUp);
            // 
            // btnPaid
            // 
            this.btnPaid.Enabled = false;
            this.btnPaid.Image = global::Momiji.Properties.Resources.auctionSale;
            this.btnPaid.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPaid.Location = new System.Drawing.Point(435, 177);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(196, 99);
            this.btnPaid.TabIndex = 13;
            this.btnPaid.Text = "Mark as Paid";
            this.btnPaid.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPaid.UseVisualStyleBackColor = true;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Change :";
            // 
            // txtChange
            // 
            this.txtChange.Enabled = false;
            this.txtChange.Location = new System.Drawing.Point(497, 282);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(134, 20);
            this.txtChange.TabIndex = 15;
            // 
            // btnFinish
            // 
            this.btnFinish.Image = global::Momiji.Properties.Resources.cross;
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(435, 308);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(196, 23);
            this.btnFinish.TabIndex = 16;
            this.btnFinish.Text = "Clear / Finish Transaction";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // frmAuctionSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 383);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPaid);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "frmAuctionSale";
            this.Text = "Auction Sale";
            this.Load += new System.EventHandler(this.frmAuctionSale_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader aID;
        private System.Windows.Forms.ColumnHeader pTitle;
        private System.Windows.Forms.ColumnHeader pID;
        private System.Windows.Forms.ColumnHeader piecePrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.Button btnFinish;
    }
}