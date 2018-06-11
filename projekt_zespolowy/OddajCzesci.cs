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
	public partial class OddajCzesci : Form
	{
		public static DataTable access = new DataTable();
		public static DataTable dt = new DataTable();
		public static DataTable ct = new DataTable();
		public static DataTable mt = new DataTable();
		public OddajCzesci()
		{
			InitializeComponent();
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("SELECT * FROM produkt", cnn);
			log.Fill(dt);
			MySqlDataAdapter log2 = new MySqlDataAdapter("SELECT COUNT(*) FROM produkt", cnn);
			log2.Fill(ct);
			int x = Int32.Parse(ct.Rows[0][0].ToString());
			for (int i = 0; i < x; i++)
			{
				comboBox1.Items.Add(dt.Rows[i][0].ToString());
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log = new MySqlDataAdapter("SELECT * FROM produkt WHERE ID=" + comboBox1.Text.ToString(), cnn);
			log.Fill(dt);

			textBox1.Text = dt.Rows[0][1].ToString();
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MySqlConnection cnn;
			string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
			cnn = new MySqlConnection(connetionString);
			cnn.Open();
			MySqlDataAdapter log1 = new MySqlDataAdapter("SELECT * FROM produkt WHERE ID=" + comboBox1.Text.ToString(), cnn);
			log1.Fill(mt);
			int y =Int32.Parse(mt.Rows[0][3].ToString());
			MySqlDataAdapter log = new MySqlDataAdapter("UPDATE produkt set  ilosc=" + (y+numericUpDown1.Value) + " WHERE ID=" + comboBox1.Text.ToString(), cnn);
			log.Fill(dt);
			MessageBox.Show("Oddano produkt pomyslnie");
			comboBox1.Text = "";
			numericUpDown1.Value = 0;
			textBox1.Text = "";
		}
	}
}
