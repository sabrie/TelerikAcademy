<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XmlTreeView.aspx.cs" Inherits="_6.DisplayXmlUsingTreeView.XmlTreeView" %>

<!DOCTYPE html>
<%--
    Task 6
    -----------

    Create a Web Form that reads arbitrary XML document and displays it as tree. 
    Use the TreeView Web control on the left side to display the inner XML of the 
    selected node on the right side.

    !!! The TreeView is not visualized correctly with Visual Studio 2013 Preview
--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XML Tree View</title>
</head>
<body>
    <form id="XMLTreeView" runat="server">
        <asp:XmlDataSource ID="XmlDataSourceBooks" runat="server"
            DataFile="books.xml" />

        <asp:TreeView ID="TreeViewXml" ImageSet="Arrows" runat="server" 
            DataSourceID="XmlDataSourceBooks"
            OnTreeNodeDataBound="TreeViewXml_TreeNodeDataBound" 
            OnSelectedNodeChanged="TreeViewBooks_SelectedNodeChanged">
        </asp:TreeView>
        
        <asp:Label ID="LabelInnerText" runat="server" />
    </form>
</body>
</html>
