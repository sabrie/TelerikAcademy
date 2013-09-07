<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsRegistrationWebForm.aspx.cs" Inherits="_04.StudentsRegistrationWebForm.StudentsRegistrationWebForm" %>

<%--
    Task 4
    --------
    
    Make a simple Web form for registration of students and courses. The form should accept 
    first name, last name, faculty number, university (drop-down list), specialty (drop-down list) 
    and a list of courses (multi-select list) and display them on submit. Use the appropriate Web server controls.
    After submission you should display summary of the entered information as formatted HTML. 
    Use dynamically generated tags (<h1>, <p>, …).
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration form</title>
    <style>
        body{
            background-color: #dedede;
            font-weight: bold;
        }
        .label{
            display: inline-block;
            width: 130px;
        }

        .dropdown-list, .textbox {
            width: 155px;
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
    <form id="form1" runat="server">
    <div>
        <h3>Students registration form</h3>

        <asp:Label ID="LabelFirstName" runat="server" CssClass="label">First Name: </asp:Label>
        <asp:TextBox ID="TextBoxFirstName" runat="server" CssClass="textbox" /><br />
        
        <asp:Label ID="LabelLastName" runat="server" CssClass="label">Last Name: </asp:Label>
        <asp:TextBox ID="TextBoxLastName" runat="server" CssClass="textbox" /><br />
        
        <asp:Label ID="LabelFacultyNumber" runat="server" CssClass="label">Faculty Number: </asp:Label>        
        <asp:TextBox ID="TextBoxFacultyNumber" runat="server" CssClass="textbox" /><br />
        
        <asp:Label ID="LabelUniversities" runat="server" CssClass="label">Universities: </asp:Label>        
        <asp:DropDownList ID="DropDownListUniversities"
                    AutoPostBack="False"
                    OnSelectedIndexChanged="DropDownListTransport_SelectedIndexChanged"
                    runat="server"
                    CssClass="dropdown-list">

                  <asp:ListItem Selected="True" Value="Telerik University"> Telerik University </asp:ListItem>
                  <asp:ListItem> Sofia University </asp:ListItem>
                  <asp:ListItem> UNSS </asp:ListItem>
                  <asp:ListItem> TU </asp:ListItem>
       </asp:DropDownList><br />
        
        <asp:Label ID="LabelCourses" runat="server" CssClass="label">Courses: </asp:Label>        
        <asp:CheckBoxList ID="CkeckBoxListCourses" runat="server">
            <asp:ListItem>C# Programming</asp:ListItem>
            <asp:ListItem>JS Programming</asp:ListItem>
            <asp:ListItem>Databases</asp:ListItem>
            <asp:ListItem>HTML</asp:ListItem>
            <asp:ListItem>CSS</asp:ListItem>
        </asp:CheckBoxList>

        <asp:Button ID="ButtonSubmit" runat="server"
                        Text="Generate Student's Data" onclick="ButtonSubmit_Click" /><br />           
    </div>
    </form>
</body>
</html>
