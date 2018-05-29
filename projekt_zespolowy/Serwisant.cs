using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class Serwisant : Form
    {
        public Serwisant(int id)
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ZakonczZgloszenie zz = new ZakonczZgloszenie();
            zz.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logowanie ok = new Logowanie();
            ok.Show();
        }

        private void Serwisant_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}