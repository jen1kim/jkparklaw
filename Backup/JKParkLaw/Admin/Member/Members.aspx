<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="JKParkLaw.Admin.Member.Members" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3.Export, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
    
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script language="javascript" type="text/javascript">
    function MembersGV_SelectionChanged(s, e) {
        s.GetSelectedFieldValues("MemberID", GetSelectedFieldValuesCallback);
    }
    function GetSelectedFieldValuesCallback(values) {    
        selList.BeginUpdate();
        try {
            selList.ClearItems();
            for(var i = 0; i < values.length; i ++) {
                selList.AddItem(values[i]);
            }
        } finally {
            selList.EndUpdate();
        }
        document.getElementById("selCount").innerHTML = MembersGV.GetSelectedRowCount();
    }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">
<asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>

    <table class="editTable">
        <tr>
            <td colspan="3" class="head"><strong>Members List </strong></td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;<asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
            </td>
        </tr> 
        <tr>
            <td colspan="3"> 
<dxwgv:ASPxGridView ID="MembersGV" runat="server" ClientInstanceName="MembersGV" AutoGenerateColumns="False" 
    Width="100%" KeyFieldName="MemberID" DataSourceID="MembersViewSource" >
    <Settings ShowFilterRow="True" GridLines="Horizontal"  />
    <Settings GridLines="Horizontal" />
    <BorderRight BorderColor="#f4f4f4" />
    <BorderLeft BorderColor="#f4f4f4" />
    <BorderTop BorderColor="#f4f4f4" />
    <BorderBottom BorderColor="#f4f4f4" />
    <Styles Cell-BackColor="#f4f4f4" Cell-ForeColor="#000000" Cell-CssClass="styleGrid_EpList" CommandColumn-BackColor="#f4f4f4" 
    CommandColumn-ForeColor="black" FilterCell-BackColor="#f4f4f4" Footer-BackColor="#dddddd" Header-ForeColor="white" Header-BackColor="#444444" ></Styles> 
    <Columns>
        <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" Width="10px" VisibleIndex="0" />
        <dxwgv:GridViewDataTextColumn FieldName="MemberID" Caption="ID" VisibleIndex="1"  SortIndex="0">
            <DataItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#  Eval("MemberID", "ViewMember.aspx?MemberID={0}")  %>'> <%# Eval("MemberID")%></asp:HyperLink> 
            </DataItemTemplate>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="FName" Caption="F" VisibleIndex="2" SortIndex="2">
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="LName" Caption="L" VisibleIndex="3" SortIndex="1">
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="KorName" Caption="KO" VisibleIndex="4" SortIndex="3">
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataDateColumn FieldName="Joined" Caption="Join" VisibleIndex="5" >
            <Settings AutoFilterCondition="Contains" />
            <PropertiesDateEdit DisplayFormatString="{0:MM/dd/yyyy}"></PropertiesDateEdit>
        </dxwgv:GridViewDataDateColumn>
        <dxwgv:GridViewDataTextColumn FieldName="ProgressStatus" Caption="Status" VisibleIndex="6">
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataCheckColumn FieldName="ActiveStatus" Caption="Active" VisibleIndex = "7">
        </dxwgv:GridViewDataCheckColumn>
        <dxwgv:GridViewDataTextColumn Caption="Act" Width="30px" VisibleIndex="8" >
            <DataItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#  Eval("MemberID", "EditMember.aspx?MemberID={0}")  %>'> Edit</asp:HyperLink> 
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#  Eval("MemberID", "ViewMember.aspx?MemberID={0}")  %>'> View</asp:HyperLink> 
            </DataItemTemplate>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewCommandColumn VisibleIndex="9">
            <ClearFilterButton Visible="True"></ClearFilterButton>
        </dxwgv:GridViewCommandColumn>
    </Columns>
    <ClientSideEvents SelectionChanged="MembersGV_SelectionChanged" />
    <Settings ShowFooter="True" ShowHeaderFilterButton="true"   />
    <SettingsBehavior AllowMultiSelection="true" />
    <SettingsPager PageSize="20">
    </SettingsPager>
    <TotalSummary >
        <dxwgv:ASPxSummaryItem FieldName="MemberID" SummaryType="Count" />
    </TotalSummary>
