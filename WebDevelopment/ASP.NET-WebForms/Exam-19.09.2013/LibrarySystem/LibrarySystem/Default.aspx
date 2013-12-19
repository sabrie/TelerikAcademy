<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Books</h1>
    <asp:Label Text="Search: " runat="server"  AssociatedControlID="TextBoxSearch"/>
    <asp:TextBox ID="TextBoxSearch" runat="server" />
    <div class="row">
        <asp:Repeater runat="server" ItemType="LibrarySystem.Models.Category" ID="RepeaterCategories">
            <ItemTemplate>
                <div class="span4">
                    <asp:Label runat="server" CssClass="single-category">
                        <h2>
                            <%#:Item.Name %>
                        </h2>
                        <ul>
                            <asp:Repeater runat="server" DataSource="<%#Item.Books %>" ItemType="LibrarySystem.Models.Book">
                                <ItemTemplate>
                                    <li>
                                        <asp:LinkButton runat="server" ID="LinkButtonSingleBook" CommandName="GoToSingeBook"
                                            CommandArgument="<%#:Item.BookId %>" Text='<%# Eval("Title") + " by " + Eval("Author") %>' OnCommand="LinkButtonSingleBook_Command"
                                            CssClass="single-book"
                                            ToolTip="Got to book details" />
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </asp:Label>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
