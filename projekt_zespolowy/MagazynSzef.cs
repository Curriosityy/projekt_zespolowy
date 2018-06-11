using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class MagazynSzef : Form
    {
        public MagazynSzef()
        {
            InitializeComponent();
        }

        private void MagazynSzef_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StanMagazynu sm = new StanMagazynu();
            sm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            WyświetlBraki ok = new WyświetlBraki();
            ok.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Szef ok = new Szef(int.Parse(Logowanie.access.Rows[0][1].ToString()));
            ok.Show();
        }

        private void MagazynSzef_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			DodawanieProduktu dp = new DodawanieProduktu();
			dp.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			UsuwanieProduktu up = new UsuwanieProduktu();
			up.Show();
		}
	}
}