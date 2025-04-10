using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    internal class ManagerProfile
    {
        private string ManagerId, Password, Email;
        private int PhoneNumber;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public string ManagerId1 { get => ManagerId; set => ManagerId=value; }
        public string Password1 { get => Password; set => Password=value; }
        public string Email1 { get => Email; set => Email=value; }
        public int PhoneNumber1 { get => PhoneNumber; set => PhoneNumber=value; }

        public ManagerProfile()
        {

        }

        public bool checkProfile(string ID,string passwoerd)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT managerId, m_password FROM manager WHERE managerId = @ID_Code AND m_password = @passcode", con);
            cmd.Parameters.AddWithValue("@ID_Code", ID);
            cmd.Parameters.AddWithValue("@passcode",passwoerd);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                check = true;

            }
            else
            {
                check = false;

            }
            con.Close();
            return check;
        }
        public string UpdateProfile(string id, string email, string password, int phoneNum)
        {
            string status;
            try
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE manager SET m_email= @mail, m_password = @code, m_num = @number WHERE managerId = @ID", con))
                {
                    command.Parameters.AddWithValue("@mail", email);
                    command.Parameters.AddWithValue("@code", password);
                    command.Parameters.AddWithValue("@number",phoneNum);
                    command.Parameters.AddWithValue("@ID",id);


                    int i = command.ExecuteNonQuery();
                    status = i != 0 ? "Profile updated successfully!" : "Profile update failed";
                }

            }
            catch (SqlException sqlEx)
            {
                status = "An error occurred while updating the profile: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                status = "An unexpected error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(status);
            return status;
        }

        public bool checkEmail(string emailadd)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT m_email FROM manager WHERE m_email = @mail", con);
            cmd.Parameters.AddWithValue("@mail", emailadd);
            
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                check = true;

            }
            else
            {
                check = false;

            }
            con.Close();
            return check;
        }

        public bool checknum(int num)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT m_num FROM manager WHERE m_num = @number", con);
            cmd.Parameters.AddWithValue("@number", num);
         
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                check = true;

            }
            else
            {
                check = false;

            }
            con.Close();
            return check;
        }


        public bool checknumID(string id,int num)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT m_num,managerId FROM manager WHERE m_num = @number and managerId = @id", con);
            cmd.Parameters.AddWithValue("@number", num);
            cmd.Parameters.AddWithValue("@id",id);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                check = true;

            }
            else
            {
                check = false;

            }
            con.Close();
            return check;
        }

        public bool checkEmailid(string id, string emailadd)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT m_email, managerId FROM manager WHERE m_email = @mail and managerId = @id", con);
            cmd.Parameters.AddWithValue("@mail", emailadd);
            cmd.Parameters.AddWithValue("@id", id);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                check = true;

            }
            else
            {
                check = false;

            }
            con.Close();
            return check;
        }



    }

}
