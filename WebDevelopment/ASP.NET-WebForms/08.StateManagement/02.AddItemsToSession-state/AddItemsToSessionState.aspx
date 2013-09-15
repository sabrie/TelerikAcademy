<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItemsToSessionState.aspx.cs" Inherits="_02.AddItemsToSession_state.AddItemsToSessionState" %>

<!DOCTYPE html>

<%--
    Task 2
    --------

    Create a ASP.NET Web Form which appends the input of a text field when a button is clicked in the 
    Session object and then prints it in a <asp:Label> control. Use List<string> to keep all the text 
    lines entered in the page during the session lifetime.

    --%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SessionState</title>
</head>
<body>
    <form id="mainForm" runat="server">
        <h1>Add items to SessionState</h1>
        <asp:Panel ID="PanelAddItemToSessionState" runat="server">
            <asp:TextBox ID="InputText" runat="server" EnableViewState="false" />
            <asp:Button ID="ButtonAddToSessionState" runat="server"
                Text="Append text to SessionState" OnClick="ButtonAddToSessionState_Click" />
        </asp:Panel>

        <asp:Panel ID="PanelShowSessionStateItem" runat="server" Visible="false">
            <asp:Label ID="LabelSessionStateItem" runat="server"  />
            <br />
            <asp:Button ID="ButtonBack" runat="server" Text="Back"
                OnClick="ButtonBack_Click" />
        </asp:Panel>
    </form>
</body>
</html>
