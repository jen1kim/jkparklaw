<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Directions.aspx.cs" Inherits="JKParkLaw.About.Directions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="breadcrumb-wrapper">
             <div class="container">
              <!-- BREADCRUMB -->
              <ol class="breadcrumb">
              <li><a href="default.aspx">홈</a></li>
              <li class="active">상담 예약</li>
            </ol>
                 </div>
           </div>
  <div class="container_bd">
       <div class="row">
          <div class="col-xs-12 col-sm-12 col-md-12">
        
              <div class="container">
                    <div class="row">
                       <div class="cases col-xs-12 col-sm-6 col-md-6">
                              <div class="preview-wrapper">
                                  <table class="table table-striped" runat="server" id="CounselingTable">                    	
                                        <tr>
                                            <td>
                                                <div class="form-group">
                                                    <div class="col-xs-6">
                            	                        <asp:TextBox ID="tbFName" CssClass="form-control" runat="server" placeholder="First Name"></asp:TextBox>
                                                    </div>
                                                    <div class="col-xs-6">
                            	                        <asp:TextBox ID="tbLName" CssClass="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                                                     </div>
                                                 </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                            <td>
                                                <div class="form-group">
                                                    <div class="col-xs-6">
                                                         <asp:TextBox ID="tbEmail" CssClass="form-control" placeholder="Email"  runat="server"/>
                                                     </div>
                                                    <div class="col-xs-6">
                                                        <asp:TextBox ID="tbPhone" MaxLength="12" CssClass="form-control" placeholder="Phone" runat="server"/>
                                                    </div>
                                                </div>
                                             </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div  class="col-xs-12">
                                                   <asp:TextBox ID="tbCounselingType" MaxLength="125" CssClass="form-control" placeholder="Subject" runat="server"/>
                                                 </div>   
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div  class="col-xs-12">
                                                    <textarea id="taCounselingDesc" cols="7" rows="7" runat="server" placeholder="Message" class="form-control"></textarea>
                                                 </div>   
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" 
                                                    onclick="btnSubmit_Click" /></td>
                                        </tr>
                                      <tr>
                                           <td><asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label></td>
                                      </tr>
                                    </table>
                              </div>
                       </div>
                       <div class="cases col-xs-12 col-sm-6 col-md-6">
                              <div class="preview-wrapper">

                	            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="address">
                                <tr>
                               
                                    <td width="70">주소</td>
                                    <td>3699 Wilshire Blvd. Suite 1130, Los Angeles, CA 90010</td>
                                </tr>
                                <tr>
                                    <td>전화번호</td>
                                    <td>213-380-1238</td>
                                </tr>
                                <tr>
                                    <td>팩스</td>
                                    <td>213-380-1288</td>
                                </tr>
                                <tr>
                                    <td class="label">이메일</td>
                                    <td><a href="mailto:jonathan@jkparklaw.com">jonathan@jkparklaw.com</a></td>
                                </tr>
                            </table>
                                 <p>* 좀 더 자세한 경로를 원하시면 지도를 클릭하세요.</p>
                                <a href="http://maps.google.com/maps?q=jonathan+k.+park+3699+Wilshire+Blvd.+Los+Angeles,+CA&gl=us&hl=en&cd=1&ei=OKAdS9aGC462uAPXp-GkBA&ie=UTF8&view=map&cid=5282425120236075241&iwloc=A&ved=0CA8QpQY&sa=X" target="_blank"><img src="<%= this.StylePath %>Images/about_map.png" /></a>
                                <br />
                             </div>
                       </div>
                    </div>
              </div>  
            </div>
         
       </div>
  </div>
  
</asp:Content>
