﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class delete : Form
    {
        string dishID;
        public delete()
        {
            InitializeComponent();
            ArrayList menuid = new ArrayList();
            menuid = MenuItems.LoadDish();
            foreach (var item in menuid )
            {
                category.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuItems dsh = new MenuItems();
            dsh.Deletemenu(dishID);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            dishID = category.Text;
            MenuItems dsh = new MenuItems();
            dataGridView1.DataSource = dsh.Displaymenu(dishID);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuOptions form4 = new MenuOptions();
            form4.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
