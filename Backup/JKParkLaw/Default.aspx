<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
Inherits="JKParkLaw.Default" %>

<%@ MasterType VirtualPath="~/Front.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div id="main">
                <div class="intro">
                	<h1>조나단 박 변호사 법률 그룹은...</h1>
                    <p>이민법 전문 변호사로서 정직과 신뢰를 바탕으로 고객님께서 당면하신 법률문제의 해결을 위해 성실하게 도와드리고 있습니다.</p>
                    <span class="readmore"><a href="/About/Lawyer.aspx"><img src="./App_Themes/Front_Theme/Images/blank.gif" width="150" height="20" title="Read More About Us" /></a></span>
                </div>
				<div class="hr"></div>
                <div class="latestnews">
                	<img src="./App_Themes/Front_Theme/Images/news_hd.jpg" alt="Latest News" />
                    <ul>
                        <asp:PlaceHolder ID="ContentsPlaceHolder" runat="server">
                        </asp:PlaceHolder>
                    </ul>
                </div>
                <ul class="links">
                	<li><a href="http://www.infopass.uscis.gov" target="_blank"><img src="./App_Themes/Front_Theme/Images/blank.gif" width="155" height="40" title="미국 이민국 예약 및 예약 취소" /></a></li>
                    <li>
                    <a href="http://travel.state.gov/visa/bulletin/bulletin_1360.html" target="_blank"><img src="./App_Themes/Front_Theme/Images/blank.gif" width="155" height="40" title="Visa Bulletin" /></a>
                    </li>
                    <li><a href="http://www.uscis.gov/portal/site/uscis" target="_blank"><img src="./App_Themes/Front_Theme/Images/blank.gif" width="155" height="40" title="USCIS 미국 이민국" /></a></li>
                </ul>
            </div>

</asp:Content>
