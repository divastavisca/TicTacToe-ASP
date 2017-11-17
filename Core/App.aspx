<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="App.aspx.cs" Inherits="Core.App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="panel" runat="server">
            <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="1" Height="51px" style="margin-right: 0px" Width="43px" OnClick="ResolveMoveEvent"/>
&nbsp;
            <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="2" Height="51px" style="margin-right: 0px" Width="43px" OnClick="ResolveMoveEvent"/>
&nbsp;
            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="3" Height="51px" style="margin-right: 0px" Width="43px" OnClick="ResolveMoveEvent"/>
            <br />
            <br />
            <asp:ImageButton ID="ImageButton4" runat="server" AlternateText="4" Height="51px" style="margin-right: 0px" Width="43px" OnClick="ResolveMoveEvent"/>
&nbsp;
            <asp:ImageButton ID="ImageButton5" runat="server" AlternateText="5" Height="51px" style="margin-right: 0px" Width="43px" OnClick="ResolveMoveEvent"/>
&nbsp;
            <asp:ImageButton ID="ImageButton6" runat="server" AlternateText="6" Height="51px" style="margin-right: 0px" Width="43px" OnClick="ResolveMoveEvent"/>
            <br />
            <br />
            <asp:ImageButton ID="ImageButton7" runat="server" AlternateText="7" Height="51px" style="margin-right: 0px" Width="43px" OnClick="ResolveMoveEvent"/>
&nbsp;
            <asp:ImageButton ID="ImageButton8" runat="server" AlternateText="8" Height="51px" style="margin-right: 0px" Width="43px" OnClick="ResolveMoveEvent"/>
&nbsp;
            <asp:ImageButton ID="ImageButton9" runat="server" AlternateText="9" Height="51px" style="margin-right: 0px" Width="43px" OnClick="ResolveMoveEvent"/>
            <br />
            <br />
            <asp:Label ID="GameResult" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="NewGame" runat="server" OnClick="NewGame_Click" Text="New Game" Visible="False" />
&nbsp;
            <asp:Button ID="Reset" runat="server" OnClick="Reset_Click" Text="Reset" />
        </div>
    </form>
    <input id="GameStatus" runat="server" type="hidden" value="newgame" enableviewstate="true"/>
    </body>
</html>
