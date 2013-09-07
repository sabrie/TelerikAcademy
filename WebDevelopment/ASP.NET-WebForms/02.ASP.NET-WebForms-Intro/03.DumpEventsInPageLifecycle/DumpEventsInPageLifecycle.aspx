<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DumpEventsInPageLifecycle.aspx.cs" Inherits="_03.DumpEventsInPageLifecycle.DumpEventsInLifecycle" %>

<%--
    Task 3
    -------

    Dump all the events in the page execution lifecycle using appropriate 
    methods or event handlers.
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dump all events</title>
    <style>
        #task-description{
            background-color: #dedede;
            border-radius: 6px;
            padding: 10px;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="DumpEventsInLifecycle" runat="server">
        <div id="task-description">
            <h3>Task 3</h3>
            <p>
                Dump all the events in the page execution lifecycle using appropriate methods or event handlers.
            </p>
            <p>
                P.S. <br />
                After you start the .aspx file a "WebAppLog.log" file will be created in the project folder holding <br />
                the events in the page execution lifecycle. <br />
                System.Diagnostics.Trace is used in Global.asax and some changes to the web.config file are required (see system.diagnostics).
            </p>
        </div>
    </form>
</body>
</html>
