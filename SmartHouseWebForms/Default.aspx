<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWebForms.Default" %>

<link rel="stylesheet" href="/Css/styles.css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Smart House</title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div id="logo">
                <img src="Css/smarthouse.png" alt="logo"/>
            </div>
        </header>
        <div id="content">
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
                            <asp:ImageButton runat="server" ID="DeleteButton" CommandName="Delete" CssClass="delete"></asp:ImageButton>
                            <div class="indicators">
                                <asp:Image runat="server" ID="RecIndicator" AlternateText="Recording" ImageUrl="Css/Controls/recind.jpg" Visible="False" CssClass="indicator" />
                                <asp:Image runat="server" ID="MuteIndicator" AlternateText="Mute" ImageUrl="Css/Controls/muteind.png" Visible="False" CssClass="indicator" />
                                <asp:Image runat="server" ID="BassIndicator" AlternateText="Bass" ImageUrl="Css/Controls/bassind.png" Visible="False" CssClass="indicator" />
                                <asp:Image runat="server" ID="ThreeDIndicator" AlternateText="3D" ImageUrl="Css/Controls/3Dind.png" Visible="False" CssClass="indicator" />
                            </div>
                            <div class="controls">
                                <asp:ImageButton runat="server" ID="SwitchButton" CommandName="On/Off" CssClass="control"></asp:ImageButton>&nbsp;
                            <asp:Panel runat="server" ID="TemperaturePanel" Visible="False" CssClass="control">
                                <img src="Css/Controls/TempIcon.png" alt="temp" />
                                <asp:Label runat="server" ID="Temperature"></asp:Label>
                                <asp:ImageButton runat="server" ID="TempUp" CommandName="Warmer"></asp:ImageButton>&nbsp;
                                <asp:ImageButton runat="server" ID="TempDown" CommandName="Cooler"></asp:ImageButton>&nbsp;
                            </asp:Panel>
                                <asp:Panel runat="server" ID="VolumePanel" Visible="False" CssClass="control">
                                    <asp:Label runat="server" ID="Volume"></asp:Label>
                                    <asp:ImageButton runat="server" ID="VolUp" CommandName="Louder"></asp:ImageButton>&nbsp;
                                <asp:ImageButton runat="server" ID="VolDown" CommandName="Hush"></asp:ImageButton>&nbsp;
                                <asp:ImageButton runat="server" ID="Mute" CommandName="Mute"></asp:ImageButton>&nbsp;
                                </asp:Panel>
                                <asp:Panel runat="server" ID="BassPanel" Visible="False" CssClass="control">
                                    <asp:ImageButton runat="server" ID="BassButton" CommandName="Bass"></asp:ImageButton>&nbsp;
                                </asp:Panel>
                                <asp:Panel runat="server" ID="LockPanel" Visible="False" CssClass="control">
                                    <asp:ImageButton runat="server" ID="LockButton" CommandName="Open/Close"></asp:ImageButton>&nbsp;
                                </asp:Panel>
                                <asp:Panel runat="server" ID="RecordingPanel" Visible="False" CssClass="control">
                                    <asp:ImageButton runat="server" ID="RecButton" CommandName="REC"></asp:ImageButton>&nbsp;
                                </asp:Panel>
                                <asp:Panel runat="server" ID="ThreeDPanel" Visible="False" CssClass="control">
                                    <asp:ImageButton runat="server" ID="ThreeDButton" CommandName="ThreeD"></asp:ImageButton>&nbsp;
                                </asp:Panel>
                            </div>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </form>
</body>
</html>
