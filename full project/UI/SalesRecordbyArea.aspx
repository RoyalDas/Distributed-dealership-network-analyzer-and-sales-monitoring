<%@ Page Title="Fixed Product Sales record of a area" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="SalesRecordbyArea.aspx.cs" Inherits="full_project.UI.SalesRecordbyArea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
         <div class="container">
            <div class="row">
                <br />
                <div class="col-sm-7">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label1" Text="Division Name" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="divisionDropDownList" runat="server" AutoPostBack="True" DataTextField="Divisionname" DataValueField="ProductId" CssClass="form-control" OnSelectedIndexChanged="divisionDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select division" ControlToValidate="divisionDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label2" Text="District Name" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="zillaDropDownList" runat="server" AutoPostBack="True" DataTextField="Zillaname" DataValueField="ProductId" CssClass="form-control" OnSelectedIndexChanged="zillaDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select District" ControlToValidate="zillaDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label3" Text="Area Name" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="areaDropDownList" runat="server" CssClass="form-control" DataTextField="Areaname" DataValueField="ProductId"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select area" ControlToValidate="areaDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label4" Text="Product Name" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ProductNameDropDownList" runat="server" CssClass="form-control" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="ProductNameDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select Product" ControlToValidate="ProductNameDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-5 col-sm-offset-2" style="margin-top: 10px">
                                <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchButton_Click" />
                            </div>
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
                <br />
                <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                             <asp:TemplateField HeaderText="Product Name">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("ProductName") %>' ID="label1"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Price">
                                 <ItemTemplate >
                                     <asp:Label runat="server" Text='<%#Eval("Price") %>' ID="label2"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Quantity">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("Quantity") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                          <asp:TemplateField HeaderText="Division Name">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("DivisionName") %>' ID="label1"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="District Name">
                                 <ItemTemplate >
                                     <asp:Label runat="server" Text='<%#Eval("DistrictName") %>' ID="label2"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Area name">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("AreaName") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                </asp:GridView>
                <asp:Label ID="messagelabel" runat="server"></asp:Label>
            </div>

        </div>
</asp:Content>
