namespace IOOP_Assignment
{
    partial class frmCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCart));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlCart = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnPay3 = new System.Windows.Forms.Button();
            this.btnPay2 = new System.Windows.Forms.Button();
            this.btnPay1 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1109, 67);
            this.panel2.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(495, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 51);
            this.label1.TabIndex = 23;
            this.label1.Text = "Cart";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(81, 616);
            this.panel1.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1028, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(81, 616);
            this.panel3.TabIndex = 27;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.pnlCart);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(87, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(935, 610);
            this.panel4.TabIndex = 28;
            // 
            // pnlCart
            // 
            this.pnlCart.AutoScroll = true;
            this.pnlCart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCart.Location = new System.Drawing.Point(5, 4);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Size = new System.Drawing.Size(901, 458);
            this.pnlCart.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.lblTotal);
            this.panel5.Controls.Add(this.btnPay3);
            this.panel5.Controls.Add(this.btnPay2);
            this.panel5.Controls.Add(this.btnPay1);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(3, 468);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(903, 288);
            this.panel5.TabIndex = 18;
            // 
            // btnPay3
            // 
            this.btnPay3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPay3.BackgroundImage")));
            this.btnPay3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPay3.FlatAppearance.BorderSize = 0;
            this.btnPay3.Location = new System.Drawing.Point(718, 159);
            this.btnPay3.Name = "btnPay3";
            this.btnPay3.Size = new System.Drawing.Size(125, 104);
            this.btnPay3.TabIndex = 29;
            this.btnPay3.UseVisualStyleBackColor = true;
            this.btnPay3.Click += new System.EventHandler(this.btnPay3_Click);
            // 
            // btnPay2
            // 
            this.btnPay2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPay2.BackgroundImage")));
            this.btnPay2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPay2.FlatAppearance.BorderSize = 0;
            this.btnPay2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPay2.Location = new System.Drawing.Point(400, 159);
            this.btnPay2.Name = "btnPay2";
            this.btnPay2.Size = new System.Drawing.Size(125, 104);
            this.btnPay2.TabIndex = 28;
            this.btnPay2.UseVisualStyleBackColor = true;
            this.btnPay2.Click += new System.EventHandler(this.btnPay2_Click);
            // 
            // btnPay1
            // 
            this.btnPay1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPay1.BackgroundImage")));
            this.btnPay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPay1.FlatAppearance.BorderSize = 0;
            this.btnPay1.Location = new System.Drawing.Point(60, 159);
            this.btnPay1.Name = "btnPay1";
            this.btnPay1.Size = new System.Drawing.Size(125, 104);
            this.btnPay1.TabIndex = 27;
            this.btnPay1.UseVisualStyleBackColor = true;
            this.btnPay1.Click += new System.EventHandler(this.btnPay1_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(899, 44);
            this.panel6.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(403, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 37);
            this.label2.TabIndex = 23;
            this.label2.Text = "Payment";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(54, 69);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 33);
            this.lblTotal.TabIndex = 30;
            this.lblTotal.Text = "Total:";
            // 
            // frmCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1109, 683);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCart";
            this.Text = "Cart";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlCart;
        private System.Windows.Forms.Button btnPay3;
        private System.Windows.Forms.Button btnPay2;
        private System.Windows.Forms.Button btnPay1;
        private System.Windows.Forms.Label lblTotal;
    }
}