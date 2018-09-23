using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class PaginaInicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SaldoAtual();

            Data d = new Data();

            if (!IsPostBack)
            {
                d.atual = DateTime.Today;
                Session["Data"] = d;

                lblMes.InnerText = d.MesAtual(d.atual);
                lblAno.InnerText = d.atual.Year.ToString();

                DateTime dataInicial = new DateTime(d.atual.Year, d.atual.Month, 1);
                DateTime dataFinal = new DateTime(d.atual.Year, d.atual.Month, DateTime.DaysInMonth(d.atual.Year, d.atual.Month));

                ValoresMensais(dataInicial, dataFinal);
            }

            if (Session["Data"] == null)
            {
                d.atual = DateTime.Today;
                Session["Data"] = d;

                lblMes.InnerText = d.MesAtual(d.atual);
                lblAno.InnerText = d.atual.Year.ToString();

                DateTime dataInicial = new DateTime(d.atual.Year, d.atual.Month, 1);
                DateTime dataFinal = new DateTime(d.atual.Year, d.atual.Month, DateTime.DaysInMonth(d.atual.Year, d.atual.Month));

                ValoresMensais(dataInicial, dataFinal);
            }
            else
            {
                d = (Data)Session["Data"];
                lblMes.InnerText = d.MesAtual(d.atual);
                lblAno.InnerText = d.atual.Year.ToString();

            }
        }

        private void SaldoAtual()
        {
            try
            {

                Usuario u = (Usuario)Session["UsuarioLogado"];
                Conta c = new Conta();

                DataTable dtContas = new DataTable();
                dtContas = c.VisualizarContas(u.id);

                float saldoAtual = 0;

                foreach (DataRow row in dtContas.Rows)
                {
                    foreach (DataColumn coloumn in dtContas.Columns)
                    {
                        if (coloumn.ColumnName == "saldo")
                        {
                            float x = float.Parse(row[coloumn.ColumnName].ToString());
                            saldoAtual += x;
                        }
                    }
                }
                txtSaldo.Text = saldoAtual.ToString("N2");
            }
            catch
            {
                Session["UsuarioLogado"] = null;
                Response.Redirect(@"~/login.aspx");
            }
        }


        private void ValoresMensais(DateTime dataInicial, DateTime dataFinal)
        {
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Operacao o = new Operacao();
            float despesas = 0;
            float receitas = 0;
            float balancoMensal = 0;

            //Despesas
            DataTable dtDespesas = new DataTable();
            dtDespesas = o.VisualizarDespesas(u.id, dataInicial, dataFinal);

            

            foreach (DataRow row in dtDespesas.Rows)
            {
                foreach (DataColumn coloumn in dtDespesas.Columns)
                {
                    if (coloumn.ColumnName == "valor")
                    {
                        float x = float.Parse(row[coloumn.ColumnName].ToString());
                        despesas += x;
                    }
                }

            }
          
            //Receitas
            DataTable dtReceitas = new DataTable();
            dtReceitas = o.VisualizarReceitas(u.id, dataInicial, dataFinal);

           
            foreach (DataRow row in dtReceitas.Rows)
            {
                foreach (DataColumn coloumn in dtReceitas.Columns)
                {
                    if (coloumn.ColumnName == "valor")
                    {
                        float x = float.Parse(row[coloumn.ColumnName].ToString());
                        receitas += x;
                    }
                }
            }
         
            //Balanço
            balancoMensal = receitas - despesas;


            //Interface
            txtDespesas.Text = despesas.ToString("N2");
            txtReceitas.Text = receitas.ToString("N2");
            txtBalanco.Text = balancoMensal.ToString("N2");

        }

        private DateTime DataInicial()
        {
            Data d = (Data)Session["Data"];
            DateTime dataInicial = new DateTime(d.atual.Year, d.atual.Month, 1);
            return dataInicial;
        }

        private DateTime DataFinal()
        {
            Data d = (Data)Session["Data"];
            DateTime dataFinal = new DateTime(d.atual.Year, d.atual.Month, DateTime.DaysInMonth(d.atual.Year, d.atual.Month));
            return dataFinal;
        }

        protected void btnVoltarMesSelecionado_ServerClick(object sender, EventArgs e)
        {
            Data d = (Data)Session["Data"];

            d.atual = d.atual.AddMonths(-1);
            Session["Data"] = d;

            lblMes.InnerText = d.MesAtual(d.atual);
            lblAno.InnerText = d.atual.Year.ToString();
            ValoresMensais(DataInicial(), DataFinal());
        }

        protected void btnAvancarMesSelecionado_ServerClick(object sender, EventArgs e)
        {
            Data d = (Data)Session["Data"];

            d.atual = d.atual.AddMonths(1);
            Session["Data"] = d;

            lblMes.InnerText = d.MesAtual(d.atual);
            lblAno.InnerText = d.atual.Year.ToString();
            ValoresMensais(DataInicial(), DataFinal());
        }

        protected void btnExtrato_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/UsrExtrato.aspx");
        }
    }
}