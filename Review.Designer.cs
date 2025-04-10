namespace IOOP_Assignment
{
    partial class frmReview
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
            this.txtRating = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblRating10 = new System.Windows.Forms.Label();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.lblDOrderNo = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblReviewTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRating
            // 
            this.txtRating.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRating.Location = new System.Drawing.Point(325, 418);
            this.txtRating.Margin = new System.Windows.Forms.Padding(2);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(38, 36);
            this.txtRating.TabIndex = 23;
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(817, 539);
            this.btnDone.Margin = new System.Windows.Forms.Padding(2);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(139, 38);
            this.btnDone.TabIndex = 22;
            this.btnDone.Text = "DONE";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(180, 539);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(139, 38);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblRating10
            // 
            this.lblRating10.AutoSize = true;
            this.lblRating10.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating10.Location = new System.Drawing.Point(376, 426);
            this.lblRating10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRating10.Name = "lblRating10";
            this.lblRating10.Size = new System.Drawing.Size(45, 28);
            this.lblRating10.TabIndex = 20;
            this.lblRating10.Text = "/10";
            // 
            // txtFeedback
            // 
            this.txtFeedback.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeedback.Location = new System.Drawing.Point(325, 198);
            this.txtFeedback.Margin = new System.Windows.Forms.Padding(2);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(631, 203);
            this.txtFeedback.TabIndex = 19;
            // 
            // lblDOrderNo
            // 
            this.lblDOrderNo.AutoSize = true;
            this.lblDOrderNo.BackColor = System.Drawing.Color.White;
            this.lblDOrderNo.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOrderNo.Location = new System.Drawing.Point(328, 130);
            this.lblDOrderNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDOrderNo.Name = "lblDOrderNo";
            this.lblDOrderNo.Size = new System.Drawing.Size(0, 33);
            this.lblDOrderNo.TabIndex = 18;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(174, 421);
            this.lblRating.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(85, 33);
            this.lblRating.TabIndex = 17;
            this.lblRating.Text = "Rating:";
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedback.Location = new System.Drawing.Point(174, 188);
            this.lblFeedback.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(108, 33);
            this.lblFeedback.TabIndex = 16;
            this.lblFeedback.Text = "Feedback:";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.BackColor = System.Drawing.Color.White;
            this.lblOrderNo.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.Location = new System.Drawing.Point(174, 130);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(118, 33);
            this.lblOrderNo.TabIndex = 15;
            this.lblOrderNo.Text = "Order No.:";
            // 
            // lblReviewTitle
            // 
            this.lblReviewTitle.AutoSize = true;
            this.lblReviewTitle.Font = new System.Drawing.Font("Segoe Script", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviewTitle.Location = new System.Drawing.Point(277, 9);
            this.lblReviewTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReviewTitle.Name = "lblReviewTitle";
            this.lblReviewTitle.Size = new System.Drawing.Size(551, 57);
            this.lblReviewTitle.TabIndex = 14;
            this.lblReviewTitle.Text = "Customer Feedback - Orders";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.lblReviewTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 75);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Azure;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 622);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1125, 100);
            this.panel2.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Azure;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 547);
            this.panel3.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Azure;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1025, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 547);
            this.panel4.TabIndex = 27;
            // 
            // frmReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1125, 722);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblRating10);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.lblDOrderNo);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblOrderNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReview";
            this.Text = "Review";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblRating10;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.Label lblDOrderNo;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblReviewTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}