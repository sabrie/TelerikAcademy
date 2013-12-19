<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Administration/AdministrationMasterPage.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="EmeraldForum.Administration.ManageUsers" %>

<asp:Content ID="ContentManageUsers" ContentPlaceHolderID="AdministrationContent" runat="server">
    <h2>Manage Users</h2>
    <%-- Search --%>
    <div id="mange-users-search">
        <h3 id="manage-users-search-title">Search users by username</h3>
        <asp:TextBox runat="server" ID="TextBoxSearchCriteria" ValidationGroup="SearchCriteria" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxSearchCriteria"
            ErrorMessage="Search criteria is required!" ValidationGroup="SearchCriteria" Display="Dynamic" />
        <br />
        <asp:Button runat="server" ID="ButtonSearch" Text="Search" OnClick="ButtonSearch_Click"
            CssClass="btn btn-primary btn-medium" ValidationGroup="SearchCriteria" />
        <br />
        <asp:Label runat="server" ID="LabelSearchedBy" Visible="false" ClientIDMode="Static" />
    </div>
    <%-- Filters --%>
    <div id="manage-users-filters">
        <asp:RadioButton runat="server" ID="RadioButtonAll" AutoPostBack="true" Checked="true" GroupName="filter"
            CssClass="filter-radio" OnCheckedChanged="CheckedChanged" />
        <asp:Label runat="server" AssociatedControlID="RadioButtonAll" Text="All" CssClass="filter-label" />

        <asp:RadioButton runat="server" ID="RadioButtonOnlyBanned" AutoPostBack="true" GroupName="filter"
            CssClass="filter-radio" OnCheckedChanged="CheckedChanged" />
        <asp:Label runat="server" AssociatedControlID="RadioButtonOnlyBanned" Text="Only banned" CssClass="filter-label" />

        <asp:RadioButton runat="server" ID="RadioButtonOnlyAdministrators" AutoPostBack="true" GroupName="filter"
            CssClass="filter-radio" OnCheckedChanged="CheckedChanged" />
        <asp:Label runat="server" AssociatedControlID="RadioButtonOnlyAdministrators" Text="Only administrators"
            CssClass="filter-label" />

        <asp:RadioButton runat="server" ID="RadioButtonOnlyUsers" AutoPostBack="true" GroupName="filter"
            CssClass="filter-radio" OnCheckedChanged="CheckedChanged" />
        <asp:Label runat="server" AssociatedControlID="RadioButtonOnlyUsers" Text="Only users" CssClass="filter-label" />
    </div>
    <asp:ListView runat="server" ID="ListViewAllUsers" ItemType="EmeraldForum.Models.ForumUser"
        SelectMethod="ListViewAllUsers_GetData" OnItemDataBound="ListViewAllUsers_ItemDataBound">

        <LayoutTemplate>
            <div runat="server" id="itemPlaceholder"></div>
            <asp:DataPager runat="server" PageSize="10">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="true" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                        ShowNextPageButton="true" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>

        <ItemTemplate>
            <div class="manage-users-single-user">
                <div class="clear">
                    <div class="left">
                        <asp:Image runat="server" Width="70" Height="70" ImageUrl="<%#:Item.PhotoPath %>" />
                    </div>
                    <div class="left users-manage-options">
                        <strong runat="server" id="Username"><%#:Item.UserName %></strong>
                        <br />
                        <asp:Label runat="server" ID="LabelStatus" />
                        <br />
                        <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-primary btn-medium" Text="Edit user"
                            CommandName="EditUser" CommandArgument="<%#:Item.Id %>" OnCommand="LinkButtonEdit_Command" />

                    </div>
                </div>
            </div>
        </ItemTemplate>

        <EmptyDataTemplate>
            No users found...
        </EmptyDataTemplate>

    </asp:ListView>
</asp:Content>
