<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RootMenu.ascx.cs" Inherits="JKParkLaw.Controls.Site.RootMenu" %>

<div class="logo"><a href="/Default.aspx"><img src="<%= this.StylePath %>Images/blank.gif" width="210" height="80" title="Home" /></a></div>

<div class="top_home"><a href="/Default.aspx"><img src="<%= this.StylePath %>Images/blank.gif" width="42" height="17" title="Home" /></a></div>
<div class="top_contact"><a href="/About/Directions.aspx"><img src="<%= this.StylePath %>Images/blank.gif" width="60" height="17" title="Contact" /></a></div>

<div id="myjquerymenu" class="jquerycssmenu">
    <ul>
        <li>
            <a class="about" href="#"><img src="<%= this.StylePath %>Images/blank.gif" width="75" height="30"/></a>
            <ul>
                <li><a href="/About/Lawyer.aspx">변호사 소개</a></li>
                <li><a href="/About/Directions.aspx">오시는 길</a></li>
            </ul>
        </li>
        <li>
            <a class="services" href="#"><img src="<%= this.StylePath %>Images/blank.gif" width="57" height="30"/></a>
            <ul>
                <li><a href="/Categories/Category.aspx?CategoryID=1">취업이민</a></li>
                <li><a href="/Categories/Category.aspx?CategoryID=2">투자이민</a></li>
                <li><a href="/Categories/Category.aspx?CategoryID=3">소액투자</a></li>
                <li><a href="/Categories/Category.aspx?CategoryID=4">전문직취업</a></li>
                <li><a href="/Categories/Category.aspx?CategoryID=5">가족이민</a></li>
                <li><a href="/Categories/Category.aspx?CategoryID=6">비이민업무</a></li>
                <li><a href="/Categories/Category.aspx?CategoryID=7">시민권신청</a></li>
                <li><a href="/Categories/Category.aspx?CategoryID=46">영주권</a></li>
                <li><a href="/Categories/Category.aspx?CategoryID=8">추방재판 및 이민소송</a></li>
            </ul>
        </li>
        <%--<li><a class="progress" href="/Status/Check.aspx"><img src="<%= this.StylePath %>Images/blank.gif" width="75" height="30" alt="수속진행확인" /></a></li>--%>
        <li><a class="progress" href="/Status/Success.aspx"><img src="<%= this.StylePath %>Images/blank.gif" width="75" height="30" alt="수속진행확인" /></a></li>
        <!--<li><a class="case" href="/Case/Cases.aspx"><img src="<%= this.StylePath %>Images/blank.gif" width="80" height="30" alt="최근승인사례" /></a></li>-->
        <li><a class="email" href="/Email/Counseling.aspx"><img src="<%= this.StylePath %>Images/blank.gif" width="70" height="30" alt="이메일 상담" /></a></li>
        <li><a class="news" href="/News/NewsList.aspx"><img src="<%= this.StylePath %>Images/blank.gif" width="55" height="30" alt="이민뉴스" /></a></li>
        <li><a class="other" href="/Other/OtherList.aspx"><img src="<%= this.StylePath %>Images/blank.gif" width="70" height="30" alt="기타 서비스" /></a></li>
    </ul>
</div>