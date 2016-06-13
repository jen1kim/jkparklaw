<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Counseling.aspx.cs" Inherits="JKParkLaw.Admin.Email.Counseling" %>

<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">


            	<h1 class="bg">이메일 상담</h1>
                <div class="hr"></div>
                <div class="email">
                    <br />
                    <span>&nbsp;&nbsp;<asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label></span>
					<table border="0" cellspacing="0" cellpadding="0" runat="server" id="CounselingTable">
                        <tr>
                            <td class="label">이름 (한글)</td>
                            <td>
                                <asp:HiddenField ID="hdlCounselingID" runat="server" />
                                <asp:Label ID="lblKorName" CssClass="txtsingle"  Width="150px" Height="12px" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="label">이름 (English)</td>
                            <td>
                            	First Name &nbsp;<asp:Label ID="lblFName" CssClass="txtsingle"  Width="150px" Height="12px" runat="server"></asp:Label>
                            	Last Name &nbsp;<asp:Label ID="lblLName" CssClass="txtsingle"  Width="150px" Height="12px" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>생년월일</td>
                            <td>
                            	<asp:Label ID="lblBirthday" CssClass="txtsingle w150" Width="150px" Height="12px" runat="server"/> 
                            </td>
                        </tr>
                        <tr>
                            <td>주소 (한국)</td>
                            <td>
                            	<asp:Label ID="lblKorAddress" CssClass="txtsingle w350" Width="350px" Height="12px" runat="server"/>
                                <div class="space10"></div>
                                <asp:Label ID="lblKorAddress2" CssClass="txtsingle w350" Width="350px" Height="12px" runat="server"/>
                                <div class="space10"></div>
                                우편번호 <asp:Label ID="lblKorZip" CssClass="txtsingle w50" Width="50px" Height="12px" runat="server"/> 
                            </td>
                        </tr>
                        <tr>
                            <td>주소 (미국)</td>
                            <td>
                            	<asp:Label ID="lblEngAddress" CssClass="txtsingle w350" Width="350px" Height="12px" runat="server"/>
                                <div class="space10"></div>
                                <asp:Label ID="lblEngAddress2" CssClass="txtsingle w350" Width="350px" Height="12px" runat="server"/>
                                <div class="space10"></div>
                                City <asp:Label ID="lblCity" CssClass="txtsingle w120" Width="120px" Height="12px" runat="server"/>&nbsp;
                                State <asp:Label ID="lblState" CssClass="txtsingle w150" Width="150px" Height="12px" runat="server"/>&nbsp;
                                Zip <asp:Label ID="lblZip" CssClass="txtsingle w50" Width="50px" Height="12px" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td>전화번호 1</td>
                            <td><asp:Label ID="lblPhone1" CssClass="txtsingle w150" Width="150px" Height="12px" runat="server"/> </td>
                        </tr>
                        <tr>
                            <td>전화번호 2</td>
                            <td><asp:Label ID="lblPhone2" CssClass="txtsingle w150" Width="150px" Height="12px" runat="server"/> </td>
                        </tr>
                        <tr>
                            <td>이메일</td>
                            <td>
                            	<asp:Label ID="lblEmail" CssClass="txtsingle w150" Width="150px" Height="12px" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td>사이트를 알게 된 경로</td>
                            <td>
                                <asp:Label ID="lblSitePath" CssClass="txtsingle w150" Width="150px" Height="12px" runat="server"/> 
                            </td>
                        </tr>
                        <tr>
                            <td>상담신청 유형</td>
                            <td>
                                <asp:Label ID="lblCounselingType" CssClass="txtsingle w150" Width="150px" Height="12px" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td>상담신청 내용</td>
                            <td><textarea id="taCounselingDesc" cols="7" rows="10" readonly="readonly" runat="server" class="txtmulti w350"></textarea></td>
                        </tr>
                        <tr>
                            <td>처리 여부</td>
                            <td><asp:CheckBox ID="cbProcessed" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>처리일</td>
                            <td><asp:Label ID="lblProcessedDate" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                        	<td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update Process Status" 
                                    onclick="btnUpdate_Click" CssClass="commandButton" />&nbsp; </td>
                        </tr>
                    </table>

                    <br />
                    <br />
                </div>

</asp:Content>
