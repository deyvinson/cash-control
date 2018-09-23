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
    public partial class UsrContas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VisualizarContas();
            PreencherGrid();
            SaldoAtual();
        }

        private void VisualizarContas()
        {
            DataTable dt = new DataTable();
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Conta c = new Conta();

            dt = c.VisualizarContas(u.id);

            if (dt.Rows.Count > 0)
            {
                StringBuilder html = new StringBuilder();

                html.Append("<table class='table table-hover'>");

                //html.Append("<thead style='background-color: #008B8B; color: white'>");

                //html.Append("<tr>");
                //html.Append("<th><center>Conta</center></th>");
                //html.Append("<th><center>Saldo</center></th>");
                //html.Append("</tr>");
                //html.Append("</thead>");

                html.Append("<tbody>");
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn coloumn in dt.Columns)
                    {
                        if (coloumn.ColumnName == "saldo")
                        {
                            float x = float.Parse(row[coloumn.ColumnName].ToString());

                            html.Append("<td style='text-align:right; padding-right:15px'><center>");
                            html.Append(x.ToString("C2"));
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

                //tblContas.Text = html.ToString();
            }
        }

        //protected void btnAddConta_ServerClick(object sender, EventArgs e)
        //{
        //    Conta c = new Conta();
        //    Usuario u = new Usuario();
        //    u = (Usuario)Session["UsuarioLogado"];

        //    c.descricao = txtEditConta.Value;
        //    c.saldo = 0;
        //    c.usuario = u.id;

        //    c.NovaConta(c);
        //    VisualizarContas();
        //}
        //protected void btnDeleteConta_ServerClick(object sender, EventArgs e)
        //{
        //    Conta c = new Conta();
        //    Usuario u = new Usuario();
        //    u = (Usuario)Session["UsuarioLogado"];

        //    c.descricao = txtEditConta.Value;
        //    c.usuario = u.id;

        //    //c.ExcluirConta(c);
        //    VisualizarContas();
        //}

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

        private void PreencherGrid()
        {
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Conta c = new Conta();
            gvContas.DataSource = c.VisualizarContas(u.id);
            gvContas.DataBind();            
        }

        protected void gvContas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int id = Convert.ToInt32(gvContas.DataKeys[index]["id"]);

            if (e.CommandName == "Excluir")
            {
                Conta c = new Conta();
                bool r = c.ExcluirConta(id);
                PreencherGrid();
            }
            else if (e.CommandName == "Editar")
            {
                Session["IdConta"] = id;
                Response.Redirect(@"~/UsrEditarConta.aspx");
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/UsrEditarConta.aspx");
        }
    }
}
