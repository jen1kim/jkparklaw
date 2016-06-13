<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentsListing.ascx.cs" Inherits="JKParkLaw.Controls.Categories.ContentsListing" %>

            <div id="main" class="about">
            	<h1 class="bg"><asp:Label ID="lblCategoryName" runat="server" Text="Category Name"></asp:Label></h1>
                <div class="hr"></div>
                <br />
                <div class="menu">
                    <ul>
                        <asp:PlaceHolder ID="ContentsPlaceHolder" runat="server">
                        </asp:PlaceHolder>
                    </ul>
                    <div class="clear"></div>
                </div>
                <br />
                <div class="read">
                	<h2><asp:Label ID="lblContentTitle" runat="server" Text="Content Title"></asp:Label></h2>
                    <div class="text" id="ContentDiv" runat="server">
                    	
                    </div>
                    <div class="disclaimer">* 상기내용은 정보제공의 목적으로 쓰여진 일반적인 법률정보이며 법률상담이 아니므로, 이용자가 정보에 근거하여 취한 행동의 결과에 대해 일체의 책임을 지지 않습니다.</div>
                </div>
            </div>
