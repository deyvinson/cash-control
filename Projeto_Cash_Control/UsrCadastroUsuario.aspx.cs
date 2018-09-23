using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_ServerClick(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            bool result;
            Log log = new Log();

            u.nome = txtNome.Value.ToString();

            if (!string.IsNullOrEmpty(txtSobrenome.Value))
                u.sobrenome = txtSobrenome.Value.ToString();
            else
                u.sobrenome = null;

            u.email = txtEmail.Value.ToString();
            u.senha = txtSenha.Value.ToString();
            u.perfil = "Usuário";

            bool validation = false;

            if (txtSenha.Value == txtSenhaRepeat.Value)
                validation = true;

            if (validation)
            {
                result = u.NovoUsuario(u);

                u = u.Login(u.email, u.senha);

                Session["UsuarioLogado"] = u;
                DadosNovoUsuario();

                log.UpdateLog("Usuário fez logon no sistema com sucesso. (ID: " + u.id.ToString() + ")");
                Response.Redirect("~/UsrPaginaInicial.aspx");
            }
            else
            {
                log.UpdateLog("Houve um erro na tentativa de criação de usuário.");
                Response.Redirect("~/login.aspx");
            }
        }

        private void DadosNovoUsuario()
        {
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Categoria cat = new Categoria();
            Conta c = new Conta();

            c.NovaConta("Carteira", 0, u.id);
            c.NovaConta("Banco", 0, u.id);

            cat.NovaCategoria("Salário", "Receita", u.id);
            cat.NovaCategoria("Outras Receitas", "Receita", u.id);
            cat.NovaCategoria("Reajuste", "Receita", u.id);
            cat.NovaCategoria("Alimentação", "Despesa", u.id);
            cat.NovaCategoria("Casa", "Despesa", u.id);
            cat.NovaCategoria("Despesas Fixas", "Despesa", u.id);
            cat.NovaCategoria("Transporte", "Despesa", u.id);
            cat.NovaCategoria("Lazer", "Despesa", u.id);
            cat.NovaCategoria("Outras Despesas", "Despesa", u.id);
            cat.NovaCategoria("Reajuste", "Despesa", u.id);
        }       
    }
}