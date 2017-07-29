<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="View Product Details of area.aspx.cs" Inherits="full_project.UI.View_Product_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr/>
    <div class="container">
        <div class="row">
            <br />
            <div class="form-horizontal" runat="server">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Division Name" CssClass="control-label col-sm-2"></asp:Label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="divisionDropDownList" runat="server"  AutoPostBack="True" DataTextField="Divisionname" DataValueField="Id" OnSelectedIndexChanged="divisionDropDownList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Division" ControlToValidate="divisionDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="District Name" CssClass="control-label col-sm-2"></asp:Label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="zillaDropDownList" runat="server"  AutoPostBack="True" DataTextField="Zillaname" DataValueField="Id" OnSelectedIndexChanged="zillaDropDownList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select district" ControlToValidate="zillaDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                   <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="AreaName" CssClass="control-label col-sm-2"></asp:Label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="areaDropDownList" runat="server" DataTextField="Areaname" DataValueField="Id" OnSelectedIndexChanged="areaDropDownList_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select Area" ControlToValidate="areaDropDownList" InitialValue="-1" CssClass="text-danger" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                </div>
                    
                
            </div>
             </div>
        <div class="row">
            <div class="col-sm-12">
               <asp:GridView ID="ProductGridView" runat="server" CssClass="form-control"></asp:GridView>
              </div>
        </div>
        </div>
</asp:Content>
