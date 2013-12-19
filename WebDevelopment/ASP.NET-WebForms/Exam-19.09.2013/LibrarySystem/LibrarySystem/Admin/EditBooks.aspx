<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" 
    Inherits="LibrarySystem.EditBooks" %>

<asp:Content ID="ContentEditBooks" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span12">
        <h1>Edit Books</h1>
    </div>
    <div class="span12">
        <asp:GridView ID="GridViewAllBooks" runat="server"
            AutoGenerateColumns="False" DataKeyNames="BookId"
            PageSize="5" AllowPaging="true" AllowSorting="true" 
            ItemType="LibrarySystem.Models.Book" OnPageIndexChanging="GridViewAllBooks_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                    <ItemTemplate>
                        <%--<%#: Eval("Title").ToString().Substring(0, 10) %>--%>
                        <%#: Item.Title %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Author" SortExpression="Author">
                    <ItemTemplate>
                        <%#: Item.Author %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                    <ItemTemplate>
                        <%#: Item.ISBN %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Web site" SortExpression="WebSite">
                    <ItemTemplate>
                        <%#: Item.WebSite %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Category" SortExpression="Category">
                    <ItemTemplate>
                        <%#: Item.Category.Name %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonShowEditPanel" Text="Edit" runat="server" CommandName="EditBook" CommandArgument="<%#: Item.BookId %>" OnCommand="LinkButtonShowEditPanel_Command" CssClass="link-button"/>
                        <asp:LinkButton ID="LinkButtonDeleteBook" Text="Delete" runat="server" CommandName="DeleteBook" CommandArgument="<%#: Item.BookId %>" OnCommand="LinkButtonDeleteBook_Command" CssClass="link-button"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <asp:LinkButton ID="LinkButtonShowCreatePanel" Text="Create New" runat="server" CssClass="link-button" OnClick="LinkButtonShowCreatePanel_Click" />

    <asp:Panel ID="PanelCreateBook" runat="server" CssClass="panel" Visible="false">
        <h3>Create New Book</h3>
        <asp:Label Text="Title: " runat="server" AssociatedControlID="TextBoxTitle" />
        <asp:TextBox ID="TextBoxTitle" runat="server" Placeholder="Enter book title ..." Width="350px" />

        <asp:Label Text="Author(s): " runat="server" AssociatedControlID="TextBoxAuthor" />
        <asp:TextBox ID="TextBoxAuthor" runat="server" Placeholder="Enter book author / authors ..." Width="350px" />

        <asp:Label Text="ISBN: " runat="server" AssociatedControlID="TextBoxISBN" />
        <asp:TextBox ID="TextBoxISBN" runat="server" Placeholder="Enter book ISBN ..." Width="350px" />

        <asp:Label Text="Web site: " runat="server" AssociatedControlID="TextBoxWebSite" />
        <asp:TextBox ID="TextBoxWebSite" runat="server" Placeholder="Enter book web site ..." Width="350px" />

        <asp:Label Text="Description: " runat="server" AssociatedControlID="TextBoxDescription" />
        <asp:TextBox ID="TextBoxDescription" runat="server" Placeholder="Enter book description ..." TextMode="MultiLine"  Rows="15" Width="350px"/>

        <asp:Label Text="Category: " runat="server" AssociatedControlID="DropDownListCategories" />
        <asp:DropDownList ID="DropDownListCategories" runat="server" 
            DataTextField="Name" DataValueField="Name" Width="350px" >
        </asp:DropDownList>
        <br />
        <asp:LinkButton ID="LinkButtonCreateBook" Text="Create" runat="server" CssClass="link-button" OnClick="LinkButtonCreateBook_Click" />
        <asp:LinkButton ID="LinkButtonCancelCreating" Text="Cancel" runat="server" CssClass="link-button" OnClick="LinkButtonCancelCreating_Click" />
    </asp:Panel>

    <asp:Panel ID="PanelEditBook" runat="server" CssClass="panel" Visible="false">
        <h3>Edit Book</h3>
        <asp:Label Text="Title: " runat="server" AssociatedControlID="TextBoxEditedTitle" />
        <asp:TextBox ID="TextBoxEditedTitle" runat="server" Width="350px" />

        <asp:Label Text="Author(s): " runat="server" AssociatedControlID="TextBoxEditedAuthor" />
        <asp:TextBox ID="TextBoxEditedAuthor" runat="server" Width="350px" />

        <asp:Label Text="ISBN: " runat="server" AssociatedControlID="TextBoxEditedISBN" />
        <asp:TextBox ID="TextBoxEditedISBN" runat="server" Width="350px" />

        <asp:Label Text="Web site: " runat="server" AssociatedControlID="TextBoxEditedWebSite" />
        <asp:TextBox ID="TextBoxEditedWebSite" runat="server" Width="350px" />

        <asp:Label Text="Description: " runat="server" AssociatedControlID="TextBoxEditedDescription" />
        <asp:TextBox ID="TextBoxEditedDescription" runat="server" TextMode="MultiLine"  Rows="15" Width="350px"/>

        <asp:Label Text="Category: " runat="server" AssociatedControlID="DropDownListCategories" />
        <asp:DropDownList ID="DropDownListEditedCategories" runat="server" 
            DataTextField="Name" DataValueField="Name" Width="350px" >
        </asp:DropDownList>
        <br />
        <asp:LinkButton ID="LinkButtonEditBook" Text="Save" runat="server" CssClass="link-button" OnClick="LinkButtonEditBook_Click" />
        <asp:LinkButton ID="LinkButtonCancelEditing" Text="Cancel" runat="server" CssClass="link-button" OnClick="LinkButtonCancelEditing_Click" />
    </asp:Panel>

    <asp:Label ID="HiddenField" runat="server" Visible="false"/>

    <div class="back-link">
        <asp:HyperLink ID="HyperLinkBackToBooks" NavigateUrl="~/" runat="server" Text="Back to books" />
    </div>
</asp:Content>
