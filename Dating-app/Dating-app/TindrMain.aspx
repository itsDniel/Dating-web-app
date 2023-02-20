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
                <asp:Button ID="homebtn" runat="server" CausesValidation="False" CssClass="hidden" OnClick="homebtn_Click" style="z-index: 1; left: 821px; top: 113px; position: absolute; height: 36px; width: 113px;" Text="Button" />
                <asp:Button ID="profilebtn" runat="server" CausesValidation="False" CssClass="hidden" OnClick="profilebtn_Click" style="z-index: 1; left: 525px; top: 125px; position: absolute; height: 33px;" Text="Button" />
                <a href="#" onclick="document.getElementById('<%= logoutbtn.ClientID %>').click(); return false;">Logout</a></li>
            </ul>
        </nav>
    </header>
        <div>
            <asp:Button ID="logoutbtn" runat="server" CausesValidation="False" CssClass="hidden" OnClick="logoutbtn_Click" style="z-index: 1; left: 713px; top: 107px; position: absolute; height: 29px;" Text="Button" />
            <asp:Label ID="welcomelbl" runat="server"  Font-Size="X-Large" ForeColor="White" style="z-index: 1; left: 30px; top: 41px; position: absolute"></asp:Label>
        </div>
    </form>
</body>
</html>
