namespace IOOP_Assignment
{
    partial class changePassword
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
            this.txtNewPassAgain = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.lblNewPassAgain = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblOldPass = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEnterNewPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewPassAgain
            // 
            this.txtNewPassAgain.Location = new System.Drawing.Point(212, 138);
            this.txtNewPassAgain.Name = "txtNewPassAgain";
            this.txtNewPassAgain.Size = new System.Drawing.Size(124, 20);
            this.txtNewPassAgain.TabIndex = 15;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(212, 83);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(124, 20);
            this.txtNewPass.TabIndex = 14;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(212, 39);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(124, 20);
            this.txtOldPass.TabIndex = 13;
            // 
            // lblNewPassAgain
            // 
            this.lblNewPassAgain.AutoSize = true;
            this.lblNewPassAgain.Location = new System.Drawing.Point(42, 143);
            this.lblNewPassAgain.Name = "lblNewPassAgain";
            this.lblNewPassAgain.Size = new System.Drawing.Size(119, 13);
            this.lblNewPassAgain.TabIndex = 12;
            this.lblNewPassAgain.Text = "Re-enter new password";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Location = new System.Drawing.Point(42, 88);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(103, 13);
            this.lblNewPass.TabIndex = 11;
            this.lblNewPass.Text = "Enter new password";
            // 
            // lblOldPass
            // 
            this.lblOldPass.AutoSize = true;
            this.lblOldPass.Location = new System.Drawing.Point(42, 42);
            this.lblOldPass.Name = "lblOldPass";
            this.lblOldPass.Size = new System.Drawing.Size(97, 13);
            this.lblOldPass.TabIndex = 10;
            this.lblOldPass.Text = "Enter old password";
            // 
            // btnBack
            // 
            this.btnBack.AllowDrop = true;
            this.btnBack.Location = new System.Drawing.Point(24, 253);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnEnterNewPass
            // 
            this.btnEnterNewPass.Location = new System.Drawing.Point(261, 192);
            this.btnEnterNewPass.Name = "btnEnterNewPass";
            this.btnEnterNewPass.Size = new System.Drawing.Size(75, 23);
            this.btnEnterNewPass.TabIndex = 8;
            this.btnEnterNewPass.Text = "Enter";
            this.btnEnterNewPass.UseVisualStyleBackColor = true;
            // 
            // changePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 315);
            this.Controls.Add(this.txtNewPassAgain);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.lblNewPassAgain);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.lblOldPass);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnEnterNewPass);
            this.Name = "changePassword";
            this.Text = "changePasswordChef";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewPassAgain;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label lblNewPassAgain;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnEnterNewPass;
    }
}