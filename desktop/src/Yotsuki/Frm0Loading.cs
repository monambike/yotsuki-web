using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yotsuki
{
    public partial class Frm0Loading : Form
    {
        public Frm0Loading()
        {
            InitializeComponent();
            Temporizador.Enabled = true;
            progressBar1.X2 = 30;
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            progressBar1.X2 += 10;
            if (progressBar1.X2 == 460)
            {
                Temporizador.Enabled = false;
                Frm1Inicio frm1 = new Frm1Inicio();
                frm1.Show();
                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            progressBar1.X2 = 450;
        }
    }
}
