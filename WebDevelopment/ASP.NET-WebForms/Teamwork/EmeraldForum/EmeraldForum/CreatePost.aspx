<%@ Page Title="Create Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="EmeraldForum.CreatePost" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="main-title">Create post</h2>
    <asp:Label Text="Title: " AssociatedControlID="TextBoxPostTitle" runat="server" />
    <asp:TextBox ID="TextBoxPostTitle" runat="server" CssClass="create-post-input" />

    <asp:Label Text="Content:" AssociatedControlID="TextBoxPostContent" runat="server" />
    <asp:TextBox ID="TextBoxPostContent" TextMode="MultiLine" runat="server" Rows="5"
        CssClass="create-post-input"/>

    <asp:Label Text="Tags:" AssociatedControlID="TextBoxPostTags" runat="server" />
    <asp:TextBox ID="TextBoxPostTags" runat="server" CssClass="create-post-input"/>
    <br />
    <span class="info-box">(Separate tags with empty space between. Max 8 tags.)
    </span>
    <br />
    <asp:Button ID="ButtonCreatePost" Text="Create" OnClick="ButtonCreatePost_Click" CssClass="btn" runat="server" />
</asp:Content>
