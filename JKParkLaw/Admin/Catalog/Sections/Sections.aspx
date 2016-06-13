<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Sections.aspx.cs" Inherits="JKParkLaw.Admin.Catalog.Sections.Sections" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ MasterType VirtualPath="~/Admin/Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">
    <div class="row">
        <table class="table" >
            <tr>
                <td>
                    <asp:GridView ID="SectionsList" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SectionsViewSource" Width="100%" AllowPaging="True" PageSize="10"
                        AllowSorting="True"  OnPageIndexChanging="SectionsList_PageIndexChanging" CssClass= "table table-striped table-bordered" >
                        <Columns>
                            <asp:BoundField DataField="CategoryID" HeaderText="ID" InsertVisible="False" ItemStyle-Width="25px"
                                ReadOnly="True" SortExpression="CategoryID" />
                            <asp:BoundField DataField="CategoryName" HeaderText="Section Name" ItemStyle-Width="200px"
                                SortExpression="CategoryName" />
                            <asp:BoundField DataField="CategoryDesc" HeaderText="Desc" ItemStyle-Width="300px"
                                SortExpression="CategoryDesc" />
                             <asp:BoundField DataField="CategoryOrder" HeaderText="Order" ItemStyle-Width="70px"
                                SortExpression="CategoryOrder" />
                            <asp:CheckBoxField DataField="CategoryAvailable" HeaderText="Available" 
                                SortExpression="CategoryAvailable" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"/>
                            <asp:TemplateField HeaderText="Edit" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink ID="Sectionhpl" runat="server" CssClass="normalLinks"
                                    NavigateUrl='<%# Eval("CategoryID", "Section.aspx?SectionID={0}") %>' Text="Edit"></asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categories" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink ID="HCategorieshpl" runat="server" CssClass="normalLinks"
                                    NavigateUrl='<%# Eval("CategoryID", "Categories.aspx?SectionID={0}") %>' Text="View"></asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SectionsViewSource" runat="server" 
                     ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>"        
                        SelectCommand="SELECT [CategoryID], [CategoryName],[CategoryDesc], [CategoryOrder], [CategoryAvailable] FROM [Categories] WHERE ([ParentID] = @ParentID) ORDER BY CategoryOrder, CategoryID" 
                        DeleteCommand="DELETE FROM [Categories] WHERE [CategoryID] = @CategoryID" 
                        InsertCommand="INSERT INTO [Categories] ([CategoryName], [CategoryOrder], [CategoryAvailable]) VALUES (@CategoryName, @CategoryURL, @CategoryOrder, @CategoryAvailable)" 
                        UpdateCommand="UPDATE [Categories] SET [CategoryName] = @CategoryName, [CategoryOrder] = @CategoryOrder, [CategoryAvailable] = @CategoryAvailable WHERE [CategoryID] = @CategoryID">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="ParentID" Type="Int32" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="CategoryID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="CategoryName" Type="String" />
                            <asp:Parameter Name="CategoryDesc" Type="String" />
                            <asp:Parameter Name="CategoryOrder" Type="Byte" />
                            <asp:Parameter Name="CategoryAvailable" Type="Boolean" />
                            <asp:Parameter Name="CategoryID" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CategoryName" Type="String" />
                            <asp:Parameter Name="CategoryDesc" Type="String" />
                            <asp:Parameter Name="CategoryOrder" Type="Byte" />
                            <asp:Parameter Name="CategoryAvailable" Type="Boolean" />
                        </InsertParameters>
                    </asp:SqlDataSource>    
                </td>
            </tr>
         </table>
        <asp:PlaceHolder ID="AddNewSectionPanel" runat="server">
        <table class="table">
            <tr>
                <td colspan="3" class="head"><b>Add new Section</b></td>
            </tr>
            <tr>
                <td style="width:250px"> Section Name*</td>
                <td colspan="2">
                    <asp:TextBox  ID="SectionName" runat="server" MaxLength="125" Width="300px" CssClass="form-control">  </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SectionName" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td> Section Desc*</td>
                <td colspan="2">
                    <asp:TextBox  ID="SectionDesc" runat="server" MaxLength="125" Width="300px" CssClass="form-control">  </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SectionDesc"  ValidationGroup="AddNew">*</asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td colspan="3" style="height:20px"> &nbsp; * Required fields (Length should be longer than 3).</td>
            </tr>
            <tr>
               <td colspan="3" c>
                    <asp:Button ID="btnAddNewSection" runat="server" Text="Add new section" ValidationGroup="AddNew" CssClass="btn btn-primary"
                        onclick="btnAddNewSection_Click" />
                 </td>
            </tr>
        </table>   
        </asp:PlaceHolder>   
    </div>
</asp:Content>
