<%@ Page Title="Send email to dealers" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="Send Email to dealers.aspx.cs" Inherits="full_project.UI.Send_Email_to_dealers" %>
<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.6.2, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
    <div class="container">
        <div class="col-sm-12">
            <CKEditor:CKEditorControl ID="CKEditor1" BasePath="~/ckeditor/" runat="server" Width="600px" Height="200px" CssClass="form-control"></CKEditor:CKEditorControl>
        </div>
        
        <div class="col-sm-12" style="margin-top: 10px">
        <asp:Button runat="server" ID="Button1" Text="Send" CssClass="btn btn-primary" OnClick="Button1_Click"/>
            </div>
        <div class="col-sm-12">
            <asp:Label runat="server" ID="Messagelabel"></asp:Label>
        </div>
    </div>
     <script src="../Jquery/jquery-3.1.1.js"></script>
    <script src="../ckeditor/ckeditor.js"></script>
     <script type="text/javascript">
         $(function () {
             CKEDITOR.replace('<%=CKEditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         });
</script>
    <script src="../bootstrap-3.3.7/js/bootstrap.min.js"></script>
</asp:Content>
