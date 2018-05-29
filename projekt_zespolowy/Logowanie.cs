using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class Logowanie : Form
    {
        public static DataTable access = new DataTable();
        public static DataTable dt = new DataTable();

        public Logowanie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn;
            string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            //           try
            //           {
            //              cnn.Open();
            //               MessageBox.Show("Connection Open ! ");
            //              cnn.Close();
            //           }
            //           catch (Exception ex)
            //           {
            //               MessageBox.Show("Can not open connection ! ");
            //           }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Proszę wprowadzić login");
                this.textBox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Proszę wprowadzić hasło");
                this.textBox1.Focus();
                return;
            }

            MySqlDataAdapter log = new MySqlDataAdapter("SELECT Count(*) FROM pracownik WHERE login='" + textBox1.Text + "' AND haslo='" + textBox2.Text + "'", cnn);

            log.Fill(dt);

            string SqlQuery = "SELECT uprawnienia,id FROM pracownik WHERE login='" + textBox1.Text.ToString() + "'";
            MySqlDataAdapter ac = new MySqlDataAdapter(SqlQuery, cnn);

            if (dt.Rows[0][0].ToString() == "1")
            {
                ac.Fill(access);

                if (access.Rows[0][0].ToString() == "3")
                {
                    this.Hide();
                    Szef s = new Szef(int.Parse(access.Rows[0][1].ToString()));
                    s.Show();
                }

                if (access.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Serwisant s1 = new Serwisant(int.Parse(access.Rows[0][1].ToString()));
                    s1.Show();
                }
                if (access.Rows[0][0].ToString() == "2")
                {
                    this.Hide();
                    Sekretarka s2 = new Sekretarka(int.Parse(access.Rows[0][1].ToString()));
                    s2.Show();
                }
                if (access.Rows[0][0].ToString() == "0")
                {
                    this.Hide();
                    Administrator s0 = new Administrator(int.Parse(access.Rows[0][1].ToString()));
                    s0.Show();
                }
            }
            else
            {
                MessageBox.Show("Złe hasło lub login");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Logowanie_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}