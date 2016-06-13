<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewMember.aspx.cs" 
Inherits="JKParkLaw.Admin.Member.ViewMember" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3.Export, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>

<%@ Register Assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dxw" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
    
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">

<asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    
    <table class="table">
        <tr>
            <td colspan="3"> 
            <dxwgv:ASPxGridView ID="ProgressGV" runat="server" ClientInstanceName="ProgressGV" OnRowUpdating="ProgressGV_RowUpdating"
                    AutoGenerateColumns="False" Width="100%" KeyFieldName="ProgressID" DataSourceID="dsProgressView" CssClass="table table-striped table-bordered" >
                <Columns>
                    <dxwgv:GridviewCommandColumn visibleindex="0" >
                        <EditButton Visible="true"></EditButton>
                    </dxwgv:GridviewCommandColumn>
                    <dxwgv:GridViewDataDateColumn FieldName="Added" Caption="Date" VisibleIndex="1" >
                        <Settings AutoFilterCondition="Contains" />
                        <PropertiesDateEdit DisplayFormatString="{0:MM/dd/yyyy}"></PropertiesDateEdit>
                        <EditFormSettings VisibleIndex ="0" />
                    </dxwgv:GridViewDataDateColumn>
                    <dxwgv:GridViewDataTextColumn FieldName="Title" Width="35%" Caption="Title" VisibleIndex="2" >
                        <DataItemTemplate>
                            <asp:Label ID="lblGVTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                        </DataItemTemplate>
                        <EditFormSettings VisibleIndex ="1" />
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn FieldName="SmallDesc" Width="40%" Caption="Desc" VisibleIndex="3" >
                        <DataItemTemplate>
                            <asp:Label ID="tbGVSmallDesc" Width="100%" runat="server" Text='<%# Eval("SmallDesc") %>'></asp:Label>
                        </DataItemTemplate>
                        <EditFormSettings Visible="False" />
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewCommandColumn VisibleIndex="4">
                        <ClearFilterButton Visible="True"></ClearFilterButton>
                        <DeleteButton Visible="true"></DeleteButton>
                    </dxwgv:GridViewCommandColumn>
                </Columns>
                <Settings ShowFooter="True" ShowHeaderFilterButton="true"   />
                <SettingsBehavior ConfirmDelete="true" />
                <SettingsEditing EditFormColumnCount="2" />
                <SettingsPager PageSize="20">
                    </SettingsPager>
                <TotalSummary >
                    <dxwgv:ASPxSummaryItem FieldName="ProgressID" SummaryType="Count" />
                </TotalSummary>
                <Templates>
                    <EditForm>
                        <div style="padding:4px 4px 3px 4px">
                        <dxtc:ASPxPageControl runat="server" ID="pageControl" Width="100%">
                        <TabPages>
                            <dxtc:TabPage Text="Info" Visible="true">
                                <ContentCollection><dxw:ContentControl runat="server">
                                <dxwgv:ASPxGridViewTemplateReplacement ID="Editors" ReplacementType="EditFormEditors" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                                </dxw:ContentControl></ContentCollection>
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Desc"  Visible="true">
                                <ContentCollection><dxw:ContentControl runat="server">
                                <dxe:ASPxMemo runat="server" ID="notesEditor" Text='<%# Eval("SmallDesc")%>' Width="100%" Height="50px"></dxe:ASPxMemo>
                                </dxw:ContentControl></ContentCollection>
                            </dxtc:TabPage>
                        </TabPages>
                        </dxtc:ASPxPageControl>
                        </div>
                        <div style="text-align:right; padding:2px 2px 2px 2px">
                            <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                            <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                        </div>
                    </EditForm>
                </Templates>
            </dxwgv:ASPxGridView>
            
            <asp:SqlDataSource ID="dsProgressView" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" OnUpdating="dsProgressView_Modifying" 
                    SelectCommand="SELECT * FROM [Progresses] WHERE [MemberID] = @MemberID " 
                    DeleteCommand="DELETE FROM [Progresses] WHERE [ProgressID] = @ProgressID " 
                    InsertCommand="INSERT INTO [Progresses] ([MemberID], [Added], [Title], [SmallDesc]) VALUES (@MemberID, @Added, @Title, @SmallDesc)" 
                    UpdateCommand="UPDATE [Progresses] SET [Added] = @Added, [Title] = @Title, [SmallDesc] = @SmallDesc WHERE [ProgressID] = @ProgressID" >
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="MemberID" Name="MemberID" Type="String" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="ProgressID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Added" Type="DateTime" />
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter Name="SmallDesc" Type="String" />
                        <asp:Parameter Name="ProgressID" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:QueryStringParameter QueryStringField="MemberID" Name="MemberID" Type="String" />
                        <asp:Parameter Name="Added" Type="DateTime" />
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter Name="SmallDesc" Type="String" />
                    </InsertParameters>
            </asp:SqlDataSource>    
            </td>
        </tr>
     
        <tr>
            <td style="width:250px">&nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
             </td>
        </tr>
    </table>
    
    <div id="AddNewProgressDiv" runat="server" >
    <table class="table">  
        <tr>
            <td colspan="3" class="head">
                <strong>Add New Progress </strong> </td>
        </tr>
        <tr>
            <td style="width:250px;">Title <span style="color:Red;">*</span></td>
            <td colspan="2">
                <asp:TextBox  ID="tbNewTitle" runat="server" MaxLength="125"  CssClass="form-control"></asp:TextBox>                
            </td>
                
        </tr>
        <tr class="alternate1">
            <td>Small desc</td>
            <td colspan="2"><textarea id="NewSmallDesc" cols="60" rows="3" runat="server" class="form-control"></textarea></td>
        </tr>
        <tr>
            <td align="left" >Date <span style="color:Red;">*</span></td> 
            <td colspan="2">
                <asp:TextBox ID="AddedDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="AddCalExtender" runat="server" TargetControlID="AddedDate" PopupButtonID="AddImgUrl" Format="MM/dd/yyyy" />
                <asp:ImageButton ID="AddImgUrl" runat="server" 
                    ImageUrl="~/Images/icons/calendar.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="AddedDate" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>                    
            </td>
        </tr>
         <tr>
            <td  style="width:100px;"> * Required fields
            </td>
            <td colspan="2">                
            </td>
        </tr>
        <tr>
            <td colspan="3">               
                <asp:Button ID="btnAddNew" runat="server" Text="Add new Case" ValidationGroup="AddNew" CausesValidation="true"
                    onclick="btnAddNew_Click" CssClass="btn btn-primary" />              
            </td>
        </tr>
     
    </table>
    </div>
     <br />   <br />   <br />   <br />   <br />  
    <div id="ProgressEdit" runat="server" visible="false">
    <table class="table">
        <tr>
            <td colspan="2" class="head"><strong>Edit Progress</strong></td>
        </tr>
        <tr>
            <td  style="width:250px;"> 
                <asp:HiddenField ID="hdnEditProgressID" runat="server" />
                Title*</td>
            <td>
                <asp:TextBox  ID="tbEditTitle" runat="server" MaxLength="125" Width="500px" CssClass="form-control">  </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Small desc</td>
            <td ><textarea id="EditSmallDesc" cols="60" rows="3" runat="server" class="form-control"></textarea></td>
        </tr>
        <tr>
            <td align="left" style="width:100px;height:25px;">Date <span style="color:Red;">*</span></td> 
            <td>
                <asp:TextBox ID="EditAddedDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="EditAddedDate" PopupButtonID="EditAddImgUrl" Format="MM/dd/yyyy" />
                <asp:ImageButton ID="EditAddImgUrl" runat="server" 
                    ImageUrl="~/Images/icons/calendar.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EditAddedDate" ValidationGroup="Update">*</asp:RequiredFieldValidator>                    
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="UpdateDetails" runat="server" Text="Update Progress"  ValidationGroup="Update" OnClick="UpdateDetails_Click" CssClass="btn btn-primary" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
