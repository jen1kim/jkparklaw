<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentsListing.ascx.cs" Inherits="JKParkLaw.Controls.Categories.ContentsListing" %>

<%@ Register src="~/Controls/Categories/CategoryListing.ascx" tagname="CatItem" tagprefix="uc2" %>
<!-- BREADCRUMB -->
<div class="breadcrumb-wrapper">
    <div class="container">
    <ol class="breadcrumb">
      <li><a href="default.aspx">홈</a></li>
      <li class="active"><asp:Label ID="lblCategoryName" runat="server" Text="Category Name"></asp:Label></li>
    </ol>
    </div>
</div>


   <div class="container_bd">
       <div class="row">
          <div class="col-xs-12 col-sm-12 col-md-12">


            <div>
                <div class="tab-container">
                    <ul id="menu" class="tab clearfix">
                       
                        <uc2:CatItem ID="CatItem1" runat="server" />   
                    </ul>
                </div>
                <br />
                <div>
                	<h2><asp:Label ID="lblContentTitle" runat="server" Text="Content Title"></asp:Label></h2>
                    <div class="text" id="ContentDiv" runat="server">
                    	
                    </div>
                    <div class="disclaimer">* 상기내용은 정보제공의 목적으로 쓰여진 일반적인 법률정보이며 법률상담이 아니므로, 이용자가 정보에 근거하여 취한 행동의 결과에 대해 일체의 책임을 지지 않습니다.</div>
                    <div class="clear"></div>
                    <div class="newslist">
                        <asp:Repeater ID="CatRepeater" runat="server">
                        <HeaderTemplate>
                        <table class="table table-striped table-bordered">
                            <tr>
                                <th>제목</th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                              <tr><td><asp:HyperLink ID="hlTitle" runat="server" NavigateUrl='<%# SetLink(Eval("ContentID")) %>'>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                    </asp:HyperLink></td></tr>
                        </ItemTemplate>
                        <FooterTemplate>
                        </table>
                        </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
          </div>
       </div>
  </div>
     
