<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CreateMember.aspx.cs" Inherits="JKParkLaw.Admin.Member.CreateMember" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
    function CheckMemberIDCheck(sender, args)
      {
        var hdField = document.getElementById("<%=MemberIDOK.ClientID %>");
        if (hdField.value == "1") 
        {
             args.IsValid = true;
             return;
        }
        args.IsValid = false;
        return;
      }
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminPlaceHolder" runat="server">
<div  class="row">
<asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    
					
                    <asp:UpdatePanel ID="EmailUpdatePanel" runat="server">
                    <ContentTemplate>
                    <table width="100%" class="table" >
                        <tr>
                            <td align="left" style="width:100px;height:25px;">&nbsp;</td> 
                            <td colspan="2">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                        </tr>
                    </table>
                    <table width="100%" id="registerTable" runat="server" class="table" >
                        <tr>
                            <td style="width:250px;">MemberID <span style="color:Red;">*</span></td> 
                            <td><asp:TextBox ID="tbMemberID" runat="server" MaxLength="125" CssClass="form-control" AutoPostBack="true" OnTextChanged="tbMemberID_TextChanged"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="btnCheckMemberID" runat="server" ImageUrl="~/Images/icons/verify.gif" OnClick="btnCheckMemberID_Click" />
                                <asp:Label ID="tbCheckResult" runat="server" Text="Check MemberID First"></asp:Label>
                                <asp:HiddenField ID="MemberIDOK" runat="server" Value="0" />
                                <asp:CustomValidator ControlToValidate="tbMemberID" SetFocusOnError="true" ValidateEmptyText="true"  
                                    ID="MemberIDOKValidator"  ClientValidationFunction="CheckMemberIDCheck" 
                                    runat="server" ValidationGroup="AddNew">Check the member id</asp:CustomValidator>
                             </td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Password <span style="color:Red;">*</span></td> 
                            <td colspan="2"><asp:TextBox ID="tbPassword" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Password Confirm <span style="color:Red;">*</span></td> 
                            <td colspan="2"><asp:TextBox ID="tbPasswordRe" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">First Name(Eng) <span style="color:Red;">*</span></td> 
                            <td colspan="2"><asp:TextBox ID="tbFName" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Last Name(Eng) <span style="color:Red;">*</span></td> 
                            <td colspan="2"><asp:TextBox ID="tbLName" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Korean Name</td> 
                            <td colspan="2"><asp:TextBox ID="tbKorName" runat="server" MaxLength="125" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Email</td> 
                            <td colspan="2"><asp:TextBox ID="tbEmail" runat="server" MaxLength="125" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Phone</td> 
                            <td colspan="2"><asp:TextBox ID="tbPhone" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Address </td> 
                            <td colspan="2"><asp:TextBox ID="tbAddress" runat="server" MaxLength="125" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Address 2</td> 
                            <td colspan="2"><asp:TextBox ID="tbAddress2" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">City </td> 
                            <td colspan="2"><asp:TextBox ID="tbCity" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">State </td> 
                            <td colspan="2"><asp:TextBox ID="tbState" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Zip </td> 
                            <td colspan="2"><asp:TextBox ID="tbZip" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Status <span style="color:Red;">*</span></td> 
                            <td colspan="2">
                                <asp:DropDownList ID="ddlProgressStatus" runat="server" CssClass="form-control" >
                                    <asp:ListItem Text="IN-PROGRESS" Value="IN-PROGRESS" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="COMPLETED" Value="COMPLETED" ></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Active <span style="color:Red;">*</span></td> 
                            <td colspan="2">
                                <asp:CheckBox ID="cbActiveStatus" Checked="true" runat="server" /></td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px;height:25px;">Join Date <span style="color:Red;">*</span></td> 
                            <td colspan="2">
                                <asp:TextBox ID="JoinedDate" runat="server" />
                                <ajaxToolkit:CalendarExtender ID="JoinModifiedCalExtender" runat="server" TargetControlID="JoinedDate" PopupButtonID="JoinImgUrl" Format="MM/dd/yyyy" />
                                <asp:ImageButton ID="JoinImgUrl" runat="server" 
                                    ImageUrl="~/Images/icons/calendar.gif" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="JoinedDate" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>                    
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                * Required fields
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="btnResister" runat="server" Text="Create Member" 
                                    onclick="btnResister_Click" ValidationGroup="AddNew" CssClass="btn btn-primary" /></td>
                        </tr>
                    </table>
                    </ContentTemplate> 
                    </asp:UpdatePanel>
</div>
</asp:Content>
