namespace Momiji
{
    partial class frmUserEdit
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
            this.lblChooseUser = new System.Windows.Forms.Label();
            this.btnLoadInfo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBanner = new System.Windows.Forms.TextBox();
            this.lblBanner = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPass2 = new System.Windows.Forms.MaskedTextBox();
            this.txtPass1 = new System.Windows.Forms.MaskedTextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.drpRank = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstUsers = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChooseUser
            // 
            this.lblChooseUser.AutoSize = true;
            this.lblChooseUser.Location = new System.Drawing.Point(12, 9);
            this.lblChooseUser.Name = "lblChooseUser";
            this.lblChooseUser.Size = new System.Drawing.Size(144, 13);
            this.lblChooseUser.TabIndex = 0;
            this.lblChooseUser.Text = "Please choose a user to edit:";
            // 
            // btnLoadInfo
            // 
            this.btnLoadInfo.Image = global::Momiji.Properties.Resources.status_away;
            this.btnLoadInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadInfo.Location = new System.Drawing.Point(167, 52);
            this.btnLoadInfo.Name = "btnLoadInfo";
            this.btnLoadInfo.Size = new System.Drawing.Size(112, 27);
            this.btnLoadInfo.TabIndex = 2;
            this.btnLoadInfo.Text = "Load User Info";
            this.btnLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadInfo.UseVisualStyleBackColor = true;
            this.btnLoadInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBanner);
            this.groupBox1.Controls.Add(this.lblBanner);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPass2);
            this.groupBox1.Controls.Add(this.txtPass1);
            this.groupBox1.Controls.Add(this.lblPass);
            this.groupBox1.Controls.Add(this.lblRank);
            this.groupBox1.Controls.Add(this.drpRank);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Location = new System.Drawing.Point(15, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 214);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Info";
            // 
            // txtBanner
            // 
            this.txtBanner.Location = new System.Drawing.Point(77, 129);
            this.txtBanner.Name = "txtBanner";
            this.txtBanner.Size = new System.Drawing.Size(175, 20);
            this.txtBanner.TabIndex = 19;
            // 
            // lblBanner
            // 
            this.lblBanner.AutoSize = true;
            this.lblBanner.Location = new System.Drawing.Point(74, 113);
            this.lblBanner.Name = "lblBanner";
            this.lblBanner.Size = new System.Drawing.Size(44, 13);
            this.lblBanner.TabIndex = 18;
            this.lblBanner.Text = "Banner:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Retype:";
            // 
            // txtPass2
            // 
            this.txtPass2.Location = new System.Drawing.Point(152, 179);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(100, 20);
            this.txtPass2.TabIndex = 16;
            // 
            // txtPass1
            // 
            this.txtPass1.Location = new System.Drawing.Point(9, 179);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(100, 20);
            this.txtPass1.TabIndex = 15;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(6, 163);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(56, 13);
            this.lblPass.TabIndex = 14;
            this.lblPass.Text = "Password:";
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Location = new System.Drawing.Point(6, 113);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(39, 13);
            this.lblRank.TabIndex = 13;
            this.lblRank.Text = "Rank :";
            // 
            // drpRank
            // 
            this.drpRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpRank.FormattingEnabled = true;
            this.drpRank.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.drpRank.Location = new System.Drawing.Point(9, 129);
            this.drpRank.Name = "drpRank";
            this.drpRank.Size = new System.Drawing.Size(36, 21);
            this.drpRank.TabIndex = 12;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(9, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 74);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(105, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "First and Last name :";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(9, 42);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(142, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 26);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::Momiji.Properties.Resources.user_edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(15, 305);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Momiji.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(190, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(15, 25);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(264, 21);
            this.lstUsers.TabIndex = 6;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // frmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 339);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoadInfo);
            this.Controls.Add(this.lblChooseUser);
            this.Name = "frmUserEdit";
            this.Text = "Luke UserWalker™";
            this.Load += new System.EventHandler(this.frmUserEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseUser;
        private System.Windows.Forms.Button btnLoadInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox lstUsers;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ComboBox drpRank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtPass2;
        private System.Windows.Forms.MaskedTextBox txtPass1;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.TextBox txtBanner;
        private System.Windows.Forms.Label lblBanner;
    }
}