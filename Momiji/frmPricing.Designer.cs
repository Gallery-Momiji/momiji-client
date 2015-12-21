namespace Momiji
{
    partial class frmPricing
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCalcPanels = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuarterPanel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHalfPanel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFullPanel = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuarterTable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHalfTable = new System.Windows.Forms.TextBox();
            this.lblFullTable = new System.Windows.Forms.Label();
            this.txtFullTable = new System.Windows.Forms.TextBox();
            this.btnCalcTables = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpOverdueDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOverduePercentage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCalcPanels);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtQuarterPanel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHalfPanel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFullPanel);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Panels";
            // 
            // btnCalcPanels
            // 
            this.btnCalcPanels.Image = global::Momiji.Properties.Resources.calculator_edit;
            this.btnCalcPanels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalcPanels.Location = new System.Drawing.Point(142, 34);
            this.btnCalcPanels.Name = "btnCalcPanels";
            this.btnCalcPanels.Size = new System.Drawing.Size(114, 23);
            this.btnCalcPanels.TabIndex = 6;
            this.btnCalcPanels.Text = "Calculate Others";
            this.btnCalcPanels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalcPanels.UseVisualStyleBackColor = true;
            this.btnCalcPanels.Click += new System.EventHandler(this.btnCalcPanels_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Price for a Quarter Panel";
            // 
            // txtQuarterPanel
            // 
            this.txtQuarterPanel.Location = new System.Drawing.Point(142, 91);
            this.txtQuarterPanel.Name = "txtQuarterPanel";
            this.txtQuarterPanel.Size = new System.Drawing.Size(104, 20);
            this.txtQuarterPanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Price for a Half Panel";
            // 
            // txtHalfPanel
            // 
            this.txtHalfPanel.Location = new System.Drawing.Point(9, 91);
            this.txtHalfPanel.Name = "txtHalfPanel";
            this.txtHalfPanel.Size = new System.Drawing.Size(104, 20);
            this.txtHalfPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Price for a Full Panel";
            // 
            // txtFullPanel
            // 
            this.txtFullPanel.Location = new System.Drawing.Point(9, 37);
            this.txtFullPanel.Name = "txtFullPanel";
            this.txtFullPanel.Size = new System.Drawing.Size(104, 20);
            this.txtFullPanel.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Momiji.Properties.Resources.page_save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(465, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Changes";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtQuarterTable);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtHalfTable);
            this.groupBox2.Controls.Add(this.lblFullTable);
            this.groupBox2.Controls.Add(this.txtFullTable);
            this.groupBox2.Controls.Add(this.btnCalcTables);
            this.groupBox2.Location = new System.Drawing.Point(280, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 122);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tables";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Price for a Quarter Table";
            // 
            // txtQuarterTable
            // 
            this.txtQuarterTable.Location = new System.Drawing.Point(142, 91);
            this.txtQuarterTable.Name = "txtQuarterTable";
            this.txtQuarterTable.Size = new System.Drawing.Size(104, 20);
            this.txtQuarterTable.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Price for a Half Table";
            // 
            // txtHalfTable
            // 
            this.txtHalfTable.Location = new System.Drawing.Point(9, 91);
            this.txtHalfTable.Name = "txtHalfTable";
            this.txtHalfTable.Size = new System.Drawing.Size(104, 20);
            this.txtHalfTable.TabIndex = 10;
            // 
            // lblFullTable
            // 
            this.lblFullTable.AutoSize = true;
            this.lblFullTable.Location = new System.Drawing.Point(6, 21);
            this.lblFullTable.Name = "lblFullTable";
            this.lblFullTable.Size = new System.Drawing.Size(104, 13);
            this.lblFullTable.TabIndex = 9;
            this.lblFullTable.Text = "Price for a Full Table";
            // 
            // txtFullTable
            // 
            this.txtFullTable.Location = new System.Drawing.Point(9, 37);
            this.txtFullTable.Name = "txtFullTable";
            this.txtFullTable.Size = new System.Drawing.Size(104, 20);
            this.txtFullTable.TabIndex = 8;
            // 
            // btnCalcTables
            // 
            this.btnCalcTables.Image = global::Momiji.Properties.Resources.calculator_edit;
            this.btnCalcTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalcTables.Location = new System.Drawing.Point(142, 34);
            this.btnCalcTables.Name = "btnCalcTables";
            this.btnCalcTables.Size = new System.Drawing.Size(114, 23);
            this.btnCalcTables.TabIndex = 7;
            this.btnCalcTables.Text = "Calculate Others";
            this.btnCalcTables.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalcTables.UseVisualStyleBackColor = true;
            this.btnCalcTables.Click += new System.EventHandler(this.btnCalcTables_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "if an Artist registers with us after ";
            // 
            // dtpOverdueDate
            // 
            this.dtpOverdueDate.Location = new System.Drawing.Point(176, 131);
            this.dtpOverdueDate.Name = "dtpOverdueDate";
            this.dtpOverdueDate.Size = new System.Drawing.Size(185, 20);
            this.dtpOverdueDate.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Charge them an extra of";
            // 
            // txtOverduePercentage
            // 
            this.txtOverduePercentage.Location = new System.Drawing.Point(176, 154);
            this.txtOverduePercentage.Name = "txtOverduePercentage";
            this.txtOverduePercentage.Size = new System.Drawing.Size(39, 20);
            this.txtOverduePercentage.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "% as a late fee.";
            // 
            // frmPricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 181);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtOverduePercentage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpOverdueDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPricing";
            this.Text = "Gallery Pricing Preferences";
            this.Load += new System.EventHandler(this.frmPricing_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuarterPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHalfPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullPanel;
        private System.Windows.Forms.Button btnCalcPanels;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuarterTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHalfTable;
        private System.Windows.Forms.Label lblFullTable;
        private System.Windows.Forms.TextBox txtFullTable;
        private System.Windows.Forms.Button btnCalcTables;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpOverdueDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOverduePercentage;
        private System.Windows.Forms.Label label8;
    }
}