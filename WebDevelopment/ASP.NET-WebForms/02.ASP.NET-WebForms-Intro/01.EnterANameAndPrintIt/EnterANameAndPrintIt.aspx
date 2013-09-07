<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterANameAndPrintIt.aspx.cs" Inherits="_01.EnterANameAndPrintIt.EnterANameAndPrintIt" %>

<%--
    Task 1
    -------

    Create a simple ASPX page that enters a name and 
    prints "Hello" + name in the page. Use a TextBox + Button + Label.
--%>

<!DOCTYPE html>
<style>
    body{
        background-color: #dedede;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Say Hello</title>
</head>
<body>
    <form id="EnterName" runat="server">
    <div>
        <asp:Label Text="Enter your name: " ID="YourName" runat="server" />
        <asp:TextBox ID="TextBoxName" runat="server" Placeholder="Enter your name here" /><br />
        <asp:Button Text="Say Hello" ID="Btn_SayHello" OnClick="Btn_SayHello_Click" runat="server" /> <br />
        <asp:Literal ID="LiteralHelloName" runat="server" Mode="Encode"/>
    </div>
    </form>
</body>
</html>
