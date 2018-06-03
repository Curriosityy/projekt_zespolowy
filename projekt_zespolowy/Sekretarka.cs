using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class Sekretarka : Form
    {
        private int idSekretarki;
        public Sekretarka(int id)
        {
            InitializeComponent();
            idSekretarki = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DodawanieKlienta dk = new DodawanieKlienta();
            dk.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logowanie log = new Logowanie();
            log.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DodajZgłoszenie dz = new DodajZgłoszenie();
            dz.Show();
        }

        private void Sekretarka_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WyslijWiadomosc wyslijWiadomosc = new WyslijWiadomosc(idSekretarki);
            wyslijWiadomosc.Show();
        }
    }
}