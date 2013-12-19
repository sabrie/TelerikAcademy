<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/Administration/AdministrationMasterPage.master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="EmeraldForum.Administration.EditUser" %>

<asp:Content ID="ContentEditUser" ContentPlaceHolderID="AdministrationContent" runat="server">

    <h2>Edit user</h2>
    <div class="clear">
        <div class="left" id="edit-user-options">
            <asp:Image runat="server" ID="ImageUser" Width="125" Height="125" />
            <br />
            <asp:Label runat="server" ID="LabelStatus" CssClass="edit-user-status" Visible="false" />
            <br />
            <asp:LinkButton runat="server" ID="LinkButtonBan" CssClass="btn btn-primary btn-medium" Text="Ban user"
                CommandName="BanUser" OnCommand="LinkButtonBan_Command" ClientIDMode="Static" />
            <br />
            <asp:LinkButton runat="server" ID="LinkButtonUnban" CssClass="btn btn-primary btn-medium" Text="Unban user"
                CommandName="UnbanUser" OnCommand="LinkButtonUnban_Command" ClientIDMode="Static" />
        </div>
        <div class="left" id="edit-user-fields">
            <h3 id="edit-user-username">
                <asp:Label runat="server" ID="LabelUsername" /> (<asp:Label runat="server" ID="LabelUserRole" />)
            </h3>
            <%-- Change profile picture --%>
            <h3 class="border-bottom-dot">Change Profile Picture</h3>
            <div class="control-group">
                <div class="controls">
                    <asp:Label runat="server" ID="LabelUploadPhoto" AssociatedControlID="FileUploadPhoto" CssClass="control-label">Choose photo</asp:Label>
                    <asp:FileUpload runat="server" ID="FileUploadPhoto" />
                    <asp:RegularExpressionValidator runat="server" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG)$"
                        ErrorMessage="Only PNG and JPG images are allowed!" ControlToValidate="FileUploadPhoto" />
                </div>
            </div>
            <div class="form-actions no-color">
                <asp:Button runat="server" Text="Upload" OnClick="ButtonUploadPhoto_Click" CssClass="btn" ID="ButtonUploadPhoto" />
            </div>
            <hr />
            <%-- Change email --%>
            <h3 class="border-bottom-dot">Change Email Address</h3>
            <div class="control-group">
                <div class="controls" id="current-email">
                    Current email: <strong>
                        <asp:Label runat="server" ID="LabelCurrentEmail" /></strong>
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
            <hr />
            <%-- Change role--%>
            <h3 class="border-bottom-dot">Change User Role</h3>
            <div class="control-group">
                <div class="controls">
                    <asp:DropDownList runat="server" ID="DropDownListRoles" DataTextField="Name" DataValueField="Id" />
                </div>
            </div>
            <div class="form-actions no-color">
                <asp:Button runat="server" Text="Change" OnClick="ButtonChangeRole_Click" CssClass="btn" ID="ButtonChangeRole" />
            </div>
        </div>
    </div>

</asp:Content>
