<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWebForms.Default" %>
<%@ Import Namespace="SmartHouseWebForms.Controls" %>
<%@ Register Src="~/Controls/DeviceControl.ascx" TagPrefix="device" TagName ="MyDevice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Loudspeakers" />
        <br />
        <% foreach (var element in Session)
           {
                { %>
                <device:MyDevice runat="server"/>
        <%
        }
           } %>
    </form>
</body>
</html>
