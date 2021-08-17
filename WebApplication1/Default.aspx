<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>
<%@ Register Src="~/ucControlimage.ascx" TagPrefix="uc1" TagName="ucControlimage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
    <uc1:ucControlimage runat="server" id="ucControlimage" MyTitle="測試一下" BackColor="Blue" />
    <uc1:WebUserControl1 runat="server" ID="WebUserControl2" />
    <uc1:ucControlimage runat="server" id="ucControlimage1" />
    <uc1:WebUserControl1 runat="server" ID="WebUserControl3" />
    <uc1:ucControlimage runat="server" id="ucControlimage2" />
  
</asp:Content>

