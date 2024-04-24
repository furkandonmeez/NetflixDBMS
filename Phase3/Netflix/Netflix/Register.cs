using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Netflix
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Netflix;Integrated Security=True";
        SqlConnection connect = new SqlConnection(constring);
        private string GenerateClientID()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 999999);
            return randomNumber.ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                if (connect.State==ConnectionState.Closed) { }
                connect.Open();

                string clientID = GenerateClientID();
                string insertQueryClients = "INSERT INTO Clients (client_id, first_name, last_name, address,signup_date) VALUES (@clientID, @firstName, @lastName, @address,@signupDate)";
                SqlCommand command = new SqlCommand(insertQueryClients, connect);

                command.Parameters.AddWithValue("@clientID", clientID);
                command.Parameters.AddWithValue("@firstName", textname.Text);
                command.Parameters.AddWithValue("@lastName", textsurname.Text);
                command.Parameters.AddWithValue("@address", textaddress.Text);
                command.Parameters.AddWithValue("@signupDate", DateTime.Now);

                command.ExecuteNonQuery();

                string insertQueryContact1 = "INSERT INTO ClientContact1 (client_id, email) VALUES (@clientID, @email)";
                SqlCommand command1 = new SqlCommand(insertQueryContact1, connect);

                command1.Parameters.AddWithValue("@clientID", clientID);
                command1.Parameters.AddWithValue("@email", textemail.Text);

                command1.ExecuteNonQuery();

                string insertQueryContact2 = "INSERT INTO ClientContact2 (client_id, phone_number) VALUES (@clientID, @phoneNumber)";
                SqlCommand command2 = new SqlCommand(insertQueryContact2, connect);

                command2.Parameters.AddWithValue("@clientID", clientID);
                command2.Parameters.AddWithValue("@phoneNumber", textphonenumber.Text);

                command2.ExecuteNonQuery();

                string insertQueryLogin = "INSERT INTO Login (username, password,client_id) VALUES (@username, @password,@clientID)";
                SqlCommand command3 = new SqlCommand(insertQueryLogin, connect);

               
                command3.Parameters.AddWithValue("@username", textusername.Text);
                command3.Parameters.AddWithValue("@password", textpassword.Text);
                command3.Parameters.AddWithValue("@clientID", clientID);

                command3.ExecuteNonQuery();

                if (string.IsNullOrEmpty(textname.Text) || string.IsNullOrEmpty(textsurname.Text) 
                    || string.IsNullOrEmpty(textemail.Text) || string.IsNullOrEmpty(textphonenumber.Text)
                    || string.IsNullOrEmpty(textusername.Text) || string.IsNullOrEmpty(textpassword.Text)
                    || string.IsNullOrEmpty(textaddress.Text))
                {
                    MessageBox.Show("Please fill in all blank fields.");
                    return;
                }
                connect.Close();

                
                this.Hide();
                Subscription subs = new Subscription(clientID);
                subs.ShowDialog();
                this.Close();



            }
            catch (Exception hata){
                MessageBox.Show("Error occurred!" + hata.Message);
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textpassword_TextChanged(object sender, EventArgs e)
        {
            textpassword.PasswordChar = '*';
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
