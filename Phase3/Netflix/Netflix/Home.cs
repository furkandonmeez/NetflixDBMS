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
    public partial class Home : Form
    {
        string clientID;
        public Home(string clientID)
        {
            InitializeComponent();
            this.clientID = clientID;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.moviesTableAdapter.Fill(this.netflixDataSet.Movies);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
            
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Movies movies = new Movies(clientID);
            movies.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form2 = new Login();
            form2.ShowDialog();
            this.Close(); 
        }
    }
}
