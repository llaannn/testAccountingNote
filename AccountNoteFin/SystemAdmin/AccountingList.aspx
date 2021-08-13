<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountNoteFin.SystemAdmin.AccountingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
            <tr>
                <td colspan="2">
                    <h1>流水帳管理系統 後台 Var2</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <a href ="UserInfo.aspx">使用者資訊</a><br />
                    <a href ="AccountingList.aspx">流水帳管理</a>
                </td>
                <td>
                  <%--<編輯頁面>--%>
                  <asp:Button ID="btnCreate" runat="server" Text="建立新紀錄" OnClick="btnCreate_Click" />    
                  <asp:GridView ID="gvAccList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvAccList_RowDataBound" >
                 <Columns>

                     <asp:BoundField DataField="Caption" HeaderText="標題" />
                     <asp:BoundField DataField="Amount" HeaderText="金額" />
                   <%--  <asp:BoundField DataField="ActType" HeaderText="收入或支出" />--%>
                       <asp:TemplateField HeaderText="IN/OUT">
                           <ItemTemplate>
                              <%-- <%#((int)Eval("ActType") == 0)? "支出"  : "收入" %>--%>
                               <asp:Literal ID="ltActType" runat="server"></asp:Literal>
                               <asp:Label ID="lblActType" runat="server" Text="Label"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>

                     <asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="建立日期" />
                     <asp:TemplateField HeaderText="Act">
                         <ItemTemplate>
                             <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">編輯</a>
                         </ItemTemplate>
                     </asp:TemplateField> 
                 <%--   <asp:TemplateField HeaderText="Act">
                         <ItemTemplate>
                             <a href="/Admin/AccountingDetail.aspx?ID=<%= Eval("ID") %>">編輯</a>
                         </ItemTemplate>
                     </asp:TemplateField>--%>
                 </Columns>
                  </asp:GridView>

                  <asp:PlaceHolder ID="plcNoData" runat="server" Visible ="false">
                    <p style="color:firebrick; background-color:khaki" >
                        你的流水帳中沒有資料
                    </p>
                </asp:PlaceHolder>
                </td>
            </tr>

        </table>
    </form>
</body>
</html>
