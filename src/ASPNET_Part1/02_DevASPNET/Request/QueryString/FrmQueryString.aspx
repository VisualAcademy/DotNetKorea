<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmQueryString.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._02_DevASPNET.Request.QueryString.FrmQueryString" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <a href="FrmQueryStringProcess.aspx?ServerName=WindowsServer">
            링크를 통해서 다른 페이지에 쿼리스트링 전송
        </a>
        <hr />
        <a href="FrmQueryStringProcess.aspx?ServerName=SqlServer">
            링크를 통해서 다른 페이지에 쿼리스트링 전송
        </a>
        <hr />
        <asp:TextBox ID="txtServerName" runat="server"></asp:TextBox>
        <asp:Button ID="btnGo" runat="server" Text="쿼리스트링을 가지고 페이지 이동" OnClick="btnGo_Click" />

    </div>
    </form>
</body>
</html>
