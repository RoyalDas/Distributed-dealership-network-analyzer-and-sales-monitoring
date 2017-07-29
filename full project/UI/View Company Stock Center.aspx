<%@ Page Title="View company stock center" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" CodeBehind="View Company Stock Center.aspx.cs" Inherits="full_project.UI.View_Company_Stock_Center" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
    <asp:GridView ID="ProductGridview" runat="server" AutoGenerateColumns="False">
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
                              <asp:TemplateField HeaderText="Available">
                                 <ItemTemplate>
                                     <asp:Label runat="server" Text='<%#Eval("Available") %>' ID="label3"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                          <asp:TemplateField HeaderText="Image">
                                 <ItemTemplate>
                                     <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%#Eval("ImageData") %>' /> 
                                 </ItemTemplate>
                             </asp:TemplateField>
                              
                         </Columns>
    </asp:GridView>
    <asp:Label ID="messagelabel" runat="server" ></asp:Label>
</asp:Content>
