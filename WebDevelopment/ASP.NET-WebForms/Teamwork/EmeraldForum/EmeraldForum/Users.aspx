<%@ Page Title="All Users" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Users.aspx.cs" 
    Inherits="EmeraldForum.Users" %>

<asp:Content ID="ContentUsers" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:ListView ID="ListViewUsers" runat="server" DataKeyNames="Id" 
        ItemType="EmeraldForum.Models.ForumUser" >
        <LayoutTemplate>
                <h1 class="main-title">All Users</h1>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
        <ItemTemplate>
            <div>                
                <asp:Image ImageUrl="<%#: Item.PhotoPath %>" runat="server" Width="120px" Height="120px"/> 
                
                <asp:HyperLink ID="HyperlinkUser" runat="server" NavigateUrl='<%# "UserProfile.aspx?id=" + Eval("Id") %>'>
                            <asp:Label ID="Name" runat="server" Text='<%# Eval("Username")%>'></asp:Label>
                </asp:HyperLink>                    
            </div>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
    </asp:ListView>

     <asp:DataPager ID="DataPagerComments" runat="server"
                   PagedControlID="ListViewUsers" PageSize="5"
                   QueryStringField="page">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true"
                                        ShowNextPageButton="false" ShowPreviousPageButton="true" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowLastPageButton="true"
                                        ShowNextPageButton="true" ShowPreviousPageButton="false" />
        </Fields>
    </asp:DataPager>

</asp:Content>
