using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            string email = txtEmail.Value.ToString();
            string senha = txtSenha.Value.ToString();

            Usuario u = new Usuario();
            u = u.Login(email, senha);

            if (u.id > 0)
            {
                Log log = new Log();

                if (u.perfil == "Administrador")
                {
                    Session["UsuarioLogado"] = u;
                    log.UpdateLog("Administrador fez logon no sistema com sucesso.");
                    Response.Redirect("~/AdmPaginaInicial.aspx");

                   
                }
                else
                {
                    Session["UsuarioLogado"] = u;
                    log.UpdateLog("Usuário fez logon no sistema com sucesso. (ID: " + u.id.ToString() + ")");
                    Response.Redirect("~/UsrPaginaInicial.aspx");
                   
                }
            }

            
        }

        protected void btnCadastrar_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/UsrCadastroUsuario.aspx");
        }
    }
}