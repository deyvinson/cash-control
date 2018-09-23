<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Projeto_Cash_Control.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <title>Login - Cash Control</title>
</head>
<body style="background-color: #008B8B">
    <form id="form1" runat="server">
        <div class="container" style="padding-top: 100px; max-width: 380px">

            <div style="color: white">
                <center>
            <h1>Cash Control</h1>
            <h4>Suas Finanças Online</h4>
            </center>
            </div>

            <br />
            <br />

            <div class="form-group">
                <label for="txtEmail" style="color: white">Email</label>
                <input type="text" class="form-control" id="txtEmail" aria-describedby="emailHelp" runat="server">
            </div>
            <div class="form-group">
                <label for="txtSenha" style="color: white">Senha</label>
                <input type="password" class="form-control" id="txtSenha" runat="server">
            </div>

            <br />

            <center><button onserverclick="btnLogin_ServerClick" type="submit" class="btn btn-outline-light btn-lg" id="btnLogin" runat="server">Entrar</button></center>

        </div>

        <br />
        <br />
        <br />
        <br />

        <center><p style="color: white">Novo por aqui?  <button onserverclick="btnCadastrar_ServerClick" type="submit" class="btn btn-outline-light" id="btnCadastrar" runat="server">Cadastre-se</button></p></center>


    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js" integrity="sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js" integrity="sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm" crossorigin="anonymous"></script>

</body>
</html>
