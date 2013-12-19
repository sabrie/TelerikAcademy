<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs"
    Inherits="EmeraldForum.UserPosts" %>

<asp:Content ID="ContentUserPosts" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="ListViewUser" runat="server" DataKeyNames="Id"
        ItemType="EmeraldForum.Models.ForumUser">
        <LayoutTemplate>
            <h1 class="main-title">User Profile</h1>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <asp:Image ImageUrl="<%#: Item.PhotoPath %>" runat="server" Width="120px" Height="120px" />
            </div>
            <br />
            <ul class="unstyled">
                <li><strong>Username: </strong><%#: Item.UserName %></li>
                <li><strong>Email: </strong><%#: Item.Email %></li>
            </ul>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
    </asp:ListView>

    <hr />

    <asp:ListView ID="ListViewUserPosts" runat="server" DataKeyNames="Id"
        ItemType="EmeraldForum.Models.Post">

        <LayoutTemplate>
            <h2 id="user-posts">Posts</h2>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>

        <ItemTemplate>
            <div>
                <h4>
                    <asp:HyperLink ID="HyperlinkTag" runat="server" NavigateUrl='<%# "Post.aspx?id=" + Eval("Id") %>'>
                        <asp:Label ID="PostTitle" runat="server" Text='<%#: Eval("Title")%>'></asp:Label>
                    </asp:HyperLink>
                </h4>
                <asp:Label ID="LabelTags" runat="server">Tags:</asp:Label>
                <asp:Repeater runat="server"
                    ItemType="EmeraldForum.Models.Tag"
                    DataSource="<%# Item.Tags %>">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperlinkTag" runat="server" NavigateUrl='<%# "SingleTagPosts.aspx?id=" + Eval("Id") %>'>
                            <asp:Label ID="Name" runat="server" Text='<%#: Eval("Name")%>'></asp:Label>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <asp:Label ID="LablePostDateCreated" runat="server">Created on: <%# string.Format("{0:dd.MM.yyyy}", Item.PostDate) %></asp:Label>
            </div>
        </ItemTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>

        <EmptyDataTemplate>
            <p class="no-data">User has no posts yet</p>
        </EmptyDataTemplate>
    </asp:ListView>


    <asp:DataPager ID="DataPagerMessages" runat="server" PagedControlID="ListViewUserPosts" PageSize="2">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false"
                ShowPreviousPageButton="true" ShowLastPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true"
                ShowPreviousPageButton="false" ShowLastPageButton="true" />
        </Fields>
    </asp:DataPager>

</asp:Content>
