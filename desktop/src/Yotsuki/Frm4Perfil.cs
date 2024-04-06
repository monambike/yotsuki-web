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
    public partial class Frm4Perfil : Form
    {
        public Frm4Perfil()
        {
            InitializeComponent();
            /*SqlConnection con = new SqlConnection(Banco.StringConexao);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select foto from client where usuario='" + lblUsuario.Text + "'", con);

            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            frm7.foto = dr[7].ToString();

            if (frm7.foto == "1")
            {
                picUnicornio.Visible = true;

                picEspada.Visible = false;
                picCaveira.Visible = false;
                picGuerreiro.Visible = false;
                picDinossauro.Visible = false;
                picBruxa.Visible = false;
            }

            else if (frm7.foto == "2")
            {
                picEspada.Visible = true;

                picUnicornio.Visible = false;
                picCaveira.Visible = false;
                picGuerreiro.Visible = false;
                picDinossauro.Visible = false;
                picBruxa.Visible = false;
            }

            else if (frm7.foto == "3")
            {
                picCaveira.Visible = true;

                picUnicornio.Visible = false;
                picEspada.Visible = false;
                picGuerreiro.Visible = false;
                picDinossauro.Visible = false;
                picBruxa.Visible = false;
            }

            else if (frm7.foto == "4")
            {
                picGuerreiro.Visible = true;

                picCaveira.Visible = false;
                picUnicornio.Visible = false;
                picEspada.Visible = false;
                picDinossauro.Visible = false;
                picBruxa.Visible = false;
            }

            else if (frm7.foto == "5")
            {
                picDinossauro.Visible = true;

                picCaveira.Visible = false;
                picUnicornio.Visible = false;
                picEspada.Visible = false;
                picBruxa.Visible = false;
                picGuerreiro.Visible = false;
            }

            else if (frm7.foto == "6")
            {
                picBruxa.Visible = true;

                picGuerreiro.Visible = false;
                picCaveira.Visible = false;
                picUnicornio.Visible = false;
                picEspada.Visible = false;
                picDinossauro.Visible = false;
            }

            else
            {
                picBruxa.Visible = false;
                picGuerreiro.Visible = false;
                picCaveira.Visible = false;
                picUnicornio.Visible = false;
                picEspada.Visible = false;
                picDinossauro.Visible = false;
            }
            cmd1.ExecuteScalar();
            con.Close();*/
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo sair? Dados não salvos serão perdidos!", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Frm1Inicio frm1 = new Frm1Inicio();
                frm1.Visible = true;
                this.Hide();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Banco.StringConexao);
            con.Open();
            string sql = "Insert into client (biografia, email, contato, foto, jogos)values(@biografia, @email, @contato, @foto, @jogos) where usuario='" + lblUsuario.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@biografia", SqlDbType.VarChar).Value = txtBiografia.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@contato", SqlDbType.VarChar).Value = txtContato.Text;
            cmd.Parameters.Add("@jogos", SqlDbType.VarChar).Value = txtJogos.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dados atualizados com sucesso!");
            con.Close();
        }
    }
}
