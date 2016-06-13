<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Section.aspx.cs" Inherits="JKParkLaw.Admin.Catalog.Sections.Section" %>
<%@ MasterType VirtualPath="~/Admin/Admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">

<asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <table class="table">
        <tr>
            <td style="width:250px;" > Section Name</td>
            <td align="left">
                <asp:TextBox  ID="SectionName" runat="server" MaxLength="125" Width="500px" CssClass="form-control">  </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="alternate1" style="width:100px;height:25px;"> Section Desc</td>
            <td align="left">
                <asp:TextBox  ID="SectionDesc" runat="server" MaxLength="125" Width="500px" CssClass="form-control">  </asp:TextBox>
            </td>
        </tr>      
         <tr>
            <td class="alternate1" style="width:100px;height:25px;"> Order</td>
            <td align="left">
                <asp:TextBox  ID="txtorder" runat="server" MaxLength="3" Width="500px" CssClass="form-control">  </asp:TextBox>
            </td>
        </tr>        
        <tr>
            <td>
                Available</td>
            <td>
                <asp:CheckBox ID="SectionAvailable" runat="server"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height:10px">&nbsp;</td>
        </tr>
        <tr>
            <td  >&nbsp;</td>
            <td>
                <asp:Button ID="UpdateDetails" runat="server" Text="Update Details"  ValidationGroup="AddNew" CssClass="btn btn-primary"
                    onclick="UpdateDetails_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
