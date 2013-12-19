<%@ Page Title="Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="EmeraldForum.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="clear">
        <div class="left" id="post-creator-info">
            <div id="divPostDate" runat="server"></div>
            <asp:Image ID="imgCreatorPhoto" Width="120px" Height="120px" runat="server" />
            <strong>
                <div id="divPostCreatorName" runat="server"></div>
            </strong>
        </div>
        <div class="left" id="post-title-container">
            <h2 id="headerPostTitle" runat="server"></h2>

        </div>
    </div>

    <div id="divPostContent" runat="server"></div>

    <div id="post-tags">
        <strong>Tags: </strong>
        <asp:ListView ID="ListViewTags" ItemType="EmeraldForum.Models.Tag" runat="server">
            <ItemTemplate>
                <asp:HyperLink Text="<%#: Item.Name%>" NavigateUrl='<%# "SingleTagPosts.aspx?id=" + Eval("Id") %>' runat="server" />
            </ItemTemplate>
        </asp:ListView>
    </div>

    <h3>Comments:</h3>
    <asp:ListView ID="ListViewComments" runat="server" ItemType="EmeraldForum.Models.Comment">
        <LayoutTemplate>
            <div id="commentsContainer">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>

        <EmptyDataTemplate>
            Be the first to comment this post.
            <br />
        </EmptyDataTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>

        <ItemTemplate>
            <div class="clear">
                <div class="left post-comment-creator">
                    <div class="commentDate"><%#: Item.Date %></div>
                    <asp:Image ImageUrl="<%#: Item.User.PhotoPath %>" Width="50px" Height="50px" runat="server" />
                    <div class="commentCreator"><strong><%#: Item.User.UserName %></strong></div>
                </div>
                <div class="left post-comment-content">
                    <div class="commentText"><%#: Item.Text %></div>

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

    <br />
    <br />
    <div runat="server" id="AddCommentContainer">
        <asp:Label Text="Your comment: " AssociatedControlID="TextBoxComment" runat="server" />
        <asp:TextBox ID="TextBoxComment" runat="server" TextMode="MultiLine" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxComment" ValidationGroup="AddComment"
            ErrorMessage="Comment cannot be empty!" Display="Dynamic" />
        <br />
        <asp:Button Text="Comment" ID="ButtonComment" OnClick="ButtonComment_Click" CssClass="btn" runat="server"
            ValidationGroup="AddComment" />
    </div>

    <br />
</asp:Content>
