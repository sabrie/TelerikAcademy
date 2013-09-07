<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateRandomNumbers.aspx.cs" Inherits="_02.GenerateRandomNumbers_WebControls.GenerateRandomNumbers" %>

<%--
    Task 2
    -------

    Using the Web server controls create a Web application for generating random numbers. 
    It should have two input fields defining a range (e.g. [10..20]) and a button to generate 
    a random number in the specified range.
--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate random numbers</title>
    <style>
        .label{
            display: inline-block;
            width: 160px;
        }

        body{
            background-color: lightgray;
            font-weight: bold;
        }

        .submit{
            background-color: #8b0606;
            padding: 10px;
            border-radius: 5px;
            color: #dedede;
        }
    </style>
</head>
<body>
    <form id="GenerateRandomNumber" runat="server">
    <div>
        <h1>Generate a random number in given range using Web server controls</h1>

        <asp:Label ID="LabelFrom" Text="From: " runat="server" class="label" />
        <asp:TextBox ID="TextBoxFrom" runat="server" /> <br />

        <asp:Label ID="LabelTo" Text="To: " runat="server" class="label" />
        <asp:TextBox ID="TextBoxTo" runat="server" /> <br />

        <asp:Button Text="Generate random number" ID="GenerateNumber_Btn" OnClick="GenerateRandomNumber_Click" runat="server" class="submit"/><br />

        <asp:Label ID="LabelRandomNumber" Text="Number: " runat="server" class="label" />
        <asp:TextBox ID="TextBoxRandomNumber" runat="server" /> 
    </div>
    </form>
</body>
</html>
