﻿using System;
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
    public partial class MagazynSerwisant : Form
    {
        public MagazynSerwisant()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Serwisant ok = new Serwisant();
            ok.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StanMagazynu st = new StanMagazynu();
            st.Show();
        }
    }
}