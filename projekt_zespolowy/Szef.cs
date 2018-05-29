using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class Szef : Form
    {
        public Szef(int id)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MagazynSzef ms = new MagazynSzef();
            ms.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logowanie ok = new Logowanie();
            ok.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            message o = new message();
            o.Show();
        }

        private void Szef_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            WyplacPremie wp = new WyplacPremie();
            wp.Show();
        }
    }
}