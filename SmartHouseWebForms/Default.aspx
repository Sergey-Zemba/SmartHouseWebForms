<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWebForms.Default" %>

<link rel="stylesheet" href="/Css/styles.css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Smart House</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="addButtons">
            <asp:Button class="add" ID="AddAirConditioner" runat="server" OnClick="AddAirConditioner_Click" Text="Add Air Conditioner" />
            <br />
            <asp:Button class="add" ID="AddCamera" runat="server" OnClick="AddCamera_Click" Text="Add Camera" />
            <br />
            <asp:Button class="add" ID="AddFridge" runat="server" OnClick="AddFridge_Click" Text="Add Fridge" />
            <br />
            <asp:Button class="add" ID="AddGarage" runat="server" OnClick="AddGarage_Click" Text="Add Garage" />
            <br />
            <asp:Button class="add" ID="AddHomeCinema" runat="server" OnClick="AddHomeCinema_Click" Text="Add Home Cinema" />
            <br />
            <asp:Panel runat="server" ID="CinemaRadio" Visible="False">
                <asp:RadioButton AutoPostBack="True" GroupName="HomeCinemaGroup" ID="PanasonicCinemaRadio" OnCheckedChanged="PanasonicCinemaRadio_CheckedChanged" runat="server" Text="Panasonic" />
                <asp:RadioButton AutoPostBack="True" GroupName="HomeCinemaGroup" ID="SamsungCinemaRadio" OnCheckedChanged="SamsungCinemaRadio_CheckedChanged" runat="server" Text="Samsung" />
            </asp:Panel>
            <asp:Button class="add" ID="AddLoudspeakers" runat="server" OnClick="AddLoudspeakers_Click" Text="Add Loudspeakers" />
            <br />
            <asp:Panel runat="server" ID="LoudspeakersRadio" Visible="False">
                <asp:RadioButton AutoPostBack="True" GroupName="LoudspeakersGroup" ID="PanasonicLoudspeakersRadio" OnCheckedChanged="PanasonicLoudspeakersRadio_CheckedChanged" runat="server" Text="Panasonic" />
                <asp:RadioButton AutoPostBack="True" GroupName="LoudspeakersGroup" ID="SamsungLoudspeakersRadio" OnCheckedChanged="SamsungLoudspeakersRadio_CheckedChanged" runat="server" Text="Samsung" />
            </asp:Panel>
            <asp:Button class="add" ID="AddTV" runat="server" OnClick="AddTV_Click" Text="Add TV" />
            <asp:Panel runat="server" ID="TVRadio" Visible="False">
                <asp:RadioButton AutoPostBack="True" GroupName="TVGroup" ID="PanasonicTVRadio" OnCheckedChanged="PanasonicTVRadio_CheckedChanged" runat="server" Text="Panasonic" />
                <asp:RadioButton AutoPostBack="True" GroupName="TVGroup" ID="SamsungTVRadio" OnCheckedChanged="SamsungTVRadio_CheckedChanged" runat="server" Text="Samsung" />
            </asp:Panel>
        </div>
        
            <div class="container">
                <asp:Repeater runat="server" OnItemCommand="OnItemCommand" OnItemDataBound="OnItemDataBound" ID="Repeater1">
                <ItemTemplate>
                    <asp:Panel runat="server" ID="device" CssClass="item">
                        <asp:HiddenField ID="hid" runat="server" Value='<%#Eval("Id") %>' />
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        <br />
                        <asp:Label runat="server" ID="State"></asp:Label>
                        <br />
                        <asp:ImageButton runat="server" ID="SwitchButton" CommandName="On/Off"></asp:ImageButton>&nbsp;
                    <asp:Panel runat="server" ID="BassPanel" Visible="False">
                        <asp:LinkButton runat="server" CommandName="Bass" Text="Bass"></asp:LinkButton>&nbsp;
                    </asp:Panel>
                        <asp:Panel runat="server" ID="LockPanel" Visible="False">
                            <asp:LinkButton runat="server" CommandName="Open" Text="Open"></asp:LinkButton>&nbsp;
                        <asp:LinkButton runat="server" CommandName="Close" Text="Close"></asp:LinkButton>&nbsp;
                        </asp:Panel>
                        <asp:Panel runat="server" ID="RecordingPanel" Visible="False">
                            <asp:LinkButton runat="server" CommandName="REC" Text="REC"></asp:LinkButton>&nbsp;
                        </asp:Panel>
                        <asp:Panel runat="server" ID="TemperaturePanel" Visible="False">
                            <asp:LinkButton runat="server" CommandName="Warmer" Text="Temperature Up"></asp:LinkButton>&nbsp;
                        <asp:LinkButton runat="server" CommandName="Cooler" Text="Temperature Down"></asp:LinkButton>&nbsp;
                        </asp:Panel>
                        <asp:Panel runat="server" ID="ThreeDPanel" Visible="False">
                            <asp:LinkButton runat="server" CommandName="ThreeD" Text="3D"></asp:LinkButton>&nbsp;
                        </asp:Panel>
                        <asp:Panel runat="server" ID="VolumePanel" Visible="False">
                            <asp:LinkButton runat="server" CommandName="Louder" Text="Sound Up"></asp:LinkButton>&nbsp;
                        <asp:LinkButton runat="server" CommandName="Hush" Text="Sound Down"></asp:LinkButton>&nbsp;
                        <asp:LinkButton runat="server" CommandName="Mute" Text="Mute"></asp:LinkButton>&nbsp;
                        </asp:Panel>
                    </asp:Panel>
                </ItemTemplate>
            </asp:Repeater>
            </div>
        
    </form>
</body>
</html>
