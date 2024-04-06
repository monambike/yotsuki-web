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
    public partial class Frm1Inicio : Form
    {
        public Frm1Inicio()
        {
            InitializeComponent();
        }

        private void btnInscrever_Click(object sender, EventArgs e)
        {
            Frm2Inscrever frm2 = new Frm2Inscrever();
            frm2.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Frm3LoginUser frm3 = new Frm3LoginUser();
            frm3.Show();
            this.Hide();
        }
        
        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo sair?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
