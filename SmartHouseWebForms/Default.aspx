<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWebForms.Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Add Panasonic Loudspeakers" OnClick="Button1_Click" />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Add Camera" OnClick="Button2_Click" />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Add Samsung Loudspeakers" />
        <br />
        <asp:Repeater runat="server" OnItemCommand="OnItemCommand" OnItemDataBound="OnItemDataBound" ID="Repeater1">
            <ItemTemplate>
                <asp:PlaceHolder runat="server"  ID="plcHolder" />
                
                <asp:Button runat="server" CommandName="Delete" Text="Delete"></asp:Button>
                <asp:HiddenField ID="hid" runat="server" Value='<%#Eval("Id") %>' />
            </ItemTemplate>
        </asp:Repeater>
        <br />
   </form>
</body>
</html>
