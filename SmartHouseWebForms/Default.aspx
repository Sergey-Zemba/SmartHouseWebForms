<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWebForms.Default" %>
<link rel="stylesheet" href="styles.css"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="AddAirConditioner" runat="server" OnClick="AddAirConditioner_Click" Text="Add Air Conditioner" CssClass="addLinkButtons" />
        <br />
        <br />
        <asp:LinkButton ID="AddCamera" runat="server" OnClick="AddCamera_Click" Text="Add Camera" CssClass="addLinkButtons" />
        <br />
        <br />
        <asp:LinkButton ID="AddFridge" runat="server" OnClick="AddFridge_Click" Text="Add Fridge" CssClass="addLinkButtons" />
        <br />
        <br />
        <asp:LinkButton ID="AddGarage" runat="server" OnClick="AddGarage_Click" Text="Add Garage" CssClass="addLinkButtons" />
        <br />
        <br />
        <asp:LinkButton ID="AddHomeCinema" runat="server" OnClick="AddHomeCinema_Click" Text="Add Home Cinema" CssClass="addLinkButtons" />
        <br />
        <asp:RadioButton AutoPostBack="True" GroupName="HomeCinemaGroup" ID="PanasonicCinemaRadio" OnCheckedChanged="PanasonicCinemaRadio_CheckedChanged" runat="server" Text="Panasonic" Visible="False" />
        <asp:RadioButton AutoPostBack="True" GroupName="HomeCinemaGroup" ID="SamsungCinemaRadio" OnCheckedChanged="SamsungCinemaRadio_CheckedChanged" runat="server" Text="Samsung" Visible="False" />
        <br />
        <asp:LinkButton ID="AddLoudspeakers" runat="server" OnClick="AddLoudspeakers_Click" Text="Add Loudspeakers" CssClass="addLinkButtons" />
        <br />
        <asp:RadioButton AutoPostBack="True" GroupName="LoudspeakersGroup" ID="PanasonicLoudspeakersRadio" OnCheckedChanged="PanasonicLoudspeakersRadio_CheckedChanged" runat="server" Text="Panasonic" Visible="False" />
        <asp:RadioButton AutoPostBack="True" GroupName="LoudspeakersGroup" ID="SamsungLoudspeakersRadio" OnCheckedChanged="SamsungLoudspeakersRadio_CheckedChanged" runat="server" Text="Samsung" Visible="False" />
        <br />
        <asp:LinkButton ID="AddStereoSystem" runat="server" OnClick="AddStereoSystem_Click" Text="Add Stereo System" CssClass="addLinkButtons" />
        <br />
        <asp:RadioButton AutoPostBack="True" GroupName="StereoSystemGroup" ID="PanasonicStereoRadio" OnCheckedChanged="PanasonicStereoRadio_CheckedChanged" runat="server" Text="Panasonic" Visible="False" />
        <asp:RadioButton AutoPostBack="True" GroupName="StereoSystemGroup" ID="SamsungStereoRadio" OnCheckedChanged="SamsungStereoRadio_CheckedChanged" runat="server" Text="Samsung" Visible="False" />
        <br />
        <asp:LinkButton ID="AddTV" runat="server" OnClick="AddTV_Click" Text="Add TV" CssClass="addLinkButtons" />
        <br />
        <asp:RadioButton AutoPostBack="True" GroupName="TVGroup" ID="PanasonicTVRadio" OnCheckedChanged="PanasonicTVRadio_CheckedChanged" runat="server" Text="Panasonic" Visible="False" />
        <asp:RadioButton AutoPostBack="True" GroupName="TVGroup" ID="SamsungTVRadio" OnCheckedChanged="SamsungTVRadio_CheckedChanged" runat="server" Text="Samsung" Visible="False" />
        <br />
        <asp:Repeater runat="server" OnItemCommand="OnItemCommand" OnItemDataBound="OnItemDataBound" ID="Repeater1">
            <ItemTemplate>
                <asp:HiddenField ID="hid" runat="server" Value='<%#Eval("Id") %>' />
                <div>
                    <asp:LinkButton runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                    <br />
                    <asp:Label runat="server" ID="State"></asp:Label>
                    <br />
                    <asp:LinkButton runat="server" CommandName="On/Off" Text="On/Off"></asp:LinkButton>&nbsp;
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
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <br />
    </form>
</body>
</html>
