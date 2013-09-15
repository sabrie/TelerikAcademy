<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="BrowserTypeAndIP.aspx.cs" 
    Inherits="_01.PrintBrowserTypeAndIP.BrowserTypeAndIP" %>

<!DOCTYPE html>

<%--
    Task 1
    --------

    Create an ASP.NET Web Form, which prints the type of the 
    browser and the client IP address requested .aspx page.
    --%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Browser type and IP</title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:Literal ID="LiteralOutput" runat="server" />
    </form>
</body>
</html>
