using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class DodajZgłoszenie : Form
    {
        public DodajZgłoszenie()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void DodajZgłoszenie_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn;
            string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
            cnn = new MySqlConnection(connetionString);

            int id = 0;

            MySqlDataReader myReader;

            try
            {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO zgloszenie (id_klienta,opis,status) VALUES (@id_klienta,@opis,@status)", cnn);
                MySqlCommand cmd1 = new MySqlCommand("SELECT id FROM klient WHERE tel='" + textBox2.Text + "'", cnn);

                myReader = cmd1.ExecuteReader();

                while (myReader.Read())
                {
                    id = int.Parse(myReader.GetString("id"));
                }
                cmd.Parameters.AddWithValue("@id_klienta", id);
                cmd.Parameters.AddWithValue("@opis", textBox1.Text);
                cmd.Parameters.AddWithValue("@status", 0);
                myReader.Close();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pomyślnie dodano zlecenie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MySqlDataAdapter adp = new MySqlDataAdapter("SELECT id FROM klient WHERE tel='" + textBox2.Text + "'", cnn);
            //DataTable koza = new DataTable();
            // adp.Fill(koza);
            //
            //if (koza.Rows[0][0].ToString() == "1")
            // {
            // }

            cnn.Close();

            this.Hide();
            Sekretarka s1 = new Sekretarka(int.Parse(Logowanie.access.Rows[0][1].ToString()));
            s1.Show();
        }
    }
}