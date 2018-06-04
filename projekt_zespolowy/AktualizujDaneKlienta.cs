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
    public partial class AktualizujDaneKlienta : Form
    {
        private List<int> listOfClient = new List<int>();
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
        private MySqlConnection cnn;
        private MySqlCommand com;
        private string query;
        private MySqlDataReader reader;

        public AktualizujDaneKlienta()
        {
            InitializeComponent();
            cnn = new MySqlConnection(connectionString);
        }

        private void AktualizujDaneKlienta_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            comboBox1.Items.Clear();
            listOfClient.Clear();
            try
            {
                cnn.Open();
                //query = "Select id,login FROM pracownik WHERE id>2 AND ID != '" + id + "';";
                query = "Select id,imie,nazwisko FROM klient;";
                com = new MySqlCommand(query, cnn);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listOfClient.Add(reader.GetInt32(0));
                        comboBox1.Items.Add(reader.GetString(1) + " " + reader.GetString(2));
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

        private void exit_add_client_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_client_Click(object sender, EventArgs e)
        {
            bool anyError = false;
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Proszę wprowadzić imie");
                this.textBoxName.Focus();
                anyError = true;
            }

            if (string.IsNullOrEmpty(textBoxSurename.Text))
            {
                MessageBox.Show("Proszę wprowadzić nazwisko");
                this.textBoxSurename.Focus();
                anyError = true;
            }

            if (string.IsNullOrEmpty(textBoxCity.Text))
            {
                MessageBox.Show("Proszę wprowadzić miasto");
                this.textBoxCity.Focus();
                anyError = true;
            }

            if (string.IsNullOrEmpty(textBoxStreet.Text))
            {
                MessageBox.Show("Proszę wprowadzić ulicę");
                this.textBoxStreet.Focus();
                anyError = true;
            }

            if (string.IsNullOrEmpty(textBoxPostCode.Text))
            {
                MessageBox.Show("Proszę wprowadzić kod pocztowy");
                this.textBoxPostCode.Focus();
                anyError = true;
            }

            if (string.IsNullOrEmpty(textBox_numberTel.Text))
            {
                MessageBox.Show("Proszę wprowadzić numer telefonu");
                this.textBox_numberTel.Focus();
                anyError = true;
            }
            else if (textBox_numberTel.TextLength < 9)
            {
                MessageBox.Show("Podany numer telefonu jest za krótki");
                this.textBox_numberTel.Focus();
                anyError = true;
            }
            else if (textBox_numberTel.TextLength > 9)
            {
                MessageBox.Show("Podany numer telefonu jest za długi");
                this.textBox_numberTel.Focus();
                anyError = true;
            }
            if (string.IsNullOrEmpty(textBoxAdressNumber.Text))
            {
                MessageBox.Show("Proszę wprowadzić numer domu");
                this.textBoxAdressNumber.Focus();
                anyError = true;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Proszę wprowadzić numer lokalu");
                this.textBoxName.Focus();
                anyError = true;
            }
            if (!anyError)
            {
                try
                {
                    cnn.Open();
                    query = "Update klient Set imie=@imie,nazwisko=@nazwisko,tel=@telefon,ulica=@ulica,nr_domu=@nrumdom,nr_lokalu=@numlok,miejscowosc=@miej,kod=@kod Where id=" + listOfClient[comboBox1.SelectedIndex] + "';";
                    com = new MySqlCommand(query, cnn);

                    com.Parameters.AddWithValue("@imie", textBoxName.Text);
                    com.Parameters.AddWithValue("@nazwisko", textBoxSurename.Text);
                    com.Parameters.AddWithValue("@telefon", textBox_numberTel.Text);
                    com.Parameters.AddWithValue("@ulica", textBoxStreet.Text);
                    com.Parameters.AddWithValue("@numdom", textBoxAdressNumber.Text);
                    com.Parameters.AddWithValue("@numlok", textBox1.Text);
                    com.Parameters.AddWithValue("@miej", textBoxCity.Text);
                    com.Parameters.AddWithValue("@kod", textBoxPostCode.Text);
                    int rows = com.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                //query = "Select id,login FROM pracownik WHERE id>2 AND ID != '" + id + "';";
                query = "SELECT imie,nazwisko,tel,ulica,nr_domu,nr_lokalu,miejscowosc,kod FROM klient Where id=" + listOfClient[comboBox1.SelectedIndex] + "';";
                com = new MySqlCommand(query, cnn);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        textBoxName.Text = reader.GetString(0);
                        textBoxSurename.Text = reader.GetString(1);
                        textBox_numberTel.Text = reader.GetString(2);
                        textBoxStreet.Text = reader.GetString(3);
                        textBoxAdressNumber.Text = reader.GetString(4);
                        textBox1.Text = reader.GetString(5);
                        textBoxCity.Text = reader.GetString(6);
                        textBoxPostCode.Text = reader.GetString(7);
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
    }
}