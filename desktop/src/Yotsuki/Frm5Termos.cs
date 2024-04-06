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
    public partial class Frm5Termos : Form
    {
        public Frm5Termos()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Frm2Inscrever frm2 = new Frm2Inscrever();
            frm2.Visible = true;
            this.Close();
        }
    }
}
