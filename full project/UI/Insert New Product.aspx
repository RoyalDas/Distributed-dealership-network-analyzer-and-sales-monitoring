<%@ Page Title="Insert New Product" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="Insert New Product.aspx.cs" Inherits="full_project.UI.Insert_New_Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="container">
         <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" Text="Product Image" CssClass="col-sm-2 control-label"></asp:Label>
           <div class="col-sm-5">
               <asp:FileUpload ID="ProductFileUpload" runat="server" CssClass="form-control" />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please upload a image" ControlToValidate="ProductFileUpload" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
        </div>
             <div class="form-group">
            <asp:Label runat="server" Text="Name" CssClass="col-sm-2 control-label"></asp:Label>
        <div class="col-sm-5">
            <asp:TextBox runat="server" ID="NameTextBox" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Name is requires" ControlToValidate="NameTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Price" CssClass="col-sm-2 control-label"></asp:Label>
        <div class="col-sm-5">
            <asp:TextBox runat="server" ID="PriceTextBox" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Price is requires" ControlToValidate="PriceTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Quantity" CssClass="col-sm-2 control-label"></asp:Label>
        <div class="col-sm-5">
            <asp:TextBox runat="server" ID="QuantityTextBox" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Quantity is required" ControlToValidate="QuantityTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        </div>
        <div class="col-sm-5 col-sm-offset-2">
        <asp:Button runat="server" ID="SaveButoon" Text="Save" CssClass="btn btn-primary" OnClick="SaveButoon_Click"/>
            </div>
        <div class="col-sm-5 col-sm-offset-2">
            <asp:Label runat="server" ID="Messagelabel"></asp:Label>
        </div>
        </div>
    </div>
     
</asp:Content>
