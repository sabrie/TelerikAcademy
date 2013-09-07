<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateRandomNumbers.aspx.cs" Inherits="_01.GenerateRandomNumbers.GenerateRandomNumbers" %>

<%--
    Task 1
    -------

    Using the HTML server controls create a Web application for generating random numbers. 
    It should have two input fields defining a range (e.g. [10..20]) and a button to generate 
    a random number in the specified range.
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate random number</title>
    <style>
        .label{
            display: inline-block;
            width: 160px;
        }

        body{
            background-color: #dedede;
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
    <form id="form1" runat="server">
    <div>
        <h1>Generate a random number in given range using HTML server controls</h1>
        <label for="InputTextRangeFrom" class="label">From: </label>
        <input id="InputTextRangeFrom" runat="server" type="text" /> <br />

        <label for="InputTextRangeTo" class="label">To: </label>
        <input id="InputTextRangeTo" runat="server" type="text" /><br />

        <input class="submit" type="submit" runat="server" value="Generate random number" onserverclick="GenerateBtn_Click" /><br />
        
        <label for="RandomNumber" class="label">Number: </label>
        <input id="RandomNumber" runat="server" readonly="readonly" />
    </div>
    </form>
</body>
</html>
