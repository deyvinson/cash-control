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
    public partial class AdmGerenciarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }

        public void CarregarUsuarios()
        {

            DataTable dt = new DataTable();
            Usuario p = new Usuario();
            dt = p.Selecionar();

            if (dt.Rows.Count > 0)
            {
                StringBuilder html = new StringBuilder();

                html.Append("<table class='table table-bordered'>");

                html.Append("<thead style='background-color: #008B8B; color: white'>");

                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
                html.Append("</tr>");
                html.Append("</thead>");

                html.Append("<tbody>");
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn coloumn in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[coloumn.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                    html.Append("</tbody>");
                }
                html.Append("</table>");


                tblUsuarios.Text = html.ToString();

            }
        }
    }
}