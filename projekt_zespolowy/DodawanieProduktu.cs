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
	public partial class DodawanieProduktu : Form
	{
		public static DataTable access = new DataTable();
		public static DataTable dt = new DataTable();
		public static DataTable ct = new DataTable();
		public static DataTable mt = new DataTable();
		public DodawanieProduktu()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("INSERT INTO produkt(nazwa, opis, ilosc, cena, id_producenta) " +
				"values('" + textBox1.Text.ToString() + "', '" +
				richTextBox1.Text.ToString() + "'," +
				numericUpDown1.Value + "," +
				numericUpDown2.Value + "," +
				numericUpDown3.Value + ");"
				 , cnn);
			log.Fill(dt);

			MessageBox.Show("Pomyslnie dodano produkt");
			textBox1.Text = "";
			richTextBox1.Text = "";
			numericUpDown1.Value = 0;
			numericUpDown2.Value = 0;
			numericUpDown3.Value = 0;
		}

		private void numericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("SELECT nazwa FROM producent WHERE ID=" + numericUpDown3.Value.ToString(), cnn);
			log.Fill(dt);
			if (dt.Rows[0][0].ToString() != "")
			{
				label6.Text = "Nazwa producenta:" + dt.Rows[0][0].ToString();
			}
			else
			{
				label6.Text = "Nazwa producenta: NIEZNANY";
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			Szef ok = new Szef(int.Parse(Logowanie.access.Rows[0][1].ToString()));
			ok.Show();

		}
	}
}
