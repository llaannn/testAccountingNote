﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="AccountNoteFin.SystemAdmin.UserInfo" %>

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
                    <table>
                        <tr>
                            <th>帳號</th>
                            <td>
                                <asp:Literal ID="ltlAcc" runat="server"></asp:Literal>
                            </td>
                        </tr>

                        <tr>
                            <th>姓名</th>
                            <td>
                                <asp:Literal ID="ltlName" runat="server"></asp:Literal>
                            </td>
                        </tr>

                        <tr>
                            <th>信箱</th>
                            <td>
                                <asp:Literal ID="ltlEmail" runat="server"></asp:Literal>
                            </td>
                        </tr>

                    </table>
                    <asp:Button ID="btnLogout" runat="server" Text="登出" OnClick="btnLogout_Click" />
                </td>
            </tr>

       

        </table>

    </form>
</body>
</html>
