<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="JKParkLaw.Admin.Catalog.Contents.AddContent" %>

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
            <td class="head"><strong>Select Master Section </strong></td>
            <td colspan="2" class="headComplete">    
                <asp:DropDownList ID="SectionsDD" runat="server" AutoPostBack="True" 
                    AppendDataBoundItems="true" CssClass="select" Width="200px"
                    DataSourceID="SectionsDS" DataTextField="CategoryName" 
                    DataValueField="CategoryID" 
                    onselectedindexchanged="SectionsDD_SelectedIndexChanged" >
                    <asp:ListItem Selected="True" Value="0">Select Master Section ...</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SectionsDS" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" 
                    SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories] WHERE ([ParentID] = @ParentID)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="ParentID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;
                <strong>Selected Master Section: 
                    <asp:Label ID="lblSelectedSection" runat="server" ForeColor="Red" Text=""></asp:Label></strong>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
             <td colspan="3" class="secondHead">
                &nbsp;&nbsp;&nbsp;<b>Categories</b>&nbsp;&nbsp;>&nbsp;Selected Category:&nbsp;
                <asp:Label ID="selectedCategory" runat="server" ForeColor="#F62217" Text=""></asp:Label>
                <asp:HiddenField ID="hdnCategoryID" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
            <asp:GridView ID="CategoryGrid" runat="server" AllowPaging="True" AllowSorting="True"   
                    AutoGenerateColumns="False" Width="100%" DataKeyNames="CategoryID" 
                    SkinID="Gridview" SelectedRowStyle-Font-Bold="true" AutoGenerateSelectButton="true" 
                    OnSelectedIndexChanged="CategoryGrid_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Name" />
                    <asp:BoundField DataField="CategoryDesc" HeaderText="Desc" />
                    <asp:BoundField DataField="CategoryAvailable" HeaderText="Available"  />
                </Columns>            
            </asp:GridView>
            <asp:SqlDataSource ID="GetFieldsDataSource" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>"             
                    SelectCommand="E_GetCategories" SelectCommandType="StoredProcedure" >
                    <SelectParameters>
                        <asp:Parameter Name="SectionID" Type="Int32"/>
                    </SelectParameters>
            </asp:SqlDataSource>    
            </td>
        </tr>
    </table>
    <br />
    <table class="editTable">
        <tr>
            <tdstyle="width:100px">&nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
             </td>
        </tr>
        <tr>
            <tdstyle="width:100px">&nbsp;</td>
            <td colspan="2">
                * Please click 'Select' to add content. 
             </td>
        </tr>
    </table>
    <br />
    <table class="editTable">
        <tr>
            <td colspan="2" class="head"><strong>Add New Content To: 
                <asp:Label ID="lblSelectedCategory" runat="server" ForeColor="Red" Text=""></asp:Label></strong></td>
        </tr>
        <tr>
            <td  style="width:100px;height:25px;">
                Content TiTle<span class="error">*</span></td>
            <td>
                <asp:TextBox  ID="tbContentTitle" runat="server" MaxLength="255" Width="500px" CssClass="editInput">  </asp:TextBox>
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
            <td  style="width:100px">Description</td>
            <td>
                <FCKeditorV2:FCKeditor Width="600" Height="300" ToolbarSet="EShop" ID="BigDescription" runat="server" BasePath="~/Images/js/fckeditor/" AutoDetectLanguage="True"></FCKeditorV2:FCKeditor>
            </td>
        </tr>
    </table>
    <br />
    <table class="editTable">
        <tr >
            <td style="width:100px">Modified</td>
            <td >
            <asp:TextBox ID="ModifiedDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="ModifiedCalExtender" runat="server" TargetControlID="ModifiedDate" PopupButtonID="ModImgUrl" Format="MM/dd/yyyy" />
                <asp:ImageButton ID="ModImgUrl" runat="server" 
                    ImageUrl="~/Images/icons/calendar.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ModifiedDate" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>                    
            </td>
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
            <td style="width:100px;height:25px;">
                Hidden</td>
            <td colspan="3">
                <asp:CheckBox ID="cbContentHidden" runat="server" />
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
                <asp:Button ID="AddNewContent" runat="server" Text="Add New Content"  ValidationGroup="AddNew" OnClick="AddNewContent_Click" CssClass="commandButton" />
            </td>
        </tr>
    </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
