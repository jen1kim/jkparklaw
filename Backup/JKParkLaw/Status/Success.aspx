<%@ Page Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="JKParkLaw.Status.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../App_Themes/Front_Theme/style.css" rel="stylesheet" type="text/css" />

<!-- add'l paging styles by don -->
<style type="text/css">
	.pagination table tr td { border:0px; text-align:center;}
	.pagination  {font-weight:bold;color:#09c;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="main" class="about">
    <img src="../App_Themes/Front_Theme/Images/hd_success.png" alt="케이스 성공사례" />
    <div class="hr"></div>
    <div class="sort">
    	<a href="Success.aspx?cat=1" class='<%= Request.QueryString["cat"] != null ? (Request.QueryString["cat"].ToString() == "1" || Request.QueryString["cat"].ToString() == "" ? "active" : "") : "active" %>'>이민/비이민</a>
        <a href="Success.aspx?cat=2" class='<%= Request.QueryString["cat"] != null ? (Request.QueryString["cat"].ToString() == "2" ? "active" : "") : "" %>'>추방재판</a>
        <a href="Success.aspx?cat=3" class='<%= Request.QueryString["cat"] != null ? (Request.QueryString["cat"].ToString() == "3" ? "active" : "") : "" %>'>형사기록 시민권신청</a>
        <div class="clear"></div>
    </div>
    
    <asp:GridView ID="gridList" runat="server" AutoGenerateColumns="False"  AllowPaging="true" PageSize="15"
        Width="100%"  DataKeyNames="UID" CssClass="boardList" DataSourceID="DS_Main" OnDataBound="gridList_DataBound" 
        AllowSorting="True" >
        <Columns>
            <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" >
                <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Title" >
                <ItemTemplate>
                    <div style="text-align:left;">
                        <a href='<%# string.Format("Detail.aspx?id={0}&cat={1}", Eval("UID"), Eval("BoardCatID")) %>'>
                        <%# Eval("BoardTitle") %>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:BoundField DataField="ControlDate" HeaderText="Date" ItemStyle-Width="100px" 
                DataFormatString="{0:MM/dd/yyyy}"/>
        </Columns>
        
        <PagerTemplate>
            <div class="pagination">
                <div style="float:left;">
                <asp:LinkButton CommandName="Page" CommandArgument="First"
                    ID="LinkButton2" runat="server"  style="text-decoration:none; font-weight:bold;">
                    <img src="../App_Themes/Front_Theme/Images/btn_paging_prev_end.gif" alt="&lt;" />
                    </asp:LinkButton>
                <asp:LinkButton CommandName="Page" CommandArgument="Prev"
                    ID="LinkButton1" runat="server"  style="text-decoration:none; font-weight:bold;">
                    <img src="../App_Themes/Front_Theme/Images/btn_paging_prev.gif" alt="&lt;" />
                    </asp:LinkButton>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />  
                <asp:LinkButton CommandName="Page" CommandArgument="Next"
                    ID="LinkButton4" runat="server"  style="text-decoration:none; font-weight:bold;">
                    <img src="../App_Themes/Front_Theme/Images/btn_paging_next.gif" alt=">&gt;" /></asp:LinkButton>
                <asp:LinkButton CommandName="Page" CommandArgument="Last"
                    ID="LinkButton3" runat="server"  style="text-decoration:none; font-weight:bold;">
                    <img src="../App_Themes/Front_Theme/Images/btn_paging_next_end.gif" alt=">&gt;" /></asp:LinkButton>
                </div>
                
            </div>
        </PagerTemplate>
        
    </asp:GridView>
</div>

<asp:SqlDataSource ID="DS_Main" runat="server" CancelSelectOnNullParameter="false"
ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" SelectCommand="up_board_retrieve" SelectCommandType="StoredProcedure" 
>
    <SelectParameters>
        <asp:QueryStringParameter QueryStringField="cat" Name="BoardCatID" Type="Int32" DefaultValue="1" />
    </SelectParameters>
</asp:SqlDataSource>    
</asp:Content>
