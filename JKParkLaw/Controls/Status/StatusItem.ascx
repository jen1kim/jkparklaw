<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusItem.ascx.cs" Inherits="JKParkLaw.Controls.Status.StatusItem" %>

   <tr>
        <td valign="top">
            <asp:Label ID="lblDate" runat="server"  Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Added")) %>'> </asp:Label> 
        </td>
        <td valign="top">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text='<%# Eval("Title") %>'></asp:Label>
            <div class="space5"></div>
            <div id="divSmallDesc" runat="server" style="width:100%;" class="txtmulti"><%# Eval("SmallDesc") %></div>
        </td>
   </tr>