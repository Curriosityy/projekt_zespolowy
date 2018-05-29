using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class DodawanieKlienta : Form
    {
        public DodawanieKlienta()
        {
            InitializeComponent();
        }

        private void exit_add_client_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sekretarka sexit = new Sekretarka(int.Parse(Logowanie.access.Rows[0][1].ToString()));
            sexit.Show();
        }

        private void add_client_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn;
            string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO klient (imie,nazwisko,tel,ulica,nr_domu,nr_lokalu,miejscowosc,kod) VALUES (@imie,@nazwisko,@tel,@ulica,@nr_domu,@nr_lokalu,@miejscowosc,@kod)", cnn);
            cmd.Parameters.AddWithValue("@imie", textBoxName.Text);
            cmd.Parameters.AddWithValue("@nazwisko", textBoxSurename.Text);
            cmd.Parameters.AddWithValue("@tel", textBox_numberTel.Text);
            cmd.Parameters.AddWithValue("@ulica", textBoxStreet.Text);
            cmd.Parameters.AddWithValue("@nr_domu", textBoxAdressNumber.Text);
            cmd.Parameters.AddWithValue("@nr_lokalu", textBox1.Text);
            cmd.Parameters.AddWithValue("@miejscowosc", textBoxCity.Text);
            cmd.Parameters.AddWithValue("@kod", textBoxPostCode.Text);

            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Proszę wprowadzić imie");
                this.textBoxName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBoxSurename.Text))
            {
                MessageBox.Show("Proszę wprowadzić nazwisko");
                this.textBoxSurename.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBoxCity.Text))
            {
                MessageBox.Show("Proszę wprowadzić miasto");
                this.textBoxCity.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBoxStreet.Text))
            {
                MessageBox.Show("Proszę wprowadzić ulicę");
                this.textBoxStreet.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBoxPostCode.Text))
            {
                MessageBox.Show("Proszę wprowadzić kod pocztowy");
                this.textBoxPostCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox_numberTel.Text))
            {
                MessageBox.Show("Proszę wprowadzić numer telefonu");
                this.textBox_numberTel.Focus();
                return;
            }
            else if (textBox_numberTel.TextLength < 9)
            {
                MessageBox.Show("Podany numer telefonu jest za krótki");
                this.textBox_numberTel.Focus();
                return;
            }
            else if (textBox_numberTel.TextLength > 9)
            {
                MessageBox.Show("Podany numer telefonu jest za długi");
                this.textBox_numberTel.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxAdressNumber.Text))
            {
                MessageBox.Show("Proszę wprowadzić numer domu");
                this.textBoxAdressNumber.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Proszę wprowadzić numer lokalu");
                this.textBoxName.Focus();
                return;
            }

            cmd.ExecuteNonQuery();
            cnn.Close();

            MessageBox.Show("Pomyślnie dodano klienta!", "Dodawanie klienta");

            this.Hide();
            Sekretarka sexit = new Sekretarka(int.Parse(Logowanie.access.Rows[0][1].ToString()));
            sexit.Show();
        }

        private void DodawanieKlienta_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}