<%@ Page Title="Search for Posts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="EmeraldForum.Search" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <fieldset class="form-vertical">
        <h1 class="main-title">Search for post by title</h1>
        <div class="control-group" id="search-controls-container">
            <asp:Label ID="LabelSearchText" runat="server" AssociatedControlID="TextBoxSearchText" CssClass="control-label">Search text: </asp:Label>
            <div class="search-panel">
                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server"
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="TextBoxSearchText" />
                        </div>
                        <div>
                            <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="btn" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="TextBoxSearchText"
                    CssClass="text-error" ErrorMessage="The search text field is required." />
            </div>
        </div>
    </fieldset>

    <asp:UpdateProgress runat="server" ID="UpdateProgressPosts" ClientIDMode="Static">
        <ProgressTemplate>
            Retrieving posts, please wait...
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanelResults" runat="server" Visible="true">
        <ContentTemplate>
            <asp:GridView ID="GridViewResults" Visible="true" runat="server"
                AutoGenerateColumns="False" DataKeyNames="Id"
                PageSize="3" AllowPaging="true" AllowSorting="true"
                ItemType="EmeraldForum.Models.Post"
                SelectMethod="GridViewResults_GetData"
                CssClass="table-striped table-hover table table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLinkPostTitle" runat="server"
                                NavigateUrl='<%# Eval("Id", @"Post?id={0}") %>'
                                Text='<%#: Item.Title %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Posted By" SortExpression="User.UserName">
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
</asp:Content>
