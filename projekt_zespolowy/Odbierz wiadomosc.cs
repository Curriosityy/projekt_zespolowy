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
        public int idMessage;

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

            MySqlCommand comm = new MySqlCommand("SELECT wiadomosc.id,pracownik.login,wiadomosc.tresc FROM pracownik INNER JOIN wiadomosc ON pracownik.id=wiadomosc.id_prac1", cnn);
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                idMessage = int.Parse(Convert.ToString(selectedRow.Cells["id"].Value));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cnn;
                string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();

                MySqlCommand deleteMessage = new MySqlCommand("DELETE FROM wiadomosc WHERE id='" + idMessage + "'", cnn);
                deleteMessage.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
            message m1 = new message();
            m1.Show();
        }
    }
}