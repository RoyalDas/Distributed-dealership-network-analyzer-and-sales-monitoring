<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="view previous sales update by areaname.aspx.cs" Inherits="full_project.UI.view_previous_sales_update_by_areaname" %>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select division" ControlToValidate="divisionDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="District Name" class="col-sm-2 control-label"></asp:Label>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="zillaDropDownList" runat="server" AutoPostBack="True" DataTextField="Zillaname" DataValueField="ProductId" OnSelectedIndexChanged="zillaDropDownList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select district" ControlToValidate="zillaDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                            <asp:Label runat="server" Text="Area Name" class="col-sm-2 control-label"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="areaDropDownList" runat="server" DataTextField="Areaname" DataValueField="ProductId" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Plese select Area" ControlToValidate="areaDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label4" Text="Product Name" CssClass="control-label col-sm-2"></asp:Label>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ProductNameDropDownList" runat="server" DataTextField="name" DataValueField="id" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ProductNameDropDownList_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select Product" ControlToValidate="ProductNameDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label5" Text="Select Date" CssClass="control-label col-sm-2"></asp:Label>
                        <div class="col-sm-5">
                            <asp:TextBox runat="server" ID="DateTextBox" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter a date" ControlToValidate="DateTextBox" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-5 col-sm-offset-2" style="margin-top: 10px">
                            <asp:Button ID="ViewButton" runat="server" Text="View" CssClass="btn btn-primary" OnClick="ViewButton_Click" />
                            <asp:Label ID="messagelabel" runat="server"></asp:Label>
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
        </div>
        <div class="row" style="margin-top: 10px; margin-left: 20px; margin-right: 20px">
            <div class="form-group">
                <div class="col-sm-8 col-sm-offset-3">
                    <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
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
