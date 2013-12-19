<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs"
    Inherits="LibrarySystem.Categories" %>

<asp:Content ID="ContentCategories" ContentPlaceHolderID="MainContent" runat="server">

    <div class="span12">
        <h1>Edit Categories</h1>
    </div>
    <div class="span12">
        <asp:GridView ID="GridViewAllCategories" runat="server"
            AutoGenerateColumns="False" DataKeyNames="CategoryId"
            PageSize="5" AllowPaging="true" AllowSorting="true" 
            ItemType="LibrarySystem.Models.Category" OnPageIndexChanging="GridViewAllCategories_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Category Name" SortExpression="Name">
                    <ItemTemplate>
                        <%#: Item.Name %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonShowEditPanel" Text="Edit" runat="server" CommandName="EditCategory" CommandArgument="<%#: Item.CategoryId %>" OnCommand="LinkButtonShowEditPanel_Command" CssClass="link-button"/>
                        <asp:LinkButton ID="LinkButtonDeleteCategory" Text="Delete" runat="server" CommandName="DeleteCategory" CommandArgument="<%#: Item.CategoryId %>" OnCommand="LinkButtonDeleteCategory_Command" CssClass="link-button"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <asp:LinkButton ID="LinkButtonShowCreatePanel" Text="Create New" runat="server" CssClass="link-button" OnClick="LinkButtonShowCreatePanel_Click" />

    <asp:Panel ID="PanelCreateCategory" runat="server" CssClass="panel" Visible="false">
        <h3>Create New Category</h3>
        <asp:Label Text="Category: " runat="server" AssociatedControlID="TextBoxCategoryName" />
        <asp:TextBox ID="TextBoxCategoryName" runat="server" Placeholder="Enter category name..." />

        <asp:LinkButton ID="LinkButtonCreateCategory" Text="Create" runat="server" CssClass="link-button" OnClick="LinkButtonCreateCategory_Click" />
        <asp:LinkButton ID="LinkButtonCancelCreating" Text="Cancel" runat="server" CssClass="link-button" OnClick="LinkButtonCancelCreating_Click" />
    </asp:Panel>

    <asp:Panel ID="PanelEditCategory" runat="server" CssClass="panel" Visible="false">
        <h3>Edit Category</h3>
        <asp:Label Text="Category: " runat="server" AssociatedControlID="TextBoxCategoryName" />
        <asp:TextBox ID="TextBoxEditedCategoryName" runat="server" />

        <asp:LinkButton ID="LinkButtonEditCategory" Text="Save" runat="server" CssClass="link-button" OnClick="LinkButtonEditCategory_Click" />
        <asp:LinkButton ID="LinkButtonCancelEditing" Text="Cancel" runat="server" CssClass="link-button" OnClick="LinkButtonCancelEditing_Click" />
    </asp:Panel>

    <asp:Label ID="HiddenField" runat="server" Visible="false"/>

    <div class="back-link">
        <asp:HyperLink ID="HyperLinkBackToBooks" NavigateUrl="~/" runat="server" Text="Back to books" />
    </div>
</asp:Content>
