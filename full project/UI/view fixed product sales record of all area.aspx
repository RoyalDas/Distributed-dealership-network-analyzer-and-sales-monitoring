<%@ Page Title="Sales record of all area" Language="C#" MasterPageFile="~/UI/MainUi.Master" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="view fixed product sales record of all area.aspx.cs" Inherits="full_project.UI.view_fixed_product_sales_record_of_all_area" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
     <div class="container">
            <div class="row">
                <br />
                <div class="form-horizontal">
                    <br />
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label1" Text="Product Name" CssClass="control-label col-sm-2"></asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList ID="ProductNameDropDownList" DataTextField="name" DataValueField="id" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Plese select product" ControlToValidate="ProductNameDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-sm-offset-2" style="margin-top: 10px">
                            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <br />
                <asp:GridView ID="fixedproductGridView" runat="server" AutoGenerateColumns="False">
                     <Columns>
                             <asp:TemplateField HeaderText="Product Name" >
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("ProductName") %>' ID="label1" ></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Price" ItemStyle-CssClass="hidden-phone" HeaderStyle-CssClass="hidden-phone" >
                                 <ItemTemplate >
                                     <asp:Label runat="server" Text='<%#Eval("price") %>' ID="label2"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Quantity"  ItemStyle-CssClass="hidden-phone" HeaderStyle-CssClass="hidden-phone" >
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("Quantity") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                                <asp:TemplateField HeaderText="Divison Name"  HeaderStyle-CssClass="visible-desktop" ItemStyle-CssClass="visible-desktop">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("DivisionName") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                               <asp:TemplateField HeaderText="District Name">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("DistrictName") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                               <asp:TemplateField HeaderText="Area Name">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("AreaName") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                </asp:GridView>

                <asp:Label runat="server" ID="messagelabel"></asp:Label>

            </div>
        </div>
</asp:Content>
