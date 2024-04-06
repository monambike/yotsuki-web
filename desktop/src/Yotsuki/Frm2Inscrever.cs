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
    public partial class Frm2Inscrever : Form
    {
        public bool ftCheck;

        public Frm2Inscrever()
        {
            InitializeComponent();
        }

        private void lblTermos_Click(object sender, EventArgs e)
        {
            Frm5Termos frm6 = new Frm5Termos();
            frm6.Show();
            this.Hide();
        }

        private void chkMostrarSenha_Click(object sender, EventArgs e)
        {
            if (chkMostrarSenha.Checked == true)
            {
                txtSenha.UseSystemPasswordChar = false;
                txtConfirmarSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                txtConfirmarSenha.UseSystemPasswordChar = true;
            }
        }

        private void btnInscrever_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != string.Empty && txtUsuario.Text != string.Empty && txtSenha.Text != string.Empty && txtConfirmarSenha.Text != string.Empty)
            {
                if (chkRobot.Checked == true)
                {
                    if (chkTermos.Checked == true)
                    {
                        if (txtSenha.Text == txtConfirmarSenha.Text)
                        {
                            Usuario user = new Usuario();
                            //Abrindo conexão com o banco de dados
                            SqlConnection con = new SqlConnection(Banco.StringConexao);
                            con.Open();
                            string sql = "Insert into client(nome, usuario, senha, foto, pais)values(@nome, @usuario, @senha, @foto, @pais)";
                            SqlCommand cmd = new SqlCommand(sql, con);

                            //Direcionando os valores das teclas
                            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = txtNome.Text;
                            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
                            cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = txtSenha.Text;
                            cmd.Parameters.Add("@foto", SqlDbType.VarChar).Value = foto;
                            cmd.Parameters.Add("@pais", SqlDbType.VarChar).Value = ".";

                            //Se tudo estiver certo ele executará o comando
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Usuário registrado com sucesso!");
                            con.Close();
                            Frm1Inicio frm1 = new Frm1Inicio();
                            frm1.Visible = true;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Os campos Senha e Confirmar Senha devem ser iguais!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, aceite os Termos de Uso!");
                    }
                }
                else
                {
                    MessageBox.Show("Confirme que você não é um robô!");
                }
            }
            else
            {
                MessageBox.Show("Não deixe nenhuma das caixas de texto vazia!");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty && txtUsuario.Text == string.Empty && txtSenha.Text == string.Empty && txtConfirmarSenha.Text == string.Empty)
            {
            }
            else
            {
                DialogResult res = MessageBox.Show("Tem certeza que deseja voltar? Todos os dados digitados e não inscritos serão perdidos.", "Aviso", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    Frm1Inicio frm1 = new Frm1Inicio();
                    frm1.Visible = true;
                    this.Visible = false;
                }
            }
        }


        private void txtConfirmarSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                lblAviso.Visible = true;
                shpAviso.Visible = true;
            }
            else
            {
                lblAviso.Visible = false;
                shpAviso.Visible = false;
            }
        }

        public string foto;

        private void picUnicornio_Click_1(object sender, EventArgs e)
        {
            lblFoto.Text = "Você escolheu: Unicórnio";
            foto = "1";
        }

        private void picEspada_Click_1(object sender, EventArgs e)
        {
            lblFoto.Text = "Você escolheu: Espada";
            foto = "2";
        }

        private void picCaveira_Click_1(object sender, EventArgs e)
        {
            lblFoto.Text = "Você escolheu: Caveira";
            foto = "3";
        }

        private void picGuerreiro_Click_1(object sender, EventArgs e)
        {
            lblFoto.Text = "Você escolheu: Guerreiro";
            foto = "4";
        }

        private void picDinossauro_Click_1(object sender, EventArgs e)
        {
            lblFoto.Text = "Você escolheu: Dinossauro";
            foto = "5";
        }

        private void picBruxa_Click_1(object sender, EventArgs e)
        {
            lblFoto.Text = "Você escolheu: Bruxa";
            foto = "6";
        }
    }
}
