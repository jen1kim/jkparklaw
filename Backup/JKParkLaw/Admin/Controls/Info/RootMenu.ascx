<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RootMenu.ascx.cs" Inherits="JKParkLaw.Admin.Controls.Info.RootMenu" %>

<table width="100%" height="50" border="0" cellspacing="0" cellpadding="0" class="editTable" >
	<tr>
	    <td style="width:850px">&nbsp; 
            <asp:HyperLink ID="HyperLink1" Font-Bold="true" Font-Size="X-Large" ForeColor="#0404B4" NavigateUrl="~/Default.aspx" runat="server">JKParkLaw.com</asp:HyperLink>
        </td>
        <td valign="bottom" align="right" style="padding: 8 10px 10px 8;">
			<table width="100%" border="0" cellpadding="0" cellspacing="0" class="editTable" >
                <tr >
                    <td align="right" style="height:25px;">
                        <asp:LinkButton ID="btLogOut" CssClass="normalLinks" ForeColor="#0404B4" runat="server" OnClick="btLogOut_Click"><b>Logout</b></asp:LinkButton>                        
                    </td>
             	</tr>
            </table>
	    </td>
  </tr>
</table>