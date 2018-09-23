using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class MasterPageAdm : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DadosUsuario();
        }

        private void DadosUsuario()
        {
            try
            {
                Usuario usuario = new Usuario();

                usuario = (Usuario)Session["UsuarioLogado"];
                string login = usuario.nome + " " + usuario.sobrenome;

                txtUsuarioLogado.Text = login;
            }
            catch
            {
                txtUsuarioLogado.Text = "Erro";
            }
        }

        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            Session["UsuarioLogado"] = null;
            Response.Redirect(@"~/login.aspx");
        }
    }
}