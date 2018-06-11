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
	public partial class Klienci : Form
	{
		public static DataTable access = new DataTable();
		public static DataTable dt = new DataTable();
		public static DataTable ct = new DataTable();
		public static DataTable mt = new DataTable();

		public Klienci()
		{
			InitializeComponent();
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("SELECT * FROM klient", cnn);
			log.Fill(dt);
			MySqlDataAdapter log2 = new MySqlDataAdapter("SELECT COUNT(*) FROM klient", cnn);
			log2.Fill(ct);
			string [,] tab = new string[3,3];

			int x=Int32.Parse( ct.Rows[0][0].ToString());
			for (int i = 0; i < x; i++)
			{
				comboBox1.Items.Add(dt.Rows[i][0].ToString());
				//comboBox1.Items.Add("id=" +  dt.Rows[i][0].ToString() + " Imie: " + dt.Rows[i][1].ToString() + " Nazwisko: " + dt.Rows[i][2].ToString()) ;
			}
			
			
			


		}

		private void button1_Click(object sender, EventArgs e)
		{
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("DELETE FROM klient WHERE ID=" + comboBox1.Text.ToString(), cnn);
			log.Fill(dt);
			MessageBox.Show("Pomyslnie usunieto klienta");
			this.Refresh();
			this.Invalidate();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("UPDATE klient SET " +
				"imie='" + textBox1.Text + "'"  +
				",nazwisko='" + textBox2.Text + "'" +
					",tel='" + textBox3.Text +  "'"  +
					",ulica='" + textBox4.Text + "'"  +
					",nr_domu='" + textBox5.Text + "'"  +
					",nr_lokalu='"+ textBox6.Text + "'"  +
				",miejscowosc='" + textBox7.Text + "'"  +
					",kod='" + textBox8.Text + "'"  +
				"WHERE ID=" + comboBox1.Text.ToString()
				, cnn);

			log.Fill(mt);
			MessageBox.Show("Modyfikacja przebiegla pomyslnie");
		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("SELECT * FROM klient WHERE ID=" + comboBox1.Text.ToString(), cnn);
			log.Fill(dt);

			textBox1.Text = dt.Rows[0][1].ToString();
			textBox2.Text = dt.Rows[0][2].ToString();
			textBox3.Text = dt.Rows[0][3].ToString();
			textBox4.Text = dt.Rows[0][4].ToString();
			textBox5.Text = dt.Rows[0][5].ToString();
			textBox6.Text = dt.Rows[0][6].ToString();
			textBox7.Text = dt.Rows[0][7].ToString();
			textBox8.Text = dt.Rows[0][8].ToString();
		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Administrator a = new Administrator(1);
			a.Show();
		}
	}
}
