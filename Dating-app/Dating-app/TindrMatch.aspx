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
        #matchForm {
            height: 793px;
            z-index: 1;
            left: 1px;
            top: 116px;
            position: absolute;
            width: 1772px;
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
    <form id="matchForm" runat="server">

        <asp:Button ID="logoutbtn" runat="server" CssClass="hidden" CausesValidation="False" Text="Button" OnClick="logoutbtn_Click" />
        <asp:Button ID="matchbtn" runat="server" CssClass="hidden" CausesValidation="False" OnClick="matchbtn_Click" Text="Button" />
    
        <asp:Label ID="welcomelbl" runat="server" Font-Size="X-Large" ForeColor="White" style="z-index: 1; left: 65px; top: -97px; position: absolute"></asp:Label>
        <asp:Label ID="instructionlbl" runat="server" Font-Size="X-Large" style="z-index: 1; left: 81px; top: 53px; position: absolute" Text="Welcome To Your Match Page, Here Are Your Matches"></asp:Label>
        <asp:Button ID="okbtn" runat="server" CausesValidation="False" OnClick="okbtn_Click" style="z-index: 1; left: 82px; top: 102px; position: absolute; height: 24px" Text="Gotcha" Visible="False" />
        <asp:GridView ID="gvMatch" runat="server" AutoGenerateColumns="False" DataKeyNames="username" style="z-index: 1; left: 77px; top: 188px; position: absolute; height: 152px; width: 232px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("photo") %>' style ="max-width: 300px; max-height: 300px;"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                <asp:BoundField DataField="age" HeaderText="Age" SortExpression="age" />
                <asp:BoundField DataField="birthday" HeaderText="Birthday" SortExpression="birthday" />
                <asp:BoundField DataField="occupation" HeaderText="Occupation " SortExpression="occupation" />
                <asp:BoundField DataField="height" HeaderText="Height" SortExpression="height" />
                <asp:BoundField DataField="favorite" HeaderText="Like" SortExpression="like" />
                <asp:BoundField DataField="dislike" HeaderText="Dislike" SortExpression="dislike" />
                <asp:BoundField DataField="goal" HeaderText="Goal" SortExpression="goal" />
                <asp:BoundField DataField="commitment" HeaderText="Commitment" SortExpression="commitment" />
                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="datebtn" runat="server" Height="29px" Text="Date Request" CausesValidation="False" OnClick="datebtn_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="unMatchbtn" runat="server" CausesValidation="False" OnClick="unMatchbtn_Click" Text="Unmatch" />
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
    
        <div>
        </div>
        <asp:Button ID="homebtn" runat="server" CssClass="hidden" CausesValidation="False" Text="Button" OnClick="homebtn_Click" />
        <asp:Button ID="profilebtn" runat="server" CssClass="hidden" CausesValidation="False" OnClick="profilebtn_Click" Text="Button" />
        <asp:GridView ID="gvDate" runat="server" AutoGenerateColumns="False" DataKeyNames="username" style="z-index: 1; left: 88px; top: 196px; position: absolute; height: 133px; width: 187px" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("photo") %>' style ="max-width: 300px; max-height: 300px;" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                <asp:BoundField DataField="age" HeaderText="Age" SortExpression="age" />
                <asp:BoundField DataField="birthday" HeaderText="Birthday" SortExpression="birthday" />
                <asp:BoundField DataField="occupation" HeaderText="Occupation" SortExpression="occupation" />
                <asp:BoundField DataField="height" HeaderText="Height" SortExpression="height" />
                <asp:BoundField DataField="favorite" HeaderText="Like" SortExpression="favorite" />
                <asp:BoundField DataField="dislike" HeaderText="Dislike" SortExpression="dislike" />
                <asp:BoundField DataField="goal" HeaderText="Goal" SortExpression="goal" />
                <asp:BoundField DataField="Description" HeaderText="Commitment" SortExpression="Description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="acceptbtn" runat="server" CausesValidation="False" OnClick="acceptbtn_Click" Text="Accept" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="rejectbtn" runat="server" CausesValidation="False" OnClick="rejectbtn_Click" Text="Reject" />
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
        <asp:GridView ID="gvProfile" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="z-index: 1; left: 77px; top: 538px; position: absolute; height: 133px; width: 187px" Visible="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("photo") %>' style ="max-width: 300px; max-height: 300px;" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                <asp:BoundField DataField="age" HeaderText="Age" SortExpression="age" />
                <asp:BoundField DataField="birthday" HeaderText="Birthday" SortExpression="birthday" />
                <asp:BoundField DataField="occupation" HeaderText="Occupation" SortExpression="occupation" />
                <asp:BoundField DataField="address" HeaderText="City" SortExpression="address" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="phone" />
                <asp:BoundField DataField="height" HeaderText="Height" SortExpression="height" />
                <asp:BoundField DataField="favorite" HeaderText="Like" SortExpression="favorite" />
                <asp:BoundField DataField="dislike" HeaderText="Dislike" SortExpression="dislike" />
                <asp:BoundField DataField="goal" HeaderText="Goal" SortExpression="goal" />
                <asp:BoundField DataField="commitment" HeaderText="Commitment" SortExpression="commitment" />
                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
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
        <asp:Label ID="profilelbl" runat="server" Font-Size="X-Large" style="z-index: 1; left: 78px; top: 483px; position: absolute" Text="Here's The Full Profile Of The Person You Are Going On A Date With" Visible="False"></asp:Label>
        <asp:Button ID="datePlanbtn" runat="server" CausesValidation="False" OnClick="datePlanbtn_Click" style="z-index: 1; left: 516px; top: 141px; position: absolute" Text="Check Your Date Plan" />
        <asp:GridView ID="gvPlan" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="username1,username2" ForeColor="#333333" GridLines="None" style="z-index: 1; left: 82px; top: 189px; position: absolute; height: 133px; width: 187px" Visible="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="username1" HeaderText="username1" SortExpression="username1" Visible="False" />
                <asp:BoundField DataField="username2" HeaderText="username2" SortExpression="username2" Visible="False" />
                <asp:BoundField DataField="username1" HeaderText="Participant 1" SortExpression="username1" />
                <asp:BoundField DataField="username2" HeaderText="Participant 2" SortExpression="username2" />
                <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
                <asp:BoundField DataField="time" HeaderText="Time" SortExpression="time" />
                <asp:BoundField DataField="dateDescription" HeaderText="Description" SortExpression="dateDescription" />
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
        <asp:Label ID="locationlbl" runat="server" style="z-index: 1; left: 1364px; top: 153px; position: absolute" Text="Date Location" Visible="False"></asp:Label>
        <asp:TextBox ID="locationtxt" runat="server" style="z-index: 1; left: 1344px; top: 181px; position: absolute" Visible="False"></asp:TextBox>
        <asp:Button ID="checkDate" runat="server" CausesValidation="False" OnClick="checkDate_Click" style="z-index: 1; left: 77px; top: 143px; position: absolute" Text="Check Your Date Request" />
        <asp:Button ID="checkMatchbtn" runat="server" CausesValidation="False" OnClick="checkMatchbtn_Click" style="z-index: 1; left: 323px; top: 142px; position: absolute" Text="Check Your Match" />
        <asp:Label ID="timelbl" runat="server" style="z-index: 1; left: 1373px; top: 231px; position: absolute" Text="Date Time" Visible="False"></asp:Label>
        <asp:TextBox ID="timetxt" runat="server" style="z-index: 1; left: 1341px; top: 266px; position: absolute; right: 303px" Visible="False"></asp:TextBox>
        <asp:Label ID="descriptionlbl" runat="server" style="z-index: 1; left: 1353px; top: 322px; position: absolute" Text="Date Description" Visible="False"></asp:Label>
        <asp:TextBox ID="descriptiontxt" runat="server" style="z-index: 1; left: 1341px; top: 360px; position: absolute" Visible="False"></asp:TextBox>
        <asp:Button ID="updatePlanbtn" runat="server" OnClick="updatePlanbtn_Click" style="z-index: 1; left: 1303px; top: 441px; position: absolute" Text="Update Plan" Visible="False" />
        <asp:Button ID="cancelbtn" runat="server" OnClick="cancelbtn_Click" style="z-index: 1; left: 1465px; top: 440px; position: absolute" Text="Cancel Date" Visible="False" />
        <asp:RequiredFieldValidator ID="locationValidator" runat="server" ControlToValidate="locationtxt" ErrorMessage="Missing Location" ForeColor="Red" style="z-index: 1; left: 1495px; top: 180px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="descriptionValidator" runat="server" ControlToValidate="descriptiontxt" ErrorMessage="Missing Description" ForeColor="Red" style="z-index: 1; left: 1501px; top: 358px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="timeValidator" runat="server" ControlToValidate="timetxt" ErrorMessage="Missing Time" ForeColor="Red" style="z-index: 1; top: 265px; position: absolute; left: 1505px"></asp:RequiredFieldValidator>
    </form>
    
            </ul>
        </nav>
    </header>
        
</body>
</html>
