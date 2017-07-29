<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="view product sales record within a time limit.aspx.cs" Inherits="full_project.UI.view_product_sales_record_within_a_time_limit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
     <div class="container">
            <div class="row">
                <br/>
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label1" Text="Start Date" CssClass="control-label col-sm-2"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="StartTextBox" runat="server"  TextMode="Date" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter start Date" ControlToValidate="StartTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label2" Text="End Date" CssClass="control-label col-sm-2"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="EndTextBox" runat="server"  TextMode="Date" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter a end date" ControlToValidate="EndTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-2">
                             <asp:Button runat="server" ID="SearchButoon" Text="Search" CssClass="btn btn-primary" OnClick="SearchButoon_Click"/>
                        </div>
                    </div>
                    <div class="col-sm-6 col-sm-offset-2">
                        <asp:Label runat="server" ID="messagelabel" ></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                  <asp:GridView runat="server" ID="ProductGridView" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                      <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                      <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#F1F1F1" />
                      <SortedAscendingHeaderStyle BackColor="#594B9C" />
                      <SortedDescendingCellStyle BackColor="#CAC9C9" />
                      <SortedDescendingHeaderStyle BackColor="#33276A" />
                        <Columns>
                             <asp:TemplateField HeaderText="Date">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("SpecificDate") %>' ID="label1"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
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
                              <asp:TemplateField HeaderText="Quantity">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("Quantity") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="DivisionName">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("DivisionName") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="DistrictName">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("DistrictName") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="AreaName">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("AreaName") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
</asp:Content>
