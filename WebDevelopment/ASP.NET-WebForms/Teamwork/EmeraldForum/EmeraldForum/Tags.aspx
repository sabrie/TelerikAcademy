<%@ Page Title="All Tags" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Tags.aspx.cs" 
    Inherits="EmeraldForum.Tags" %>

<asp:Content ID="ContentTags" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewTags" runat="server" DataKeyNames="Id"
        ItemType="EmeraldForum.Models.Tag">
        
        <LayoutTemplate>
            <h1 class="main-title">Tags</h1>
            <div id="tagsContainer">
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="singleTag">
                <asp:HyperLink ID="HyperlinkTag" runat="server" NavigateUrl='<%# "SingleTagPosts.aspx?id=" + Eval("Id") %>'>
                    <asp:Label ID="Tag" runat="server" Text='<%#: Item.Name + "(" + Item.Posts.Count + ")"%>'></asp:Label>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:DataPager ID="DataPagerMessages" runat="server" PagedControlID="ListViewTags" PageSize="10">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false"
                ShowPreviousPageButton="true" ShowLastPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true"
                ShowPreviousPageButton="false" ShowLastPageButton="true" />
        </Fields>
    </asp:DataPager>
</asp:Content>
