<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Lawyer.aspx.cs" Inherits="JKParkLaw.About.Lawyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div id="main" class="about">
            	<img src="<%= this.StylePath %>Images/hd_about_lawyer.png" />
                <div class="hr"></div>
                <br />
                <img src="<%= this.StylePath %>Images/about_Jpark.jpg" class="pic" />
                <img src="<%= this.StylePath %>Images/about_greetings.png" class="right" />
                <div class="clear"></div>
                <img src="<%= this.StylePath %>Images/hd_about_profile.png" />
                <div class="hr"></div>
                <br />
                <img src="<%= this.StylePath %>Images/about_profile.jpg" class="left" />
                <img src="<%= this.StylePath %>Images/about_profile.png" class="right" />
                <div class="clear"></div>
                <br />
				<br />
            </div>

</asp:Content>
