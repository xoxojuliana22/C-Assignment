namespace IOOP_Assignment
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnBeverages = new System.Windows.Forms.Button();
            this.btnDessert = new System.Windows.Forms.Button();
            this.btnMainDishes = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowMenu
            // 
            this.flowMenu.AllowDrop = true;
            this.flowMenu.AutoScroll = true;
            this.flowMenu.BackColor = System.Drawing.Color.White;
            this.flowMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowMenu.Location = new System.Drawing.Point(78, 105);
            this.flowMenu.Name = "flowMenu";
            this.flowMenu.Size = new System.Drawing.Size(970, 616);
            this.flowMenu.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAll);
            this.panel1.Controls.Add(this.btnBeverages);
            this.panel1.Controls.Add(this.btnDessert);
            this.panel1.Controls.Add(this.btnMainDishes);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnCart);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 105);
            this.panel1.TabIndex = 2;
            // 
            // btnAll
            // 
            this.btnAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAll.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAll.Location = new System.Drawing.Point(78, 56);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(155, 45);
            this.btnAll.TabIndex = 7;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnBeverages
            // 
            this.btnBeverages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBeverages.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBeverages.FlatAppearance.BorderSize = 0;
            this.btnBeverages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeverages.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeverages.ForeColor = System.Drawing.SystemColors.Window;
            this.btnBeverages.Location = new System.Drawing.Point(637, 56);
            this.btnBeverages.Name = "btnBeverages";
            this.btnBeverages.Size = new System.Drawing.Size(155, 45);
            this.btnBeverages.TabIndex = 6;
            this.btnBeverages.Text = "Beverages";
            this.btnBeverages.UseVisualStyleBackColor = true;
            this.btnBeverages.Click += new System.EventHandler(this.btnBeverages_Click);
            // 
            // btnDessert
            // 
            this.btnDessert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDessert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDessert.FlatAppearance.BorderSize = 0;
            this.btnDessert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDessert.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDessert.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDessert.Location = new System.Drawing.Point(452, 56);
            this.btnDessert.Name = "btnDessert";
            this.btnDessert.Size = new System.Drawing.Size(155, 45);
            this.btnDessert.TabIndex = 5;
            this.btnDessert.Text = "Dessert";
            this.btnDessert.UseVisualStyleBackColor = true;
            this.btnDessert.Click += new System.EventHandler(this.btnDessert_Click);
            // 
            // btnMainDishes
            // 
            this.btnMainDishes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMainDishes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMainDishes.FlatAppearance.BorderSize = 0;
            this.btnMainDishes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainDishes.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainDishes.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMainDishes.Location = new System.Drawing.Point(257, 56);
            this.btnMainDishes.Name = "btnMainDishes";
            this.btnMainDishes.Size = new System.Drawing.Size(155, 45);
            this.btnMainDishes.TabIndex = 4;
            this.btnMainDishes.Text = "Main Dishes";
            this.btnMainDishes.UseVisualStyleBackColor = true;
            this.btnMainDishes.Click += new System.EventHandler(this.btnMainDishes_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnSearch.Location = new System.Drawing.Point(12, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 45);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnCart.Location = new System.Drawing.Point(1047, 8);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(66, 45);
            this.btnCart.TabIndex = 3;
            this.btnCart.Text = "Cart";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(97, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(751, 38);
            this.txtSearch.TabIndex = 0;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1125, 722);
            this.ControlBox = false;
            this.Controls.Add(this.flowMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnBeverages;
        private System.Windows.Forms.Button btnDessert;
        private System.Windows.Forms.Button btnMainDishes;
        private System.Windows.Forms.Button btnAll;
    }
}