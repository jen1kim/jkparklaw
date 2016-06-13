<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Counseling.aspx.cs" Inherits="JKParkLaw.Email.Counseling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container_bd">
       <div class="row">
          <div class="col-xs-12 col-sm-12 col-md-12">

              <!-- BREADCRUMB -->
            <ol class="breadcrumb">
              <li><a href="default.aspx">홈</a></li>
              <li class="active">상담예약</li>
            </ol>


            <div class="content">
               <div class="email">
                    <span>&nbsp;&nbsp;<asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label></span>
					<table class="table table-striped" runat="server" id="CounselingTable">
                    	<tr>
                        	<td colspan="2" class="note">* 모든 항목을 빠짐없이 기입하여 주시기 바랍니다. 주소는 한국과 미국 중 한군데 주소만 기입하셔도 됩니다.</td>
                        </tr>
                        <tr>
                            <td width="20%">이름 (한글)</td>
                            <td>
                                <div  class="col-xs-8">
                                    <asp:TextBox ID="tbKorName" CssClass="form-control" runat="server" placeholder="Korean Name"></asp:TextBox>
                                </div>
                             </td>
                        </tr>
                        <tr>
                            <td>이름 (English)</td>
                            <td>
                                <div class="form-group">
                                    <div class="col-xs-4">
                            	        <asp:TextBox ID="tbFName" CssClass="form-control" runat="server" placeholder="First Name"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-4">
                            	        <asp:TextBox ID="tbLName" CssClass="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                                     </div>
                                 </div>
                            </td>
                        </tr>
                        <tr>
                            <td>생년월일</td>
                            <td>
                                <div class="form-group">
                                    <div class="col-xs-2">
                            	        <asp:TextBox ID="tbYear" CssClass="form-control" runat="server" placeholder="년"/>
                                     </div>
                                    <div class="col-xs-2">
                                         <asp:TextBox ID="tbMonth" CssClass="form-control" runat="server" placeholder="월"/>
                                     </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="tbDay" CssClass="form-control" runat="server" placeholder="일"/>
                                     </div>
                                 </div>
                            </td>
                        </tr>
                        <tr>
                            <td>주소 (한국)</td>
                            <td>
                              
                                <div  class="col-xs-8">
                            	    <asp:TextBox ID="tbKorAddress" CssClass="form-control" runat="server"/>
                                </div>
                                <div  class="col-xs-8">
                                    <asp:TextBox ID="tbKorAddress2" CssClass="form-control" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <div class="col-xs-2">
                                            <asp:TextBox ID="tbKorZip1" MaxLength="3" CssClass="form-control" runat="server"/> - 
                                    </div>
                                    <div class="col-xs-2">
                                            <asp:TextBox ID="tbKorZip2" MaxLength="3" CssClass="txtsingle w50" runat="server"/>
                                        </div>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td>주소 (미국)</td>
                            <td>
                                <div  class="col-xs-8">
                            	    <asp:TextBox ID="tbEngAddress" CssClass="form-control" runat="server"/>
                                </div>
                                <div  class="col-xs-8">
                                    <asp:TextBox ID="tbEngAddress2" CssClass="form-control" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <div class="col-xs-2">
                                City    <asp:TextBox ID="tbCity" CssClass="form-control" runat="server"/>
                                    </div>
                                    <div class="col-xs-2">
                                    State <asp:TextBox ID="tbState" CssClass="form-control" runat="server"/>
                                    </div>
                                    <div class="col-xs-2">
                                Zip <asp:TextBox ID="tbZip" CssClass="form-control" runat="server"/>
                                     </div>
                                 </div>
                            </td>
                        </tr>
                        <tr>
                            <td>전화번호 1</td>
                            <td>
                                <div class="form-group">
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="tbPhone11" MaxLength="3" CssClass="form-control" runat="server"/> - 
                                     </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="tbPhone12" MaxLength="3" CssClass="txtsingle w50" runat="server"/>  - 
                                     </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="tbPhone13" MaxLength="4" CssClass="txtsingle w50" runat="server"/>
                                    </div>
                                </div>
                             </td>
                        </tr>
                        <tr>
                            <td>전화번호 2</td>
                            <td>
                                <div class="form-group">
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="tbPhone21" MaxLength="3" CssClass="form-control" runat="server"/> - 
                                     </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="tbPhone22" MaxLength="3" CssClass="txtsingle w50" runat="server"/>  - 
                                     </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="tbPhone23" MaxLength="4" CssClass="txtsingle w50" runat="server"/>
                                    </div>
                                </div>
                           </td>
                        </tr>
                        <tr>
                            <td>이메일</td>
                            <td>
                                <div class="form-group">
                                    <div class="col-xs-4">
                            	        <asp:TextBox ID="tbEmail1" CssClass="form-control" runat="server"/> @ 
                                     </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox ID="tbEmail2" CssClass="txtsingle w150" runat="server"/>
                                    </div>
                                </div>
                                * 답변을 받을 이메일 주소를 기입하십시오.
                            </td>
                        </tr>
                        <tr>
                            <td>사이트를 알게 된 경로</td>
                            <td>
                                <div class="form-group">
                                    <div class="col-xs-4">
                                        <asp:DropDownList ID="ddlSitePath" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="Not Selected">선택하세요</asp:ListItem>
                                            <asp:ListItem Value="인터넷 검색">인터넷 검색</asp:ListItem>
                                            <asp:ListItem Value="지인소개">지인소개</asp:ListItem>
                                            <asp:ListItem Value="지면광고">지면광고</asp:ListItem>
                                            <asp:ListItem Value="Other">기타</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-4">
                                         <asp:TextBox ID="tbSitePath" MaxLength="125" CssClass="form-control" runat="server"/> * 선택이 기타일 경우 입력하세요.
                                     </div>
                                 </div>
                            </td>
                        </tr>
                        <tr>
                            <td>상담신청 유형</td>
                            <td>
                                <div class="form-group">
                                    <div class="col-xs-4">
                                        <asp:DropDownList ID="ddlCounselingType" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="Not Selected">선택하세요</asp:ListItem>
                                            <asp:ListItem Value="이민수속전 질문">이민수속전 질문</asp:ListItem>
                                            <asp:ListItem Value="이민수속중 질문">이민수속중 질문</asp:ListItem>
                                            <asp:ListItem Value="이민수속후 질문">이민수속후 질문</asp:ListItem>
                                            <asp:ListItem Value="초청 관련">초청 관련</asp:ListItem>
                                            <asp:ListItem Value="미국입국 관련">미국입국 관련</asp:ListItem>
                                            <asp:ListItem Value="이민법 관련 질문">이민법 관련 질문</asp:ListItem>
                                            <asp:ListItem Value="Other">기타</asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                        <div class="col-xs-4">
                                             <asp:TextBox ID="tbCounselingType" MaxLength="125" CssClass="form-control" runat="server"/> * 선택이 기타일 경우 입력하세요.
                                        </div>
                                 </div>
                            </td>
                        </tr>
                        <tr>
                            <td>상담신청 내용</td>
                            <td>
                                <div  class="col-xs-8">
                                    <textarea id="taCounselingDesc" cols="7" rows="7" runat="server" class="form-control"></textarea>
                                 </div>   
                            </td>
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
          </div>
       </div>
  </div>

</asp:Content>
