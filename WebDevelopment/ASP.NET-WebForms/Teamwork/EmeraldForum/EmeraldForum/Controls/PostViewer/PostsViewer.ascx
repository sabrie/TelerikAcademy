<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostsViewer.ascx.cs" Inherits="EmeraldForum.Controls.PostViewer.PostView" %>

<asp:Repeater runat="server" ItemType="EmeraldForum.Models.Post" ID="RepeaterPosts">
    <ItemTemplate>
        <asp:Label runat="server" CssClass="single-post">
            <h2>
                <asp:LinkButton runat="server" Text="<%#:Item.Title %>" ID="ButtonGoToPost" CommandName="GoToPost"
                    CommandArgument="<%#:Item.Id %>" OnCommand="ButtonGoToPost_Command" CssClass="single-post-title"
                    ToolTip="<%#:Item.Title %>" />
            </h2>
            <p class="posted-by">
                <%#:string.Format("{0:hh:MM dd-mm-yyyy}", Item.PostDate) %> by 
                <asp:LinkButton runat="server" ID="GoToUserProfile" CommandArgument="<%#:Item.User.Id %>"
                    CommandName="GoToCreatorProfile" Text="<%#:Item.User.UserName %>" 
                    OnCommand="GoToUserProfile_Command"/>
            </p>
            <asp:Repeater runat="server" DataSource="<%#Item.Tags %>" ItemType="EmeraldForum.Models.Tag">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="LinkButtonSingleTagPosts" CommandName="GoToSingeTagPosts"
                        CommandArgument="<%#:Item.Id %>" Text="<%#:Item.Name %>"
                        OnCommand="LinkButtonSingleTagPosts_Command" CssClass="single-post-tag"
                        ToolTip="Get all posts with this tag" />
                </ItemTemplate>
            </asp:Repeater>
        </asp:Label>
    </ItemTemplate>
</asp:Repeater>
