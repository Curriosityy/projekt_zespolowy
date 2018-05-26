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
    public partial class Sekretarka : Form
    {
        public Sekretarka()
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
    }
}