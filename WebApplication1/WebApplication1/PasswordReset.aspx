<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PasswordReset.aspx.vb" Inherits="WebApplication1.PasswordReset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>reset form</title>
    <link rel="Stylesheet" href="StyleSheetclaim.css"/>
</head>
<body>
<div>
 <h1 id="hreset" style="font-weight: bold; font-style: oblique; color: #000000">Reset Your Password Here</h1>
    <form id="freset" runat="server" style="background-color: #008000">
    <asp:Label ID="Lblinput" runat="server" Text="Enter Username or Email" 
        Font-Bold="True" ForeColor="Black"></asp:Label>
    <br /><br />
    <asp:TextBox ID="Txxnewuser" runat="server"></asp:TextBox>
    <br /><br />
    
        <asp:Label ID="Lblpass" runat="server" Text="New Password" Font-Bold="True" 
        ForeColor="Black"></asp:Label>
         <br /><br />
        <asp:TextBox ID="Txtconfirmpassword" runat="server" TextMode="Password" 
        ForeColor="Black"></asp:TextBox>
     <br /><br />
 <asp:Label ID="Lblnew" runat="server" Text="Confirm New Password" Font-Bold="True" 
        ForeColor="Black" ></asp:Label>
     <br /><br />
    <asp:TextBox ID="Txtnewpass" runat="server" TextMode="Password" 
        ForeColor="Black"></asp:TextBox>
     <br /><br />
    <asp:Button ID="BtnReset" runat="server" Text="Reset" Font-Bold="True" 
        ForeColor="Black" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnReset0" runat="server" Text="HOME" Font-Bold="True" 
        ForeColor="Black" />
    </form>
     </div>
</body>
</html>
