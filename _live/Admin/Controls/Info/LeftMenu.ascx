<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="JKParkLaw.Admin.Controls.Info.LeftMenu" %>

<ul class="nav nav-sidebar">
   
        <li>
          <asp:TreeView ID="LeftSiteMap" runat="server" DataSourceID="SiteMapDS" 
                ExpandDepth="2" Width="200px" BorderColor="#75AADB" 
                ondatabound="LeftSiteMap_DataBound"  >
              <NodeStyle ForeColor="#01427d" Font-Names="Arial" Font-Size="16px" height ="35px"/>
                <SelectedNodeStyle Font-Underline="true"  Font-Bold="true" />
                                    
            </asp:TreeView>
            <asp:SiteMapDataSource ID="SiteMapDS" runat="server" SiteMapProvider="AdminSiteMap" />
        </li>  
  
</ul>