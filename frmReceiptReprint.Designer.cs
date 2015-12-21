namespace Momiji
{
    partial class frmReceiptReprint
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
            this.txtTransactionID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnReprintLast = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.Location = new System.Drawing.Point(12, 34);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.Size = new System.Drawing.Size(100, 20);
            this.txtTransactionID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Every ticket has a Transaction ID. If you don\'t remember it, \r\npress the \'Last re" +
                "ceipt\' button and it will be reprinted!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transaction ID:";
            // 
            // btnReprint
            // 
            this.btnReprint.Image = global::Momiji.Properties.Resources.printer_error;
            this.btnReprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprint.Location = new System.Drawing.Point(118, 32);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(95, 23);
            this.btnReprint.TabIndex = 3;
            this.btnReprint.Text = "Re-Print";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnReprintLast
            // 
            this.btnReprintLast.Image = global::Momiji.Properties.Resources.printer_add1;
            this.btnReprintLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprintLast.Location = new System.Drawing.Point(12, 110);
            this.btnReprintLast.Name = "btnReprintLast";
            this.btnReprintLast.Size = new System.Drawing.Size(283, 23);
            this.btnReprintLast.TabIndex = 4;
            this.btnReprintLast.Text = "Re-Print Last Receipt";
            this.btnReprintLast.UseVisualStyleBackColor = true;
            this.btnReprintLast.Click += new System.EventHandler(this.btnReprintLast_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(95, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(13, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmReceiptReprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 145);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnReprintLast);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTransactionID);
            this.Name = "frmReceiptReprint";
            this.Text = "Receipt Reprinter!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTransactionID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Button btnReprintLast;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}