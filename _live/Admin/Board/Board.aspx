<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Board.aspx.cs" Inherits="JKParkLaw.Admin.Board.Board" %>
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
        
    <table class="table">
        <tr>
            <td  style="width:250px;"> ID</td>
            <td>
                <asp:Label ID="lblUID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td> Category<span class="error">*</span></td>
            <td>
                <asp:DropDownList ID="ddlBoardCatID" runat="server" DataSourceID="DS_BoardCategory_Detail" DataTextField="BoardCategory" DataValueField="BoardCatID" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_ddlBoardCatID" runat="server" ControlToValidate="ddlBoardCatID" InitialValue="0" ErrorMessage="* required field" Display="Dynamic" SetFocusOnError="true" ValidationGroup="Update"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Title<span class="error">*</span></td>
            <td>
                <asp:TextBox  ID="tbBoardTitle" runat="server" MaxLength="125"  CssClass="form-control">  </asp:TextBox>
            </td>
        </tr>
        <tr class="alternate1">
            <td >Description<span class="error">*</span></td>
            <td>
                <FCKeditorV2:FCKeditor Width="800" Height="300" ToolbarSet="EShop" ID="txtBoardContent" runat="server" BasePath="~/Images/js/fckeditor/" AutoDetectLanguage="True"></FCKeditorV2:FCKeditor>
                <br />
                Insert Image to Content:&nbsp;
                <uc:upload id="upload1" runat="server" image_upload_folder="/Files/images/board/" max_size="2048"></uc:upload>
                <asp:Label ID="lblMsgUpload1" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td ><b>Display Order:</b>&nbsp; </td>
            <td class="head">
                <asp:TextBox id="txtBOrder" runat="server" Width="50px" MaxLength="10" CssClass="form-control"></asp:TextBox>
                <asp:CompareValidator id="CompareValidator1" runat="server" ControlToValidate="txtBOrder" Operator="DataTypeCheck" 
                    Type="Integer"  Display="Dynamic" ErrorMessage="Value should be numeric."  ValidationGroup="Update"/>
                <asp:CompareValidator id="CompareValidator2" runat="server" ControlToValidate="txtBOrder" Operator="GreaterThanEqual" ValueToCompare="0"
                    Type="Integer"  Display="Dynamic" ErrorMessage="Value should be a positive number."  ValidationGroup="Update"/>
            </td>
        </tr>
    
        <tr>
            <td style="width:100px">Date<span class="error">*</span></td>
            <td >
            <asp:TextBox ID="ModifiedDate" runat="server"  />
                <ajaxToolkit:CalendarExtender ID="ModifiedCalExtender" runat="server" TargetControlID="ModifiedDate" PopupButtonID="ModImgUrl" Format="MM/dd/yyyy" />
                <asp:ImageButton ID="ModImgUrl" runat="server" 
                    ImageUrl="~/Images/icons/calendar.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ModifiedDate" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>                    
            (MM/dd/yyyy)</td>
        </tr>
        <tr>
             <td>
                * Required fields
            </td>
            <td>
                <asp:Label ID="lblMessage" ForeColor="Red" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btSave" runat="server" Text="Update Message"  ValidationGroup="Update" OnClick="btSave_Click" CssClass="btn btn-primary" /> &nbsp;
                <asp:Button ID="btBack" runat="server" Text="Back to List"  CausesValidation="false" OnClick="btBack_Click" CssClass="btn btn-secondary" />
                
            </td>
        </tr>
    </table>
    
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="upload1" />
            </Triggers>
    </asp:UpdatePanel>

    <asp:SqlDataSource ID="DS_Main" runat="server" CancelSelectOnNullParameter="false"
        ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" SelectCommand="up_board_retrieve" SelectCommandType="StoredProcedure" 
        UpdateCommand="up_board_update" UpdateCommandType="StoredProcedure"
        >
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="UID" Type="Int32" DefaultValue="-1" />
        </SelectParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="lblUID" PropertyName="Text" Name="UID" Type="Int32"/>
            <asp:ControlParameter ControlID="ModifiedDate" PropertyName="Text" Name="ControlDate" Type="DateTime" />
            <asp:ControlParameter ControlID="tbBoardTitle" PropertyName="Text" Name="BoardTitle" Type="String" />
            <asp:ControlParameter ControlID="txtBoardContent" PropertyName="Value" Name="BoardContent" Type="String" />
            <asp:ControlParameter ControlID="txtBOrder" PropertyName="Text" Name="BOrder" Type="Int32"/>
            <asp:ControlParameter ControlID="ddlBoardCatID" PropertyName="SelectedValue" Name="BoardCatID" Type="Int32"/>
        </UpdateParameters>
    </asp:SqlDataSource>    
    <asp:SqlDataSource ID="DS_BoardCategory_Detail" runat="server" CancelSelectOnNullParameter="false"
        ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" SelectCommand="up_boardcategories_retrieveforlistitem" SelectCommandType="StoredProcedure" 
        >
        <SelectParameters>
        </SelectParameters>
    </asp:SqlDataSource>                
</asp:Content>
