<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Counseling.aspx.cs" Inherits="JKParkLaw.Email.Counseling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div id="main" class="about">
            	<img src="../App_Themes/Front_Theme/Images/hd_email.png" />
                <div class="hr"></div>
                <div class="email">
                    <span>&nbsp;&nbsp;<asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label></span>
					<table border="0" cellspacing="0" cellpadding="0" runat="server" id="CounselingTable">
                    	<tr>
                        	<td colspan="2" class="note">* 모든 항목을 빠짐없이 기입하여 주시기 바랍니다. 주소는 한국과 미국 중 한군데 주소만 기입하셔도 됩니다.</td>
                        </tr>
                        <tr>
                            <td class="label">이름 (한글)</td>
                            <td>
                                <asp:TextBox ID="tbKorName" CssClass="txtsingle" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="label">이름 (English)</td>
                            <td>
                            	First Name &nbsp;<asp:TextBox ID="tbFName" CssClass="txtsingle" runat="server"></asp:TextBox>
                            	Last Name &nbsp;<asp:TextBox ID="tbLName" CssClass="txtsingle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>생년월일</td>
                            <td>
                            	<asp:TextBox ID="tbYear" CssClass="txtsingle w50" runat="server"/> 년 &nbsp;&nbsp;
                                <asp:TextBox ID="tbMonth" CssClass="txtsingle w30" runat="server"/> 월 &nbsp;&nbsp;
                                <asp:TextBox ID="tbDay" CssClass="txtsingle w30" runat="server"/> 일 &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>주소 (한국)</td>
                            <td>
                            	<asp:TextBox ID="tbKorAddress" CssClass="txtsingle w350" runat="server"/>
                                <div class="space10"></div>
                                <asp:TextBox ID="tbKorAddress2" CssClass="txtsingle w350" runat="server"/>
                                <div class="space10"></div>
                                우편번호 <asp:TextBox ID="tbKorZip1" MaxLength="3" CssClass="txtsingle w50" runat="server"/> - <asp:TextBox ID="tbKorZip2" MaxLength="3" CssClass="txtsingle w50" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td>주소 (미국)</td>
                            <td>
                            	<asp:TextBox ID="tbEngAddress" CssClass="txtsingle w350" runat="server"/>
                                <div class="space10"></div>
                                <asp:TextBox ID="tbEngAddress2" CssClass="txtsingle w350" runat="server"/>
                                <div class="space10"></div>
                                City <asp:TextBox ID="tbCity" CssClass="txtsingle w120" runat="server"/>&nbsp;
                                State <asp:TextBox ID="tbState" CssClass="txtsingle w50" runat="server"/>&nbsp;
                                Zip <asp:TextBox ID="tbZip" CssClass="txtsingle w50" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td>전화번호 1</td>
                            <td><asp:TextBox ID="tbPhone11" MaxLength="3" CssClass="txtsingle w50" runat="server"/> - <asp:TextBox ID="tbPhone12" MaxLength="3" CssClass="txtsingle w50" runat="server"/>  - <asp:TextBox ID="tbPhone13" MaxLength="4" CssClass="txtsingle w50" runat="server"/></td>
                        </tr>
                        <tr>
                            <td>전화번호 2</td>
                            <td><asp:TextBox ID="tbPhone21" MaxLength="3" CssClass="txtsingle w50" runat="server"/> - <asp:TextBox ID="tbPhone22" MaxLength="3" CssClass="txtsingle w50" runat="server"/>  - <asp:TextBox ID="tbPhone23" MaxLength="4" CssClass="txtsingle w50" runat="server"/></td>
                        </tr>
                        <tr>
                            <td>이메일</td>
                            <td>
                            	<asp:TextBox ID="tbEmail1" CssClass="txtsingle w100" runat="server"/> @ <asp:TextBox ID="tbEmail2" CssClass="txtsingle w150" runat="server"/>
                                <div class="space10"></div>
                                * 답변을 받을 이메일 주소를 기입하십시오.
                            </td>
                        </tr>
                        <tr>
                            <td>사이트를 알게 된 경로</td>
                            <td>
                                <asp:DropDownList ID="ddlSitePath" CssClass="txtsingle w200" runat="server">
                                    <asp:ListItem Value="Not Selected">선택하세요</asp:ListItem>
                                    <asp:ListItem Value="인터넷 검색">인터넷 검색</asp:ListItem>
                                    <asp:ListItem Value="지인소개">지인소개</asp:ListItem>
                                    <asp:ListItem Value="지면광고">지면광고</asp:ListItem>
                                    <asp:ListItem Value="Other">기타</asp:ListItem>
                                </asp:DropDownList>
                                <div class="space10"></div>
                                <asp:TextBox ID="tbSitePath" MaxLength="125" CssClass="txtsingle w150" runat="server"/> * 선택이 기타일 경우 입력하세요.
                            </td>
                        </tr>
                        <tr>
                            <td>상담신청 유형</td>
                            <td>
                                <asp:DropDownList ID="ddlCounselingType" runat="server">
                                    <asp:ListItem Value="Not Selected">선택하세요</asp:ListItem>
                                    <asp:ListItem Value="이민수속전 질문">이민수속전 질문</asp:ListItem>
                                    <asp:ListItem Value="이민수속중 질문">이민수속중 질문</asp:ListItem>
                                    <asp:ListItem Value="이민수속후 질문">이민수속후 질문</asp:ListItem>
                                    <asp:ListItem Value="초청 관련">초청 관련</asp:ListItem>
                                    <asp:ListItem Value="미국입국 관련">미국입국 관련</asp:ListItem>
                                    <asp:ListItem Value="이민법 관련 질문">이민법 관련 질문</asp:ListItem>
                                    <asp:ListItem Value="Other">기타</asp:ListItem>
                                </asp:DropDownList>
                                <div class="space10"></div>
                                <asp:TextBox ID="tbCounselingType" MaxLength="125" CssClass="txtsingle w150" runat="server"/> * 선택이 기타일 경우 입력하세요.
                            </td>
                        </tr>
                        <tr>
                            <td>상담신청 내용</td>
                            <td><textarea id="taCounselingDesc" cols="7" rows="7" runat="server" class="txtmulti w350"></textarea></td>
                        </tr>
                        <tr>
                        	<td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" 
                                    onclick="btnSubmit_Click" />&nbsp; <asp:Button ID="btnCancel" runat="server" 
                                    Text="CANCEL" onclick="btnCancel_Click" /></td>
                        </tr>
                    </table>

                    <br />
                    <br />
                </div>
            </div>

</asp:Content>
