<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TindrLogin.aspx.cs" Inherits="Dating_app.Tindr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #accountForm {
            height: 567px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 27px">
            <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ErrorMessage="Username missing!" ControlToValidate="userNametxt" ForeColor="Red" style="z-index: 1; left: 248px; top: 64px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ErrorMessage="Password missing!" ControlToValidate="passWordtxt" ForeColor="#FF3300" style="z-index: 1; left: 249px; top: 102px; position: absolute"></asp:RequiredFieldValidator>
            <asp:Button ID="accountBtn" runat="server" style="z-index: 1; left: 95px; top: 154px; position: absolute; height: 27px;" Text="Create Acount" CausesValidation="False" OnClick="accountBtn_Click" />
            <asp:Label ID="userNamelbl" runat="server" style="z-index: 1; left: 13px; top: 67px; position: absolute; height: 18px" Text="Username: "></asp:Label>
            <asp:Label ID="passWordlbl" runat="server" style="z-index: 1; left: 15px; top: 101px; position: absolute" Text="Password: "></asp:Label>
            <asp:TextBox ID="userNametxt" runat="server" style="z-index: 1; left: 97px; top: 64px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="passWordtxt" runat="server" style="z-index: 1; left: 96px; top: 102px; position: absolute"></asp:TextBox>
            <asp:Button ID="loginBtn" runat="server" style="z-index: 1; left: 16px; top: 155px; position: absolute; height: 26px; width: 54px" Text="Login" OnClick="loginBtn_Click" />
            <asp:Label ID="loginTest" runat="server" style="z-index: 1; left: 614px; top: 257px; position: absolute"></asp:Label>
        </div>
       
        
    </form>
    <form id="accountForm" runat="server">
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
         <asp:TextBox ID="userCreationtxt" runat="server" style="z-index: 1; left: 105px; top: 222px; position: absolute"></asp:TextBox>
         <asp:TextBox ID="passCreationtxt" runat="server" style="z-index: 1; left: 105px; top: 278px; position: absolute"></asp:TextBox>
    </form>
</body>
</html>
