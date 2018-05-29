using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class ZakonczZgloszenie : Form
    {
        public ZakonczZgloszenie()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Serwisant ok = new Serwisant(int.Parse(Logowanie.access.Rows[0][1].ToString()));
            ok.Show();
        }

        private void ZakonczZgloszenie_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn;
            string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            try
            {
                MySqlCommand update = new MySqlCommand("UPDATE zgloszenia SET koszt = @koszt, opis = @opis, status = @status WHERE id=2", cnn);

                update.Parameters.AddWithValue("koszt", textBox1);
                update.Parameters.AddWithValue("opis", textBox2);
                update.Parameters.AddWithValue("status", 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Hide();
            Serwisant s1 = new Serwisant(int.Parse(Logowanie.access.Rows[0][1].ToString()));
            s1.Show();
        }
    }
}