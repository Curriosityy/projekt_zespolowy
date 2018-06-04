using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace projekt_zespolowy
{
    public partial class OdbierzZgloszenie : Form
    {
        private int idSerwisanta;
        private List<int> idZgloszenia = new List<int>();
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
        private MySqlConnection cnn;
        private MySqlCommand com;
        private string query;
        private MySqlDataReader reader;

        public OdbierzZgloszenie(int id)
        {
            InitializeComponent();
            idSerwisanta = id;
            cnn = new MySqlConnection(connectionString);
        }

        private void OdbierzZgloszenie_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            checkedListBox1.Items.Clear();
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
                        checkedListBox1.Items.Add(reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4));
                    }
                }
                reader.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkedListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.checkedListBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                try
                {
                    cnn.Open();
                    query = "Select zgloszenie.id,zgloszenie.opis,klient.imie,klient.nazwisko,klient.ulica,klient.nr_domu,klient.nr_lokalu From zgloszenie JOIN klient ON klient.id=zgloszenie.id_klienta Where zgloszenie.id='" + idZgloszenia[index] + "';";
                    com = new MySqlCommand(query, cnn);
                    reader = com.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        MessageBox.Show(reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4) + " " + reader.GetString(5) + "/" + reader.GetString(6) + "\n" + reader.GetString(1));
                    }
                    reader.Close();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                cnn.Open();
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    id = checkedListBox1.Items.IndexOf(checkedListBox1.CheckedItems[i]);
                    query = "Update zgloszenia Set id_prac='" + idSerwisanta + "',status='1' Where id='" + idZgloszenia[id] + "';";
                    com = new MySqlCommand(query, cnn);
                    reader = com.ExecuteReader();
                    reader.Close();
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