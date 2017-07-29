<%@ Page Title="Recover Password" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="ChangePassword.aspx.cs" Inherits="full_project.UI.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
        <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" Id="Label1" Text="New Password"  CssClass="control-label col-sm-2" Visible="False" ></asp:Label>
                    <div class="col-sm-5">
                        <asp:TextBox runat="server" ID="NewPasswordTextBox" CssClass="form-control" Visible="False" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter new password" ControlToValidate="NewPasswordTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" Id="Label2" Text="Confirm Password"  CssClass="control-label col-sm-2"  Visible="False"></asp:Label>
                    <div class="col-sm-5">
                         <asp:TextBox runat="server" ID="ConfirmTextBox" CssClass="form-control" Visible="False" TextMode="Password"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Confirm your password" ControlToValidate="ConfirmTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Both Password must be same" ControlToValidate="ConfirmTextBox" ControlToCompare="NewPasswordTextBox" CssClass="text-danger" ForeColor="Red"></asp:CompareValidator>
                    </div>
                    </div>
                    <div class="col-sm-5 col-sm-offset-2">
                        <asp:Button runat="server" ID="ChangePasswordButton" Text="Change Password" class="btn btn-primary" OnClick="ChangePasswordButton_Click" Visible="False"/>
                    </div>
                    <div class="col-sm-5 col-sm-offset-2">
                         <asp:Label runat="server" ID="Messagelabel" ></asp:Label>
                    </div>
                </div>
   
        </div>
</asp:Content>
