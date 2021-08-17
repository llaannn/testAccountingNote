<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcDomSample.ascx.cs" Inherits="WebApplication1.UcDomSample" %>

<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </asp:PlaceHolder>
    <asp:Image ID="Image1" runat="server" />
</asp:PlaceHolder>
