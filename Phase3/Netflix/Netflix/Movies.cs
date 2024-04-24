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
    public partial class Movies : Form
    {
        string clientID;
        public Movies(string clientID)
        {
            InitializeComponent();
            this.clientID = clientID;
        }

        private void Movies_Load(object sender, EventArgs e)
        {
            this.moviesTableAdapter.Fill(this.netflixDataSet1.Movies);
            this.genreTableAdapter.Fill(this.netflixDataSet1.Genre);

        }
     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int movieId = int.Parse(textmovieid.Text);
            DateTime watchDate = DateTime.Now;

            using (SqlConnection connection = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Netflix; Integrated Security = True"))
            {
                string query = "INSERT INTO Watches (movie_id, watch_date) VALUES (@MovieId, @WatchDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MovieId", movieId);
                    command.Parameters.AddWithValue("@WatchDate", watchDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                    this.Hide();
                    Home home = new Home(clientID);
                    home.ShowDialog();
                    this.Close();
                }
            }
        }
    }

    }
