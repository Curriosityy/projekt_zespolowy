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
	public partial class Podglad_raportu : Form
	{
		public static DataTable access = new DataTable();
		public static DataTable dt = new DataTable();
		public static DataTable ct = new DataTable();
		public static DataTable mt = new DataTable();
		public Podglad_raportu()
		{
			InitializeComponent();
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("SELECT * FROM raport", cnn);
			log.Fill(dt);
			MySqlDataAdapter log2 = new MySqlDataAdapter("SELECT COUNT(*) FROM raport", cnn);
			log2.Fill(ct);

			int x = Int32.Parse(ct.Rows[0][0].ToString());
			for (int i = 0; i < x; i++)
			{
				comboBox1.Items.Add(dt.Rows[i][0].ToString());
				//comboBox1.Items.Add("id=" +  dt.Rows[i][0].ToString() + " Imie: " + dt.Rows[i][1].ToString() + " Nazwisko: " + dt.Rows[i][2].ToString()) ;
			}
		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("SELECT * FROM raport WHERE ID=" + comboBox1.Text.ToString(), cnn);
			log.Fill(dt);
			label3.Text = dt.Rows[0][2].ToString();
			label5.Text =  dt.Rows[0][3].ToString();
			label7.Text = "Ilosc: " + dt.Rows[0][4].ToString();
			label9.Text = "Cena: " + dt.Rows[0][5].ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Szef s = new Szef(int.Parse(Logowanie.access.Rows[0][1].ToString()));
			s.Show();
		}
	}
}
