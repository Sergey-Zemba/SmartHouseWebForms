<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWebForms.Default" %>
<%@ Import Namespace="SmartHouseWebForms.SmartHouse.Devices" %>
<%@ Import Namespace="SmartHouseWebForms.SmartHouse.Interfaces" %>
<%@ Register Src="~/Controls/DeviceControl.ascx" TagPrefix="device" TagName ="MyDevice" %>
<%@ Register Src="~/Controls/BassControl.ascx" TagPrefix="bass" TagName ="MyBass" %>
<%@ Register Src="~/Controls/RecordingControl.ascx" TagPrefix="rec" TagName ="MyRec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Add Panasonic Loudspeakers" />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Add Camera" />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Add Samsung Loudspeakers" />
        <br />
        <br />
   </form>
</body>
</html>
