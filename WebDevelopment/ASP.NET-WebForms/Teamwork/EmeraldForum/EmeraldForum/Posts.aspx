<%@ Page Title="All Posts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="EmeraldForum.AllPosts" %>

<asp:Content ID="AllPostsContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>All Posts: </h1>
    <div class="all-posts">
        <asp:UpdatePanel ID="UpdatePanelAllPosts" runat="server" Visible="true">
            <ContentTemplate>
                <asp:GridView ID="GridViewAllPosts" Visible="true" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="Id"
                    PageSize="10" AllowPaging="true" AllowSorting="true"
                    ItemType="EmeraldForum.Models.Post"
                    SelectMethod="GridViewAllPosts_GetData"
                    CssClass="table-striped table-hover table table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="Title" SortExpression="Title">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLinkPostTitle" runat="server"
                                    NavigateUrl='<%# Eval("Id", @"Post?id={0}") %>'
                                    Text='<%#: Item.Title %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Posted By">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLinkUserName" runat="server"
                                    NavigateUrl='<%# Eval("User.Id", @"UserProfile?id={0}") %>'
                                    Text='<%#: Item.User.UserName %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PostDate" HeaderText="Posted On"
                            SortExpression="PostDate" />
                        <asp:BoundField DataField="Comments.Count" HeaderText="Comments" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
