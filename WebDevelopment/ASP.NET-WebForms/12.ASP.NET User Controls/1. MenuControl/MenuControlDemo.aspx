﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuControlDemo.aspx.cs" Inherits="_1.MenuControl.MenuControlDemo" %>

<%@ Register Src="~/Controls/MenuControl/MenuControl.ascx" TagPrefix="custom" TagName="MenuControl" %>

<!DOCTYPE html>

<%--
    Task 1
    --------

    Create a user control that visualizes a menu of links. The control should have a property to initialize 
    the menu links (a list of items, each containing a title and URL). Use DataList and data binding to 
    visualize the menu links. Implement a property to change the font and the font color. 
    Don’t use the Menu control!
    
    --%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu Control Demo</title>
</head>
<body>
    <form id="FormMenuControlDemo" runat="server">
        <custom:MenuControl runat="server" ID="MenuControlMain" FontColor="#00ff00" FontName="Segoe UI" RepeatDirection="Horizontal" />
    </form>
</body>
</html>
