<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmeraldForum._Default" %>

<%@ Register Src="~/Controls/PostViewer/PostsViewer.ascx" TagPrefix="emerald" TagName="PostView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-unit">
        <asp:Label ID="LabelBannedUser" Text="You are banned! You can only browse posts but you are not allowed to create and comment posts!" runat="server" ForeColor="Red" Visible="false" />
        <h1 class="main-title" id="home-title">Latest posts</h1>

        <emerald:PostView runat="server" ID="PostsViewer" />
    </div>
</asp:Content>
