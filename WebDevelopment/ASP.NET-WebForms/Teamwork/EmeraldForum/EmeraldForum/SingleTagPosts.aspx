<%@ Page Title="Single Tag Posts" Language="C#" MasterPageFile="~/Site.Master"
     AutoEventWireup="true" CodeBehind="SingleTagPosts.aspx.cs" 
    Inherits="EmeraldForum.SingleTagPosts" %>

<asp:Content ID="ContentSingleTagPosts" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:ListView ID="ListViewSingleTagPosts" runat="server" DataKeyNames="Id"
        ItemType="EmeraldForum.Models.Post">
        
        <LayoutTemplate>
            <h1>Posts</h1>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>
        
        <ItemTemplate>
            <div>
                <h3>
                    <asp:HyperLink ID="HyperlinkTag" runat="server" NavigateUrl='<%#: "Post.aspx?id=" + Eval("Id") %>'>
                                <asp:Label ID="PostTitle" runat="server" Text='<%#: Eval("Title")%>'></asp:Label>
                            </asp:HyperLink>
                </h3>
                <asp:Label ID="LabelCreatedBy" runat="server">Created by <%# Item.User.UserName %></asp:Label>                
                <asp:Label ID="LablePostDateCreated" runat="server"> on <%# string.Format("{0:dd.MM.yyyy}", Item.PostDate) %></asp:Label>
            </div>
        </ItemTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
    </asp:ListView>


    <asp:DataPager ID="DataPagerSingleTagPosts" runat="server" PagedControlID="ListViewSingleTagPosts" PageSize="2">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false"
                ShowPreviousPageButton="true" ShowLastPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true"
                ShowPreviousPageButton="false" ShowLastPageButton="true" />
        </Fields>
    </asp:DataPager>
</asp:Content>
