<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWebForms.Default" %>
<%@ Import Namespace="SmartHouseWebForms.SmartHouse.Devices" %>
<%@ Import Namespace="SmartHouseWebForms.SmartHouse.Interfaces" %>
<%@ Register Src="~/Controls/DeviceControl.ascx" TagPrefix="device" TagName ="MyDevice" %>
<%@ Register Src="~/Controls/BassControl.ascx" TagPrefix="bass" TagName ="MyBass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Panasonic Loudspeakers" />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add Samsung Loudspeakers" />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add Camera" />
        <br />
        <asp:Repeater runat="server" ID="Repeater1">
            <ItemTemplate>
                <%# Container.DataItem %>
                <device:MyDevice runat="server" />
                <bass:MyBass runat="server" />
            </ItemTemplate>
        </asp:Repeater>
        

               

    </form>
</body>
</html>
