<%@ Page Title="Edit Tags" Language="C#" MasterPageFile="~/Administration/AdministrationMasterPage.master" AutoEventWireup="true" CodeBehind="EditPostTags.aspx.cs" Inherits="EmeraldForum.Administration.EditPostTags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdministrationContent" runat="server">
    <h2>Edit the Tags of <asp:HyperLink NavigateUrl='<%#:"~/Post.aspx?id=" + postId %>' ForeColor="#0094ff" runat="server">"<%#: postTitle %>"</asp:HyperLink></h2>

    <asp:GridView
        ID="GridViewTags" 
        ItemType="EmeraldForum.Models.Tag"
        AutoGenerateColumns="false" 
        OnRowDeleting="GridViewTags_RowDeleting"
        DataKeyNames="Id"
        runat="server" CssClass="table-striped table-hover table table-bordered">
        <Columns>
            <asp:BoundField 
                DataField="Name"
                HeaderText="Tag Name" />

            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkdel" runat="server" Text="Delete" CssClass="btn" CommandName="Delete"></asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />
    <asp:Label Text="Add Tags:" AssociatedControlID="TextBoxPostTags" runat="server" />
    <asp:TextBox ID="TextBoxPostTags" runat="server" CssClass="create-post-input"/>
    <br />
    <span class="info-box">(Separate tags with empty space between) </span>
    <br />
    <asp:Button ID="ButtonAddTags" Text="Add Tags" OnClick="ButtonAddTags_Click" CssClass="btn" runat="server" />
</asp:Content>
