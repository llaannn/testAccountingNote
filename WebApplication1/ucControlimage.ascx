<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucControlimage.ascx.cs" Inherits="WebApplication1.ucControlimage" %>
<div style="background-color:aquamarine" runat="server" id="divMain">
    <img runat="server" id="imgCover" src="Image/cat.png" height="80" width="130"  />
<span>
    <asp:Literal ID="ltlTitle1111" runat="server"></asp:Literal>
    <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
</span>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</div>
