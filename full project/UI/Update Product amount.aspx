<%@ Page Title="Enrich stock center" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="Update Product amount.aspx.cs" Inherits="full_project.UI.Update_Product_amount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
    <div class="row">
            <div class="col-sm-7">
                <div class="container">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Product Name" CssClass="col-sm-2 control-label" ID="Label1"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList runat="server" ID="ProductNameDropDownList" CssClass="form-control" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="ProductNameDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select product" ControlToValidate="ProductNameDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="label2" Text="quantity" CssClass="col-sm-2 control-label"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox runat="server" ID="QuantityTextbox" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Quantity is required" ControlToValidate="QuantityTextbox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-sm-5 col-sm-offset-2 " style="margin-top: 10px">
                            <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" CssClass="btn btn-primary" />
                        </div>
                        <div class="col-sm-5 col-sm-offset-2">
                            <asp:Label ID="MessageLabel" runat="server" CssClass="col-sm-11"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-5" runat="server" id="ImageDiv">
            <div class="thumbnail">
                <asp:Image ID="Image1" runat="server" />
                <asp:Label runat="server" ID="ProducNamelabel"></asp:Label>
            </div>
        </div>
        </div>
</asp:Content>
