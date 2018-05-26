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
            this.Hide();
            StanMagazynu sm = new StanMagazynu();
            sm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            WyświetlBraki ok = new WyświetlBraki();
            ok.Show();
        }
    }
}