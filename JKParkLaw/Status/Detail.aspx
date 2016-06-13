<%@ Page Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="JKParkLaw.Status.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <div class="breadcrumb-wrapper">
             <div class="container">
              <!-- BREADCRUMB -->
            <ol class="breadcrumb">
              <li><a href="default.aspx">홈</a></li>
              <li class="active">케이스 성공사례</li>
            </ol>
                </div>
           </div>
     <div class="container_bd">
       <div class="row">
          <div class="col-xs-12 col-sm-12 col-md-12">
           
            <div class="content">
                <div class="tab-container">
                    <ul id="menu" class="tab clearfix">                       
                         <li> <a href="Success.aspx?cat=1" class='<%= Request.QueryString["cat"] != null ? (Request.QueryString["cat"].ToString() == "1" || Request.QueryString["cat"].ToString() == "" ? "active" : "") : "active" %>'>이민/비이민</a></li>
                         <li> <a href="Success.aspx?cat=2" class='<%= Request.QueryString["cat"] != null ? (Request.QueryString["cat"].ToString() == "2" ? "active" : "") : "" %>'>추방재판</a></li>
                         <li><a href="Success.aspx?cat=3" class='<%= Request.QueryString["cat"] != null ? (Request.QueryString["cat"].ToString() == "3" ? "active" : "") : "" %>'>형사기록 시민권신청</a></li>
                    </ul>
                </div>
               
                <div  class="well well-lg">
                    <!-- BOARD DETAIL -->
                    <asp:FormView ID="fDetail" runat="server" DataSourceID="DS_Main">
                        <ItemTemplate>
    
                            <div class="boardDetail">
                            <table cellpadding="0" cellspacing="0">
                                <thead>
                                <tr>
                                    <th width="90%"><%# Eval("BoardTitle") %></th>
                                    <th width="10%" style="text-align:right"><%# string.Format("{0:d}", Eval("ControlDate")) %></th>
                                </tr>
                                </thead>
                
                                <tbody>
                                <tr>
                                    <td colspan="2">
                    	                <div style="width:653px">
						                <%# Eval("BoardContent") %>
                                        </div>
                                    </td>
                                </tr>
                                </tbody>
                            </table>
                         <!--   <asp:HyperLink ID="hlList" runat="server" NavigateUrl="~/Status/Success.aspx?cat=1">
                                <img src="../App_Themes/Front_Theme/Images/btn_viewlist.png" alt="View List" />
                            </asp:HyperLink> -->
            
                            </div>    
                        </ItemTemplate>
                    </asp:FormView>
                </div> 

                <div class="newslist"> 
                    
                    <!-- BOARD LIST -->
                    <asp:GridView ID="gridList" runat="server" AutoGenerateColumns="False"  AllowPaging="true" PageSize="15"
                        Width="100%"  DataKeyNames="UID" class="table table-striped table-bordered" DataSourceID="DS_List" OnDataBound="gridList_DataBound" 
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
             
            </div>
          </div>
       </div>
  </div>

<asp:SqlDataSource ID="DS_Main" runat="server" CancelSelectOnNullParameter="false"
ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" SelectCommand="up_board_retrieve" SelectCommandType="StoredProcedure" 
>
    <SelectParameters>
        <asp:QueryStringParameter QueryStringField="cat" Name="BoardCatID" Type="Int32" DefaultValue="0" />
        <asp:QueryStringParameter QueryStringField="id" Name="UID" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>    

<asp:SqlDataSource ID="DS_List" runat="server" CancelSelectOnNullParameter="false"
ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" SelectCommand="up_board_retrieve" SelectCommandType="StoredProcedure" 
>
    <SelectParameters>
        <asp:QueryStringParameter QueryStringField="cat" Name="BoardCatID" Type="Int32" DefaultValue="0" />
    </SelectParameters>
</asp:SqlDataSource>    
</asp:Content>
