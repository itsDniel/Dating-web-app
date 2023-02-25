<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tindr.aspx.cs" Inherits="Dating_app.Tindr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tindr</title>
    <link href ="tindr.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous"/>
    <style type="text/css">
        #accountForm {
            height: 567px;
        }
        #myPanel2 {
            height: 562px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="myPanel1" style="height: 645px">          
           
           <asp:Panel ID="Panel1" runat="server" Height="511px" style="z-index: 1; left: 788px; top: 100px; position: absolute; height: 511px; width: 280px">
           
            <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ErrorMessage="Username missing!" ControlToValidate="userNametxt" ForeColor="Red" style="z-index: 1; left: 248px; top: 64px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ErrorMessage="Password missing!" ControlToValidate="passWordtxt" ForeColor="#FF3300" style="z-index: 1; left: 249px; top: 102px; position: absolute"></asp:RequiredFieldValidator>
            <asp:Button ID="accountBtn" runat="server" style="z-index: 1; left: 95px; top: 154px; position: absolute; height: 27px;" Text="Create Acount" CausesValidation="False" OnClick="accountBtn_Click" />
            <asp:Label ID="userNamelbl" runat="server" style="z-index: 1; left: 13px; top: 67px; position: absolute; height: 18px" Text="Username: "></asp:Label>
            <asp:Label ID="passWordlbl" runat="server" style="z-index: 1; left: 15px; top: 101px; position: absolute" Text="Password: "></asp:Label>
            <asp:TextBox ID="userNametxt" runat="server" style="z-index: 1; left: 97px; top: 64px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="passWordtxt" TextMode="Password" runat="server" style="z-index: 1; left: 96px; top: 102px; position: absolute"></asp:TextBox>
            <asp:Button ID="loginBtn" runat="server" style="z-index: 1; left: 16px; top: 155px; position: absolute; height: 26px; width: 54px" Text="Login" OnClick="loginBtn_Click" />
            <asp:Label ID="loginTest" runat="server" style="z-index: 1; left: 279px; top: 82px; position: absolute" Font-Size="Large" ForeColor="Red"></asp:Label>
        </asp:Panel>
               </div>
       
        
    </form>
    <form id="accountForm" runat="server">
        <div id="myPanel2">
        <asp:Panel ID="Panel2" runat="server" Height="511px" style="z-index: 1; left: 777px; top: 74px; position: absolute; height: 511px; width: 472px">
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 15px; top: 51px; position: absolute" Text="Please enter your info"></asp:Label>
        <asp:Label ID="fnamelbl" runat="server" style="z-index: 1; left: 15px; top: 93px; position: absolute" Text="First Name:"></asp:Label>
        <asp:Label ID="lnamelbl" runat="server" style="z-index: 1; left: 14px; top: 128px; position: absolute" Text="Last Name: "></asp:Label>
        <asp:Label ID="emaillbl" runat="server" style="z-index: 1; left: 17px; top: 177px; position: absolute" Text="Email: "></asp:Label>
        <asp:Label ID="useramelbl" runat="server" style="z-index: 1; left: 16px; top: 224px; position: absolute" Text="Username: "></asp:Label>
        <asp:Label ID="passcreationlbl" runat="server" style="z-index: 1; left: 18px; top: 279px; position: absolute" Text="Password"></asp:Label>
        <asp:RequiredFieldValidator ID="fNameValidator" runat="server" ErrorMessage="First Name missing!" ControlToValidate="fNametxt" ForeColor="#FF3300" style="z-index: 1; left: 290px; top: 89px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="emailValidator" runat="server" ErrorMessage="Email is missing!" ControlToValidate="emailtxt" ForeColor="#FF3300" style="z-index: 1; left: 292px; top: 172px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="lNameValidator" runat="server" ErrorMessage="Last Name missing!" ControlToValidate="lNametxt" ForeColor="#FF3300" style="z-index: 1; left: 290px; top: 130px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="passCreationValidator" runat="server" ErrorMessage="Password missing!" ControlToValidate="passCreationtxt" ForeColor="#FF3300" style="z-index: 1; left: 290px; top: 278px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="userCreationValidator" runat="server" ErrorMessage="Username missing!" ControlToValidate="userCreationtxt" ForeColor="#FF3300" style="z-index: 1; left: 289px; top: 222px; position: absolute"></asp:RequiredFieldValidator>
         <asp:Button ID="createAccountbtn" runat="server" style="z-index: 1; left: 22px; top: 329px; position: absolute" Text="Create Account" OnClick="createAccountbtn_Click" />
         <asp:TextBox ID="fNametxt" runat="server" style="z-index: 1; left: 103px; top: 95px; position: absolute"></asp:TextBox>
         <asp:TextBox ID="lNametxt" runat="server" style="z-index: 1; left: 107px; top: 128px; position: absolute"></asp:TextBox>
         <asp:TextBox ID="emailtxt" runat="server" style="z-index: 1; left: 104px; top: 175px; position: absolute"></asp:TextBox>
         <asp:TextBox ID="userCreationtxt" runat="server" style="z-index: 1; left: 105px; top: 222px; position: absolute; right: 1576px;"></asp:TextBox>
         <asp:TextBox ID="passCreationtxt" runat="server" style="z-index: 1; left: 105px; top: 278px; position: absolute"></asp:TextBox>
         <asp:Label ID="uNameAlertlbl" runat="server" ForeColor="Red" style="z-index: 1; left: 290px; top: 220px; position: absolute" Visible="False">Username is already taken!</asp:Label>
        <asp:Button ID="backbtn" runat="server" OnClick="backbtn_Click" style="z-index: 1; left: 172px; top: 330px; position: absolute; width: 108px; height: 22px;" Text="Go Back" CausesValidation="False" />
            
    </asp:Panel>
        </div>
            </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
</body>
</html>
