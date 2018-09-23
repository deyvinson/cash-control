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
    public partial class UsrCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //VisualizarCategoriasReceitas();
            //VisualizarCategoriasDespesas();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            Usuario u = (Usuario)Session["UsuarioLogado"];
            Categoria cat = new Categoria();

            gvCategoriasReceitas.DataSource = cat.VisualizarCategoriasReceitas(u.id);
            gvCategoriasReceitas.DataBind();

            gvCategoriasDespesas.DataSource = cat.VisualizarCategoriasDespesas(u.id);
            gvCategoriasDespesas.DataBind();
        }

        //metodos Antigos
        //private void VisualizarCategoriasReceitas()
        //{
        //    DataTable dt = new DataTable();
        //    Usuario u = (Usuario)Session["UsuarioLogado"];
        //    CategoriaReceita cr = new CategoriaReceita();
        //    dt = cr.VisualizarCategorias(u.id);

        //    if (dt.Rows.Count > 0)
        //    {
        //        StringBuilder html = new StringBuilder();

        //        html.Append("<table class='table table-hover'>");

        //        /*html.Append("<thead style='background-color: #008B8B; color: white'>");

        //        html.Append("<tr>");
        //        foreach (DataColumn column in dt.Columns)
        //        {
        //            html.Append("<th>");
        //            html.Append("<center>Categorias de Entrada</center>");
        //            html.Append("</th>");
        //        }
        //        html.Append("</tr>");
        //        html.Append("</thead>");*/

        //        html.Append("<tbody>");
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            html.Append("<tr>");
        //            foreach (DataColumn coloumn in dt.Columns)
        //            {
        //                html.Append("<td>");
        //                html.Append(row[coloumn.ColumnName]);
        //                html.Append("</td>");
        //            }
        //            html.Append("</tr>");
        //            html.Append("</tbody>");
        //        }
        //        html.Append("</table>");

        //        //tblCategoriasReceitas.Text = html.ToString();
        //    }
        //}
        //private void VisualizarCategoriasDespesas()
        //{
        //    DataTable dt = new DataTable();
        //    Usuario u = (Usuario)Session["UsuarioLogado"];
        //    CategoriaDespesa cd = new CategoriaDespesa();
        //    dt = cd.VisualizarCategorias(u.id);

        //    if (dt.Rows.Count > 0)
        //    {
        //        StringBuilder html = new StringBuilder();

        //        html.Append("<table class='table table-hover'>");

        //        /*html.Append("<thead style='background-color: #008B8B; color: white'>");

        //        html.Append("<tr>");
        //        foreach (DataColumn column in dt.Columns)
        //        {
        //            html.Append("<th>");
        //            html.Append("<center>Categorias de Saída</center>");
        //            html.Append("</th>");
        //        }
        //        html.Append("</tr>");
        //        html.Append("</thead>");*/

        //        html.Append("<tbody>");
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            html.Append("<tr>");
        //            foreach (DataColumn coloumn in dt.Columns)
        //            {
        //                html.Append("<td>");
        //                html.Append(row[coloumn.ColumnName]);
        //                html.Append("</td>");
        //            }
        //            html.Append("</tr>");
        //            html.Append("</tbody>");
        //        }
        //        html.Append("</table>");

        //        //tblCategoriasDespesas.Text = html.ToString();
        //    }
        //}
        //protected void btnAddCategoriaReceitas_ServerClick(object sender, EventArgs e)
        //{
            
        //    CategoriaReceita cr = new CategoriaReceita();
        //    Usuario u = new Usuario();
        //    u = (Usuario)Session["UsuarioLogado"];

        //    cr.descricao = txtEditReceita.Value;
        //    cr.usuario = u.id;           
        //    cr.NovaCategoria(cr);
        //    VisualizarCategoriasReceitas();
        //}
        //protected void btnEditCategoriaReceitas_ServerClick(object sender, EventArgs e)
        //{

        //}
        ////protected void btnDeleteCategoriaReceitas_ServerClick(object sender, EventArgs e)
        ////{
        ////    CategoriaReceita cr = new CategoriaReceita();
        ////    Usuario u = new Usuario();
        ////    u = (Usuario)Session["UsuarioLogado"];

        ////    cr.descricao = txtEditReceita.Value;
        ////    cr.usuario = u.id;
        ////    cr.ExcluirCategoria(cr);
        ////    VisualizarCategoriasReceitas();
        ////}
        //protected void btnAddCategoriaDespesas_ServerClick(object sender, EventArgs e)
        //{
        //    CategoriaDespesa cd = new CategoriaDespesa();
        //    Usuario u = new Usuario();
        //    u = (Usuario)Session["UsuarioLogado"];

        //    cd.descricao = txtEditDespesa.Value;
        //    cd.usuario = u.id;
        //    cd.NovaCategoria(cd);
        //    VisualizarCategoriasDespesas();
        //}


        //protected void btnDeleteCategoriaDespesas_ServerClick(object sender, EventArgs e)
        //{
        //    CategoriaDespesa cd = new CategoriaDespesa();
        //    Usuario u = new Usuario();
        //    u = (Usuario)Session["UsuarioLogado"];

        //    cd.descricao = txtEditDespesa.Value;
        //    cd.usuario = u.id;
        //    cd.ExcluirCategoria(cd);
        //    VisualizarCategoriasDespesas();
        //}

        protected void gvCategoriasReceitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int id = Convert.ToInt32(gvCategoriasReceitas.DataKeys[index]["id"]);

            if (e.CommandName == "Excluir")
            {
                Categoria cat = new Categoria();
                bool r = cat.ExcluirCategoria(id);
                PreencherGrid();
            }
            else if (e.CommandName == "Editar")
            {
                Session["IdCategoria"] = id;
                Response.Redirect(@"~/UsrEditarCategoria.aspx");
            }
        }

        protected void gvCategoriasDespesas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int id = Convert.ToInt32(gvCategoriasDespesas.DataKeys[index]["id"]);

            if (e.CommandName == "Excluir")
            {
                Categoria cat = new Categoria();
                bool r = cat.ExcluirCategoria(id);
                PreencherGrid();
            }
            else if (e.CommandName == "Editar")
            {
                Session["IdCategoria"] = id;
                Response.Redirect(@"~/UsrEditarCategoria.aspx");
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/UsrEditarCategoria.aspx");
        }
    } 
}