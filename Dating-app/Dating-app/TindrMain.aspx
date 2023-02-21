<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TindrMain.aspx.cs" Inherits="Dating_app.TindrMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tindr</title>
    <link href ="tindr.css" rel="stylesheet" />
    <style type="text/css">
        #form1 {
            height: 900px;
        }
        #profileTable {
            z-index: 1;
            left: 47px;
            top: 360px;
            position: absolute;
            height: 79px;
            width: 818px;
        }
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <header>
        <nav id="nav">
            <ul>
            <li><a href="#" onclick="document.getElementById('<%= homebtn.ClientID %>').click(); return false;">Home</a></li>
            <li><a href="#" onclick="document.getElementById('<%= profilebtn.ClientID %>').click(); return false;">My Profile</a></li>
            <li>
                
                <a href="#" onclick="document.getElementById('<%= logoutbtn.ClientID %>').click(); return false;">Logout</a></li>
            </ul>
        </nav>
    </header>

        <div>
            <asp:Button ID="logoutbtn" runat="server" CausesValidation="False" CssClass="hidden" OnClick="logoutbtn_Click" style="z-index: 1; left: 713px; top: 107px; position: absolute; height: 29px;" Text="Button" />
            <asp:Label ID="welcomelbl" runat="server"  Font-Size="X-Large" ForeColor="White" style="z-index: 1; left: 30px; top: 41px; position: absolute"></asp:Label>
             <asp:Button ID="homebtn" runat="server" CausesValidation="False" CssClass="hidden" OnClick="homebtn_Click" style="z-index: 1; left: 821px; top: 113px; position: absolute; height: 36px; width: 113px;" Text="Button" />
                <asp:Button ID="profilebtn" runat="server" CausesValidation="False" CssClass="hidden" OnClick="profilebtn_Click" style="z-index: 1; left: 525px; top: 125px; position: absolute; height: 33px;" Text="Button" />
            <asp:Label ID="instructionlbl" runat="server" Font-Size="X-Large" style="z-index: 1; left: 40px; top: 179px; position: absolute">Hi There Let&#39;s Look For People That Have Something In Common With You </asp:Label>
            <asp:DropDownList ID="searchddl" runat="server" style="z-index: 1; left: 45px; top: 224px; position: absolute">
                <asp:ListItem Value="0">Same City</asp:ListItem>
                <asp:ListItem Value="1">Like The Same Thing</asp:ListItem>
                <asp:ListItem Value="2">Dislike The Same Thing</asp:ListItem>
                <asp:ListItem Value="3">Same Commitment Type</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="searchbtn" runat="server" OnClick="Button2_Click" style="z-index: 1; left: 44px; top: 265px; position: absolute" Text="Search" />
            <asp:GridView ID="gvCity" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="username" ForeColor="#333333" GridLines="None" style="z-index: 1; left: 44px; top: 324px; position: absolute; height: 133px; width: 187px" Visible="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" Visible="False" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("photo") %>' style ="max-width: 300px; max-height: 300px;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="age" HeaderText="Age" SortExpression="age" />
                    <asp:BoundField DataField="address" HeaderText="City" SortExpression="address" />
                    <asp:BoundField DataField="favorite" HeaderText="Like" SortExpression="favorite" />
                    <asp:BoundField DataField="dislike" HeaderText="Dislike" SortExpression="dislike" />
                    <asp:BoundField DataField="commitment" HeaderText="Commitment Type" SortExpression="commitment" />
                    <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="profilebtn" runat="server" Text="Button" CommandName="MyCommand" CommandArgument="<%# Container.DataItemIndex %>" EnableViewState="False" OnClick="profilebtn_Click1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        
            <asp:Button ID="likebtn" runat="server" style="z-index: 1; left: 1685px; top: 627px; position: absolute; height: 46px; width: 91px" Text="Like" Visible="False" OnClick="likebtn_Click" />
            <asp:Label ID="namePlaceholder" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="usernamePlaceholder" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="closebtn" runat="server" Height="39px" OnClick="closebtn_Click" style="z-index: 1; left: 1620px; top: 630px; position: absolute" Text="Close" Visible="False" Width="86px" />
            <asp:Button ID="nobtn" runat="server" OnClick="nobtn_Click" style="z-index: 1; left: 1549px; top: 628px; position: absolute; height: 44px; width: 88px" Text="Nah" Visible="False" />
        <table style="z-index: 1; left: 1029px; top: 401px; position: absolute; height: 165px; width: 754px" id="profileT">
            <tr runat="server" id="table">
                <th>Name</th>
                <th>Age</th>
                <th>Birthday</th>
                <th>Occupation</th>
                <th>Height</th>
                <th>Like</th>
                <th>Dislike</th>
                <th>Goal</th>
                <th>Commitment</th>
                <th>Description</th>
            </tr>
            <asp:Repeater ID="rprProfile" runat="server" Visible="false">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "name") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAge" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "age") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblBirth" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "birthday") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblOccu" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "occupation") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblHeight" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "height") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLike" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "favorite") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDislike" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "dislike") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblGoal" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "goal") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCommit" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "commitment") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDesc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "description") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </table>


            <asp:Image ID="profileImg" runat="server" style="z-index: 1; left: 1571px; top: 187px; position: absolute; height: 193px; width: 186px;" Visible="False" />
        </div>
    </form>
</body>
</html>
