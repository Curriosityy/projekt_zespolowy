using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class MagazynSerwisant : Form
    {
        public MagazynSerwisant()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Serwisant ok = new Serwisant(int.Parse(Logowanie.access.Rows[0][1].ToString()));
            ok.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StanMagazynu st = new StanMagazynu();
            st.Show();
        }

        private void MagazynSerwisant_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}