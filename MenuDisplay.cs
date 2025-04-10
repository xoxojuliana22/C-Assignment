using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    class MenuDisplay
    {
        private GroupBox grpMainDishes;
        private GroupBox grpDessert;
        private GroupBox grpBeverages;

        private FlowLayoutPanel flpMainDishes;
        private FlowLayoutPanel flpDessert;
        private FlowLayoutPanel flpBeverages;

        public MenuDisplay(GroupBox mainDishesGroupBox, GroupBox dessertGroupBox, GroupBox beveragesGroupBox, EventHandler plusButton_Click, EventHandler minusButton_Click)
        {
            grpMainDishes = mainDishesGroupBox;
            grpDessert = dessertGroupBox;
            grpBeverages = beveragesGroupBox;

            flpMainDishes = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = true,
                MinimumSize = new Size(965, 0),
                MaximumSize = new Size(965, 0)
            };

            flpDessert = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = true,
                MinimumSize = new Size(965, 0),
                MaximumSize = new Size(965, 0)
            };

            flpBeverages = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = true,
                MinimumSize = new Size(965, 0),
                MaximumSize = new Size(965, 0)
            };

            grpMainDishes.Controls.Add(flpMainDishes);
            grpDessert.Controls.Add(flpDessert);
            grpBeverages.Controls.Add(flpBeverages);
        }

        public void DisplayMenuItems(EventHandler plusButton_Click, EventHandler minusButton_Click)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT menuID, m_name, m_description, m_price, m_image, m_category FROM menu", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string menuId = reader["menuID"].ToString();
                        string name = reader["m_name"].ToString();
                        string description = reader["m_description"].ToString();
                        decimal price = Convert.ToDecimal(reader["m_price"]);
                        byte[] imageBytes = reader["m_image"] as byte[] ?? new byte[0];
                        string category = reader["m_category"].ToString();

                        Image image = GetImageFromBytes(imageBytes);
                        Panel menuPanel = CreateMenuPanel(menuId, name, description, price, image, plusButton_Click, minusButton_Click);

                        switch (category.ToLower())
                        {
                            case "main dishes":
                                flpMainDishes.Controls.Add(menuPanel);
                                break;
                            case "dessert":
                                flpDessert.Controls.Add(menuPanel);
                                break;
                            case "beverages":
                                flpBeverages.Controls.Add(menuPanel);
                                break;
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateMenuPanel(string menuId, string name, string description, decimal price, Image image, EventHandler plusButton_Click, EventHandler minusButton_Click)
        {
            Panel panel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BorderStyle = BorderStyle.Fixed3D,
                Margin = new Padding(5)
            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(80, 80),
                Image = image ?? Properties.Resources.NoImage,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            panel.Controls.Add(pictureBox);

            Label lblInfo = new Label
            {
                Font = new Font("Segoe Print", 10),
                Text = $"{menuId} {name}\n{description}\nRM {price:0.00}",
                AutoSize = true,
                Location = new Point(100, 10)
            };
            panel.Controls.Add(lblInfo);

            Label lblQuantity = new Label
            {
                Text = "0",
                Font = new Font("Segoe Print", 12),
                Location = new Point(panel.Width - -565, panel.Height - 10),
                AutoSize = true
            };
            panel.Controls.Add(lblQuantity);

            Button btnMinus = new Button
            {
                Text = "-",
                Font = new Font("Segoe Print", 12, FontStyle.Bold),
                Size = new Size(50, 50),
                Location = new Point(panel.Width - -500, panel.Height - 20),
                Tag = new Tuple<string, Label>(menuId, lblQuantity),
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnMinus.Click += minusButton_Click;
            panel.Controls.Add(btnMinus);

            Button btnPlus = new Button
            {
                Text = "+",
                Font = new Font("Segoe Print", 12, FontStyle.Bold),
                Size = new Size(50, 50),
                Location = new Point(panel.Width - -600, panel.Height - 20),
                Tag = new Tuple<string, Label>(menuId, lblQuantity),
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnPlus.Click += plusButton_Click;
            panel.Controls.Add(btnPlus);

            return panel;
        }

        private Image GetImageFromBytes(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}