<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="BannedUserPage.aspx.cs" 
    Inherits="EmeraldForum.BannedUserPage" %>

<asp:Content ID="ContentBannedUserPage" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server">
        <asp:Label ID="LabelBannedUser" Text="You are banned! You can only browse posts but you are not allowed to create and comment posts!" runat="server" ForeColor="Red"/>
    </asp:Panel>
</asp:Content>
