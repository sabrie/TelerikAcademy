<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebChat.aspx.cs" Inherits="_2.WebChat.WebChat" %>

<!DOCTYPE html>

<%--
    Task 2
    ---------
    
    Using Timer and UpdatePanel implement very simple Web-based chat application. Use a single database 
    table Messages holding all chat messages. All users should see in a ListView the last 100 lines of the Messages 
    table. Users can send new messages at any time and should see the messages posted by the others at interval of 500 milliseconds.
    
    --%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web chat</title>
    <style type="text/css">
        .red {
            color: #ff0000;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="FormWebChat" runat="server">
        <asp:ScriptManager ID="ScriptManagerMain" runat="server" />
        <asp:Label ID="LabelDateTimeWhenStarted" runat="server" CssClass="red">When the application is started: <%= string.Format("{0:dd.MM.yyyy HH:mm:ss}", DateTime.Now )%></asp:Label>
        <h1>Web chat</h1>
        Username:
        <asp:TextBox ID="TextBoxUsername" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="TextBoxUsername" Display="Dynamic"
            ErrorMessage="The username is required." CssClass="error" />
        <br />
        Message:
        <asp:TextBox ID="TextBoxMessage" runat="server" EnableViewState="false" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" ControlToValidate="TextBoxMessage" Display="Dynamic"
            ErrorMessage="The message is required." CssClass="error" />
        
        <asp:UpdatePanel ID="UpdatePanelNewMessage" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:Button ID="ButtonSendMessage" runat="server" Text="Send" OnClick="ButtonSendMessage_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ListViewMessages" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:Timer ID="TimerMessages" runat="server" Interval="5000" OnTick="TimerMessages_Tick" />
        <asp:UpdatePanel ID="UpdatePanelMessages" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <h2>Messages</h2>
                <asp:ListView ID="ListViewMessages" runat="server"
                    ItemType="_2.WebChat.Models.Message" SelectMethod="ListViewMessages_GetData"
                    DataKeyNames="Id">
                    <LayoutTemplate>
                        <span runat="server" id="itemPlaceholder" />
                        <asp:DataPager ID="DataPagerMessages" runat="server" PageSize="5">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false"
                                    ShowPreviousPageButton="true" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true"
                                    ShowPreviousPageButton="false" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                        
                    </LayoutTemplate>

                    <ItemTemplate>
                        <div>
                            <strong><%#: string.Format("[{0:dd.MM.yyyy HH:mm:ss}] {1}:", Item.CreationDate, Item.Author.Username) %></strong>
                            <%#: Item.Text %>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <br />
                <asp:Label ID="LabelDateTime" runat="server" CssClass="red">When the "Messages" panel is last updated: <%= DateTime.Now %></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerMessages" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        
    </form>
</body>
</html>
