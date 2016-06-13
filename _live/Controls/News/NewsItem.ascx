<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsItem.ascx.cs" Inherits="JKParkLaw.Controls.News.NewsItem" %>

    <tr>
        <td class="align-center"><asp:Label ID="lblNewsID" runat="server" Text='<%# Eval("RowNumber") %>'> </asp:Label> </td>
        <td>
            <asp:HyperLink ID="hlTitle" runat="server" NavigateUrl='<%# SetLink(Eval("NewsID")) %>'>
                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("NewsTitle") %>'></asp:Label>
            </asp:HyperLink>
        </td>
        <td class="align-center"><asp:Label ID="lblModified" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Modified")) %>' ></asp:Label> </td>
    </tr>

