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
    public partial class Zgłoszenia : Form
    {
        private int id_odbier;
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";

        public Zgłoszenia(int id)
        {
            InitializeComponent();
            id_odbier = id;
            loadTable(id_odbier);
            MySqlConnection cnn = new MySqlConnection(connectionString);
        }

        private void loadTable(int id)
        {
            try
            {
                MySqlConnection cnn;
                cnn = new MySqlConnection(connectionString);
                cnn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT zgloszenie.id,klient.imie,klient.nazwisko,zgloszenie.opis FROM klient INNER JOIN zgloszenie ON klient.id = zgloszenie.id_klienta  WHERE zgloszenie.id_prac='" + id + "' AND zgloszenie.status='" + 1 + "'", cnn);

                MySqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3));
                    }
                }
                reader.Close();

                cnn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button2.Visible = true;
                ZakonczZgloszenie.ActiveForm.Height = 500;
            }
            else
            {
                MessageBox.Show("Proszę wybrać zgłoszenie!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cnn;
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                int id_zgloszenia = ((int)listBox1.SelectedItem.ToString()[0]) - 48;

                MySqlCommand update_zgl = new MySqlCommand("UPDATE zgloszenie SET koszt=@koszt,opis=@opis,status=@status,data2=@data2 WHERE id='" + id_zgloszenia + "'", cnn);
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Proszę wprowadzić cenę!");
                }
                else
                {
                    update_zgl.Parameters.AddWithValue("@koszt", textBox1.Text);
                }

                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Proszę wprowadzić opis!");
                }
                else
                {
                    update_zgl.Parameters.AddWithValue("@opis", textBox2.Text);
                    update_zgl.Parameters.AddWithValue("@status", 2);
                    update_zgl.Parameters.AddWithValue("@data2", DateTime.Now);
                    update_zgl.ExecuteNonQuery();
                    MessageBox.Show("Pomyślnie zakończnono zgłoszenie!");
                    this.Hide();
                    Serwisant s1 = new Serwisant(int.Parse(Logowanie.access.Rows[0][1].ToString()));
                    s1.Show();
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}