<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Counseling.aspx.cs" Inherits="JKParkLaw.Admin.Email.Counseling" %>

<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">
    <div class="row">
        <span>&nbsp;&nbsp;<asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label></span>
		<table  class="table"  runat="server" id="CounselingTable">
            <tr>
                <td  style="width:250px;">이름 (한글)</td>
                <td>
                    <asp:HiddenField ID="hdlCounselingID" runat="server" />
                    <asp:Label ID="lblKorName" CssClass="form-control"  runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td >이름 (English)</td>
                <td>
                    First Name &nbsp;<asp:Label ID="lblFName" CssClass="form-control"  Width="300px" runat="server"></asp:Label>
                    Last Name &nbsp;<asp:Label ID="lblLName" CssClass="form-control"  Width="300px" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>생년월일</td>
                <td>
                    <asp:Label ID="lblBirthday" CssClass="form-control" Width="300px" runat="server"/> 
                </td>
            </tr>
            <tr>
                <td>주소 (한국)</td>
                <td>
                    <asp:Label ID="lblKorAddress" CssClass="form-control" runat="server"/>
                    <div class="space10"></div>
                    <asp:Label ID="lblKorAddress2" CssClass="form-control" runat="server"/>
                    <div class="space10"></div>
                    우편번호 <asp:Label ID="lblKorZip" CssClass="form-control" runat="server"/> 
                </td>
            </tr>
            <tr>
                <td>주소 (미국)</td>
                <td>
                    <asp:Label ID="lblEngAddress" CssClass="form-control" runat="server"/>
                    <div class="space10"></div>
                    <asp:Label ID="lblEngAddress2" CssClass="form-control" runat="server"/>
                    <div class="space10"></div>
                    City <asp:Label ID="lblCity" CssClass="form-control" runat="server"/>&nbsp;
                    State <asp:Label ID="lblState" CssClass="form-control" runat="server"/>&nbsp;
                    Zip <asp:Label ID="lblZip" CssClass="form-control" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>전화번호 1</td>
                <td><asp:Label ID="lblPhone1" CssClass="form-control" runat="server"/> </td>
            </tr>
            <tr>
                <td>전화번호 2</td>
                <td><asp:Label ID="lblPhone2" CssClass="form-control" runat="server"/> </td>
            </tr>
            <tr>
                <td>이메일</td>
                <td>
                    <asp:Label ID="lblEmail" CssClass="form-control" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>사이트를 알게 된 경로</td>
                <td>
                    <asp:Label ID="lblSitePath" CssClass="form-control" runat="server"/> 
                </td>
            </tr>
            <tr>
                <td>상담신청 유형</td>
                <td>
                    <asp:Label ID="lblCounselingType" CssClass="form-control" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>상담신청 내용</td>
                <td><textarea id="taCounselingDesc" cols="7" rows="10" readonly="readonly" runat="server" Class="form-control"></textarea></td>
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
                <td colspan="2">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Process Status" 
                        onclick="btnUpdate_Click" CssClass="btn btn-primary" />&nbsp; </td>
            </tr>
        </table>
    </div>
</asp:Content>
