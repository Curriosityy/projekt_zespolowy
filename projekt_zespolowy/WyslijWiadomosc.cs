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
    public partial class WyslijWiadomosc : Form
    {

        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
        private MySqlConnection cnn;
        private MySqlCommand com;
        private string query;
        private MySqlDataReader reader;
        private int idWysylajacego;
        private List<int> szefowie = new List<int>();

        public WyslijWiadomosc(int id)
        {
            InitializeComponent();
            idWysylajacego = id;
        }

        private void RefreshList()
        {
            comboBox1.Items.Clear();
            szefowie.Clear();
            try
            {
                cnn.Open();
                //query = "Select id,login FROM pracownik WHERE id>2 AND ID != '" + id + "';";
                query = "Select id,login FROM pracownik WHERE id>2;";
                com = new MySqlCommand(query, cnn);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        szefowie.Add(reader.GetInt32(0));
                        comboBox1.Items.Add(reader.GetString(1));
                    }
                    comboBox1.SelectedItem = comboBox1.Items[0];
                }
                reader.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void WyslijWiadomosc_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && comboBox1.SelectedItem != null)
            {
                try
                {
                    cnn.Open();

                    query = "INSERT INTO Wiadomosc(od,do,wiadomosc) VALUES('"+idWysylajacego+"','" + szefowie[comboBox1.SelectedIndex] + "','" + richTextBox1.Text + "');";

                    com = new MySqlCommand(query, cnn);

                    reader = com.ExecuteReader();
                    reader.Close();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    cnn.Close();
                    reader.Close();
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
