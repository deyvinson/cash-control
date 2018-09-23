using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class UsrNovaReceita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CmbCategorias();
                CmbContas();

                if (NovaOperacao())
                {
                    lblTitulo.InnerText = "Nova Receita";
                    txtData.Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    lblTitulo.InnerText = "Editar Receita";
                    PreencherDados();
                }
            }
        }

        private bool NovaOperacao()
        {
            if (Session["IdOperacao"] == null)
                return true;
            else
                return false;
        }

        private void PreencherDados()
        {
            int id = Convert.ToInt32(Session["IdOperacao"]);

            Operacao o = new Operacao();
            o = o.SelecionarporId(id);

            txtData.Value = o.dataHora.ToString("yyyy-MM-dd");
            txtDescricao.Value = o.descricao;
            txtValor.Value = o.valor.ToString("N2");
            cmbCategorias.Text = o.categoria;
            cmbConta.Text = o.conta;

            Session["Temp"] = o;
        }

        private void CmbCategorias()
        {
            try
            {

                Usuario u = (Usuario)Session["UsuarioLogado"];
                DataTable dt = new DataTable();
                Categoria cat = new Categoria();

                dt = cat.VisualizarCategoriasReceitas(u.id);

                cmbCategorias.DataSource = dt;
                cmbCategorias.DataTextField = "descricao";
                cmbCategorias.DataValueField = "descricao";
                cmbCategorias.DataBind();
            }
            catch
            {
                Session["UsuarioLogado"] = null;
                Response.Redirect(@"~/login.aspx");
            }

        }
        private void CmbContas()
        {
            try
            {
                Usuario u = (Usuario)Session["UsuarioLogado"];
                DataTable dt = new DataTable();
                Conta c = new Conta();

                dt = c.VisualizarContas(u.id);

                cmbConta.DataSource = dt;
                cmbConta.DataTextField = "descricao";
                cmbConta.DataValueField = "descricao";
                cmbConta.DataBind();
            }
            catch
            {
                Session["UsuarioLogado"] = null;
                Response.Redirect(@"~/login.aspx");
            }
        }

        private void NovaReceita()
        {
            try
            {
                Usuario u = (Usuario)Session["UsuarioLogado"];
                Operacao o = new Operacao();

                o.usuario = u.id;
                o.tipo = "receita";

                o.descricao = txtDescricao.Value;
                o.dataHora = DateTime.Parse(txtData.Value);
                o.categoria = cmbCategorias.Text;
                o.conta = cmbConta.Text;
                o.valor = float.Parse(txtValor.Value);

                o.NovaOperacao(o);

                Conta c = new Conta();
                c = c.VisualizarPorDescricao(o.conta, u.id);
                c.AtualizarReceita(c, o.valor);

                Response.Redirect(@"~/UsrReceitas.aspx");
            }
            catch
            {

            }
        }

        private void EditarReceita()
        {
            try
            {
                Operacao inicial = (Operacao)Session["Temp"];

                string contaInicial = inicial.conta;
                float valorInicial = inicial.valor;

                Operacao o = new Operacao();

                o.id = Convert.ToInt32(Session["IdOperacao"]);
                o.descricao = txtDescricao.Value;
                o.dataHora = DateTime.Parse(txtData.Value);
                o.categoria = cmbCategorias.Text;
                o.valor = float.Parse(txtValor.Value);
                o.conta = cmbConta.Text;

                Usuario u = (Usuario)Session["UsuarioLogado"];

                Conta c = new Conta();
                c = c.VisualizarPorDescricao(contaInicial, u.id);
                c.AtualizarDespesa(c, valorInicial);

                c = c.VisualizarPorDescricao(o.conta, u.id);
                c.AtualizarReceita(c, o.valor);

                bool r = o.EditarOperacao(o);
                Session["IdOperacao"] = null;
                Session["Temp"] = null;
            }
            catch
            {

            }
        }

        protected void btnCancelar_ServerClick(object sender, EventArgs e)
        {
            Session["IdOperacao"] = null;
            Session["Temp"] = null;
            Response.Redirect(@"~/UsrReceitas.aspx");
        }

        protected void btnOK_ServerClick(object sender, EventArgs e)
        {
            if (NovaOperacao())
                NovaReceita();
            else
                EditarReceita();

            Response.Redirect(@"~/UsrReceitas.aspx");

        }
    }
}