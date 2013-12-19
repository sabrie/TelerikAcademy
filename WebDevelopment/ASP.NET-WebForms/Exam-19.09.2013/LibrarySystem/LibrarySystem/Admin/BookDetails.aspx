<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs"
    Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="ContentBookDetails" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Book Details</h1>

    <asp:ListView ID="ListViewBookDetails" runat="server" DataKeyNames="BookId"
        ItemType="LibrarySystem.Models.Book">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <p class="book-title"><%#: Item.Title %>"</p>
            <p class="book-author">by <%#: Item.Author %>"</p>
            <p class="book-isbn">ISBN <%#: Item.ISBN %>"</p>
            <p class="book-isbn">
                Web site: 
                <a href="<%#: Item.WebSite %>"><%#: Item.WebSite %>"</a>
            </p>

            <div class="row-fluid">
                <p>
                    <%#: Item.Description %>
                </p>
            </div>        
        </ItemTemplate>
        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
    </asp:ListView>

    <asp:HyperLink ID="HyperLinkBackToBooks" NavigateUrl="~/" runat="server" Text="Back to books"/>

</asp:Content>
