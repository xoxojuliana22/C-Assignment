﻿using System;
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
    public partial class chosenOrder : Form
    {
        public chosenOrder()
        {
            InitializeComponent();
        }


        private void btnBackMain_Click(object sender, EventArgs e)
        {
            chefMain chefMain = new chefMain();
            chefMain.Show();
            this.Hide();
        }
    }
}
