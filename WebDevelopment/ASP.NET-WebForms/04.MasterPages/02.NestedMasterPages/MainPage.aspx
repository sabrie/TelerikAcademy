<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" %>

<asp:Content ID="ContentMainPage" 
    ContentPlaceHolderID="ContentPlaceHolderPageContent" runat="server">

    <h2>Our offices all over the world</h2>
    <div id="mainPageContent">
        <asp:HyperLink runat="server" NavigateUrl="~/Bulgaria/BulgariaHome.aspx" 
            Text="Bulgaria" CssClass="country"/>
        <asp:HyperLink runat="server" NavigateUrl="~/France/FranceHome.aspx"
             Text="France" CssClass="country"/>
        <asp:HyperLink runat="server" NavigateUrl="~/USA/UsaHome.aspx"
            Text="USA" CssClass="country"/>
    </div>
</asp:Content>
