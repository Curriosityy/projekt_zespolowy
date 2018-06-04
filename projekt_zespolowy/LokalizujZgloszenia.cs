using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projekt_zespolowy
{
    public partial class LokalizujZgloszenia : Form
    {
        private int idSerwisanta;
        private List<int> idZgloszenia = new List<int>();
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
        private MySqlConnection cnn;
        private MySqlCommand com;
        private string query;
        private MySqlDataReader reader;

        public LokalizujZgloszenia(int id)
        {
            InitializeComponent();
            idSerwisanta = id;
            cnn = new MySqlConnection(connectionString);
        }

        private void RefreshList()
        {
            comboBox1.Items.Clear();
            idZgloszenia.Clear();
            try
            {
                cnn.Open();
                query = "Select zgloszenie.id,zgloszenie.opis,klient.imie,klient.nazwisko,klient.ulica From zgloszenie JOIN klient ON klient.id=zgloszenie.id_klienta Where zgloszenie.status=0;";
                com = new MySqlCommand(query, cnn);
                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idZgloszenia.Add(reader.GetInt32(0));
                        comboBox1.Items.Add(reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4));
                    }
                }
                reader.Close();
                cnn.Close();
                comboBox1.SelectedItem = comboBox1.Items[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LokalizujZgloszenia_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();

                query = "Update zgloszenie Set id_prac='" + idSerwisanta + "',status='1' Where id='" + idZgloszenia[comboBox1.SelectedIndex] + "';";
                com = new MySqlCommand(query, cnn);
                reader = com.ExecuteReader();
                reader.Close();

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ulica = "";
            string numerdomu = "";
            string miasto = "";
            try
            {
                cnn.Open();
                query = "Select zgloszenie.id,zgloszenie.opis,klient.imie,klient.nazwisko,klient.ulica,klient.nr_domu,klient.miejscowosc From zgloszenie JOIN klient ON klient.id=zgloszenie.id_klienta Where zgloszenie.id='" + idZgloszenia[comboBox1.SelectedIndex] + "';";
                com = new MySqlCommand(query, cnn);
                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    richTextBox1.Text = reader.GetString(2) + " " + reader.GetString(3) + "\n" + reader.GetString(1);
                    ulica = reader.GetString(4);
                    numerdomu = reader.GetString(5);
                    miasto = reader.GetString(6);
                }
                reader.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                StringBuilder addres = new StringBuilder();

                addres.Append("https://www.google.pl/maps/place/");
                addres.Append(ulica + "+" + numerdomu + ",+");
                addres.Append(miasto);
                webBrowser1.Navigate(addres.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //webBrowser1
        }
    }
}