<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="UsrExtrato.aspx.cs" Inherits="Projeto_Cash_Control.UsrExtrato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

    <center>
    <div class="border-bottom" style="padding-top: 10px; padding-bottom: 5px; background-color:#008B8B;  color: white">
        <h4>EXTRATO</h4>
        <h6>Uma visão geral de sua movimentação.</h6>
    </div>
    </center>

    <center>
    <div class="row" style="max-width:300px; padding-top: 15px">
        <div class="col-md-3">
            <button onserverclick="btnVoltarMesSelecionado_ServerClick" type="button" class="btn btn-dark" runat="server" id="btnVoltarMesSelecionado"><</button>
        </div>
         <div class="col-md-6">
            <h4 id="lblMes" runat="server">Mês</h4>
        </div>
         <div class="col-md-3">
            <button onserverclick="btnAvancarMesSelecionado_ServerClick" type="button" class="btn btn-dark" runat="server" id="btnAvancarMesSelecionado">></button>
        </div>
    </div>
        <h6 id="lblAno" runat="server">Ano</h6>
    </center>

    <div class="container" style="padding-top: 10px">
            <asp:Literal ID="tblExtrato" runat="server"></asp:Literal>    
    </div>

    <br />

    <!--<button onserverclick="btnVoltar_ServerClick" type="button" class="btn btn-outline-info" runat="server" id="btnVoltar">Voltar</button>-->

    <footer class="footer fixed-bottom border-top" style="padding: 3px; color: white; max-height: 25px; background-color: #008B8B">

        <div class="row">

            <div class="col-md-3" style="text-align: left">
                <h6>Cash Control - Suas finanças online.</h6>
            </div>

            <div class="col-md-3" style="text-align: right; padding-right: 15px">
                <h6>Receitas do Mês:
                <asp:Literal ID="lblReceitasMes" runat="server"></asp:Literal></h6>
            </div>
            
            <div class="col-md-3" style="text-align: right; padding-right: 15px">    
                    <h6>Despesas do Mês:
                <asp:Literal ID="lblDespesasMes" runat="server"></asp:Literal></h6>
            </div>
            
            <div class="col-md-3" style="text-align: right; padding-right: 15px">        
                        <h6>Saldo Atual:
                <asp:Literal ID="lblSaldoAtual" runat="server"></asp:Literal></h6>

                    </div>

                </div>
    </footer>


</asp:Content>
