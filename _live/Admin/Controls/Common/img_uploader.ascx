<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="img_uploader.ascx.cs" Inherits="Image_Uploader.img_uploader" %>
<asp:FileUpload ID="image_file" runat="server" /><asp:Button ID="btUpload" runat="server" Text="Upload" />
<asp:Label ID="lblimage_file_msg" runat="server" ForeColor="Red"></asp:Label>