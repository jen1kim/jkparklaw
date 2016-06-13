<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Directions.aspx.cs" Inherits="JKParkLaw.About.Directions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div id="main" class="about">
            	<img src="<%= this.StylePath %>Images/hd_about_directions.png" />
                <div class="hr"></div>
                <br />
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="address">
                    <tr>
                        <td width="100" rowspan="4"><img src="<%= this.StylePath %>Images/about_icon.gif" /></td>
                        <td width="70" class="label">주소</td>
                        <td>3699 Wilshire Blvd. Suite 1130, Los Angeles, CA 90010</td>
                    </tr>
                    <tr>
                        <td class="label">전화번호</td>
                        <td>213-380-1238</td>
                    </tr>
                    <tr>
                        <td class="label">팩스</td>
                        <td>213-380-1288</td>
                    </tr>
                    <tr>
                        <td class="label">이메일</td>
                        <td><a href="mailto:jonathan@jkparklaw.com">jonathan@jkparklaw.com</a></td>
                    </tr>
                </table>
                <br />
                <br />
                <p>* 좀 더 자세한 경로를 원하시면 지도를 클릭하세요.</p>
                <a href="http://maps.google.com/maps?q=jonathan+k.+park+3699+Wilshire+Blvd.+Los+Angeles,+CA&gl=us&hl=en&cd=1&ei=OKAdS9aGC462uAPXp-GkBA&ie=UTF8&view=map&cid=5282425120236075241&iwloc=A&ved=0CA8QpQY&sa=X" target="_blank"><img src="<%= this.StylePath %>Images/about_map.png" /></a>
                <br />
                <br />
				<br />
                <br />
            </div>
</asp:Content>
