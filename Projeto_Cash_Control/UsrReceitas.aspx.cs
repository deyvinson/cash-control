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
    public partial class UsrReceitas : System.Web.UI.Page
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

                VisualizarReceitas(dataInicial, dataFinal);
                PreencherGrid(dataInicial, dataFinal);

            }
            
            else if (Session["Data"] == null)
            {
                d.atual = DateTime.Today;
                Session["Data"] = d;

                lblMes.InnerText = d.MesAtual(d.atual);
                lblAno.InnerText = d.atual.Year.ToString();

                DateTime dataInicial = new DateTime(d.atual.Year, d.atual.Month, 1);
                DateTime dataFinal = new DateTime(d.atual.Year, d.atual.Month, DateTime.DaysInMonth(d.atual.Year, d.atual.Month));

                VisualizarReceitas(dataInicial, dataFinal);
                PreencherGrid(dataInicial, dataFinal);
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

        protected void btnNovaReceita_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/UsrNovaReceita.aspx");
        }

        private void VisualizarReceitas(DateTime dataInicial, DateTime dataFinal)
        {
            DataTable dt = new DataTable();
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Operacao o = new Operacao();
            float totalReceitas = 0;

            dt = o.VisualizarReceitas(u.id, dataInicial, dataFinal);

            if (dt.Rows.Count > 0)
            {
                StringBuilder html = new StringBuilder();

                html.Append("<table class='table table-hover'>");

                html.Append("<thead style='background-color: forestgreen; color: white'>");
                html.Append("<tr>");
                html.Append("<th><center></center></th>");
                html.Append("<th><center>Data</center></th>");
                html.Append("<th><center>Descrição</center></th>");
                html.Append("<th><center>Categoria</center></th>");
                html.Append("<th><center>Conta</center></th>");
                html.Append("<th><center>Valor</center></th>");
                html.Append("</tr>");
                html.Append("</thead>");

                html.Append("<tbody>");
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn coloumn in dt.Columns)
                    {
                        if (coloumn.ColumnName == "valor")
                        {
                            float x = float.Parse(row[coloumn.ColumnName].ToString());
                            totalReceitas += x;

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

                tblReceitas.Text = html.ToString();
                lblTotalReceitas.Text = totalReceitas.ToString("C2");

            }
            else
            {
                tblReceitas.Text = "<center><p>Nenhum dado a ser exibido.</p> <p>Clique em '<b>Novo</b>' para adicionar uma transação.</p></center>";
                lblTotalReceitas.Text = "R$ 0,00";
            }
            
        }

        protected void btnVoltarMesSelecionado_ServerClick(object sender, EventArgs e)
        {
            Data d = (Data)Session["Data"];

            d.atual = d.atual.AddMonths(-1);
            Session["Data"] = d;

            lblMes.InnerText = d.MesAtual(d.atual);
            lblAno.InnerText = d.atual.Year.ToString();
            VisualizarReceitas(DataInicial(), DataFinal());
            PreencherGrid(DataInicial(), DataFinal());

        }

        protected void btnAvancarMesSelecionado_ServerClick(object sender, EventArgs e)
        {
            Data d = (Data)Session["Data"];

            d.atual = d.atual.AddMonths(1);
            Session["Data"] = d;

            lblMes.InnerText = d.MesAtual(d.atual);
            lblAno.InnerText = d.atual.Year.ToString();
            VisualizarReceitas(DataInicial(), DataFinal());
            PreencherGrid(DataInicial(), DataFinal());

        }

        private void PreencherGrid(DateTime dataInicial, DateTime dataFinal)
        {
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Operacao o = new Operacao();
            float totalReceitas = 0;

            try
            {

                gvReceitas.DataSource = o.VisualizarReceitas(u.id, dataInicial, dataFinal);
                gvReceitas.DataBind();


                if (gvReceitas.Rows.Count >= 1)
                {
                    DataTable dt = o.VisualizarDespesas(u.id, dataInicial, dataFinal);

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn coloumn in dt.Columns)
                        {
                            if (coloumn.ColumnName == "valor")
                            {
                                float x = float.Parse(row[coloumn.ColumnName].ToString());
                                totalReceitas += x;
                            }
                        }
                    }

                    lblTotalReceitas.Text = totalReceitas.ToString("C2");
                }

                else
                {
                    gvReceitas.EmptyDataText = "<center><p>Nenhum dado a ser exibido.</p> <p>Clique em '<b>Novo</b>' para adicionar uma transação.</p></center>";
                    gvReceitas.DataBind();

                    lblTotalReceitas.Text = "R$ 0,00";
                }
            }
            catch
            {
                Session["UsuarioLogado"] = null;
                Response.Redirect(@"~/login.aspx");
            }
        }

        protected void gvReceitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int id = Convert.ToInt32(gvReceitas.DataKeys[index]["id"]);

            if (e.CommandName == "Excluir")
            {
                Operacao o = new Operacao();
                bool r = o.ExcluirOperacao(id);
                PreencherGrid(DataInicial(), DataFinal());
            }
            else if (e.CommandName == "Editar")
            {
                Session["IdOperacao"] = id;
                Response.Redirect(@"~/UsrNovaReceita.aspx");
            }

        }
    }
}