﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" 
Inherits="JKParkLaw.Admin.News.NewsList" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">
    <div class="row">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
            <table class="table">
                <tr>
                    <td colspan="3"> 
                        <asp:GridView ID="NewsGrid" runat="server" AutoGenerateColumns="False"  AllowPaging="true" PageSize="15"
                            Width="100%"  DataKeyNames="NewsID" OnPageIndexChanging="NewsGrid_PageIndexChanging"
                            AllowSorting="True" CssClass= "table table-striped table-bordered" AutoGenerateDeleteButton="true" 
                            OnRowDeleting="NewsGrid_RowDeleting" OnRowDeleted="NewsGrid_RowDeleted">
                            <Columns>
                                <asp:BoundField DataField="NewsID" HeaderText="ID" InsertVisible="False" 
                                    ReadOnly="True"  />
                                <asp:BoundField DataField="RowNumber" HeaderText="No" InsertVisible="False" 
                                    ReadOnly="True"  />
                                <asp:BoundField DataField="NewsTitle" HeaderText="Title" />
                                <asp:BoundField DataField="Modified" HeaderText="Mod Date" ItemStyle-Width="100px" 
                                    DataFormatString="{0:MM/dd/yyyy}"/>
                                <asp:CheckBoxField DataField="Hidden" HeaderText="Hidden"  />
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="NewsHL" runat="server" CssClass="normalLinks"
                                        NavigateUrl='<%# Eval("NewsID", "News.aspx?NewsID={0}") %>' Text="Edit"></asp:HyperLink>
                                </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         <asp:SqlDataSource ID="NewsViewSource" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" SelectCommand="SELECT * FROM [News]" SelectCommandType="Text" >
                        </asp:SqlDataSource>    
                   </td>
                </tr>
           </table>
   
               <br />
            <table class="table">
                <tr>
                    <td colspan="2" class="head"><strong>Add News 
                    </td>
                </tr>
                <tr>
                    <td  style="width:250px;"> Title<span class="error">*</span></td>
                    <td>
                        <asp:TextBox  ID="tbNewsTitle" runat="server" MaxLength="125" CssClass="form-control">  </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> Source</td>
                    <td>
                        <asp:TextBox  ID="tbSource" runat="server" MaxLength="125" CssClass="form-control">  </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td > Author</td>
                    <td>
                        <asp:TextBox  ID="tbAuthor" runat="server" MaxLength="125"  CssClass="form-control">  </asp:TextBox>
                    </td>
                </tr>
         
                <tr>
                    <td >Small desc</td>
                    <td><textarea id="SmallDesc" cols="60" rows="3" runat="server" class="form-control"></textarea></td>
                </tr>
                <tr class="alternate1">
                    <td>Description<span class="error">*</span></td>
                    <td>
                        <FCKeditorV2:FCKeditor Width="800" Height="300" ToolbarSet="EShop" ID="BigDescription" runat="server" BasePath="~/Images/js/fckeditor/" AutoDetectLanguage="True"></FCKeditorV2:FCKeditor>
                    </td>
                </tr>
          
                <tr>
                    <td>
                        Hidden</td>
                    <td>
                        <asp:CheckBox ID="cbNewsHidden" runat="server" />
                    </td>
                 </tr>         
                <tr>
                    <td>Modified<span class="error">*</span></td>
                    <td >
                    <asp:TextBox ID="ModifiedDate" runat="server"  />
                        <ajaxToolkit:CalendarExtender ID="ModifiedCalExtender" runat="server" TargetControlID="ModifiedDate" PopupButtonID="ModImgUrl" Format="MM/dd/yyyy" />
                        <asp:ImageButton ID="ModImgUrl" runat="server" 
                            ImageUrl="~/Images/icons/calendar.gif" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ModifiedDate" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>                    
                    (MM/dd/yyyy)</td>
                </tr>
                <tr>
                    <td> * Required fields</td>
                    <td >
                        <asp:Label ID="lblMessage" ForeColor="Red" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
               
                <tr>
                    <td colspan="2">
                        <asp:Button ID="AddNewNews" runat="server" Text="Add News"  ValidationGroup="AddNew" OnClick="AddNewContent_Click" CssClass="btn btn-primary" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
