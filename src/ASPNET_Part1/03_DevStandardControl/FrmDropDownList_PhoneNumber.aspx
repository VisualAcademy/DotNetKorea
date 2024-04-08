<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDropDownList_PhoneNumber.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._03_DevStandardControl.FrmDropDownList_PhoneNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>드롭다운리스트(콤보박스, 리스트박스)에 전화번호 바인딩</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlPhoneNumber" runat="server">
                <asp:ListItem>010</asp:ListItem>
                <asp:ListItem Value="019">019</asp:ListItem>
                <asp:ListItem Value="018" Text="018"></asp:ListItem>
                <asp:ListItem>017</asp:ListItem>
                <asp:ListItem>016</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="btnPostBack" runat="server" Text="포스트백 테스트" />
        </div>
    </form>
</body>
</html>
