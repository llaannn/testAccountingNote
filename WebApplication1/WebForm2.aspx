<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

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
                    <h1>示範系統 後台 Var2</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="UserInfo.aspx">使用者資訊</a><br />
                    <a href="AccountingList.aspx">流水帳管理</a><br />
                    <a href="AccountingList.aspx">這邊是做測試的第三頁</a>
                </td>
                <td>
                    <%--<編輯頁面>--%>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    <h1>第二頁</h1>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
