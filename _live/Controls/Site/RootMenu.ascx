<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RootMenu.ascx.cs" Inherits="JKParkLaw.Controls.Site.RootMenu" %>

   <div class="container">
    <nav class="navbar navbar-default">
        <div class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="/Default.aspx"><img src="/images/logo-jkpark.png" alt="JK Park Law"></a>
          </div>
          <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav navbar-right">
              <li><a href="/About/Lawyer.aspx">변호사소개</a></li>
              <li role="presentation" class="dropdown">
                <a href="#">
                  업무분야<span class="caret"></span>
                </a>
                <ul class="dropdown-menu">
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
              </li>
              <li><a href="/Status/Success.aspx">성공사례</a></li>
              <li><a href="/News/NewsList.aspx">이민뉴스</a></li>
              <li><a href="/Other/OtherList.aspx">프레스</a></li>
              <li><a href="/About/Directions.aspx">상담문의</a></li>
            </ul>
          </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
      </nav>
      </div>
