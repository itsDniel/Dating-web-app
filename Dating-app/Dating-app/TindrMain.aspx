﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TindrMain.aspx.cs" Inherits="Dating_app.TindrMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tindr</title>
    <link href ="tindr.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous"/>
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
        .auto-style2 {
            width: 72px;
        }
        .auto-style3 {
            width: 71px;
        }
        .auto-style4 {
            width: 65px;
        }
    </style>
</head>
<body>
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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
    <form id="form1" runat="server">



        <div>
            <asp:Button ID="matchbtn" runat="server" CssClass="hidden" CausesValidation="False" OnClick="matchbtn_Click" Text="Button" />
            <asp:Button ID="logoutbtn" runat="server" CausesValidation="False" CssClass="hidden" OnClick="logoutbtn_Click" style="z-index: 1; left: 713px; top: 107px; position: absolute; height: 29px;" Text="Button" />
            <asp:Label ID="welcomelbl" runat="server"  Font-Size="X-Large" ForeColor="White" style="z-index: 1; left: 26px; top: 21px; position: absolute; height: 26px;"></asp:Label>
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
            <asp:GridView ID="gvCity" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="username" GridLines="Horizontal" style="z-index: 1; left: 44px; top: 324px; position: absolute; height: 133px; width: 187px" Visible="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" Visible="False" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("photo") %>' style ="max-width: 300px; max-height: 300px;" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="age" HeaderText="Age" SortExpression="age" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="address" HeaderText="City" SortExpression="address" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="favorite" HeaderText="Like" SortExpression="favorite" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dislike" HeaderText="Dislike" SortExpression="dislike" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="commitment" HeaderText="Commitment Type" SortExpression="commitment" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="profilebtn" runat="server" Text="Button" CommandName="MyCommand" CommandArgument="<%# Container.DataItemIndex %>" EnableViewState="False" OnClick="profilebtn_Click1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        
            <asp:Button ID="likebtn" runat="server" style="z-index: 1; left: 1178px; top: 864px; position: absolute; height: 46px; width: 91px" Text="Like" Visible="False" OnClick="likebtn_Click" />
            <asp:Label ID="namePlaceholder" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="usernamePlaceholder" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="closebtn" runat="server" Height="39px" OnClick="closebtn_Click" style="z-index: 1; left: 1106px; top: 871px; position: absolute; right: 641px;" Text="Close" Visible="False" Width="86px" />
            <asp:Button ID="nobtn" runat="server" OnClick="nobtn_Click" style="z-index: 1; left: 1038px; top: 866px; position: absolute; height: 44px; width: 88px" Text="Nah" Visible="False" />
            <div class="container">
                <div class="header">
            <table style="z-index: 1; left: 1029px; top: 401px; position: absolute; height: 165px; width: 754px" id="profileT">
            <tr runat="server" id="table_header">
                <th>Name</th>
                <th class="auto-style3">Age</th>
                <th>Birthday</th>
                <th>Occupation</th>
                <th class="auto-style4">Height</th>
                <th>Like</th>
                <th>Dislike</th>
                <th class="auto-style2">Goal</th>
                <th>Commitment</th>
                <th>Description</th>
            </tr>
                </table>
                    </div>
                <div class="repeater">
                    <table style="z-index: 1; left: 1140px; top: 401px; position: absolute; height: 195px; bottom: 327px">
            <asp:Repeater ID="rprProfile" runat="server" Visible="false">
                <ItemTemplate>
                    
                    <tr id="table_body">
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
             </div>
            </div>


            <asp:Image ID="profileImg" runat="server" style="z-index: 1; left: 1086px; top: 181px; position: absolute; height: 193px; width: 186px;" Visible="False" />
        </div>
    </form>
</body>
</html>
