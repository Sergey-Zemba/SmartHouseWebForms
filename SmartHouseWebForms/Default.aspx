<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWebForms.Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="AddAirConditioner" runat="server" OnClick="AddAirConditioner_Click" Text="Add Air Conditioner" />
        <br />
        <br />
        <asp:Button ID="AddCamera" runat="server" OnClick="AddCamera_Click" Text="Add Camera" />
        <br />
        <br />
        <asp:Button ID="AddFridge" runat="server" OnClick="AddFridge_Click" Text="Add Fridge" />
        <br />
        <br />
        <asp:Button ID="AddGarage" runat="server" OnClick="AddGarage_Click" Text="Add Garage" />
        <br />
        <br />
        <asp:Button ID="AddHomeCinema" runat="server" OnClick="AddHomeCinema_Click" Text="Add Home Cinema" />
        <br />
        <asp:RadioButton AutoPostBack="True" GroupName="HomeCinemaGroup" ID="PanasonicCinemaRadio" OnCheckedChanged="PanasonicCinemaRadio_CheckedChanged" runat="server" Text="Panasonic" Visible="False" />
        <asp:RadioButton AutoPostBack="True" GroupName="HomeCinemaGroup" ID="SamsungCinemaRadio" OnCheckedChanged="SamsungCinemaRadio_CheckedChanged" runat="server" Text="Samsung" Visible="False" />
        <br />
        <asp:Button ID="AddLoudspeakers" runat="server" OnClick="AddLoudspeakers_Click" Text="Add Loudspeakers" />
        <br />
        <asp:RadioButton AutoPostBack="True" GroupName="LoudspeakersGroup" ID="PanasonicLoudspeakersRadio" OnCheckedChanged="PanasonicLoudspeakersRadio_CheckedChanged" runat="server" Text="Panasonic" Visible="False" />
        <asp:RadioButton AutoPostBack="True" GroupName="LoudspeakersGroup" ID="SamsungLoudspeakersRadio" OnCheckedChanged="SamsungLoudspeakersRadio_CheckedChanged" runat="server" Text="Samsung" Visible="False" />
        <br />
        <asp:Button ID="AddStereoSystem" runat="server" OnClick="AddStereoSystem_Click" Text="Add Stereo System" />
        <br />
        <asp:RadioButton AutoPostBack="True" GroupName="StereoSystemGroup" ID="PanasonicStereoRadio" OnCheckedChanged="PanasonicStereoRadio_CheckedChanged" runat="server" Text="Panasonic" Visible="False" />
        <asp:RadioButton AutoPostBack="True" GroupName="StereoSystemGroup" ID="SamsungStereoRadio" OnCheckedChanged="SamsungStereoRadio_CheckedChanged" runat="server" Text="Samsung" Visible="False" />
        <br />
        <asp:Button ID="AddTV" runat="server" OnClick="AddTV_Click" Text="Add TV" />
        <br />
        <asp:RadioButton AutoPostBack="True" GroupName="TVGroup" ID="PanasonicTVRadio" OnCheckedChanged="PanasonicTVRadio_CheckedChanged" runat="server" Text="Panasonic" Visible="False" />
        <asp:RadioButton AutoPostBack="True" GroupName="TVGroup" ID="SamsungTVRadio" OnCheckedChanged="SamsungTVRadio_CheckedChanged" runat="server" Text="Samsung" Visible="False" />
        <br />
        <asp:Repeater runat="server" OnItemCommand="OnItemCommand" OnItemDataBound="OnItemDataBound" ID="Repeater1">
            <ItemTemplate>
                <asp:HiddenField ID="hid" runat="server" Value='<%#Eval("Id") %>' />
                <asp:PlaceHolder runat="server" ID="plcHolder" />
                <asp:Button runat="server" CommandName="Delete" Text="Delete" ></asp:Button>
            </ItemTemplate>
        </asp:Repeater>
        <br />
    </form>
</body>
</html>
