<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JKParkLaw.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Admin Login</title>
</head>
<body onload="document.getElementById('txtMid').focus();">
    <form id="form1" runat="server">
        <div id="container_login" align="center">
        
        <div id="divheader">
            <table width="980" height="85" border="0" cellpadding="0" cellspacing="0" >
                <tr>
                    <td align="left" valign="bottom">&nbsp;</td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table align="center" width="400" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><div class="login_title">LOGIN</div></td>
          </tr>
          <tr>
            <td align="center" style="padding: 30px 0; border: 1px solid #ddd1c8;">
                    <table align="center" cellspacing="0" cellpadding="0" width="340" border="0">
                      <tr valign="middle">
                            <td width="95" align="center" style="FONT-SIZE: 12px; COLOR: Gray; FONT-FAMILY: Arial"><b>User ID</b></td>
                            <td width="245" align="right"><asp:textbox id="txtMid" tabIndex="1" runat="server" MaxLength="20" Width="240px" ></asp:textbox></td>
                      </tr>
                      <tr valign="middle">
                            <td width="95" height="5" align="left"></td>
                            <td width="245" height="5" align="right"></td>
                      </tr>
                      <tr valign="middle">
                            <td width="95" align="center" style="FONT-SIZE: 12px; COLOR: Gray; FONT-FAMILY: Arial"><b>Password</b></td>
                            <td width="245" align="right"><asp:textbox id="txtMpwd" tabIndex="1" runat="server" MaxLength="20" Width="240px" TextMode="Password"></asp:textbox></td>
                      </tr>
                      <tr>
                            <td>&nbsp;</td>
                            <td align="center" valign="bottom" style="padding: 10px 0 0 0;">
                                <asp:button id="btLogin" Text="Enter" tabIndex="2" Runat="server" Width="64px" Height="25px" CssClass="commandButton" OnClick="btLogin_Click">
                            </asp:button></td>
                      </tr>
                    </table>
                    
            </td>
          </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />   
        
       
    </div>
    </form>
</body>
</html>
