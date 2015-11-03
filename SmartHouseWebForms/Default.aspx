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
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Loudspeakers" />
        <br />
        <% Dictionary<string, Device> devices = (Dictionary<string, Device>)Session["devices"];
           foreach (KeyValuePair<string, Device> pair in devices)
           { %>
        <div>
            <device:MyDevice runat="server"/>
            <asp:Button ID="Button2" runat="server" Text="Remove" OnClick="Button2_Click" />
            <%if(pair.Value is IBass){%>
            <bass:MyBass runat="server"></bass:MyBass>
            <%} %>
        </div>
               
           <% } %>
    </form>
</body>
</html>
