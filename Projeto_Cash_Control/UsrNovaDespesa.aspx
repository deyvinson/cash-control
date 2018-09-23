<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="UsrNovaDespesa.aspx.cs" Inherits="Projeto_Cash_Control.UsrNovaDespesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

    <div class="container" style="max-width: 650px">

        <div class="border-bottom" style="padding-top: 10px">
            <h3 style="color: #B22222; padding: 10px" id="lblTitulo" runat="server">Nova Despesa</h3>
        </div>

        <br />

        <div class="row">

            <div class="col-md-3">
                <div class="form-group">
                    <label for="txtValor">Valor (R$):</label>
                    <input type="text" class="form-control" id="txtValor" runat="server" required>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label for="txtData">Data:</label>
                    <input type="date" class="form-control" id="txtData" runat="server" required>
                </div>
            </div>

        </div>

        <div class="form-group">
            <label for="txtDescricao">Descrição:</label>
            <input type="text" class="form-control" id="txtDescricao" runat="server" required>
        </div>


        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="cmbCategorias">Categoria:</label>
                    <select class="form-control" id="cmbCategorias" runat="server">
                    </select>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="cmbContas">Conta:</label>
                    <select class="form-control" id="cmbContas" runat="server">
                    </select>
                </div>
            </div>
        </div>

        <br />

        <center>
        <button type="button" class="btn btn-danger" id="btnOK" runat="server" onserverclick="btnOK_ServerClick">OK</button>
        <button type="button" class="btn btn-outline-danger" id="btnCancelar" runat="server" onserverclick="btnCancelar_ServerClick">Cancelar</button>
        </center>

        <footer class="footer fixed-bottom border-top" style="padding: 3px; color: white; max-height: 25px; background-color: #008B8B">
            <div class="row">
                <div class="col-md-6" style="text-align: left">
                    <h6>Cash Control - Suas finanças online.</h6>
                </div>

                <div class="col-md-6" style="text-align: right; padding-right: 15px">
                </div>
            </div>
        </footer>

    </div>

</asp:Content>
