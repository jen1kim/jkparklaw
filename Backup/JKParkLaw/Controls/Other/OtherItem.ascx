<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OtherItem.ascx.cs" Inherits="JKParkLaw.Controls.Other.OtherItem" %>

    <tr>
        <td class="align-center"><asp:Label ID="lblID" runat="server" Text='<%# Eval("RowNumber") %>'> </asp:Label> </td>
        <td>
            <asp:HyperLink ID="hlTitle" runat="server" NavigateUrl='<%# SetLink(Eval("ID")) %>'>
                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
            </asp:HyperLink>
        </td>
        <td class="align-center"><asp:Label ID="lblModified" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Modified")) %>' ></asp:Label> </td>
    </tr>

