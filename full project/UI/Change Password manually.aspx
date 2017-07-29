<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="Change Password manually.aspx.cs" Inherits="full_project.UI.Change_Password_manually" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
     <div class="container">
    <div class="row">
        <br/>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" ID="Label1" Text="User Name" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox runat="server" ID="UserNameTextBox" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" runat="server" CssClass="text-danger" ErrorMessage="User Name Is required" ControlToValidate="UserNameTextBox" ForeColor="red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="Label2" Text="Email" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox runat="server" ID="EmailTxtBox" TextMode="Email" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email is required" CssClass="text-danger" ControlToValidate="EmailTxtBox" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Your Email Is not Valid" CssClass="text-danger" ControlToValidate="EmailTxtBox" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="Label3" Text="Current Password" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox runat="server" ID="CurrentPasswordTextBox" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Your Current Password" ControlToValidate="CurrentPasswordTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="Label4" Text="New Password" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox runat="server" ID="NewPasswordTextBox" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter New Password" ControlToValidate="NewPasswordTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="form-group">
                <asp:Label runat="server" ID="Label5" Text="Confirm Password"  CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox runat="server" ID="ConfirmPasswordTextBox" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Confirm your Password" ControlToValidate="ConfirmPasswordTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Both Password must be same" ControlToCompare="NewPasswordTextBox" ControlToValidate="ConfirmPasswordTextBox" ForeColor="Red"></asp:CompareValidator>

                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-6 col-sm-offset-2">
                    <asp:Button runat="server" ID="ChangePasswordButton" Text="Change Password" CssClass="btn btn-primary" OnClick="ChangePasswordButton_Click"/>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-6 col-sm-offset-2">
                    <asp:Label runat="server" ID="MessageLabel"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
