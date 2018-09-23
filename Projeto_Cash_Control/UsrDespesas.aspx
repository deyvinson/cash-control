<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="UsrDespesas.aspx.cs" Inherits="Projeto_Cash_Control.UsrDespesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

    <center>
    <div class="border-bottom" style="padding-top: 10px; padding-bottom: 5px; background-color: #B22222; color:white">
        <h4>MINHAS DESPESAS</h4>
        <h6>Uma visão geral dos seus gastos e investimentos.</h6>
    </div>
    </center>

    <center>
    <div class="row" style="max-width:300px; padding-top:15px">
        <div class="col-md-3">
            <button onserverclick="btnVoltarMesSelecionado_ServerClick" type="button" class="btn btn-danger" runat="server" id="btnVoltarMesSelecionado"><</button>
        </div>
         <div class="col-md-6">
            <h4 id="lblMes" runat="server">Mês</h4>
        </div>
         <div class="col-md-3">
            <button onserverclick="btnAvancarMesSelecionado_ServerClick" type="button" class="btn btn-danger" runat="server" id="btnAvancarMesSelecionado">></button>
        </div>
    </div>

        <h6 id="lblAno" runat="server">Ano</h6>
    </center>

    <div class="container" style="padding-top: 10px">
        <center>

        <!--<div style="padding-top: 15px">
            <asp:Literal ID="tblDespesas" runat="server"></asp:Literal>
        </div>-->

            <asp:GridView ID="gvDespesas" CssClass="table table-hover table-sm" GridLines="None" AutoGenerateColumns="false" runat="server" OnRowCommand="gvDespesas_RowCommand" DataKeyNames="id">

                <RowStyle Wrap="false" />
                <Columns>
                   
                    <asp:TemplateField HeaderText="DATA" HeaderStyle-CssClass="text-center" HeaderStyle-Width="120px"  HeaderStyle-BackColor="#B22222" HeaderStyle-ForeColor="white">
                        <ItemTemplate>
                            <div style="text-align:center"><asp:Label runat="server" ID="lblData" Text='<%# Eval("dataHora", "{0:dd/MM/yyyy}") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="DESCRIÇÃO" HeaderStyle-Width="250px"  HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#B22222" HeaderStyle-ForeColor="white">
                        <ItemTemplate>
                            <div style="text-align:center"><asp:Label runat="server" ID="lblDescricao" Text='<%# Eval("descricao") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CATEGORIA" HeaderStyle-Width="250px" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#B22222" HeaderStyle-ForeColor="white">
                        <ItemTemplate>
                            <div style="text-align: center">
                                <asp:Label runat="server" ID="lblCategoria" Text='<%# Eval("categoria") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CONTA" HeaderStyle-Width="250px" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#B22222" HeaderStyle-ForeColor="white">
                        <ItemTemplate>
                            <div style="text-align: center">
                                <asp:Label runat="server" ID="lblConta" Text='<%# Eval("conta") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="VALOR (R$)" HeaderStyle-CssClass="text-right" HeaderStyle-Width="100px"  HeaderStyle-BackColor="#B22222" HeaderStyle-ForeColor="white">                       
                        <ItemTemplate>
                            <div style="text-align: right">
                                <asp:Label runat="server" ID="lblValor" Text='<%# Eval("valor", "{0:0.00}") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-BackColor="#B22222" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <div style="text-align: right">
                                <asp:LinkButton CssClass="btn btn-outline-secondary btn-sm" ID="btnEditar" runat="server" Text='<i class="fa fa-pencil-alt"></i>' CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" data-toggle="tooltip" data-placement="bottom" title="Editar"></asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-outline-secondary btn-sm" ID="btnExcluir" runat="server" Text='<i class="fa fa-trash-alt"></i>' CommandName="Excluir" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="if(!Confirma()) return false;" data-toggle="tooltip" data-placement="bottom" title="Excluir"></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        <br />
        </center>
    </div>

    <div class=" fixed-bottom" style="padding-bottom: 30px; padding-left: 5px">
        <asp:LinkButton CssClass="btn btn-danger btn-lg" ID="btnNovo" runat="server" Text='<i class="fa fa-plus-circle"></i>' OnClick="btnNovaDespesa_ServerClick" data-toggle="tooltip" data-placement="bottom" title="Adicionar Despesa"></asp:LinkButton>
    </div>

    <footer class="footer fixed-bottom border-top" style="padding: 3px; color: white; max-height: 25px; background-color: #008B8B">

        <div class="row">
            <div class="col-md-6" style="text-align: left">
                <h6>Cash Control - Suas finanças online.</h6>
                <!--<button type="button" class="btn btn-danger btn-sm" id="btnNovaDespesa" runat="server" onserverclick="btnNovaDespesa_ServerClick">Nova Despesa</button>-->
            </div>

            <div class="col-md-6" style="text-align: right; padding-right: 15px">
                <h6>Total em despesas:
                        <asp:Literal ID="lblTotalDespesas" runat="server"></asp:Literal></h6>
            </div>
        </div>
    </footer>

     <script>
        function Confirma()
        {
            return confirm("Deseja excluir o registro?");
        }
    </script>

    <script>
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>

</asp:Content>
