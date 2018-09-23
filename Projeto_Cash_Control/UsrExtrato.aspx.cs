using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Cash_Control
{
    public partial class UsrExtrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Data d = new Data();

            if (!IsPostBack)
            {
                d.atual = DateTime.Today;
                Session["Data"] = d;

                lblMes.InnerText = d.MesAtual(d.atual);
                lblAno.InnerText = d.atual.Year.ToString();

                DateTime dataInicial = new DateTime(d.atual.Year, d.atual.Month, 1);
                DateTime dataFinal = new DateTime(d.atual.Year, d.atual.Month, DateTime.DaysInMonth(d.atual.Year, d.atual.Month));

                VisualizarExtrato(dataInicial, dataFinal);
                ValoresMensais(dataInicial, dataFinal);
            }

            else if (Session["Data"] == null)
            {
                d.atual = DateTime.Today;
                Session["Data"] = d;

                lblMes.InnerText = d.MesAtual(d.atual);
                lblAno.InnerText = d.atual.Year.ToString();

                DateTime dataInicial = new DateTime(d.atual.Year, d.atual.Month, 1);
                DateTime dataFinal = new DateTime(d.atual.Year, d.atual.Month, DateTime.DaysInMonth(d.atual.Year, d.atual.Month));

                VisualizarExtrato(dataInicial, dataFinal);
            }

            else
            {
                d = (Data)Session["Data"];
                lblMes.InnerText = d.MesAtual(d.atual);
                lblAno.InnerText = d.atual.Year.ToString();
            }
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


        private void VisualizarExtrato(DateTime dataInicial, DateTime dataFinal)
        {
            DataTable dt = new DataTable();
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Operacao o = new Operacao();

            try
            {

                dt = o.VisualizarTudo(u.id, dataInicial, dataFinal);


                if (dt.Rows.Count > 0)
                {
                    StringBuilder html = new StringBuilder();

                    html.Append("<table class='table table-sm'>");

                    html.Append("<thead style='background-color: #008B8B; color: white'>");
                    html.Append("<tr>");
                    html.Append("<th><center></center></th>");
                    html.Append("<th><center>DATA</center></th>");
                    html.Append("<th><center>DESCRIÇÃO</center></th>");
                    html.Append("<th><center>CATEGORIA</center></th>");
                    html.Append("<th><center>CONTA</center></th>");
                    html.Append("<th><center>VALOR</center></th>");
                    html.Append("</tr>");
                    html.Append("</thead>");

                    html.Append("<tbody>");



                    foreach (DataRow row in dt.Rows)
                    {

                        string tp = row[0].ToString();

                        if (tp == "receita")
                            html.Append("<tr class='table-success'>");
                        else
                            html.Append("<tr class='table-danger'>");

                        foreach (DataColumn coloumn in dt.Columns)
                        {

                            if (coloumn.ColumnName == "valor")
                            {
                                float x = float.Parse(row[coloumn.ColumnName].ToString());

                                html.Append("<td style='text-align:right; padding-right:15px'>");
                                html.Append(x.ToString("C2"));
                                html.Append("</td>");

                            }
                            else if (coloumn.ColumnName == "datahora")
                            {
                                CultureInfo cult = new CultureInfo("pt-BR");
                                DateTime dataFormatada = DateTime.Parse(row[coloumn.ColumnName].ToString());
                                string data = dataFormatada.ToString("dd/MM/yyyy", cult);

                                html.Append("<td><center>");
                                html.Append(data);
                                html.Append("</center></td>");
                            }

                            else if (coloumn.ColumnName == "tipo")
                            {
                                if (row[coloumn.ColumnName].ToString() == "receita")
                                {
                                    html.Append("<td class='table-success'><center>");
                                    html.Append("<b>+</b>");
                                    html.Append("</center></td>");
                                }
                                else
                                {
                                    html.Append("<td class='table-danger'><center>");
                                    html.Append("<b>-</b>");
                                    html.Append("</center></td>");
                                }

                            }
                            else
                            {
                                html.Append("<td><center>");
                                html.Append(row[coloumn.ColumnName]);
                                html.Append("</center></td>");
                            }
                        }
                        html.Append("</tr>");
                        html.Append("</tbody>");
                    }
                    html.Append("</table>");

                    tblExtrato.Text = html.ToString();
                    SaldoAtual();

                }
                else
                {
                    tblExtrato.Text = "<center><p>Nenhum dado a ser exibido.</p> <p>Clique em '<b>Novo</b>' para adicionar uma transação.</p></center>";
                    SaldoAtual();
                }
            }
            catch
            {
                Session["UsuarioLogado"] = null;
                Response.Redirect(@"~/login.aspx");
            }
        }



        private void SaldoAtual()
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

            lblSaldoAtual.Text = saldoAtual.ToString("C2");
        }


        private void ValoresMensais(DateTime dataInicial, DateTime dataFinal)
        {
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Operacao o = new Operacao();
            float despesas = 0;
            float receitas = 0;

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

            //Interface
            lblDespesasMes.Text = despesas.ToString("C2");
            lblReceitasMes.Text = receitas.ToString("C2");

        }




        protected void btnVoltarMesSelecionado_ServerClick(object sender, EventArgs e)
        {
            Data d = (Data)Session["Data"];

            d.atual = d.atual.AddMonths(-1);
            Session["Data"] = d;

            lblMes.InnerText = d.MesAtual(d.atual);
            lblAno.InnerText = d.atual.Year.ToString();
            VisualizarExtrato(DataInicial(), DataFinal());
            ValoresMensais(DataInicial(), DataFinal());
        }

        protected void btnAvancarMesSelecionado_ServerClick(object sender, EventArgs e)
        {
            Data d = (Data)Session["Data"];

            d.atual = d.atual.AddMonths(1);
            Session["Data"] = d;

            lblMes.InnerText = d.MesAtual(d.atual);
            lblAno.InnerText = d.atual.Year.ToString();
            VisualizarExtrato(DataInicial(), DataFinal());
            ValoresMensais(DataInicial(), DataFinal());
        }

        protected void btnVoltar_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/UsrPaginaInicial.aspx");
        }
    }
}