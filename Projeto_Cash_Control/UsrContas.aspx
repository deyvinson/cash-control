<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="UsrContas.aspx.cs" Inherits="Projeto_Cash_Control.UsrContas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

    <center>
    <div class="border-bottom" style="padding-top: 10px; padding-bottom: 5px; background-color:#008B8B;  color: white">
        <h4>MINHAS CONTAS</h4>
        <h6>Gerencie suas contas.</h6>
    </div>
    </center>

    <div class="container" style="max-width: 700px; padding-top: 15px">

        <div class="container" style="padding-top: 10px">
            <center>

            <asp:GridView ID="gvContas" CssClass="table table-hover table-sm" GridLines="None" AutoGenerateColumns="false" runat="server" OnRowCommand="gvContas_RowCommand" DataKeyNames="id">

                <RowStyle Wrap="false" />
                <Columns>                   
                    
                    <asp:TemplateField HeaderText="CONTA" HeaderStyle-Width="250px" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#008B8B" HeaderStyle-ForeColor="white">
                        <ItemTemplate>
                            <div style="text-align: center">
                                <asp:Label runat="server" ID="lblConta" Text='<%# Eval("descricao") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SALDO (R$)" HeaderStyle-CssClass="text-right" HeaderStyle-Width="100px"  HeaderStyle-BackColor="#008B8B" HeaderStyle-ForeColor="white">                       
                        <ItemTemplate>
                            <div style="text-align: right">
                                <asp:Label runat="server" ID="lblValor" Text='<%# Eval("saldo", "{0:0.00}") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-BackColor="#008B8B" HeaderStyle-Width="100px">
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
    </div>

    <div class=" fixed-bottom" style="padding-bottom: 30px; padding-left: 5px">
        <asp:LinkButton CssClass="btn btn-info btn-lg" ID="btnNovo" runat="server" Text='<i class="fa fa-plus-circle"></i>' OnClick="btnNovo_Click" data-toggle="tooltip" data-placement="bottom" title="Adicionar Conta"></asp:LinkButton>
    </div>

    <footer class="footer fixed-bottom border-top" style="padding: 3px; color: white; max-height: 25px; background-color: #008B8B">

        <div class="row">
            <div class="col-md-6" style="text-align: left">
                <h6>Cash Control - Suas finanças online.</h6>
            </div>

            <div class="col-md-6" style="text-align: right; padding-right: 15px">
                <h6>Total em contas:
                <asp:Literal ID="lblSaldoAtual" runat="server"></asp:Literal></h6>
            </div>
        </div>
    </footer>



    <script>
        function Confirma() {
            return confirm("Pode haver registros vinculados a essa conta. Os valores na conta serão perdidos. Tem certeza que deseja excluí-la?");
        }
    </script>

</asp:Content>
