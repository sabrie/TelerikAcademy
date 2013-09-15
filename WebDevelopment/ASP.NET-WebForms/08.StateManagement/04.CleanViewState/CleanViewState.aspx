<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CleanViewState.aspx.cs" Inherits="_04.CleanViewState.CleanViewState" %>

<!DOCTYPE html>
<%--
    Task 4
    --------

    In ASPX page holding a TextBox run a JavaScript code that deletes the ViewState 
    hidden field variable in ASPX page. What happens at postback?

    --%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clean ViewState</title>
</head>
<body>
    <h1>Clean ViewState</h1>

    <form id="formViewState" runat="server">
        <p>
            If the ViewState remains on the page, the browser keeps the entered value in the text box. <br />
            Cleaning the ViewState results in data loss. When the page is posted back, the value in the text box disappears.
        </p>
        <asp:TextBox ID="TextBoxViewState" runat="server" Text="" />
        <asp:Button ID="ButtonDoPostback" runat="server" Text="Do postback" />
    </form>
    <script>
        document.onload = function () {
            var viewState = document.getElementById("__VIEWSTATE");
            document.forms[0].children[0].removeChild(viewState);
        }();
    </script>
</body>
</html>
