<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AccountNoteFin.SystemAdmin.UserList" %>

<%@ Register Src="~/UserControl/usPager.ascx" TagPrefix="uc1" TagName="usPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btNew" runat="server" Text="Add" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <uc1:usPager runat="server" id="usPager" />
    <uc1:usPager runat="server" id="usPager1" />
    <uc1:usPager runat="server" id="usPager2" />
</asp:Content>