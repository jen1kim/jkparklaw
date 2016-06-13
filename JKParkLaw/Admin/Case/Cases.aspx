<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" 
CodeBehind="Cases.aspx.cs" Inherits="JKParkLaw.Admin.Case.Cases" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">
<div class="row">
    <table class="table">
        <tr>
            <td style ="width:250px;" class="secondHead">Selected Case:  </td>
             <td colspan="2" >
                <asp:Label ID="selectedCase" runat="server" ForeColor="#F62217" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
            <asp:GridView ID="CasesGrid" runat="server" AllowPaging="True"
                    AllowSorting="True"  PageSize="15" OnPageIndexChanging="CasesGrid_PageIndexChanging"
                    AutoGenerateColumns="False" Width="100%" DataKeyNames="CaseID" 
                   CssClass= "table table-striped table-bordered" SelectedRowStyle-Font-Bold="true" AutoGenerateSelectButton="true" 
                    OnSelectedIndexChanged="CasesGrid_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="CaseID" HeaderText="ID" />
                    <asp:BoundField DataField="CaseTitle" HeaderText="Title" />
                    <asp:BoundField DataField="CaseFileName" HeaderText="File" />
                    <asp:CheckBoxField DataField="Hidden" HeaderText="Hidden" />                    
               </Columns>            
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>"             
                    SelectCommand="E_GetCaseList" SelectCommandType="StoredProcedure" >
            </asp:SqlDataSource>    
            </td>
        </tr>
        <tr>
             <td colspan="3" >
                <asp:Button ID="btnDeleteCase" runat="server" Text="Delete Selected Case" 
                    onclick="btnDeleteCase_Click" Enabled="false" CssClass="btn btn-primary" />
                    * Click 'Select' to edit or delete a case.
            </td>
        </tr>
    </table>
    <br />
    <table class="table">
        <tr>
            <td style="width:100px">&nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
             </td>
        </tr>
    </table>
    
    <div id="AddNewCaseDiv" runat="server" >
        <table class="table">  
            <tr>
                <td colspan="3" class="head">
                    <strong>ADD NEW CASE </td>
            </tr>
            <tr>
                <td style="width:250px;">Case Title</td>
                <td colspan="2">
                    <asp:TextBox  ID="tbNewCaseTitle" runat="server" MaxLength="125" CssClass="form-control"></asp:TextBox>                
                </td>
                
            </tr>
            <tr class="alternate1">
                <td>
                    Case File</td>
                <td colspan="2">
                    <asp:FileUpload ID="fuNewCaseFileName" runat="server"  Width="500px"  />
                </td>                
            </tr>        
            <tr>
                <td>Small desc</td>
                <td colspan="2"><textarea id="NewSmallDesc" cols="60" rows="3" runat="server" Class="form-control"></textarea></td>
            </tr>
            <tr>
                <td colspan="3">               
                    <asp:Button ID="btnAddNew" runat="server" Text="Add new Case" ValidationGroup="AddNew" CausesValidation="true"
                        onclick="btnAddNew_Click" CssClass="btn btn-primary" />              
                </td>
            </tr>
        </table>
    </div>
    
    <div id="CaseEdit" runat="server" visible="false">
        <table class="table">
        <tr>
            <td colspan="2" class="head"><strong>EDIT CASE</strong></td>
        </tr>
        <tr>
            <td  style="width:250px;"> 
                <asp:HiddenField ID="hdnEditCaseID" runat="server" />
                Case Title*

            </td>
            <td>
                <asp:TextBox  ID="tbEditCaseTitle" runat="server" MaxLength="125"  CssClass="form-control">  </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >
                Case File*</td>
            <td>
                <asp:Label ID="lblEditCaseFileName" runat="server" Text=""></asp:Label><br />
                <asp:FileUpload ID="fuEditCaseFileName" runat="server"  Width="500px"  />
            </td>
        </tr>
        <tr>
            <td>Small desc</td>
            <td ><textarea id="EditSmallDesc" cols="60" rows="3" runat="server" class="form-control"></textarea></td>
        </tr>

        <tr>
            <td>
                Hidden</td>
            <td>
                <asp:CheckBox ID="cbHidden" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="UpdateDetails" runat="server" Text="Update Case"  ValidationGroup="AddNew" OnClick="UpdateDetails_Click" CssClass="btn btn-primary" />
            </td>
        </tr>
    </table>
    </div>
</div>
</asp:Content>
