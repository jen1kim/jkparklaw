﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Counselings.aspx.cs" Inherits="JKParkLaw.Admin.Email.Counselings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">
    <div class="row">

    <table class="table">
        <tr>
            <td colspan="3">
                &nbsp;<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:GridView ID="CounselingsGrid" runat="server" AutoGenerateColumns="False"  AllowPaging="true" PageSize="10"
                    Width="100%"  AutoGenerateDeleteButton="true" OnRowDeleting="CounselingsGrid_RowDeleting" OnPageIndexChanging="CounselingsGrid_PageIndexChanging"
                    AllowSorting="True" CssClass= "table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="CounselingID" HeaderText="ID" InsertVisible="False" ItemStyle-Width="25px"
                            ReadOnly="True" SortExpression="CounselingID" />
                        <asp:BoundField DataField="EngFName" HeaderText="FName"
                            SortExpression="EngFName" />
                        <asp:BoundField DataField="EngLName" HeaderText="LName"
                            SortExpression="EngLName" />
                        <asp:BoundField DataField="CounselingType" HeaderText="Type"
                            SortExpression="CounselingType" />
                        <asp:CheckBoxField DataField="Processed" HeaderText="Status" SortExpression="Processed" />
                        <asp:BoundField DataField="Created" HeaderText="Date" 
                            SortExpression="Created" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="CounselingsHL" runat="server" CssClass="normalLinks"
                                NavigateUrl='<%# Eval("CounselingID", "Counseling.aspx?CounselingID={0}") %>' Text="View"></asp:HyperLink>
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                 <asp:SqlDataSource ID="CounselingsViewSource" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" 
                    SelectCommand="SELECT * FROM [Counselings] " SelectCommandType="Text" 
                    DeleteCommand="" >
                </asp:SqlDataSource>    
           </td>
        </tr>
   </table>
   
    </div>
</asp:Content>
