using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class message : Form
    {
        public message()
        {
            InitializeComponent();
            loadTable();
        }

        private void loadTable()
        {
            MySqlConnection cnn;
            string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            MySqlCommand comm = new MySqlCommand("SELECT pracownik.login,wiadomosc.tresc FROM pracownik INNER JOIN wiadomosc ON pracownik.id=wiadomosc.id_prac1", cnn);
            MySqlDataAdapter adpt = new MySqlDataAdapter();
            adpt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dt;
            dataGridView1.DataSource = bSource;
            adpt.Update(dt);

            cnn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for (int i = dataGridView1.Rows.Count - 1; i >= 0; i++)
            //{
            //    bool delete = (bool)dataGridView1.Rows[i].Cells[1].Value;
            //    if (delete == true)
            //    {
            //        MySqlCommand del = new MySqlCommand("DELETE FROM wiadomosc WHERE id='" + i + "'");
            //        MySqlDataReader reader = del.ExecuteReader();
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}