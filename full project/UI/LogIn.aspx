<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" UnobtrusiveValidationMode="none" Inherits="full_project.UI.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../bootstrap-3.3.7/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container col-sm-12 col-sm-offset-1" style="margin-top: 200px;">
            <div class="form-horizontal center-page" >
                <div class="form-group">
                    <asp:Label runat="server" ID="Label1" Text="UserName" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="UserNameTextBox" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="UserName is Required" ForeColor="red" ControlToValidate="UserNameTextBox" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>
                 <div class="form-group">
                    <asp:Label runat="server" ID="Label2" Text="Password" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-5">
                        <asp:TextBox runat="server" ID="PasswordTextBox" CssClass="form-control" TextMode="Password"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is Required" ForeColor="red" ControlToValidate="PasswordTextBox" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-5 col-md-offset-2">
                        <div>
                            <div class="col-sm-3">
                                <asp:CheckBox runat="server" ID="CheckBox1"/>
                                <asp:Label runat="server" ID="Label3" Text="remember me?" CssClass="control-label" ></asp:Label>
                            </div>
                            <asp:LinkButton runat="server"  CssClass="col-sm-5 col-sm-offset-4" ID="LinkButton" CausesValidation="False" PostBackUrl="ResetPassword.aspx">Forgot password</asp:LinkButton>
                        </div>
                    </div>
                </div>
                 <div class="form-group">
                    <div class="col-md-5 col-md-offset-2">
                        <div>
                            <div class="col-sm-3">
                                 <asp:Button runat="server" ID="SignInButton" Text="Sign In" CssClass="btn btn-primary" OnClick="SignInButton_Click" />
                            </div>
                            <asp:LinkButton runat="server"  CssClass="col-sm-5 col-sm-offset-4" ID="LinkButton1" CausesValidation="False" PostBackUrl="Registration.aspx">Register</asp:LinkButton>
                        </div>
                    </div>
                </div>
        
                <div class="form-group">
                    <div class="col-sm-10 col-sm-offset-2">
                        <asp:Label runat="server" ID="MessageLabel"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../Jquery/jquery-3.1.1.js"></script>
    <script src="../bootstrap-3.3.7/js/bootstrap.min.js"></script>
</body>
</html>
