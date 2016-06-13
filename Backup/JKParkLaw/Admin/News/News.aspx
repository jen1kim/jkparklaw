<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="JKParkLaw.Admin.News.News" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


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
            <td colspan="2" class="head"><strong>Update News Details
            </td>
        </tr>
        <tr>
            <td  style="width:100px;height:25px;"> News ID</td>
            <td>
                <asp:Label ID="lblNewsID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="width:100px;height:25px;"> Title<span class="error">*</span></td>
            <td>
                <asp:TextBox  ID="tbNewsTitle" runat="server" MaxLength="125" Width="500px" CssClass="editInput">  </asp:TextBox>
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
                <asp:TextBox  ID="tbAuthor" runat="server" MaxLength="125" Width="300px" CssClass="editInput">  </asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="editTable">
        <tr>
            <td colspan="2" class="head"><b>Descriptions</b></td>
        </tr>
        <tr>
            <td style="width:100px">Small desc</td>
            <td><textarea id="SmallDesc" cols="60" rows="3" runat="server"></textarea></td>
        </tr>
        <tr class="alternate1">
            <td  style="width:100px">Description<span class="error">*</span></td>
            <td>
                <FCKeditorV2:FCKeditor Width="600" Height="300" ToolbarSet="EShop" ID="BigDescription" runat="server" BasePath="~/Images/js/fckeditor/" AutoDetectLanguage="True"></FCKeditorV2:FCKeditor>
            </td>
        </tr>
    </table>
    <br />
    <table class="editTable">
         <tr >
            <td style="width:100px;height:25px;">
                Hidden</td>
            <td>
                <asp:CheckBox ID="cbNewsHidden" runat="server" />
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
                <asp:Button ID="UpdateNews" runat="server" Text="Update News"  ValidationGroup="Update" OnClick="UpdateNewsContent_Click" CssClass="commandButton" />
            </td>
        </tr>
    </table>
    
            </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
