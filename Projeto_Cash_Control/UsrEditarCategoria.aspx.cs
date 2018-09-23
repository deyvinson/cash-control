using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class UsrEditarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (NovaOperacao())
                {
                    lblTitulo.InnerText = "Nova Categoria";
                }
                else
                {
                    lblTitulo.InnerText = "Editar Categoria";
                    cmbTipo.Disabled = true;
                    PreencherDados();
                }
            }
        }

        private bool NovaOperacao()
        {
            if (Session["IdCategoria"] == null)
                return true;
            else
                return false;
        }

        private void PreencherDados()
        {
            int id = Convert.ToInt32(Session["IdCategoria"]);

            Categoria cat = new Categoria();
            cat = cat.SelecionarPorId(id);

            txtDescricao.Value = cat.descricao;
            cmbTipo.Value = cat.tipo;

            Session["Temp"] = cat;
        }

        private void NovaCategoria()
        {
            try
            {
                Usuario u = (Usuario)Session["UsuarioLogado"];
                Categoria cat = new Categoria();
                cat.NovaCategoria(txtDescricao.Value, cmbTipo.Value, u.id);

                Response.Redirect(@"~/UsrCategorias.aspx");
            }
            catch
            {

            }
        }

        private void EditarCategoria()
        {
            try
            {
                Usuario u = (Usuario)Session["UsuarioLogado"];
                Categoria cat = new Categoria();

                int id = Convert.ToInt32(Session["IdCategoria"]);
                bool r = cat.EditarCategoria(txtDescricao.Value, cmbTipo.Value, id);

                Session["IdCategoria"] = null;
                Session["Temp"] = null;               
            }
            catch (Exception ex)
            {

            }
            Response.Redirect(@"~/UsrCategorias.aspx");
        }


        protected void btnOK_ServerClick(object sender, EventArgs e)
        {
            if (NovaOperacao())
                NovaCategoria();
            else
                EditarCategoria();
        }

        protected void btnCancelar_ServerClick(object sender, EventArgs e)
        {
            Session["IdCategoria"] = null;
            Session["Temp"] = null;
            Response.Redirect(@"~/UsrCategorias.aspx");
        }
    }
}