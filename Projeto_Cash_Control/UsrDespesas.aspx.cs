using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;

namespace Projeto_Cash_Control
{
    public partial class UsrDespesas : System.Web.UI.Page
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

                //VisualizarDespesas(dataInicial, dataFinal);
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

                //VisualizarDespesas(dataInicial, dataFinal);
                PreencherGrid(dataInicial, dataFinal);
            }
            else
            {
                d = (Data)Session["Data"];
                lblMes.InnerText = d.MesAtual(d.atual);
                lblAno.InnerText = d.atual.Year.ToString();
            }

        }

        protected void btnNovaDespesa_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/UsrNovaDespesa.aspx");
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

        //private void VisualizarDespesas(DateTime dataInicial, DateTime dataFinal)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        Usuario u = (Usuario)Session["UsuarioLogado"];
        //        Operacao o = new Operacao();


        //        dt = o.VisualizarDespesas(u.id, dataInicial, dataFinal);


        //        float totalDespesas = 0;

        //        if (dt.Rows.Count > 0)
        //        {
        //            StringBuilder html = new StringBuilder();

        //            html.Append("<table class='table table-hover'>");

        //            html.Append("<thead style='background-color: #B22222; color: white'>");
        //            html.Append("<tr>");
        //            html.Append("<th><center></center></th>");
        //            html.Append("<th><center>Data</center></th>");
        //            html.Append("<th><center>Descrição</center></th>");
        //            html.Append("<th><center>Categoria</center></th>");
        //            html.Append("<th><center>Conta</center></th>");
        //            html.Append("<th><center>Valor</center></th>");
        //            html.Append("</tr>");
        //            html.Append("</thead>");

        //            html.Append("<tbody>");
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                html.Append("<tr>");
        //                foreach (DataColumn coloumn in dt.Columns)
        //                {
        //                    if (coloumn.ColumnName == "valor")
        //                    {
        //                        float x = float.Parse(row[coloumn.ColumnName].ToString());
        //                        totalDespesas += x;

        //                        html.Append("<td style='text-align:right; padding-right:15px'>");
        //                        html.Append(x.ToString("C2"));
        //                        html.Append("</td>");
        //                    }
        //                    else if (coloumn.ColumnName == "datahora")
        //                    {
        //                        CultureInfo cult = new CultureInfo("pt-BR");
        //                        DateTime dataFormatada = DateTime.Parse(row[coloumn.ColumnName].ToString());
        //                        string data = dataFormatada.ToString("dd/MM/yyyy", cult);

        //                        html.Append("<td><center>");
        //                        html.Append(data);
        //                        html.Append("</center></td>");
        //                    }
        //                    else
        //                    {
        //                        html.Append("<td><center>");
        //                        html.Append(row[coloumn.ColumnName]);
        //                        html.Append("</center></td>");
        //                    }
        //                }


        //                html.Append("</tr>");
        //                html.Append("</tbody>");
        //            }
        //            html.Append("</table>");

        //            // tblDespesas.Text = html.ToString();
        //            lblTotalDespesas.Text = totalDespesas.ToString("C2");
        //        }
        //        else
        //        {
        //            tblDespesas.Text = "<center><p>Nenhum dado a ser exibido.</p> <p>Clique em '<b>Novo</b>' para adicionar uma transação.</p></center>";
        //            lblTotalDespesas.Text = "R$ 0,00";
        //        }
        //    }
        //    catch
        //    {
        //        Session["UsuarioLogado"] = null;
        //        Response.Redirect(@"~/login.aspx");
        //    }

        //}

        protected void btnVoltarMesSelecionado_ServerClick(object sender, EventArgs e)
        {
            Data d = (Data)Session["Data"];

            d.atual = d.atual.AddMonths(-1);
            Session["Data"] = d;

            lblMes.InnerText = d.MesAtual(d.atual);
            lblAno.InnerText = d.atual.Year.ToString();
            //VisualizarDespesas(DataInicial(), DataFinal());
            PreencherGrid(DataInicial(), DataFinal());
        }

        protected void btnAvancarMesSelecionado_ServerClick(object sender, EventArgs e)
        {
            Data d = (Data)Session["Data"];

            d.atual = d.atual.AddMonths(1);
            Session["Data"] = d;

            lblMes.InnerText = d.MesAtual(d.atual);
            lblAno.InnerText = d.atual.Year.ToString();
            //VisualizarDespesas(DataInicial(), DataFinal());
            PreencherGrid(DataInicial(), DataFinal());
        }

        protected void btnExcluirDespesa_ServerClick(object sender, EventArgs e)
        {

        }

        private void PreencherGrid(DateTime dataInicial, DateTime dataFinal)
        {
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Operacao o = new Operacao();
            float totalDespesas = 0;

            try
            {
                gvDespesas.DataSource = o.VisualizarDespesas(u.id, dataInicial, dataFinal);
                gvDespesas.DataBind();


                if (gvDespesas.Rows.Count >= 1)
                {
                    DataTable dt = o.VisualizarDespesas(u.id, dataInicial, dataFinal);

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn coloumn in dt.Columns)
                        {
                            if (coloumn.ColumnName == "valor")
                            {
                                float x = float.Parse(row[coloumn.ColumnName].ToString());
                                totalDespesas += x;
                            }
                        }
                    }

                    lblTotalDespesas.Text = totalDespesas.ToString("C2");
                }

                else
                {
                    gvDespesas.EmptyDataText = "<center><p>Nenhum dado a ser exibido.</p> <p>Clique em '<b>Novo</b>' para adicionar uma transação.</p></center>";
                    gvDespesas.DataBind();

                    lblTotalDespesas.Text = "R$ 0,00";
                }
            }
            catch
            {
                Session["UsuarioLogado"] = null;
                Response.Redirect(@"~/login.aspx");
            }
        }

        protected void gvDespesas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int id = Convert.ToInt32(gvDespesas.DataKeys[index]["id"]);
            

            if (e.CommandName == "Excluir")
            {
                Operacao o = new Operacao();
                bool r = o.ExcluirOperacao(id);
                PreencherGrid(DataInicial(), DataFinal());
            }
            else if (e.CommandName == "Editar")
            {
                Session["IdOperacao"] = id;
                Response.Redirect(@"~/UsrNovaDespesa.aspx");
            }

        }
    }
}