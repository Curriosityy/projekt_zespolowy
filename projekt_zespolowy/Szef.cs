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
    public partial class Szef : Form
    {
        public Szef()
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
    }
}