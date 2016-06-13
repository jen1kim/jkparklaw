<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
Inherits="JKParkLaw.Default" %>

<%@ MasterType VirtualPath="~/Front.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- MAIN -->
   
      <div class="main-banner">
          <div class="flexslider">
            <ul class="slides">
              <li>
                <img src="images/banner.jpg" />
              </li>
            </ul>
          </div>
      </div>

   

      <div class="container">
        <div class="row">
          <div class="cases col-xs-12 col-sm-4 col-md-4">
            <div class="preview-wrapper">
              <h3 class="preview-title">업무 사례</h3>
              <ul class="case-preview list-unstyled">
                    <asp:Repeater ID="CatRepeater" runat="server" >                        
                        <ItemTemplate>
                              <li><asp:HyperLink ID="hlTitle" runat="server" NavigateUrl='<%# SetLink(Eval("UID"),Eval("BoardCatID")) %>'>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("BoardTitle") %>'></asp:Label>
                                    </asp:HyperLink></li>
                        </ItemTemplate>
                        </asp:Repeater>
              </ul>
              <a href="Status/Success.aspx" class="button">View All</a>
              </div>
          </div>

          <div class="recent-news col-xs-12 col-sm-4 col-md-4">
            <div class="preview-wrapper">
              <h3 class="preview-title">최근 이민뉴스</h3>
              <div class="post-preview wrapper">
                    <ul class="case-preview list-unstyled">
                        <asp:PlaceHolder ID="ContentsPlaceHolder" runat="server">
                        </asp:PlaceHolder>
                    </ul>
                    <a href="News/NewsList.aspx" class="button">Read More</a>
              </div>
            </div>
          </div>

          <div class="boards col-xs-12 col-sm-4 col-md-4">
            <div class="preview-wrapper">
              <h3 class="preview-title">업무 분야</h3>
              <ul class="board-preview list-unstyled">
                    <li><a href="/Categories/Category.aspx?CategoryID=1">취업이민</a></li>
                    <li><a href="/Categories/Category.aspx?CategoryID=5">가족초청이민</a></li>
                    <li><a href="/Categories/Category.aspx?CategoryID=2">투자이민</a></li>
                    <li><a href="/Categories/Category.aspx?CategoryID=54">종교사역자이민</a></li>
                    <li><a href="/Categories/Category.aspx?CategoryID=46">영주권업무</a></li>
                    <li><a href="/Categories/Category.aspx?CategoryID=6">비이민업무</a></li>
                    <li><a href="/Categories/Category.aspx?CategoryID=55">공연비자</a></li>
                    <li><a href="/Categories/Category.aspx?CategoryID=7">시민권신청</a></li>                  
                    <li><a href="/Categories/Category.aspx?CategoryID=8">추방재판 및 이민소송</a></li>
                    <li><a href="/Categories/Category.aspx?CategoryID=4">전문직취업</a></li>
                    <li><a href="/Categories/Category.aspx?CategoryID=3">소액투자</a></li>
              </ul>
              <div class="preview-link"></div>
            </div>
          </div>
        </div>
      </div>
   
</asp:Content>
