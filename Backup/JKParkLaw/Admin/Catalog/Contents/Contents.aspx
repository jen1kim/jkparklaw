﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Contents.aspx.cs" Inherits="JKParkLaw.Admin.Catalog.Contents.Contents" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
            <asp:GridView ID="CategoryGrid" runat="server" AllowPaging="True" PageSize="15"
                    AllowSorting="True"  OnPageIndexChanging="CategoryGrid_PageIndexChanging"
                    AutoGenerateColumns="False" Width="100%" DataKeyNames="CategoryID" 
                    SkinID="Gridview" SelectedRowStyle-Font-Bold="true" AutoGenerateSelectButton="true" 
                    OnSelectedIndexChanged="CategoryGrid_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Name" />
                    <asp:BoundField DataField="CategoryDesc" HeaderText="Desc" />
                    <asp:CheckBoxField DataField="CategoryAvailable" HeaderText="Available"  />
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
         <tr>
            <td colspan="3">
                &nbsp; * Please click 'Select' to view the contents of a category.
            </td>
        </tr>
   </table>
    <br />
    <table class="editTable">
        <tr>
             <td colspan="3" class="secondHead">
                &nbsp;&nbsp;&nbsp;<b>Contents</b>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
            <asp:GridView ID="ContentGrid" runat="server" AllowPaging="True"
                    AllowSorting="True"  PageSize="15"
                    AutoGenerateColumns="False" Width="100%" DataKeyNames="ContentID" OnPageIndexChanging="ContentGrid_PageIndexChanging"
                    SkinID="Gridview" SelectedRowStyle-Font-Bold="true" AutoGenerateDeleteButton="true" 
                    OnRowDeleting="ContentGrid_RowDeleting" OnRowDeleted="ContentGrid_RowDeleted" >
                <Columns>
                    <asp:BoundField DataField="ContentID" HeaderText="ID" />
                    <asp:BoundField DataField="ContentTitle" HeaderText="Title" />
                    <asp:BoundField DataField="ContentSmallDesc" HeaderText="SmallDesc" />
                    <asp:CheckBoxField DataField="Hidden" HeaderText="Hidden" />
                    <asp:TemplateField HeaderText="Edit" >
                        <ItemTemplate>
                            <asp:HyperLink ID="contentHL" runat="server" CssClass="normalLinks"
                                NavigateUrl='<%# Eval("ContentID", "Content.aspx?ContentID={0}") %>' Text="Edit"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
               </Columns>            
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>"             
                    SelectCommand="E_GetContents" SelectCommandType="StoredProcedure" >
                    <SelectParameters>
                        <asp:Parameter Name="CategoryID" Type="Int32"/>
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
    </table>
    <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
