<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumNumbers.aspx.cs" Inherits="_02.SumNumbers_WebForms.SumNumbers" %>

<%--
    Task 2
    -------
    
    Write a simple application to sum numbers in ASP.NET Web Forms.
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sumator</title>
    <style>
        .label{
            display: inline-block;
            width: 160px;

        }

        body{
            background-color: #dedede;
            font-weight: bold;
        }

        .button{
            background-color: #8b0606;
            padding: 10px;
            border-radius: 5px;
            color: #dedede;
        }
    </style>
</head>

<body>
    <form id="sumator" runat="server">
        <p> This is a simple application to sum numbers in ASP.NET Web Forms</p>
        <h1 class="header">Sumator</h1>
        <div>
            <asp:Label class="label" ID="LableFirstNum" runat="server" AssociatedControlID="TextBoxFirstNum">
                Enter First Number: 
            </asp:Label>
            <asp:TextBox ID="TextBoxFirstNum" runat="server" Text="0" Columns="40"></asp:TextBox><br />
            
            <asp:Label class="label" ID="LableSecondNum" runat="server" AssociatedControlID="TextBoxFirstNum">
                Enter Second Number: 
            </asp:Label> 
            <asp:TextBox ID="TextBoxSecondNum" runat="server" Text="0" Columns="40"></asp:TextBox><br />
            <asp:Button class="button" ID="BtnCalculateSum" runat="server" Text="Calculate Sum" OnClick="BtnCalculateSum_Click"/><br />
            <asp:Label class="label" ID="LableSum" runat="server" AssociatedControlID="TextBoxFirstNum">
                Sum: 
            </asp:Label>  
            <asp:TextBox ID="TextBoxSum" runat="server" Columns="40" ReadOnly="true"></asp:TextBox><br />
        </div>
    </form>
</body>
</html>
