<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="ResetPassword.aspx.cs" Inherits="full_project.UI.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
     <div class="container">
        <div class="row" style="margin-top: 10px; margin-left: 20px;margin-right: 20px">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" ID="Label1" Text="Email" CssClass="control-label col-sm-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field id required" ControlToValidate="EmailTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-5 col-sm-offset-2" style="margin-top: 10px">
                <asp:Button ID="ResetPasswordButton" runat="server" Text="Reset Password" CssClass="btn btn-primary" OnClick="ResetPasswordButton_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="messageLabel" runat="server" Text="" CssClass="col-sm-5 col-sm-offset-2"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
