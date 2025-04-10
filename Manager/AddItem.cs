using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IOOP_Assignment
{
    public partial class description : Form
    {
        string dishName, dishId, dishcategory, dshDescription;
        double dshprice;
        public description()
        {
            InitializeComponent();
            dishname.Leave += dishname_Leave;
            price.Leave += price_Leave;
            dishid.Leave += dishid_Leave;
            descriptiontxt.Leave += descriptiontxt_Leave;


        }
        private bool ValidateTextWithWhitespaces(string input)
        {
            // Regex to allow letters, digits, and whitespaces but ensure there is at least one non-whitespace character
            Regex regex = new Regex(@"^(?=.*\S)[a-zA-Z0-9\s]*$");
            return regex.IsMatch(input);
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        static bool alphanumeric(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z0-9]*$");
        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dishname_Leave(object sender, EventArgs e)
        {
            if (alphanumeric(dishname.Text) == true || ValidateTextWithWhitespaces(dishname.Text) == true)
            {
                MenuItems dsh = new MenuItems();
                
                if (dsh.checkDishName(dishname.Text) == true)
                {
                    MessageBox.Show("A dish with the same name already exists. Please re enter.");
                    dishname.Clear();
                }
                else
                {
                    dishName = dishname.Text;
                }




            }
            else if (dishname.Text == "")
            {
                MessageBox.Show("Please enter dishname.");
            }
            else
            {
                MessageBox.Show("Invalid dish name, please re enter. Make sure dish name contains letters only.");
                dishname.Clear();
            }
        }

        private bool ValidateInput(string input)
        {
            Regex regex = new Regex("^[a-zA-Z\\s]+$");
            return regex.IsMatch(input);
        }

        
        private bool ValidateWhitespaceInput(string input)
        {
            Regex regex = new Regex("^[\\s]+$");
            return regex.IsMatch(input);
        }
        

        private void category_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuOptions form4 = new MenuOptions();
            form4.Show();
            this.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            dishcategory = category.Text;
        }

        private void price_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(price.Text, out dshprice))
            {
                dshprice = double.Parse(price.Text);
               
            }
            else if (price.Text == "")
            {
                MessageBox.Show("Please enter item price.");
            }
            else
            {
                MessageBox.Show("Please enter a number.");
                price.Clear();
            }
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void price_Click(object sender, EventArgs e)
        {

        }

        private void dishid_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dishid_Leave(object sender, EventArgs e)
        {
            if (alphanumeric(dishid.Text) == true)
            {
                MenuItems rsv1 = new MenuItems();
                if (rsv1.checkDishID(dishid.Text) == true)
                {
                    MessageBox.Show("A dish with this dish ID already exist. Please re-enter.");
                    dishid.Clear();
                }
                else
                {
                    dishId = dishid.Text;
                }
            }
            else if( dishid.Text == "")
            {
                MessageBox.Show("Please enter dish ID");
            }
            else
            {
                MessageBox.Show("Please enter a valid dish id.");
            }

        }
        private void descriptiontxt_Leave(object sender, EventArgs e)
        {
            if (descriptiontxt.Text == "")
            {
                MessageBox.Show("Please enter menu description");
            }
            if(alphanumeric(descriptiontxt.Text) == true || ValidateTextWithWhitespaces(descriptiontxt.Text) == true) 
            {
                dshDescription = descriptiontxt.Text;
               
            }
            else
            {
                dshDescription = descriptiontxt.Text;
            }
            
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(dishid.Text == "" || dishname.Text == "" || price.Text == "" || category.Text == "" || descriptiontxt.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                MenuItems ds = new MenuItems();
                ds.AddDish(dishId, dishName, dishcategory, dshprice, dshDescription);
            }
            

        }
    }
}
