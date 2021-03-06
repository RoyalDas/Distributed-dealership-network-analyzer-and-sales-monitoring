﻿<%@ Page Title="Distribute Product" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="Distribute Products by areaname.aspx.cs" Inherits="full_project.UI.Distribute_Products_by_areaname" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
        <div class="container">
            <div class="row">
                <div class="col-sm-7">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Division Name" class="col-sm-2 control-label"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="divisionDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="divisionDropDownList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Division is required" ControlToValidate="divisionDropDownList" CssClass="text-danger" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="District Name" class="col-sm-2 control-label"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="zillaDropDownList" runat="server" AutoPostBack="True" DataTextField="Zillaname" DataValueField="ProductId" OnSelectedIndexChanged="zillaDropDownList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="District is required" ControlToValidate="zillaDropDownList" CssClass="text-danger" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Area Name" class="col-sm-2 control-label"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="areaDropDownList" runat="server" DataTextField="Areaname" DataValueField="ProductId" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Area Name is Required" ControlToValidate="areaDropDownList" CssClass="text-danger" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="ProDuct Name" CssClass="col-sm-2 control-label"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ProductNameDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ProductNameDropDownList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Product" ControlToValidate="ProductNameDropDownList" CssClass="text-danger" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Price" class="col-sm-2 control-label"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="valueTextBox" runat="server" PlaceHolder="Price" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Price is requires" ControlToValidate="valueTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Quantity" CssClass="col-sm-2 control-label"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="QuantityTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Quantity is required" ControlToValidate="QuantityTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-5 col-sm-offset-2" style="margin-top: 10px">
                            <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" CssClass="btn btn-primary" />
                        </div>
                        <div class="col-sm-5 col-sm-offset-2">
                             <asp:Label ID="MessageLabel" runat="server" CssClass="col-sm-11"></asp:Label>
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
            <div class="row">
                <div class="col-sm-7">
                     <asp:GridView runat="server" ID="ProductGridView" AutoGenerateColumns="False">
                         <Columns>
                             <asp:TemplateField HeaderText="Product Name">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("ProductName") %>' ID="label1"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Price">
                                 <ItemTemplate >
                                     <asp:Label runat="server" Text='<%#Eval("price") %>' ID="label2"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Available">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("Available") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
</asp:Content>
