using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class Sekretarka : Form
    {
        public Sekretarka(int id)
        {
            InitializeComponent();
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
    }
}