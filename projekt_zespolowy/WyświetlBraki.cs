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
    public partial class WyświetlBraki : Form
    {
        public WyświetlBraki()
        {
            InitializeComponent();
            missing();
        }

        private void missing()
        {
            try
            {
                MySqlConnection cnn;
                string connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt;";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();

                string SqlQuery = "SELECT ilosc FROM produkt";
                MySqlDataAdapter ad = new MySqlDataAdapter(SqlQuery, cnn);
                DataTable dta = new DataTable();
                ad.Fill(dta);

                if (dta.Rows[0][0].ToString() == "0")
                {
                    MySqlCommand comm = new MySqlCommand("SELECT nazwa,opis,ilosc,cena,id_producenta FROM produkt WHERE ilosc Like 0", cnn);
                    MySqlDataAdapter adpt = new MySqlDataAdapter();
                    DataTable dt = new DataTable();
                    adpt.SelectCommand = comm;
                    adpt.Fill(dt);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dt;
                    dataGridView1.DataSource = bSource;
                    adpt.Update(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Wstecz_Click(object sender, EventArgs e)
        {
            this.Hide();
            MagazynSzef ms = new MagazynSzef();
            ms.Show();
        }
    }
}