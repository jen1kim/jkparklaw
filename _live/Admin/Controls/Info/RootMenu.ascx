<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RootMenu.ascx.cs" Inherits="JKParkLaw.Admin.Controls.Info.RootMenu" %>

<nav class="navbar navbar-inverse navbar-fixed-top">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#">JKParkLaw.com</a>
    </div>
    <div id="navbar" class="navbar-collapse collapse">
      <ul class="nav navbar-nav navbar-right">
        <li><asp:LinkButton ID="btLogOut" runat="server" Font-Bold="True" ForeColor="White" onclick="btLogOut_Click">LOG OUT</asp:LinkButton></li>
      </ul>
    </div>
  </div>
</nav>