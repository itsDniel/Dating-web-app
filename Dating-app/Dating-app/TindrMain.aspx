<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TindrMain.aspx.cs" Inherits="Dating_app.TindrMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tindr</title>
    <link href ="tindr.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <nav id="nav">
            <ul>
            <li><a href="#" onclick="document.getElementById('<%= homebtn.ClientID %>').click(); return false;">Home</a></li>
            <li><a href="#" onclick="document.getElementById('<%= profilebtn.ClientID %>').click(); return false;">My Profile</a></li>
            <li>
                <asp:Button ID="homebtn" runat="server" OnClick="homebtn_Click" style="z-index: 1; left: 2357px; top: 143px; position: absolute" Text="Button" />
                <asp:Button ID="profilebtn" runat="server" OnClick="profilebtn_Click" style="z-index: 1; left: 2308px; top: 228px; position: absolute" Text="Button" />
                <a href="#" onclick="document.getElementById('<%= logoutbtn.ClientID %>').click(); return false;">Logout</a></li>
            </ul>
        </nav>
    </header>
        <div>
            <asp:Button ID="logoutbtn" runat="server" OnClick="logoutbtn_Click" style="z-index: 1; left: 2174px; top: 96px; position: absolute" Text="Button" />
            <asp:Label ID="welcomelbl" runat="server" Font-Size="X-Large" ForeColor="White" style="z-index: 1; left: 23px; top: 43px; position: absolute"></asp:Label>
        </div>
    </form>
</body>
</html>
