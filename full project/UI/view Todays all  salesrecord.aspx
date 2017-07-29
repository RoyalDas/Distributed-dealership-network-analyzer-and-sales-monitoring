<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true"  CodeBehind="view Todays all  salesrecord.aspx.cs" Inherits="full_project.UI.view_Todays_all__salesrecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
    <div>
        <asp:GridView ID="ViewAllSalesRecordGridView" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="ViewAllSalesRecordGridView_PageIndexChanging" PageSize="8">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label runat="server" text='<%#Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="quantity">
                    <ItemTemplate>
                        <asp:Label runat="server" text='<%#Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label runat="server" text='<%#Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DivisionName">
                    <ItemTemplate>
                        <asp:Label runat="server" text='<%#Eval("DivisionName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DistrictName">
                    <ItemTemplate>
                        <asp:Label runat="server" text='<%#Eval("DistrictName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AreaName">
                    <ItemTemplate>
                        <asp:Label runat="server" text='<%#Eval("AreaName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br/>
        <asp:Label runat="server" ID="messagelabel"></asp:Label>
    </div>
</asp:Content>
