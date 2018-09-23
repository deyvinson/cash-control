<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="UsrCategorias.aspx.cs" Inherits="Projeto_Cash_Control.UsrCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

    <center>
    <div class="border-bottom" style="padding-top: 10px; padding-bottom: 5px; background-color:#008B8B;  color: white">
        <h4>MINHAS CATEGORIAS</h4>
        <h6>Gerencie suas categorias.</h6>
    </div>
    </center>

    <br />

    <div class="container">

        <div class="row">

            <div class="col-md-6">

                <asp:GridView ID="gvCategoriasReceitas" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false" runat="server" OnRowCommand="gvCategoriasReceitas_RowCommand" DataKeyNames="id">
                    <RowStyle Wrap="false" />
                    <Columns>
                        <asp:TemplateField HeaderText="CATEGORIAS DE ENTRADA" HeaderStyle-Width="250px" HeaderStyle-CssClass="text-left" HeaderStyle-BackColor="#008B8B" HeaderStyle-ForeColor="white">
                            <ItemTemplate>
                                <div style="text-align: left">
                                    <asp:Label runat="server" ID="lblDescricao" Text='<%# Eval("descricao") %>'></asp:Label>
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

            </div>

            <div class="col-md-6">

                <asp:GridView ID="gvCategoriasDespesas" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false" runat="server" OnRowCommand="gvCategoriasDespesas_RowCommand" DataKeyNames="id">
                    <RowStyle Wrap="false" />
                    <Columns>
                        <asp:TemplateField HeaderText="CATEGORIAS DE SAÍDA" HeaderStyle-Width="250px" HeaderStyle-CssClass="text-left" HeaderStyle-BackColor="#008B8B" HeaderStyle-ForeColor="white">
                            <ItemTemplate>
                                <div style="text-align: left">
                                    <asp:Label runat="server" ID="lblDescricao2" Text='<%# Eval("descricao") %>'></asp:Label>
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

            </div>
        </div>
    </div>

    <div class=" fixed-bottom" style="padding-bottom:30px; padding-left:5px">
        <asp:LinkButton CssClass="btn btn-info btn-lg" ID="btnNovo" runat="server" Text='<i class="fa fa-plus-circle"></i>' OnClick="btnNovo_Click" data-toggle="tooltip" data-placement="top" title="Adicionar Categoria"></asp:LinkButton>
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

    <script>
        function Confirma() {
            return confirm("Pode haver registros vinculados a essa categoria. Tem certeza que deseja excluir?");
        }
    </script>


</asp:Content>
