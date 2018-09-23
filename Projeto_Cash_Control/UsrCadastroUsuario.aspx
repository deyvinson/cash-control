<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsrCadastroUsuario.aspx.cs" Inherits="Projeto_Cash_Control.CadastroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Criação de Usuário - Cash Control</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
</head>
<body style="background-color: #008B8B; color: white">

    <form id="form1" runat="server">

        <!--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>  -->

        <div class="container" style="padding-top: 30px; max-width: 400px">


            <center>
                <h3>Novo usuário</h3>
                <h5>Preencha os campos abaixo com seus dados.</h5>
            </center>


            <div class="form-group">
                <label for="txtNome">Nome:</label>
                <input type="text" class="form-control" id="txtNome" runat="server" required>
            </div>

            <div class="form-group">
                <label for="txtSobrenome">Sobrenome:</label>
                <input type="text" class="form-control" id="txtSobrenome" runat="server">
            </div>

            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <input type="email" class="form-control" id="txtEmail" aria-describedby="emailHelp" runat="server" required>
            </div>

            <div class="form-group">
                <label for="txtSenha">Senha:</label>
                <input type="password" class="form-control" id="txtSenha" runat="server" required>
            </div>

            <div class="form-group">
                <label for="txtSenhaRepeat">Repita sua Senha:</label>
                <input type="password" class="form-control" id="txtSenhaRepeat" runat="server" required>
            </div>


            <div>
                <center><button onserverclick="btnEnviar_ServerClick" type="submit" class="btn btn-outline-light btn-lg" id="btnEnviar" runat="server">Enviar</button></center>
            </div>

        </div>

        </script>


    </form>


    <!-- <script type="text/javascript">

        function Confirmar()
        {
            if (confirm("Confirmar as informações?"))
                return true;
            else
                return false;
        } -->

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js" integrity="sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js" integrity="sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm" crossorigin="anonymous"></script>


</body>
</html>
