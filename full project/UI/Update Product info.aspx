<%@ Page Title="Edit Product info" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="Update Product info.aspx.cs" Inherits="full_project.UI.Update_Product_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
    <div class="container">
        <div class="row">
            <div class="col-sm-7">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label1" Text="Product Name" CssClass="col-sm-2 control-label"></asp:Label>
                        <div class="col-sm-5">
                            <asp:DropDownList runat="server" ID="ProductDropDownList" DataTextField="name" DataValueField="id" CssClass="form-control" OnSelectedIndexChanged="ProductDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select product" ControlToValidate="ProductDropDownList" CssClass="text-danger" ForeColor=" Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-sm-2 control-label" ID="Label2" Text="Previous Price"></asp:Label>
                        <div class="col-sm-5">
                            <asp:TextBox runat="server" ID="PreviousPriceTextBox" CssClass="form-control"></asp:TextBox>

                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-sm-2 control-label" ID="Label3" Text="Update Price"></asp:Label>
                        <div class="col-sm-5">
                            <asp:TextBox runat="server" ID="UpadtePriceTextBox" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter new price" ControlToValidate="UpadtePriceTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-5 col-sm-offset-2" style="margin-top: 10px">
                        <asp:Button ID="UpdateButton" runat="server" Text="Save" OnClick="UpdateButton_Click" CssClass="btn btn-primary" />
                    </div>
                    <div class="col-sm-5 col-sm-offset-2">
                        <asp:Label ID="messagelabel" runat="server"></asp:Label>
                    </div>


                </div>
            </div>
            <div class="col-sm-5" runat="server" id="ImageDiv">
                <div class="thumbnail">
                    <asp:Image ID="Image1" runat="server" />
                    <asp:Label runat="server" ID="ProducNamelabel"></asp:Label>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
