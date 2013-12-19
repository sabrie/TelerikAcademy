﻿<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="EmeraldForum.Account.Manage" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1 class="main-title"><%: Title %>.</h1>
    </hgroup>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="text-error" />
    </div>

    <div class="row-fluid">
        <div class="span6">
            <section id="passwordForm">
                <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                    <p>
                        You do not have a local password for this site. Add a local
                        password so you can log in without an external login.
                    </p>
                    <fieldset class="form-horizontal">
                        <legend>Set Password Form</legend>
                        <div class="control-group">
                            <asp:Label runat="server" AssociatedControlID="password" CssClass="control-label">Password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                    CssClass="text-error" ErrorMessage="The password field is required."
                                    Display="Dynamic" ValidationGroup="SetPassword" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                    CssClass="text-error" SetFocusOnError="true" />
                            </div>
                        </div>

                        <div class="control-group">
                            <asp:Label runat="server" AssociatedControlID="confirmPassword" CssClass="control-label">Confirm password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                    CssClass="text-error" Display="Dynamic" ErrorMessage="The confirm password field is required."
                                    ValidationGroup="SetPassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                    CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match."
                                    ValidationGroup="SetPassword" />

                            </div>
                        </div>

                        <div class="form-actions no-color">
                            <asp:Button runat="server" Text="Set Password" ValidationGroup="SetPassword" OnClick="SetPassword_Click" CssClass="btn" />
                        </div>
                    </fieldset>
                </asp:PlaceHolder>

                <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false">
                    <h2>Hello, <span runat="server" id="CurrentUser"></span>!</h2>
                    <div class="clear" id="current-user-info">
                        <div class="left" id="user-profile-picture">
                            <asp:Image runat="server" ID="ImageProfilePicture" />
                        </div>
                        <div class="left" id="user-manage-account">
                            <p id="manage-profile-info">
                                Here you can change account information:
                            </p>
                            <ul>
                                <li>Change profile picture</li>
                                <li>Change password</li>
                                <li>Change emial address</li>
                            </ul>
                        </div>
                    </div>
                    <%-- Change profile picture --%>
                    <fieldset class="form-horizontal">
                        <legend>Change Profile Picture</legend>
                        <div class="control-group">
                            <asp:Label runat="server" ID="LabelUploadPhoto" AssociatedControlID="FileUploadPhoto" CssClass="control-label">Choose photo</asp:Label>
                            <div class="controls">
                                <asp:FileUpload runat="server" ID="FileUploadPhoto" />
                                <asp:RegularExpressionValidator runat="server" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG)$"
                                    ErrorMessage="Only PNG and JPG images are allowed!" ControlToValidate="FileUploadPhoto" />
                            </div>
                        </div>
                        <div class="form-actions no-color">
                            <asp:Button runat="server" Text="Upload" OnClick="ButtonUploadPhoto_Click" CssClass="btn" ID="ButtonUploadPhoto" />
                        </div>
                    </fieldset>
                    <%-- Change password --%>
                    <fieldset class="form-horizontal">
                        <legend>Change Password Form</legend>
                        <div class="control-group">
                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="control-label">Current password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="text-error" ErrorMessage="The current password field is required."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="control-label">New password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                    CssClass="text-error" ErrorMessage="The new password is required."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="control-label">Confirm new password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-error" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-error" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-actions no-color">
                            <asp:Button runat="server" Text="Change password" OnClick="ChangePassword_Click" CssClass="btn" ValidationGroup="ChangePassword" />
                        </div>
                    </fieldset>
                    <%-- Change email --%>
                    <fieldset class="form-horizontal">
                        <legend>Change Email Address</legend>
                        <div class="control-group">
                            <div class="controls" id="current-email">
                                Current email: <strong><asp:Label runat="server" ID="LabelCurrentEmail" /></strong>
                            </div>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="TextBoxEmail" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail"
                                    CssClass="text-error" Display="Dynamic" ErrorMessage="The email field is required."
                                    ValidationGroup="ValidateEmail" />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxEmail"
                                    CssClass="text-error" Display="Dynamic" ErrorMessage="Invalid email."
                                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}"
                                     ValidationGroup="ValidateEmail" />
                            </div>
                        </div>
                        <div class="form-actions no-color">
                            <asp:Button runat="server" Text="Change" OnClick="ButtonChangeEmail_Click" CssClass="btn" ID="ButtonChangeEmail"
                                 ValidationGroup="ValidateEmail" />
                        </div>
                    </fieldset>
                </asp:PlaceHolder>
            </section>

            <section id="externalLoginsForm">

                <asp:ListView runat="server"
                    ItemType="Microsoft.AspNet.Identity.IUserLogin"
                    SelectMethod="GetLogins" DeleteMethod="RemoveLogin" DataKeyNames="LoginProvider,ProviderKey">

                    <LayoutTemplate>
                        <h3>Registered Logins</h3>
                        <table class="table">
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>

                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.LoginProvider %></td>
                            <td>
                                <asp:Button runat="server" Text="Remove" CommandName="Delete" CausesValidation="false"
                                    ToolTip='<%# "Remove this " + Item.LoginProvider + " login from your account" %>'
                                    Visible="<%# CanRemoveExternalLogins %>" CssClass="btn" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

                <uc:OpenAuthProviders runat="server" ReturnUrl="~/Account/Manage" />
            </section>

        </div>
    </div>

</asp:Content>
