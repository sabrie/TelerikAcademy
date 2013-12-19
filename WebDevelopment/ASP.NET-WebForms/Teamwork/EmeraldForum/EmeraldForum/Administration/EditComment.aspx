<%@ Page Title="Edit comment" Language="C#" MasterPageFile="~/Administration/AdministrationMasterPage.master"
    AutoEventWireup="true" CodeBehind="EditComment.aspx.cs" Inherits="EmeraldForum.Administration.EditComment" %>

<asp:Content ID="ContentEditComment" ContentPlaceHolderID="AdministrationContent" runat="server">
    <h2 class="main-title">Edit comment</h2>

    <strong>Post title:
        <asp:Label ID="LabelPostTitle" runat="server" /></strong><br />

    <asp:Label Text="Content:" AssociatedControlID="TextBoxEditableCommentContent" runat="server" />
    <asp:TextBox ID="TextBoxEditableCommentContent" TextMode="MultiLine" runat="server" Columns="120" Rows="10"
        CssClass="create-post-input" />
    <asp:Button ID="ButtonEditComment" Text="Edit" OnClick="ButtonEditComment_Click" CssClass="btn" runat="server"
        ValidationGroup="EditComment" />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEditableCommentContent" Display="Dynamic"
        ValidationGroup="EditComment" ErrorMessage="Comment content cannot be empty!" />
</asp:Content>
