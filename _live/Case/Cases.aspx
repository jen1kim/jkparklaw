<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Cases.aspx.cs" Inherits="JKParkLaw.Case.Cases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div id="main" class="about">
            	<img src="../App_Themes/Front_Theme/Images/hd_case.png" />
                <div class="hr"></div>
                <br />
                <div class="casestudy">
                	<ul class="caselist">
                        <asp:PlaceHolder ID="ContentsPlaceHolder" runat="server">
                        </asp:PlaceHolder>
                    </ul>
                </div>
            </div>

</asp:Content>
