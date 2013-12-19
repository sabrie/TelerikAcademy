<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Register.aspx.cs" Inherits="EmeraldForum.Account.Register" Async ="true"%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1 class="main-title"><%: Title %>.</h1>
    </hgroup>
    <p class="text-error">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset class="form-horizontal">
        <legend>Create a new account.</legend>
        <%-- Username --%>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="control-label">User name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="UserName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-error" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <%-- Password --%>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-error" ErrorMessage="The password field is required." />
            </div>
        </div>
        <%-- Repeat Password --%>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <%-- Email --%>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxEmail" CssClass="control-label">Email</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="TextBoxEmail" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The email field is required." />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxEmail"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="Invalid email."
                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />
            </div>
        </div>
        <%-- Photo Upload --%>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="FileUploadPhoto" CssClass="control-label">Upload Photo</asp:Label>
            <div class="controls">
                <asp:FileUpload runat="server" ID="FileUploadPhoto" />
                <asp:RegularExpressionValidator runat="server" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG)$"
                        ErrorMessage="Only PNG and JPG images are allowed!" ControlToValidate="FileUploadPhoto" />
                <br />
                <span class="info-box">
                    (If you don't upload an image - a default one will be assigned to your profile.)
                </span>
            </div>
        </div>
        <div class="form-actions no-color">
            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn" />
        </div>
    </fieldset>

</asp:Content>
