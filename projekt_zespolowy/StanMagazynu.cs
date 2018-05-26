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
    public partial class StanMagazynu : Form
    {
        public StanMagazynu()
        {
            InitializeComponent();
            loadTable();
        }

        private void loadTable()
        {
            try
            {
                MySqlConnection cnn;
                string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT nazwa,opis,ilosc,cena,id_producenta FROM produkt", cnn);
                MySqlDataAdapter adpt = new MySqlDataAdapter();
                adpt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dt;
                dataGridView1.DataSource = bSource;
                adpt.Update(dt);

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MagazynSzef ms = new MagazynSzef();
            ms.Show();
        }
    }
}