<%@ Page Title="Edit Post" Language="C#" MasterPageFile="~/Administration/AdministrationMasterPage.master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="EmeraldForum.Administration.EditPost" %>

<%@ Reference VirtualPath="~/Site.Master" %>

<asp:Content ID="EditPostContent" ContentPlaceHolderID="AdministrationContent" runat="server">
    <h2>Edit Post: </h2>
    <div class="post-edit">
        <div>
            <span>Posted on: <mark ID="PostDate" runat="server"></mark></span>
            <span> by: <strong runat="server" ID="PostCreatorName"></strong></span>
            <asp:Image ID="imgCreatorPhoto" Width="25px" Height="25px" runat="server" />
            <asp:HyperLink ID="HyperLinkEditUser" runat="server"
                Text='Edit User...'></asp:HyperLink>
        </div>
        <div id="post-title-container">
            <h4>Title: </h4>
            <asp:TextBox ID="TextBoxTitle" runat="server" />
        </div>
        <div>
            <h4>Content: </h4>
            <asp:TextBox ID="TextBoxPostContent" Rows="4" Columns="15" TextMode="MultiLine" runat="server" />
        </div>

        <asp:Button ID="ButtonSavePost" CssClass="btn btn-primary btn-medium" Text="Save Post" OnClick="ButtonSavePost_Click" runat="server" />

        <hr />

        <div id="post-tags">
            <strong>Tags: </strong>
            <asp:ListView ID="ListViewTags" ItemType="EmeraldForum.Models.Tag" runat="server">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLinkTag" Text="<%#: Item.Name %>"
                        NavigateUrl='<%# "~/SingleTagPosts.aspx?id=" + Eval("Id") %>'
                        runat="server" />
                </ItemTemplate>
            </asp:ListView>
        </div>
        <asp:HyperLink CssClass="btn btn-primary btn-medium" ID="HyperLinkEditTags" Text="Edit Tags..."
            runat="server" />
    </div>

    <hr />

    <h3>Comments:</h3>
    <asp:ListView ID="ListViewComments" runat="server" ItemType="EmeraldForum.Models.Comment">
        <LayoutTemplate>
            <div id="commentsContainer">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>

        <ItemTemplate>
            <hr />
        </ItemTemplate>

        <ItemTemplate>
            <div class="clear edit-comments">
                <div class="left post-comment-creator">
                    <div class="commentDate"><%#: Item.Date %></div>
                    <div class="commentCreator"><strong><%#: Item.User.UserName %></strong></div>
                </div>
                <div class="left post-comment-content">
                    <div class="commentText"><%#: Item.Text %></div>
                </div>
                <div class="edit-comment-link">
                    <asp:HyperLink ID="HyperLinkEditComment" Text="Edit Comment..." 
                        CssClass=""
                        runat="server" NavigateUrl='<%# Eval("Id", @"EditComment.aspx?id={0}") %>' />
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:DataPager ID="DataPagerComments" runat="server"
        PagedControlID="ListViewComments" PageSize="3"
        QueryStringField="page">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="true" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowLastPageButton="true"
                ShowNextPageButton="true" ShowPreviousPageButton="false" />
        </Fields>
    </asp:DataPager>
</asp:Content>
