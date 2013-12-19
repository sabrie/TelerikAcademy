<%@ Page Title="Manage Posts" Language="C#" MasterPageFile="~/Administration/AdministrationMasterPage.Master" AutoEventWireup="true" CodeBehind="ManagePosts.aspx.cs" Inherits="EmeraldForum.Administration.ManagePosts" %>

<asp:Content ID="ManagePostsContent" ContentPlaceHolderID="AdministrationContent" runat="server">
    <h2>Manage Posts: </h2>

    <div class="all-posts">
        <asp:UpdatePanel ID="UpdatePanelManageAllPosts" runat="server" Visible="true">
            <ContentTemplate>
                <asp:GridView ID="GridViewManageAllPosts" Visible="true" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="Id"
                    PageSize="10" AllowPaging="true" AllowSorting="true"
                    ItemType="EmeraldForum.Models.Post"
                    SelectMethod="GridViewManageAllPosts_GetData"
                    CssClass="table-striped table-hover table table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="Title" SortExpression="Title">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLinkPostTitle" runat="server"
                                    NavigateUrl='<%# Eval("Id", @"~/Post?id={0}") %>'
                                    Text='<%#: Item.Title %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Posted By">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLinkUserName" runat="server"
                                    NavigateUrl='<%# Eval("User.Id", @"~/UserProfile?id={0}") %>'
                                    Text='<%#: Item.User.UserName %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PostDate" HeaderText="Posted On"
                            SortExpression="PostDate" />
                        <asp:BoundField DataField="Comments.Count" HeaderText="Comments" />
                        <asp:HyperLinkField ControlStyle-CssClass="btn" Text="Edit..." HeaderText="Action"
                            DataNavigateUrlFields="Id"
                            DataNavigateUrlFormatString="EditPost.aspx?id={0}" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
