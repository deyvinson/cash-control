<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="UsrPaginaInicial.aspx.cs" Inherits="Projeto_Cash_Control.PaginaInicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

    <center>
    <div class="border-bottom" style="padding-top: 10px; padding-bottom:5px; background-color:#008B8B; color:white">
        <h4>RESUMO</h4>
        <h6>Use o menu para visualizar detalhes das suas contas, despesas, receitas e categorias.</h6>
    </div>
    </center>

    <div class="container" style="max-width: 1000px; padding-top: 20px">

        <center>
    <div class="row" style="max-width:300px">
        <div class="col-md-3">
            <button onserverclick="btnVoltarMesSelecionado_ServerClick" type="button" class="btn btn-dark" runat="server" id="btnVoltarMesSelecionado"><</button>
        </div>
         <div class="col-md-6" style="text-align:center">
            <center><h4 id="lblMes" runat="server">Mês</h4></center>
        </div>
         <div class="col-md-3">
            <button onserverclick="btnAvancarMesSelecionado_ServerClick" type="button" class="btn btn-dark" runat="server" id="btnAvancarMesSelecionado">></button>
        </div>
    </div>
            <h6 id="lblAno" runat="server">Ano</h6>
    </center>

        <br />

        <div class="row">

            <div class="col-md-4" style="border-radius: 30px;">
                
                    <h5 style="padding: 10px; padding-left: 30px; background-color: cadetblue; color: white">Saldo em Contas:
                    <br />
                        R$
                    <asp:Literal ID="txtSaldo" runat="server"></asp:Literal></h5>
                
            </div>

            <div class="col-md-4">
                <a href="UsrReceitas.aspx" style="text-decoration:none">
                <h5 style="padding: 10px; padding-left: 30px; background-color: forestgreen; color: white">Receitas:
                    <br />
                    R$
                    <asp:Literal ID="txtReceitas" runat="server"></asp:Literal></h5>
                    </a>
            </div>

            <div class="col-md-4">
                <a href="UsrDespesas.aspx" style="text-decoration:none">
                <h5 style="padding: 10px; padding-left: 30px; background-color: #B22222; color: white">Despesas:
                    <br />
                    R$
                    <asp:Literal ID="txtDespesas" runat="server"></asp:Literal></h5>
                </a>
            </div>

        </div>


        <div style="padding-top: 10px">
            <center><h5 style="padding: 10px; padding-left: 30px; padding-top:25px; padding-bottom:25px; background-color: #008B8B; color: white">Balanço mensal: R$ <asp:Literal ID="txtBalanco" runat="server"></asp:Literal></h5></center>
        </div>


        <footer class="footer fixed-bottom border-top" style="padding: 3px; color: white; max-height: 25px; background-color: #008B8B">

            <div class="row">
                <div class="col-md-6" style="text-align: left">
                    <h6>Desenvolvido por: Deyvinson H. Vidal</h6>
                </div>

                <div class="col-md-6" style="text-align: right; padding-right: 15px">
                </div>
            </div>
        </footer>

    </div>

</asp:Content>
