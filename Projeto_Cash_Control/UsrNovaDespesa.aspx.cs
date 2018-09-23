using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class UsrNovaDespesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CmbCategorias();
                CmbContas();

                if (NovaOperacao())
                {
                    lblTitulo.InnerText = "Nova Despesa";
                    txtData.Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    lblTitulo.InnerText = "Editar Despesa";
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
            cmbCategorias.Value = o.categoria;
            cmbContas.Value = o.conta;

            Session["Temp"] = o;
        }

        private void CmbCategorias()
        {
            Usuario u = (Usuario)Session["UsuarioLogado"];
            DataTable dt = new DataTable();
            Categoria cat = new Categoria();

            dt = cat.VisualizarCategoriasDespesas(u.id);

            cmbCategorias.DataSource = dt;
            cmbCategorias.DataTextField = "descricao";
            cmbCategorias.DataValueField = "descricao";
            cmbCategorias.DataBind();
        }

        private void CmbContas()
        {
            Usuario u = (Usuario)Session["UsuarioLogado"];
            DataTable dt = new DataTable();
            Conta c = new Conta();

            dt = c.VisualizarContas(u.id);

            cmbContas.DataSource = dt;
            cmbContas.DataTextField = "descricao";
            cmbContas.DataValueField = "descricao";
            cmbContas.DataBind();
        }


        private void NovaDespesa()
        {
            try
            {
                Usuario u = (Usuario)Session["UsuarioLogado"];
                Operacao o = new Operacao();

                o.usuario = u.id;
                o.tipo = "despesa";

                o.descricao = txtDescricao.Value;
                o.dataHora = DateTime.Parse(txtData.Value);
                o.categoria = cmbCategorias.Value;
                o.conta = cmbContas.Value;
                o.valor = float.Parse(txtValor.Value);

                o.NovaOperacao(o);

                Conta c = new Conta();
                c = c.VisualizarPorDescricao(o.conta, u.id);
                c.AtualizarDespesa(c, o.valor);
            }
            catch
            {

            }
        }

        private void EditarDespesa()
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
                o.categoria = cmbCategorias.Value;
                o.valor = float.Parse(txtValor.Value);
                o.conta = cmbContas.Value;

                Usuario u = (Usuario)Session["UsuarioLogado"];

                Conta c = new Conta();
                c = c.VisualizarPorDescricao(contaInicial, u.id);
                c.AtualizarReceita(c, valorInicial);

                c = c.VisualizarPorDescricao(o.conta, u.id);
                c.AtualizarDespesa(c, o.valor);

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
            Response.Redirect(@"~/UsrDespesas.aspx");
        }


        protected void btnOK_ServerClick(object sender, EventArgs e)
        {
            if (NovaOperacao())
                NovaDespesa();
            else
                EditarDespesa();

            Response.Redirect(@"~/UsrDespesas.aspx");
        }


    }
}