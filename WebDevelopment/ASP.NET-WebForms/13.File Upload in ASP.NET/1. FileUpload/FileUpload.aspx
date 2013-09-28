<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="_1.FileUpload.FileUpload" %>

<!DOCTYPE html>

<%--
    Task
    ------

    Create a Web Forms upload page using Kendo UI for archive with text files. 
    The upload must work only with .zip file extension. You should not write the 
    zip file into the server file system. Save the file to the memory and using 
    external library, extract the text files and save their content into the database. 
    The text files should not be saved to the file system either.
    
    --%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload</title>
    <link href="Styles/kendo.common.min.css" rel="stylesheet" />
    <link href="Styles/kendo.metro.min.css" rel="stylesheet" />

    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/kendo.web.min.js"></script>
</head>
<body>
    <p>You can find a file named <strong>files.zip</strong> in the solution folder. Try to upload it.</p>
    <p>If uploading goes on successfully and you see the green strip, open the local database (see App_Data folder) to view the files content</p>

    <input name="fileUpload" id="fileUpload" type="file" />
    
    <script>
        $(document).ready(function () {
            $("#fileUpload").kendoUpload({
                async: {
                    saveUrl: "Upload.aspx",
                    removeUrl: "Remove.aspx",
                    autoUpload: true,
                }
            });
        });
    </script>
</body>
</html>
