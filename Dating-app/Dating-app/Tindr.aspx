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
        .welcomeLogin {
            z-index: 1;
            left: 0px;
            top: 0px;
            position: absolute;
        }
    </style>
</head>
<body>
    <div class="lblLogin">
    <asp:Label ID="welcomelbl" runat="server" Text="Where Your Soulmate Await" ForeColor="White"></asp:Label>
     </div>
    <div class="intro" id="introDiv" runat="server">
        <h1 class="logo-header">
            <span class="logo">Welcome</span> <span class="logo">to Tindr</span>
        </h1>
    </div>
    <form id="form1" runat="server" >

           <div class="login">
           
            <asp:Label ID="loginTest" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
            <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ErrorMessage="Username missing!" ControlToValidate="userNametxt" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ErrorMessage="Password missing!" ControlToValidate="passWordtxt" ForeColor="#FF3300" ValidationGroup="login"></asp:RequiredFieldValidator>
            <asp:Label ID="usernamelbl" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="userNametxt" runat="server" BackColor="White" ValidationGroup="login"></asp:TextBox>
            <asp:Label ID="passwordlbl" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="passWordtxt" TextMode="Password" runat="server" ValidationGroup="login" ></asp:TextBox>
            <asp:Button ID="loginBtn" runat="server" CssClass="btn" Text="Login" OnClick="loginBtn_Click" BackColor="#9900CC" BorderColor="#9900CC" ForeColor="White" ValidationGroup="login" />
            <asp:Button ID="accountBtn" runat="server" CssClass ="btn" Text="Create Acount" CausesValidation="False" OnClick="accountBtn_Click" ValidationGroup="login"/>


        
        </div>
       
        
    </form>
    <form id="accountForm" runat="server"  >
        <div class="account">
       
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 15px; top: 51px; position: absolute" Text="Please enter your info"></asp:Label>
        <asp:Label ID="fnamelbl" runat="server" style="z-index: 1; left: 8px; top: 106px; position: absolute" Text="First Name:"></asp:Label>
        <asp:Label ID="lnamelbl" runat="server" style="z-index: 1; left: 8px; top: 144px; position: absolute" Text="Last Name: "></asp:Label>
        <asp:Label ID="emaillbl" runat="server" style="z-index: 1; left: 27px; top: 188px; position: absolute; height: 19px;" Text="Email: "></asp:Label>
        <asp:Label ID="useramelbl" runat="server" style="z-index: 1; left: 16px; top: 230px; position: absolute" Text="Username: "></asp:Label>
        <asp:Label ID="passcreationlbl" runat="server" style="z-index: 1; left: 18px; top: 279px; position: absolute" Text="Password"></asp:Label>
        <asp:RequiredFieldValidator ID="fNameValidator" runat="server" ErrorMessage="First Name missing!" ControlToValidate="fNametxt" ForeColor="#FF3300" style="z-index: 1; left: 50%; top: 106px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="emailValidator" runat="server" ErrorMessage="Email is missing!" ControlToValidate="emailtxt" ForeColor="#FF3300" style="z-index: 1; left: 50%; top: 187px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="lNameValidator" runat="server" ErrorMessage="Last Name missing!" ControlToValidate="lNametxt" ForeColor="#FF3300" style="z-index: 1; left: 50%; top: 145px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="passCreationValidator" runat="server" ErrorMessage="Password missing!" ControlToValidate="passCreationtxt" ForeColor="#FF3300" style="z-index: 1; left: 50%; top: 284px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="userCreationValidator" runat="server" ErrorMessage="Username missing!" ControlToValidate="userCreationtxt" ForeColor="#FF3300" style="z-index: 1; left: 50%; top: 234px; position: absolute"></asp:RequiredFieldValidator>
         <asp:Button ID="createAccountbtn" runat="server" CssClass="btn" style="z-index: 1; left: 22px; top: 329px; position: absolute" Text="Create Account" OnClick="createAccountbtn_Click" BackColor="#9900CC" BorderColor="#9900CC" ForeColor="White" />
         <asp:TextBox ID="fNametxt" runat="server" style="z-index: 1; left: 101px; top: 104px; position: absolute"></asp:TextBox>
         <asp:TextBox ID="lNametxt" runat="server" style="z-index: 1; left: 103px; top: 143px; position: absolute"></asp:TextBox>
         <asp:TextBox ID="emailtxt" runat="server" style="z-index: 1; left: 105px; top: 184px; position: absolute"></asp:TextBox>
         <asp:TextBox ID="userCreationtxt" runat="server" style="z-index: 1; left: 105px; top: 230px; position: absolute; right: 239px;"></asp:TextBox>
         <asp:TextBox ID="passCreationtxt" runat="server" style="z-index: 1; left: 105px; top: 278px; position: absolute; width: 161px;"></asp:TextBox>
         <asp:Label ID="uNameAlertlbl" runat="server" ForeColor="Red" style="z-index: 1; left: 288px; top: 234px; position: absolute" Visible="False">Username is already taken!</asp:Label>
        <asp:Button ID="backbtn" runat="server" CssClass="btn" OnClick="backbtn_Click" style="z-index: 1; left: 172px; top: 327px; position: absolute; width: 117px; height: 31px;" Text="Go Back" CausesValidation="False" BackColor="#9900CC" BorderColor="#9900CC" ForeColor="White" />
            
    
        </div>
            </form>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
</body>
</html>