</dxwgv:ASPxGridView>
<!-- exporter grid -->
<dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="MembersGrid">
</dxwgv:ASPxGridViewExporter>

                 <asp:SqlDataSource ID="MembersViewSource" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SiteDBConnection %>" 
                    SelectCommand="SELECT * FROM [Members]" 
                    DeleteCommand="DELETE FROM [Members] WHERE [MemberID] = @MemberID" 
                    InsertCommand="INSERT INTO [Members] ([MemberID], [Password], [Email], [FName], [LName], [KorName], [Phone], [Address], [Address2], [City], [State], [Zip], [ProgressStatus], [ActiveStatus], [Joined]) VALUES (@MemberID, @Password, @Email, @FName, @LName, @KorName, @Phone, @Address, @Address2, @City, @State, @Zip, @ProgressStatus, @ActiveStatus, @Joined)" 
                    UpdateCommand="UPDATE [Members] SET [MemberID] = @MemberID, [Password] = @Password, [Email] = @Email, [FName] = @FName, [LName] = @LName, [KorName] = @KorName, [Phone] = @Phone, [Address] = @Address, [Address2] = @Address2, [City] = @City, [State] = @State, [Zip] = @Zip, [ProgressStatus] = @ProgressStatus, [ActiveStatus] = @ActiveStatus, [Joined] = @Joined WHERE [ID] = @ID" >
                     <DeleteParameters>
                         <asp:Parameter Name="MemberID" Type="String" />
                     </DeleteParameters>
                     <UpdateParameters>
                         <asp:Parameter Name="MemberID" Type="String" />
                         <asp:Parameter Name="Password" Type="String" />
                         <asp:Parameter Name="Email" Type="String" />
                         <asp:Parameter Name="FName" Type="String" />
                         <asp:Parameter Name="LName" Type="String" />
                         <asp:Parameter Name="KorName" Type="String" />
                         <asp:Parameter Name="Phone" Type="String" />
                         <asp:Parameter Name="Address" Type="String" />
                         <asp:Parameter Name="Address2" Type="String" />
                         <asp:Parameter Name="City" Type="String" />
                         <asp:Parameter Name="State" Type="String" />
                         <asp:Parameter Name="Zip" Type="String" />
                         <asp:Parameter Name="ProgressStatus" Type="String" />
                         <asp:Parameter Name="ActiveStatus" Type="Boolean" />
                         <asp:Parameter Name="Joined" Type="DateTime" />
                     </UpdateParameters>
                     <InsertParameters>
                         <asp:Parameter Name="MemberID" Type="String" />
                         <asp:Parameter Name="Password" Type="String" />
                         <asp:Parameter Name="Email" Type="String" />
                         <asp:Parameter Name="FName" Type="String" />
                         <asp:Parameter Name="LName" Type="String" />
                         <asp:Parameter Name="KorName" Type="String" />
                         <asp:Parameter Name="Phone" Type="String" />
                         <asp:Parameter Name="Address" Type="String" />
                         <asp:Parameter Name="Address2" Type="String" />
                         <asp:Parameter Name="City" Type="String" />
                         <asp:Parameter Name="State" Type="String" />
                         <asp:Parameter Name="Zip" Type="String" />
                         <asp:Parameter Name="ProgressStatus" Type="String" />
                         <asp:Parameter Name="ActiveStatus" Type="Boolean" />
                         <asp:Parameter Name="Joined" Type="DateTime" />
                     </InsertParameters>
                </asp:SqlDataSource>    
           </td>
        </tr>
  </table>
  <table class="editTable">
        <tr>
           <td align="left" style="width:10px;">&nbsp;
            <dxe:ASPxListBox ID="AspxLB" ClientInstanceName="selList" runat="server" ClientVisible="false" />
               <asp:HiddenField ID="hdnPageIndex" runat="server" />
           </td> 
           <td style="width:120px;">                   
                 <p>
                     Selected count: 
                     <span id="selCount" style="font-weight: bold">0</span>            
                 </p>                
           </td>
           <td align="left">
               <asp:Button ID="btnDelete" runat="server" Text="Delete Selected Members"
               onclick="btnDelete_Click" CssClass="commandButton" />
           </td>
        </tr>
   </table>
<br /><br /><br /><br />
</asp:Content>
