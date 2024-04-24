using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Netflix
{
    public partial class Subscription : Form
    {
        string clientID;
        public Subscription(string clientID)
        {
            InitializeComponent();
            this.clientID = clientID;
        }
        private string GenerateSubscriptionID()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 999999);
            return randomNumber.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            string subscriptionType = comboBox1.SelectedItem.ToString();
            DateTime subscriptionDate = dateTimePicker1.Value;

            // SQL bağlantı dizesini tanımlayın
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Netflix;Integrated Security=True";

            // SQL bağlantısını oluşturun ve sorguyu yürütün
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string subscriptionID = GenerateSubscriptionID();
                    string selectedSubscription = comboBox1.SelectedItem.ToString();
                    textclientid.Text = clientID.ToString();

                    // Verileri ekleme sorgusunu hazırlayın
                    string query = "INSERT INTO Subscription (subscription_id, client_id, subscription_date) VALUES (@subscriptionID, @clientID, @subscriptionDate)";

                    // Sorguyu yürütmek için bir SqlCommand nesnesi oluşturun
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri ekleyin ve değerlerini atayın
                        command.Parameters.AddWithValue("@subscriptionID", subscriptionID);
                        command.Parameters.AddWithValue("@clientID", clientID);
                        
                        command.Parameters.AddWithValue("@subscriptionDate", subscriptionDate);
                        

                        // Sorguyu yürütün
                        command.ExecuteNonQuery();
                        if (string.IsNullOrEmpty(comboBox1.Text))
                        {
                            MessageBox.Show("Please fill in all blank fields.");
                            return;
                        }
                        
                        this.Hide();
                        Payment paym = new Payment(selectedSubscription,clientID);
                        paym.ShowDialog();
                        this.Close();

                        //MessageBox.Show("Veriler SQL'e başarıyla eklendi.");
                    }
                }
                catch (Exception hata)
                {
                    
                }
            }
        }

        private void textclientid_TextChanged(object sender, EventArgs e)
        {
            textclientid.Text = clientID.ToString();

        }
    }
}
