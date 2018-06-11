using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class Administrator : Form
    {
        public Administrator(int id)
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logowanie ok = new Logowanie();
            ok.Show();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
        }

        private void Administrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Klienci k = new Klienci();
			k.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			Pracownicy p = new Pracownicy();
			p.Show();
		}
	}
}