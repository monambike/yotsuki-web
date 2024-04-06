using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Yotsuki
{
    public partial class Frm3LoginUser : Form
    {
        /*Iniciar*/
        public Frm3LoginUser()
        {
            InitializeComponent();
        }
        /*---*/

        /*Ações*/
        private void chkMostrarSenha_Click(object sender, EventArgs e)
        {
            if (chkMostrarSenha.Checked == true)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }
        /*---*/

        /*Botões*/
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Frm1Inicio frm1 = new Frm1Inicio();
            frm1.Visible = true;
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(Banco.StringConexao);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from client where usuario = '" + txtUsuario.Text + "' and senha = '" + txtSenha.Text + "';", cn);
            SqlDataReader dados = cmd.ExecuteReader();
            Usuario user = new Usuario();
            if (dados.Read())
            {
                user.pais = dados[8].ToString();
            }

            bool result = VerificaLogin();
            if (result)
            {
                if (user.pais != ".")
                {
                    Frm4Perfil frm4 = new Frm4Perfil();
                    frm4.Show();
                    frm4.lblUsuario.Text = txtUsuario.Text;
                    MessageBox.Show(txtUsuario.Text + " seja bem vindo!");
                    this.Hide();
                }
                else
                {
                    frm6PrimeiroUso frm6 = new frm6PrimeiroUso();
                    frm6.Show();
                    this.Hide();
                }
            }
            else
            {
                lblAviso.Visible = true;
                shpAviso.Visible = true;
            }
        }
        /*---*/

        /*Métodos*/
        bool VerificaLogin()
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Banco.StringConexao))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from client where usuario = '" + txtUsuario.Text + "' and senha = '" + txtSenha.Text + "';", cn);
                    SqlDataReader dados = cmd.ExecuteReader();
                    result = dados.HasRows;
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    cn.Close();
                }
                return result;
            }
        }
    }
}
