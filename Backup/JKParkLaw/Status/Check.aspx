<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Check.aspx.cs" Inherits="JKParkLaw.Status.Check" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register src="../Controls/Status/StatusItem.ascx" tagname="StatusItem" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
            <div id="main" class="about">
            	<img src="../App_Themes/Front_Theme/Images/hd_progress.png" />
                <div class="hr"></div>
                <br />
                로그인을 하시면 고객의 케이스진행과정을 확인할 수 있습니다.
                <br />
                <br />
                <div runat="server" id="loginDiv" class="login">
                	<table>
                	    <tr>
                	        <td colspan="2">
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> </td>                	        
                	    </tr>
                	    <tr>
                	        <td class="align-right w70">Client ID </td>
                	        <td><asp:TextBox ID="tbMemberID" CssClass="w200" runat="server"></asp:TextBox></td>
                	    </tr>
                	    <tr>
                	        <td class="align-right">Password </td>
                	        <td><asp:TextBox ID="tbPassword" CssClass="w200" runat="server" TextMode="Password"></asp:TextBox></td>
                	    </tr>
                	    <tr>
                	        <td>&nbsp; </td>
                	        <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Login" OnClick="btnSubmit_Click" /></td>
                	    </tr>
                	</table>
                </div>
                <div runat="server" id="progresslistDiv" visible="false">
                    
                    <asp:Repeater ID="ProgressRepeater" runat="server">
                    <HeaderTemplate>
                    <table width="100%" class="status">
                        <tr>
                            <th width="100">날짜</th>
                            <th>제목</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                         <uc1:StatusItem ID="StatusItem1" runat="server" />
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>
                </div>
                 
            </div>
    </ContentTemplate> 
    </asp:UpdatePanel>
</asp:Content>
