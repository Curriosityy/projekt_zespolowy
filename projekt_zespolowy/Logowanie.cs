﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uprawnienia;

            MySqlConnection cnn;
            string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            /*   try
               {
                  cnn.Open();
                  MessageBox.Show("Connection Open ! ");
                  cnn.Close();
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Can not open connection ! ");
               }
            */

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
            DataTable dt = new DataTable();
            log.Fill(dt);

            string SqlQuery = "SELECT uprawnienia FROM pracownik WHERE login='" + textBox1.Text + "'";
            MySqlCommand comm = new MySqlCommand(SqlQuery, cnn);

            if (dt.Rows[0][0].ToString() == "1")
            {
                //                using (MySqlDataReader oReader = comm.ExecuteReader())
                //                    try
                //                    {
                //                        while (oReader.Read())
                //                        {
                //
                //                        }

                //                    }
                this.Hide();
                Szef s = new Szef();
                s.Show();
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
    }
}