<%@ Page Title="Registration" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true"UnobtrusiveValidationMode="none" CodeBehind="Registration.aspx.cs" Inherits="full_project.UI.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
        <div class="container">
        <div class="row">
            <br/>
            <div class="form-horizontal">
                <div class="form-group">
                     <asp:Label runat="server" ID="Label1" Text="User Name" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-5">
                    <asp:TextBox runat="server" ID="UserNameTextBox" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Name is required" ControlToValidate="UserNameTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                </div>
                 <div class="form-group">
                     <asp:Label runat="server" ID="Label2" Text="Email" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-5">
                    <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email Is required" ControlToValidate="EmailTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="please enter a valid email " ControlToValidate="EmailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                </div>
                 <div class="form-group">
                     <asp:Label runat="server" ID="Label3" Text="Password" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-5">
                     <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Password is required" ControlToValidate="PasswordTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                </div>
                 <div class="form-group">
                     <asp:Label runat="server" ID="Label4" Text="Confirm Password" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-5">
                   <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Confirm your password" ControlToValidate="ConfirmPasswordTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Both Password must be same" ControlToValidate="ConfirmPasswordTextBox" ControlToCompare="PasswordTextBox" CssClass="text-danger" ForeColor="Red"></asp:CompareValidator>
                </div>
                </div>
                <div class="form-group">
                     <asp:Label runat="server" ID="Label5" Text="Contact NO" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-5">
                   <asp:TextBox ID="ContactNoTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Contact Number is required" ControlToValidate="ContactNoTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                </div>
                 <div class="form-group">
                     <asp:Label runat="server" ID="Label6" Text="Division Name" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-5">
                    <asp:TextBox ID="DivisionNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Division name is required" ControlToValidate="DivisionNameTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                </div>
                 <div class="form-group">
                     <asp:Label runat="server" ID="Label7" Text="District Name" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-5">
                    <asp:TextBox ID="DistrictNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="District is required" ControlToValidate="DistrictNameTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                </div>
                 <div class="form-group">
                     <asp:Label runat="server" ID="Label8" Text="Area Name" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-5">
                    <asp:TextBox ID="AreaNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Area name is required" ControlToValidate="AreaNameTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-5 col-sm-offset-2" style="margin-top: 10px">
                        <asp:Button ID="RegisterButton" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="RegisterButton_Click" />
                    </div>
                </div>
                  <div class="form-group">
                       <asp:Label ID="MessageLabel" runat="server" CssClass="control-label col-sm-offset-2"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
