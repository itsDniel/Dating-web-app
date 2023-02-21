<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TindrProfile.aspx.cs" Inherits="Dating_app.TindrProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tindr</title>
    <link href ="tindr.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous"/>


    <style type="text/css">
        #profileForm {
            height: 868px;
            width: 1548px;
            z-index: 1;
            left: 21px;
            top: 100px;
            position: absolute;
        }
        #form1 {
            height: 820px;
        }
    </style>


</head>
<body>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
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
    <form id="profileForm" runat="server" visible="True">
        


        <asp:Button ID="matchbtn" runat="server" CssClass="hidden" CausesValidation="False" OnClick="matchbtn_Click" Text="Button" />
        


        <asp:Button ID="profilebtn" runat="server" CausesValidation="False" CssClass="hidden" style="z-index: 1; left: 1403px; top: 126px; position: absolute" Text="Button" />
        


        <asp:Button ID="homebtn" runat="server" CausesValidation="False" CssClass="hidden" OnClick="homebtn_Click" Text="Button" style="z-index: 1; left: 1407px; top: 66px; position: absolute" />
        <div>
            <asp:Label ID="welcomelbl" runat="server" style="z-index: 1; top: -79px; position: absolute; left: 25px;" Font-Size="X-Large" ForeColor="White"></asp:Label>
            
        </div>

            <asp:Label ID="greetinglbl" runat="server" Font-Bold="True" Font-Size="XX-Large" style="z-index: 1; top: 5px; position: absolute; left: 438px" Text="Hi There, Let's Get Your Profile Set Up"></asp:Label>

        <p>
            <asp:RequiredFieldValidator ID="occupationValidator" runat="server" ControlToValidate="occupationtxt" ErrorMessage="You Must Enter Your Occupation!" ForeColor="Red" style="z-index: 1; left: 1289px; top: 146px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="emailValidator" runat="server" ControlToValidate="emailtxt" ErrorMessage="You Must Enter Your Email!" ForeColor="Red" style="z-index: 1; left: 159px; top: 250px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="addressValidator" runat="server" ControlToValidate="addresstxt" ErrorMessage="You Must Enter Your City" ForeColor="Red" style="z-index: 1; left: 526px; top: 254px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="phoneValidator" runat="server" ControlToValidate="phonetxt" ErrorMessage="You Must Enter Your Phone Number" ForeColor="Red" style="z-index: 1; left: 875px; top: 255px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="heightValidator" runat="server" ControlToValidate="heighttxt" ErrorMessage="You Must Enter Your Height" ForeColor="Red" style="z-index: 1; left: 1311px; top: 255px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="goalValidator" runat="server" ControlToValidate="goaltxt" ErrorMessage="You Must Enter Your Goal" ForeColor="Red" style="z-index: 1; left: 906px; top: 374px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="descriptionValidator" runat="server" ControlToValidate="descriptiontxt" ErrorMessage="You Must Enter Your Description" ForeColor="Red" style="z-index: 1; left: 1294px; top: 371px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="picValidator" runat="server" ControlToValidate="pictxt" ErrorMessage="You Must Enter Your Photo URL" ForeColor="Red" style="z-index: 1; left: 1030px; top: 505px; position: absolute"></asp:RequiredFieldValidator>
            <asp:Button ID="submitbtn" runat="server" OnClick="submitbtn_Click" style="z-index: 1; left: 814px; top: 763px; position: absolute; height: 43px; width: 145px" Text="Submit" />
            <asp:RequiredFieldValidator ID="birthdayValidator" runat="server" ControlToValidate="birthdaytxt" ErrorMessage="You Must Enter Your Birthday" ForeColor="Red" style="z-index: 1; left: 543px; top: 148px; position: absolute"></asp:RequiredFieldValidator>
            
        </p>

            <asp:Button ID="logoutbtn" runat="server" CssClass="hidden" OnClick="logoutbtn_Click" style="z-index: 1; left: 1414px; top: 5px; position: absolute; height: 32px; width: 61px;" Text="Logout" CausesValidation="False" />

            <asp:TextBox ID="emailtxt" runat="server" style="z-index: 1; left: 180px; top: 283px; position: absolute"></asp:TextBox>
            <asp:RequiredFieldValidator ID="nameValidator" runat="server" ControlToValidate="nametxt" ErrorMessage="You Must Enter Your Name!" ForeColor="Red" style="z-index: 1; left: 153px; top: 136px; position: absolute; height: 18px"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="ageValidator" runat="server" ControlToValidate="agetxt" ErrorMessage="You Must Enter Your Age!" ForeColor="Red" style="z-index: 1; left: 908px; top: 144px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="agetxt" ErrorMessage="Input Must Be Number!" ForeColor="Red" MaximumValue="99" MinimumValue="0" style="z-index: 1; left: 914px; top: 143px; position: absolute"></asp:RangeValidator>

        
        
        <asp:Label ID="namelbl" runat="server" style="z-index: 1; left: 84px; top: 172px; position: absolute" Text="Your Name: "></asp:Label>
        <asp:TextBox ID="nametxt" runat="server" style="z-index: 1; left: 183px; top: 172px; position: absolute"></asp:TextBox>
        <asp:Label ID="birthdaylbl" runat="server" style="z-index: 1; top: 174px; position: absolute; left: 446px; height: 19px; right: 1299px" Text="Your Birthday: "></asp:Label>
        <asp:TextBox ID="birthdaytxt" runat="server" style="z-index: 1; left: 552px; top: 175px; position: absolute"></asp:TextBox>
        <asp:Label ID="agelbl" runat="server" style="z-index: 1; left: 844px; top: 175px; position: absolute" Text="Your Age: "></asp:Label>
        <asp:TextBox ID="agetxt" runat="server" style="z-index: 1; left: 923px; top: 173px; position: absolute"></asp:TextBox>
        <asp:Label ID="occupationlbl" runat="server" style="z-index: 1; left: 1204px; top: 176px; position: absolute; height: 17px" Text="Your Occupation: "></asp:Label>
        <asp:Label ID="emaillbl" runat="server" style="z-index: 1; left: 82px; top: 282px; position: absolute" Text="Your Email: "></asp:Label>
        <asp:TextBox ID="occupationtxt" runat="server" style="z-index: 1; left: 1333px; top: 173px; position: absolute"></asp:TextBox>
        <asp:Label ID="addresslbl" runat="server" style="z-index: 1; left: 450px; top: 278px; position: absolute" Text="Your City"></asp:Label>
        <asp:TextBox ID="addresstxt" runat="server" style="z-index: 1; left: 552px; top: 282px; position: absolute"></asp:TextBox>
        <asp:Label ID="phonelbl" runat="server" style="z-index: 1; left: 841px; top: 284px; position: absolute" Text="Your Phone: "></asp:Label>
        <asp:TextBox ID="phonetxt" runat="server" style="z-index: 1; left: 923px; top: 282px; position: absolute"></asp:TextBox>
        <asp:Label ID="heightlbl" runat="server" style="z-index: 1; left: 1214px; top: 285px; position: absolute" Text="Your Height: "></asp:Label>
        <asp:TextBox ID="heighttxt" runat="server" style="z-index: 1; left: 1332px; top: 283px; position: absolute"></asp:TextBox>
        <asp:Label ID="likelbl" runat="server" style="z-index: 1; left: 59px; top: 401px; position: absolute" Text="What do you like:"></asp:Label>
        <asp:DropDownList ID="liketxt" runat="server" style="z-index: 1; left: 209px; top: 403px; position: absolute; right: 1236px">
            <asp:ListItem>Dog</asp:ListItem>
            <asp:ListItem>Cat</asp:ListItem>
            <asp:ListItem>Games</asp:ListItem>
            <asp:ListItem>Football</asp:ListItem>
            <asp:ListItem>Basketball</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="disliketxt" runat="server" style="z-index: 1; left: 599px; top: 404px; position: absolute">
            <asp:ListItem>Dog</asp:ListItem>
            <asp:ListItem>Cat</asp:ListItem>
            <asp:ListItem>Football</asp:ListItem>
            <asp:ListItem>Basketball</asp:ListItem>
            <asp:ListItem>Baseball</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="dislikelbl" runat="server" style="z-index: 1; left: 419px; top: 403px; position: absolute" Text="What do you dislike:"></asp:Label>
        <asp:Label ID="goallbl" runat="server" style="z-index: 1; left: 772px; top: 403px; position: absolute" Text="What is your goal: "></asp:Label>
        <asp:TextBox ID="goaltxt" runat="server" style="z-index: 1; top: 402px; position: absolute; left: 922px"></asp:TextBox>
        <asp:Label ID="descriptionlbl" runat="server" style="z-index: 1; left: 1175px; top: 404px; position: absolute" Text="Enter Your Description:"></asp:Label>
        <asp:TextBox ID="descriptiontxt" runat="server" style="z-index: 1; left: 1333px; top: 402px; position: absolute"></asp:TextBox>
        <asp:Label ID="piclbl" runat="server" style="z-index: 1; left: 913px; top: 533px; position: absolute" Text="Enter Your Photo URL:"></asp:Label>
        <asp:TextBox ID="pictxt" runat="server" style="z-index: 1; left: 1069px; top: 534px; position: absolute"></asp:TextBox>
        <asp:Label ID="commitmentlbl" runat="server" style="z-index: 1; left: 178px; top: 534px; position: absolute" Text="Please Choose Your Commitment Type: "></asp:Label>
        <asp:DropDownList ID="commitddl" runat="server" style="z-index: 1; left: 435px; top: 534px; position: absolute">
            <asp:ListItem>One Night</asp:ListItem>
            <asp:ListItem>Sex Friend</asp:ListItem>
            <asp:ListItem>Dating</asp:ListItem>
            <asp:ListItem>1v1</asp:ListItem>
        </asp:DropDownList>
                <asp:GridView ID="gvProfile" runat="server" CssClass="grid" AutoGenerateColumns="False" CellPadding="4" GridLines="None" style="z-index: 1; left: 54px; top: 354px; position: absolute; height: 269px; width: 1366px" ForeColor="#333333" BorderColor="Black" BorderStyle="None">
                    <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="age" HeaderText="Age" />
                <asp:BoundField DataField="birthday" HeaderText="Birthday" SortExpression="birthday" />
                <asp:BoundField DataField="occupation" HeaderText="Occupation" SortExpression="occupation" />
                <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                <asp:BoundField DataField="phone" HeaderText="Phone Number" SortExpression="phone" />
                <asp:BoundField DataField="height" HeaderText="Height" SortExpression="height" />
                <asp:BoundField DataField="favorite" HeaderText="Like" SortExpression="favorite" />
                <asp:BoundField DataField="dislike" HeaderText="Dislike" SortExpression="dislike" />
                <asp:BoundField DataField="goal" HeaderText="Future Goal" SortExpression="goal" />
                <asp:BoundField DataField="commitment" HeaderText="Commitment Type" SortExpression="commitment" />
                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
            </Columns>
                    <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
                <asp:Button ID="deletebtn" runat="server" style="z-index: 1; left: 1091px; top: 220px; position: absolute" Text="Delete And Create New" Font-Size="Large" OnClick="deletebtn_Click" />
        <asp:Button ID="modifybtn" runat="server" Font-Size="Large" OnClick="modifybtn_Click" style="z-index: 1; left: 1244px; top: 112px; position: absolute" Text="Modify" />
        <asp:Image ID="profilePic" runat="server" style="z-index: 1; left: 51px; top: 65px; position: absolute; height: 237px; width: 227px" />
    </form>


</body>
</html>
