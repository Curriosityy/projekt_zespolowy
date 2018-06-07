using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class Zgłoszenia : Form
    {
        private int id_odbier;
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";

        public Zgłoszenia(int id)
        {
            InitializeComponent();
            id_odbier = id;
            loadTable(id_odbier);
            MySqlConnection cnn = new MySqlConnection(connectionString);
        }

        private void loadTable(int id)
        {
            try
            {
                MySqlConnection cnn;
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                // id_klienta = "SELECT "
                // string SqlQuery ="SELECT imie, nazwisko FROM klient WHERE id='" + id_klienta + "'";
                MySqlCommand comm = new MySqlCommand("SELECT id_klienta, opis FROM zgloszenie WHERE id_prac='" + id + "'", cnn);
                MySqlDataAdapter adpty = new MySqlDataAdapter();
                adpty.SelectCommand = comm;
                DataTable dad = new DataTable();
                adpty.Fill(dad);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dad;
                dataGridView1.DataSource = bSource;
                adpty.Update(dad);

                //      MySqlDataAdapter adpt = new MySqlDataAdapter("SELECT * FROM produkt", cnn);
                //      DataSet ds = new DataSet();
                //      adpt.Fill(ds, "stan");
                //      dataGridView1.DataSource = ds.Tables["stan"];
                //      Application.Run(new StanMagazynu());
                cnn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}