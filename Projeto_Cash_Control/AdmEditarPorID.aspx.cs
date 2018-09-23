using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class AdmEditarPorID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(txtIdSearch.Value);

                Usuario u = new Usuario();
                u = u.SelecionarPorId(id);

                txtIdUsuario.Value = u.id.ToString();
                txtNomeUsuario.Value = u.nome;
                txtSobrenomeUsuario.Value = u.sobrenome;
                txtEmailUsuario.Value = u.email;
                txtSenhaUsuario.Value = u.senha;

                if (u.ativo == true)
                    rbAtivo.Checked = true;
                else
                    rbInativo.Checked = true;
                

            }
            catch
            {

            }

        }

        protected void btnSalvar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Usuario u = new Usuario();

                u.id = Convert.ToInt32(txtIdUsuario.Value);
                u.nome = txtNomeUsuario.Value;
                u.sobrenome = txtSobrenomeUsuario.Value;
                u.email = txtEmailUsuario.Value;
                u.senha = txtSenhaUsuario.Value;

                if (u.ativo == true)
                    rbAtivo.Checked = true;
                else
                    rbInativo.Checked = true;


                u.EditarUsuarioNomeSobrenomeEmail(u);

                if (rbAtivo.Checked)
                    u.AtivarUsuario(u);
                if (rbInativo.Checked)
                    u.DesativarUsuario(u);

                msgSucesso.Visible = true;
            }
            catch
            {
                Log l = new Log();
                l.UpdateLog("Erro ao tentar alterar o usuário");
            }

        }
    }
}