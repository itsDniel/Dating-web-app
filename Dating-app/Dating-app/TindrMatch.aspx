<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TindrMatch.aspx.cs" Inherits="Dating_app.TindrMatch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tindr</title>
    <link href="tindr.css" rel="stylesheet" />
    
    <style type="text/css">
        #form1 {
            height: 557px;
        }
    </style>
</head>
<body>
    <form id="matchForm" runat="server">
    <header>
        <nav id="nav">
            <ul>
            <li><a href="#" onclick="document.getElementById('<%= homebtn.ClientID %>').click(); return false;">Home</a></li>
            <li><a href="#" onclick="document.getElementById('<%= profilebtn.ClientID %>').click(); return false;">My Profile</a></li>
            <li><a href="#" onclick="document.getElementById('<%= matchbtn.ClientID %>').click(); return false;">My Match</a></li>
            <li><a href="#" onclick="document.getElementById('<%= logoutbtn.ClientID %>').click(); return false;">Logout</a></li>
            </ul>
        </nav>
    </header>
        <asp:Button ID="logoutbtn" runat="server" CssClass="hidden" CausesValidation="False" Text="Button" OnClick="logoutbtn_Click" />
        <asp:Button ID="matchbtn" runat="server" CssClass="hidden" CausesValidation="False" OnClick="matchbtn_Click" Text="Button" />
    
        <asp:Label ID="welcomelbl" runat="server" Font-Size="X-Large" ForeColor="White" style="z-index: 1; left: 49px; top: 22px; position: absolute"></asp:Label>
        <asp:Label ID="instructionlbl" runat="server" Font-Size="X-Large" style="z-index: 1; left: 76px; top: 161px; position: absolute" Text="Welcome To Your Match Page, Here Are Your Matches"></asp:Label>
        <asp:GridView ID="gvMatch" runat="server" AutoGenerateColumns="False" DataKeyNames="username" style="z-index: 1; left: 66px; top: 230px; position: absolute; height: 152px; width: 232px">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("photo") %>' Height="16px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                <asp:BoundField DataField="age" HeaderText="Age" SortExpression="age" />
                <asp:BoundField DataField="birthday" HeaderText="Birthday" SortExpression="birthday" />
                <asp:BoundField DataField="occupation" HeaderText="Occupation " SortExpression="occupation" />
                <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="phone" />
                <asp:BoundField DataField="height" HeaderText="Height" SortExpression="height" />
                <asp:BoundField DataField="favorite" HeaderText="Like" SortExpression="like" />
                <asp:BoundField DataField="dislike" HeaderText="Dislike" SortExpression="dislike" />
                <asp:BoundField DataField="goal" HeaderText="Goal" SortExpression="goal" />
                <asp:BoundField DataField="commitment" HeaderText="Commitment" SortExpression="commitment" />
                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Height="29px" Text="Button" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
        <div>
        </div>
        <asp:Button ID="homebtn" runat="server" CssClass="hidden" CausesValidation="False" Text="Button" OnClick="homebtn_Click" />
        <asp:Button ID="profilebtn" runat="server" CssClass="hidden" CausesValidation="False" OnClick="profilebtn_Click" Text="Button" />
    </form>
    
</body>
</html>
