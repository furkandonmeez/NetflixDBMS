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

namespace Netflix
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Netflix;Integrated Security=True";
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register formRegister = new Register();
            formRegister.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(constring))
                {
                    connect.Open();
                    string query = "SELECT COUNT(*) FROM Login WHERE username = @username AND password = @password";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.Parameters.AddWithValue("@username", textusername.Text);
                    command.Parameters.AddWithValue("@password", textpassword.Text);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        string query2 = "SELECT client_id FROM login WHERE username = @username AND password = @password";
                        SqlCommand command2 = new SqlCommand(query, connect);
                        command2.Parameters.AddWithValue("@username", textusername.Text);
                        command2.Parameters.AddWithValue("@password", textpassword.Text);
                        string clientId2 = command.ExecuteScalar()?.ToString();

                        MessageBox.Show("Login successful.");

                        this.Hide();
                        Home home = new Home(clientId2);
                        home.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }

                   

                 
                    connect.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Error occurred! " + hata.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textpassword.PasswordChar = '*';
        }
    }
}
