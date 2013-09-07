<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlEscaping.aspx.cs" Inherits="_03.HtmlEscaping.HtmlEscaping" %>

<%--
    Task 3
    --------
    
    Define a Web form with text box and button. On button click show 
    the entered in the first textbox text in other textbox control and 
    label control. Enter some potentially dangerous text. Fix issues 
    related to HTML escaping – the application should accept HTML tags 
    and display them correctly.
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Html Escaping</title>
</head>
<body>
    <form id="HtmlEscaping" runat="server">
    <div>
        <h3>Enter HTML tags in the first textbox, click "Submit" and display them correctly (escaped) in both TextBox And Label</h3>
        Enter Text: <asp:TextBox ID="TextBoxText" runat="server" /><br />
        <asp:Button Text="Submit" runat="server" ID="ButtonSubmit" OnClick="ButtonSubmit_Click" /><br />

        Escaped text in TextBox: 
        <asp:TextBox ID="TextBoxEscapedText" runat="server" /><br />
        
        Escaped text in Label: 
        <asp:Label ID="LabelEscapedText" runat="server" Mode="Encode" ><%: this.TextBoxText.Text %></asp:Label><br />
    </div>
    </form>
</body>
</html>
