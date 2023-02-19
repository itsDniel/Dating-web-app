<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TindrProfile.aspx.cs" Inherits="Dating_app.TindrProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="welcomelbl" runat="server" style="z-index: 1; left: 1500px; top: 29px; position: absolute"></asp:Label>
            <asp:Button ID="logoutbtn" runat="server" OnClick="logoutbtn_Click" style="z-index: 1; left: 1706px; top: 25px; position: absolute" Text="Logout" />
            <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 458px; top: 196px; position: absolute; height: 30px; width: 63px" Text="Test Page"></asp:Label>
        </div>
    </form>
</body>
</html>
