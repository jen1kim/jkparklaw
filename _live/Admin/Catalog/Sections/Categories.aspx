<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="JKParkLaw.Admin.Catalog.Sections.Categories" %>
<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">
    <div class="row">
        <table class="table">
            <tr>
                <td style="width:250px;"><strong>Select Master Section </strong></td>
                <td colspan="2" >    
                    <asp:DropDownList ID="SectionsDD" runat="server" AutoPostBack="True" 
                        AppendDataBoundItems="true" CssClass="form-control" 
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
                <td><strong>Selected Master Section: </strong></td>
                <td colspan="2">
                    <strong><asp:Label ID="lblSelectedSection" runat="server" ForeColor="Red" Text=""></asp:Label></strong>
                </td>
            </tr>
            <tr>
                 <td><strong><b>Categories</b>&nbsp;&nbsp;>&nbsp;Selected Category:</strong></td>
                 <td colspan="2" >
                    <asp:Label ID="selectedCategory" runat="server" ForeColor="#F62217" Text=""></asp:Label>
                    <asp:HiddenField ID="hdnCategoryID" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3"> 
                <asp:GridView ID="CategoryGrid" runat="server" AllowPaging="True" PageSize="15" 
                        AllowSorting="True"  OnPageIndexChanging="CategoryGrid_PageIndexChanging" 
                        AutoGenerateColumns="False" Width="100%" DataKeyNames="CategoryID" 
                        CssClass= "table table-striped table-bordered"  SelectedRowStyle-Font-Bold="true" AutoGenerateSelectButton="true" 
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
            <tr>
                 <td colspan="3" >
                    <asp:Button ID="btnDeleteCategory" runat="server" Text="Delete Selected Category" 
                        onclick="btnDeleteCategory_Click" Enabled="false" CssClass="btn btn-primary" />
                        * Click 'Select' to edit or delete a category.
                </td>
            </tr>
        </table>
        <br />
        <div id="AddNewCategoryDiv" runat="server" >
            <table class="table">  
                <tr>
                    <td colspan="3">
                        <strong>ADD NEW CATEGORY </td>
                </tr>
                <tr>
                    <td style="width:250px;">Category Name</td>
                    <td colspan="2">
                        <asp:TextBox  ID="CategoryName" runat="server" MaxLength="125" Width="500px" CssClass="form-control"></asp:TextBox>                
                    </td>
                
                </tr>
                <tr class="alternate1">
                    <td>
                        Category Desc</td>
                    <td colspan="2">
                        <asp:TextBox  ID="CategoryDesc" runat="server" MaxLength="125" Width="500px" CssClass="form-control">  </asp:TextBox>
                    </td>                
                </tr>        
            </table>    
            <br />  
            <table class="table">
                <tr>
                    <td colspan="3">               
                        <asp:Button ID="btnAddNew" runat="server" Text="Add new Category" ValidationGroup="AddNew" CausesValidation="true"
                            onclick="btnAddNew_Click" CssClass="btn btn-primary" />              
                    </td>
                </tr>
              
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                     </td>
                </tr>
            </table>
        </div>
        <div id="CategoryEdit" runat="server" visible="false">
            <table class="table">
            <tr>
                <td colspan="3" ><strong>EDIT CATEGORY</strong></td>
            </tr>
            <tr>
                <td  style="width:250px;">
                    Category Name</td>
                <td>
                    <asp:TextBox  ID="tbCategoryName" runat="server" MaxLength="125" Width="500px" CssClass="form-control">  </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Category Desc</td>
                <td>
                    <asp:TextBox  ID="tbCategoryDesc" runat="server" MaxLength="125" Width="500px" CssClass="form-control">  </asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    Available</td>
                <td>
                    <asp:CheckBox ID="cbCategoryAvailable" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="UpdateDetails" runat="server" Text="Update Category"  ValidationGroup="AddNew" OnClick="UpdateDetails_Click" CssClass="btn btn-primary" />
                </td>
            </tr>
        </table>
        </div>
    </div>
</asp:Content>
