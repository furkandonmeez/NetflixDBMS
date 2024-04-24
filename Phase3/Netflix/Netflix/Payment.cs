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
    public partial class Payment : Form
    {
        string clientID;
        string selectedSubscription;
        public Payment(string subscription , string clientID)
        {
            InitializeComponent();
           selectedSubscription = subscription;
            this.clientID = clientID;

        }

        

        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

            labelSubscriptionType.Text = selectedSubscription ;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int paymentId = random.Next(1000, 99999);

           
            decimal amountDueBy = CalculateAmountDue(selectedSubscription);

            DateTime paymentDate = DateTime.Now;

            string paymentMethod = comboBox1.SelectedItem.ToString();

            try
            {
                SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Netflix;Integrated Security=True");
                string query = "INSERT INTO Payment (payment_id, client_id, amount_due, payment_date, payment_method) VALUES (@paymentId, @clientId, @amountDue, @paymentDate, @paymentMethod)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@paymentId", paymentId);
                command.Parameters.AddWithValue("@clientId", clientID);
                command.Parameters.AddWithValue("@amountDue", amountDueBy);
                command.Parameters.AddWithValue("@paymentDate", paymentDate);
                command.Parameters.AddWithValue("@paymentMethod", paymentMethod);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Payment created successfully!");

                this.Hide();
                Login log = new Login();
                log.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while creating payment: " + ex.Message);
            }
        }

        private decimal CalculateAmountDue(string subscriptionType)
        {
            decimal amountDueBy = 0;

            if (subscriptionType == "Standard (100 TL)")
            {
                amountDueBy = 100;
            }
            else if (subscriptionType == "Basic (159 TL)")
            {
                amountDueBy = 159;
            }
            else if (subscriptionType == "Premium (225 TL)")
            {
                amountDueBy = 225;
            }

            return amountDueBy;
        }
    }
    }

