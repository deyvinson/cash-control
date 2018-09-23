<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="UsrEditarCategoria.aspx.cs" Inherits="Projeto_Cash_Control.UsrEditarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

    <div class="container" style="max-width:300px">

        <div class="border-bottom" style="padding-top: 10px">
            <h3 style="color: #008B8B; padding: 10px; text-align:center" id="lblTitulo" runat="server">Nova Categoria</h3>
        </div>

        <br />

        <div class="form-group">
            <label for="txtDescricao">Descrição:</label>
            <input type="text" class="form-control" id="txtDescricao" runat="server" required>
        </div>

        <div class="form-group">
            <label for="cmbTipo">Tipo:</label>
            <select class="form-control" id="cmbTipo" runat="server">
                <option>Receita</option>
                <option>Despesa</option>
            </select>
        </div>

        <center>
        <button type="button" class="btn btn-info" id="btnOK" runat="server" onserverclick="btnOK_ServerClick">OK</button>
        <button type="button" class="btn btn-outline-info" id="btnCancelar" runat="server" onserverclick="btnCancelar_ServerClick">Cancelar</button>
        </center>

    </div>

    <footer class="footer fixed-bottom border-top" style="padding: 3px; color: white; max-height: 25px; background-color: #008B8B">
        <div class="row">
            <div class="col-md-6" style="text-align: left">
                <h6>Cash Control - Suas finanças online.</h6>
            </div>

            <div class="col-md-6" style="text-align: right; padding-right: 15px">
            </div>
        </div>
    </footer>


</asp:Content>
