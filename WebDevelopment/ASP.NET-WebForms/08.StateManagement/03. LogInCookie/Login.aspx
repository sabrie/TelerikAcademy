<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_03.LogInCookie.Login" %>

<!DOCTYPE html>
<%--
    Task 3
    --------

    Create two pages that exchange user data with cookies. The first page is a login page. 
    The second one redirects to the first one if the expected cookie is missing. 
    The cookie must expire in 1 minute.

    --%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login form</title>
</head>
<body>
    <form id="FormLogin" runat="server">
        Username:
        <asp:TextBox ID="TextBoxUsername" runat="server" />
        Password:
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" />
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
    </form>
</body>
</html>
