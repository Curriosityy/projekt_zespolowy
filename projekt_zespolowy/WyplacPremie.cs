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
    public partial class WyplacPremie : Form
    {
        public MySqlDataAdapter adpt;
        public DataTable da;

        public WyplacPremie()
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

                MySqlCommand comm = new MySqlCommand("SELECT login, pensja, premia FROM pracownik WHERE uprawnienia = 1 OR uprawnienia = 2", cnn);
                adpt = new MySqlDataAdapter();
                adpt.SelectCommand = comm;
                da = new DataTable();
                adpt.Fill(da);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = da;
                dataGridView1.DataSource = bSource;
                adpt.Update(da);

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
            Szef s = new Szef(int.Parse(Logowanie.access.Rows[0][1].ToString()));
            s.Show();
        }
    }
}