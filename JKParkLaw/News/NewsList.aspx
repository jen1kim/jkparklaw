<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="JKParkLaw.News.NewsList" %>

<%@ Register src="~/Controls/News/NewsItem.ascx" tagname="NewsItem" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="breadcrumb-wrapper">
             <div class="container">
              <!-- BREADCRUMB -->
            <ol class="breadcrumb">
              <li><a href="default.aspx">홈</a></li>
              <li class="active">이민뉴스</li>
            </ol>
   </div>
           </div>
     <div class="container_bd">
       <div class="row">
          <div class="col-xs-12 col-sm-12 col-md-12">
           

            <div class="content">
                <div  class="well well-lg">
                	<div>
                    	<h3><asp:Label ID="lblNewsTitle" runat="server" Text=""></asp:Label></h3>
                        <p><asp:Label ID="lblNewsDate" runat="server" Text=""></asp:Label></p>
                    	
                        <div class="clear"></div>
                    </div>
                    <div class="text" id="NewsContentDiv" runat="server">
                    
                    </div>
                </div>
                <div class="newslist">
                    <asp:Repeater ID="NewsRepeater" runat="server">
                    <HeaderTemplate>
                    <table class="table table-striped table-bordered" width="100%">
                        <tr>
                            <th width="80">번호</th>
                            <th>제목</th>
                            <th width="100">등록일</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <uc2:NewsItem ID="NewsItem1" runat="server" />   
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="paging">
                     <asp:HyperLink ID="firstLink" runat="server"  Visible="False">
                     <asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/Front_Theme/images/icon_arrow_first.gif" /></asp:HyperLink>
                     <asp:HyperLink ID="previousLink" runat="server"  Visible="False">
                     <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/Front_Theme/images/icon_arrow_prev.gif" /></asp:HyperLink>
                     &nbsp;<asp:Label ID="pagingLabel" runat="server" Visible="false"></asp:Label>&nbsp;
                     <asp:HyperLink ID="nextLink" runat="server" Visible="False">
                     <asp:Image ID="Image4" runat="server" ImageUrl="~/App_Themes/Front_Theme/images/icon_arrow_next.gif" /></asp:HyperLink>
                     <asp:HyperLink ID="lastLink" runat="server" Visible="False">
                     <asp:Image ID="Image5" runat="server" ImageUrl="~/App_Themes/Front_Theme/images/icon_arrow_last.gif" /></asp:HyperLink>
                </div>  
            </div>
          </div>
       </div>
  </div>
     

</asp:Content>
