<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Other.aspx.cs" Inherits="JKParkLaw.Admin.Other.Other" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register TagPrefix="uc" TagName="upload" Src="~/Admin/Controls/Common/img_uploader.ascx" %>

<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">

<asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
    <table class="editTable">
        <tr>
            <td colspan="2" class="head"><strong>Update Item Details
            </td>
        </tr>
        <tr>
            <td  style="width:100px;height:25px;"> ID</td>
            <td>
                <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="width:100px;height:25px;"> Title<span class="error">*</span></td>
            <td>
                <asp:TextBox  ID="tbTitle" runat="server" MaxLength="255" Width="500px" CssClass="editInput">  </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  style="width:100px;height:25px;"> Source</td>
            <td>
                <asp:TextBox  ID="tbSource" runat="server" MaxLength="125" Width="500px" CssClass="editInput">  </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  style="width:100px;height:25px;"> Author</td>
            <td>
                <asp:TextBox  ID="tbAuthor" runat="server" MaxLength="50" Width="300px" CssClass="editInput">  </asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="editTable">
        <tr>
            <td colspan="2" class="head"><b>Descriptions</b></td>
        </tr>
        <tr style="display:none;">
            <td style="width:100px">Small Desc</td>
            <td><textarea id="SmallDesc" cols="60" rows="3" runat="server"></textarea></td>
        </tr>
        <tr class="alternate1">
            <td  style="width:100px">Description<span class="error">*</span></td>
            <td>
                <FCKeditorV2:FCKeditor Width="600" Height="300" ToolbarSet="EShop" ID="BigDesc" runat="server" BasePath="~/Images/js/fckeditor/" AutoDetectLanguage="True"></FCKeditorV2:FCKeditor>
                <br />
                Insert Image to Content:&nbsp;
                <uc:upload id="upload1" runat="server" image_upload_folder="/Files/images/other/" max_size="2048"></uc:upload>
                <asp:Label ID="lblMsgUpload1" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
    <br />
    <table class="editTable">
         <tr >
            <td style="width:100px;height:25px;">
                Hidden</td>
            <td>
                <asp:CheckBox ID="cbHidden" runat="server" />
            </td>
            <td style="width:100px">Modified<span class="error">*</span></td>
            <td >
            <asp:TextBox ID="ModifiedDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="ModifiedCalExtender" runat="server" TargetControlID="ModifiedDate" PopupButtonID="ModImgUrl" Format="MM/dd/yyyy" />
                <asp:ImageButton ID="ModImgUrl" runat="server" 
                    ImageUrl="~/Images/icons/calendar.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ModifiedDate" ValidationGroup="Update">*</asp:RequiredFieldValidator>                    
            </td>
        </tr>
        
        <tr>
            <td style="width:100px;">
               &nbsp;</td>
            <td colspan="3">
                <asp:Label ID="lblMessage" ForeColor="Red" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100px;height:25px;">
               &nbsp;</td>
            <td colspan="3">
                * Required fields
            </td>
        </tr>
    </table>
    <br />
    <table class="editTable">
        <tr>
            <td style="width:100px">&nbsp;</td>
            <td>
                <asp:Button ID="UpdateOther" runat="server" Text="Update Item"  ValidationGroup="Update" OnClick="UpdateContent_Click" CssClass="commandButton" />
            </td>
        </tr>
    </table>
    
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="upload1" />
            </Triggers>
    </asp:UpdatePanel>

</asp:Content>
