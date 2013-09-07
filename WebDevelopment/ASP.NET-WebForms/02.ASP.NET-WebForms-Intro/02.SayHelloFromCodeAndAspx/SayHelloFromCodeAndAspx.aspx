<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SayHelloFromCodeAndAspx.aspx.cs" Inherits="_02.SayHelloFromCodeAndAspx.SayHelloFromCodeAndAspx" %>

<%--
    Task 2
    ---------
    Print "Hello, ASP.NET" from the C# code and from the aspx code. 
    Display the current assembly location by Assembly.GetExecutingPath().
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello, ASP.NET</title>
    <style>
        #task-description{
            background-color: #dedede;
            border-radius: 6px;
            padding: 10px;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="SayHello" runat="server">
        <div id="task-description">
            <h3>Task 2</h3>
            <p>
                Print "Hello, ASP.NET" from the C# code and from the aspx code. <br />
                Display the current assembly location by Assembly.GetExecutingPath().
            </p>
        </div>
        <div>
            <asp:PlaceHolder ID="PlaceholderHello" runat="server" /><br />
            <asp:Literal Text="Hello, ASP.NET (from aspx)" ID="LiteralHello" runat="server" /><br />
            <asp:Literal ID="LiteralAssemblyLocation" runat="server" />
        </div>
    </form>
</body>
</html>
