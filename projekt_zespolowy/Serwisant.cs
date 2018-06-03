using System;
using System.Windows.Forms;

namespace projekt_zespolowy
{
    public partial class Serwisant : Form
    {
        private int idSerwisanta;

        public Serwisant(int id)
        {
            InitializeComponent();

            idSerwisanta = id;
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

        private void button3_Click(object sender, EventArgs e)
        {
            WyslijWiadomosc wyslijWiadomosc = new WyslijWiadomosc(idSerwisanta);
            wyslijWiadomosc.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OdbierzZgloszenie odbierzZgloszenie = new OdbierzZgloszenie(idSerwisanta);
            odbierzZgloszenie.Show();
        }
    }
}