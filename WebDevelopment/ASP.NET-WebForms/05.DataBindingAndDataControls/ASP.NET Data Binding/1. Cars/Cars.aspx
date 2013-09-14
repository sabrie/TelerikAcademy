<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="_1.Cars.Cars" %>

<!DOCTYPE html>

<%--
    Task 1
    ------------

    Create a Web form for searching for cars by producer + model + type of engine + set of extras (see www.mobile.bg). 
    Use two DropDownLists for the producer (e.g. VW, BMW, …) and for the model (A6, Corsa,…). Create a class Producer 
    hodling Name + collection of models. Bind the list of producers to the first DropDownList. The second should be 
    bound to the models of this producer. You should have a check box for each “extra” (use class Extra and bind the 
    list of extras at the server side). Implement the type of engine as a horizontal radio button selection 
    (options bound to a fixed array). On submit display all collected information in <asp:Literal>.
--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cars</title>
    <style type="text/css">
        .label {
            font-weight: bold;
        }

        #model {
            padding-left: 15px;
        }
    </style>
</head>
<body>
    <form id="Cars" runat="server">
        <span id="producer">
            <asp:Label ID="Producer" runat="server" Text="Producer: " CssClass="label" />
            <asp:DropDownList ID="DropDownListProducer" runat="server" DataTextField="Name"
                DataValueField="Name" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProducer_SelectedIndexChanged">
            </asp:DropDownList>
        </span>
        <span id="model">
            <asp:Label ID="Model" runat="server" Text="Model: " CssClass="label" />
            <asp:DropDownList ID="DropDownListModel" runat="server">
            </asp:DropDownList>
        </span>
        <div>
            <asp:Label ID="TypeOfEngine" runat="server" Text="Type of engine: " CssClass="label" />
            <asp:RadioButtonList ID="RadioButtonListTypeOfEngine" runat="server" RepeatDirection="Horizontal" />
        </div>
        <div>
            <asp:Label ID="Extras" runat="server" Text="Extras: " CssClass="label" />
            <asp:CheckBoxList runat="server" ID="CheckBoxListExtras" RepeatDirection="Vertical" DataTextField="Name" DataValueField="Id" />
        </div>
        <div>
            <asp:Button Text="Submit" runat="server" ID="ButtonSubmit" OnClick="ButtonSubmit_Click" />
        </div>
        <div>
            <asp:Literal ID="LiteralResult" runat="server" />
        </div>
    </form>
</body>
</html>
