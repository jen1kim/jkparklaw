<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="JKParkLaw.Admin.Controls.Info.LeftMenu" %>

    <table cellpadding="0" cellspacing="0" width="220px" align="center" style="background-color:#FFFFFF">
        <tr>
            <td width="8"></td>
			<td align="center" valign="middle" width="204px" height="29" background='<%= this.MasterPage.AppPath %>App_Themes/Admin_Theme/Images/bara_m_b.jpg' class="style14Ba_back">
			    <img src="<%= this.MasterPage.AppPath %>App_Themes/Admin_Theme/Images/ico1_tab.jpg" width="15" height="17" style="padding-left:10px" align="absmiddle"> 
			    <span style="padding-left:20px; padding-right:60px" >Contents</span>
			</td>
			<td width="8"></td>
        </tr>
		<tr>
			<td colspan="3" style="padding:2px 0px 3px 0px" >
				<table cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" align="center" class="case_a" width="204" >
		    	    <tr>
				        <td align ="left">
                            <asp:TreeView ID="LeftSiteMap" runat="server" DataSourceID="SiteMapDS" 
                                ExpandDepth="2" Width="200px" BorderColor="#75AADB" 
                                ondatabound="LeftSiteMap_DataBound"  >
                                <NodeStyle ForeColor="#01427d"  Font-Names="Arial" Font-Size="12px" />
                                <SelectedNodeStyle Font-Underline="true"  Font-Bold="true" />
                                    
                            </asp:TreeView>
                            <asp:SiteMapDataSource ID="SiteMapDS" runat="server" SiteMapProvider="AdminSiteMap" />
					    </td>
                    </tr>
                </table>
			</td>
		</tr>
    </table>
