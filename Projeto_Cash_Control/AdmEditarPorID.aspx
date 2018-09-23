<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdm.Master" AutoEventWireup="true" CodeBehind="AdmEditarPorID.aspx.cs" Inherits="Projeto_Cash_Control.AdmEditarPorID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

    <div class="container" style="padding: 20px; max-width: 500px">

        <div class="row border-bottom">

            <div class="col-3">
                <label for="txtIdSearch">insira o ID:</label>
            </div>
            <div class="col-3">
                <div class="form-group">
                    <input type="number" class="form-control" id="txtIdSearch" runat="server" style="max-width: 60px">
                </div>
            </div>
            <div class="col-6">
                <button type="button" class="btn btn-info btn-block" id="btnSearch" runat="server" onserverclick="btnSearch_ServerClick">Procurar</button>
            </div>
        </div>
        <br />

        <div class="row">

            <div class="col-md-6">

                <div class="form-group">
                    <label for="txtIdUsuario">ID</label>
                    <input type="text" class="form-control" id="txtIdUsuario" runat="server" style="max-width: 60px" disabled>
                </div>

            </div>
            <div class="col-md-6">
                

            </div>
        </div>
        <div class="row">

            <div class="col-md-6">

                <div class="form-group">
                    <label for="txtNomeUsuario">Nome</label>
                    <input type="text" class="form-control" id="txtNomeUsuario" runat="server">
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtSobrenomeUsuario">Sobrenome</label>
                    <input type="text" class="form-control" id="txtSobrenomeUsuario" runat="server">
                </div>
            </div>
        </div>

        <div class="form-group">
            <label for="txtEmailUsuario">E-mail</label>
            <input type="text" class="form-control" id="txtEmailUsuario" runat="server">
        </div>

        <div class="row">

            <div class="col-md-8">

                <div class="form-group">
                    <label for="txtSenhaUsuario">Senha</label>
                    <input type="password" class="form-control" id="txtSenhaUsuario" runat="server" disabled>
                </div>

            </div>

            <div class="col-md-4">

                <div class="form-check">
                    <input class="form-check-input" type="radio" name="exampleRadios" id="rbAtivo" value="option1" runat="server">
                    <label class="form-check-label" for="rbAtivo">
                        Ativo
                    </label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="exampleRadios" id="rbInativo" value="option2" runat="server">
                    <label class="form-check-label" for="rbInativo">
                        Inativo
                    </label>
                </div>

            </div>


        </div>

        <button type="button" class="btn btn-info btn-lg btn-block" id="btnSalvar" runat="server" onserverclick="btnSalvar_ServerClick">Salvar</button>

        <div class="alert alert-success alert-dismissible fade show" role="alert" id="msgSucesso" runat="server" visible="false">
            Usuário alterado com sucesso!
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>



</asp:Content>
