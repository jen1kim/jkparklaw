<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="JKParkLaw.Admin.Catalog.Contents.Content" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">
<div class="row">
     <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

            <table class="table">
                <tr>
                    <td  style="width:250px;">
                        Content TiTle</td>
                    <td>
                        <asp:HiddenField ID="hdnContentID" runat="server" />
                        <asp:TextBox  ID="tbContentTitle" runat="server" MaxLength="255"  CssClass="form-control">  </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >Small desc</td>
                    <td><textarea id="SmallDesc" cols="60" rows="3" runat="server" class="form-control"></textarea></td>
                </tr>
                <tr class="alternate1">
                    <td>Description</td>
                    <td>
                        <FCKeditorV2:FCKeditor Width="800" Height="300" ToolbarSet="EShop" ID="BigDescription" runat="server" BasePath="~/Images/js/fckeditor/" AutoDetectLanguage="True"></FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr >
                    <td>Modified</td>
                    <td >
                    <asp:TextBox ID="ModifiedDate" runat="server" />
                        <ajaxToolkit:CalendarExtender ID="ModifiedCalExtender" runat="server" TargetControlID="ModifiedDate" PopupButtonID="ModImgUrl" Format="MM/dd/yyyy" />
                        <asp:ImageButton ID="ModImgUrl" runat="server" 
                            ImageUrl="~/Images/icons/calendar.gif" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ModifiedDate" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>                    
                    </td>
                </tr>
                <tr >
                    <td >Created</td>
                    <td>
                        <asp:TextBox ID="CreatedDate" runat="server" />
                            <ajaxToolkit:CalendarExtender ID="CreatedCalExtender" runat="server" TargetControlID="CreatedDate" PopupButtonID="CreatedImgUrl" Format="MM/dd/yyyy" />
                            <asp:ImageButton ID="CreatedImgUrl" runat="server" 
                                ImageUrl="~/Images/icons/calendar.gif" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CreatedDate" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Hidden</td>
                    <td colspan="3">
                        <asp:CheckBox ID="cbContentHidden" runat="server" />
                    </td>
                </tr>           
                <tr>
                    <td colspan="2">
                        <asp:Button ID="UpdateContent" runat="server" Text="Update Content"  ValidationGroup="AddNew" OnClick="UpdateContent_Click" CssClass="btn btn-primary" />
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                     </td>
                </tr>
            </table>
            <br />
    </ContentTemplate>
    </asp:UpdatePanel>
 </div>   
</asp:Content>
