using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class UsrEditarConta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (NovaOperacao())
                {
                    lblTitulo.InnerText = "Nova Conta";
                    txtSaldo.Value = "0,00";
                }
                else
                {
                    lblTitulo.InnerText = "Editar Conta";
                    PreencherDados();
                }
            }
        }

        private bool NovaOperacao()
        {
            if (Session["IdConta"] == null)
                return true;
            else
                return false;
        }

        private void PreencherDados()
        {
            int id = Convert.ToInt32(Session["IdConta"]);

            Conta c = new Conta();
            c = c.SelecionarPorId(id);

            txtDescricao.Value = c.descricao;
            txtSaldo.Value = c.saldo.ToString("N2");
            lblSaldo.InnerText = "Saldo Atual (R$):";

            Session["Temp"] = c;
        }

        private void NovaConta()
        {
            try
            {
                Usuario u = (Usuario)Session["UsuarioLogado"];
                Conta c = new Conta();
                c.NovaConta(txtDescricao.Value, float.Parse(txtSaldo.Value), u.id);                
            }
            catch
            {

            }
            Response.Redirect(@"~/UsrContas.aspx");
        }

        private void EditarConta()
        {
            try
            {
                Usuario u = (Usuario)Session["UsuarioLogado"];
                Conta c = new Conta();

                int id = Convert.ToInt32(Session["IdConta"]);
                bool r = c.EditarConta(txtDescricao.Value, float.Parse(txtSaldo.Value), id);

                Session["IdConta"] = null;
                Session["Temp"] = null;
            }
            catch (Exception ex)
            {

            }
            Response.Redirect(@"~/UsrContas.aspx");
        }

        protected void btnOK_ServerClick(object sender, EventArgs e)
        {
            if (NovaOperacao())
                NovaConta();
            else
                EditarConta();
        }

        protected void btnCancelar_ServerClick(object sender, EventArgs e)
        {
            Session["IdConta"] = null;
            Session["Temp"] = null;
            Response.Redirect(@"~/UsrContas.aspx");
        }
    }   
}