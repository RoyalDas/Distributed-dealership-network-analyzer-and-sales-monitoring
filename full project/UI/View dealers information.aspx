<%@ Page Title="View dealers information" Language="C#" MasterPageFile="~/UI/MainUi.Master" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="View dealers information.aspx.cs" Inherits="full_project.UI.View_dealers_information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
    <div class="container">
            <div class="row">
                <div class="col-sm-12 text-center">
                    <asp:GridView ID="DealersinfoGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnPageIndexChanging="DealersinfoGridView_PageIndexChanging" PageSize="3">
                          <Columns>
                             <asp:TemplateField HeaderText="Name">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("Name") %>' ID="label1"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Email">
                                 <ItemTemplate >
                                     <asp:Label runat="server" Text='<%#Eval("Email") %>' ID="label2"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="ContactNo">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("ContactNo") %>' ID="label3"></asp:Label>
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
                </div>
            </div>
        </div>
        <asp:Label ID="MessageLabel1" runat="server"></asp:Label>
</asp:Content>
