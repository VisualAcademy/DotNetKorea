<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmBulletedList.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._09_DevDataControl.StandardControl.FrmBulletedList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Circle">
                <asp:ListItem Text="Home" Value="0"></asp:ListItem>
                <asp:ListItem Text="About" Value="1"></asp:ListItem>
            </asp:BulletedList>

            <asp:BulletedList ID="BulletedList2" runat="server" BulletStyle="Circle">
                <asp:ListItem Text="Home" Value="0"></asp:ListItem>
                <asp:ListItem Text="About" Value="1"></asp:ListItem>
            </asp:BulletedList>
        </div>
    </form>
</body>
</html>
