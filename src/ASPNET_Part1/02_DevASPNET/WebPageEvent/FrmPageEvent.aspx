<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPageEvent.aspx.cs"
    Inherits="MemoEngine.Demos.ASPNET.WebForms._02_DevASPNET.WebPageEvent.FrmPageEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>페이지 이벤트 확인 : Page_Load와 PostBack 살펴보기</h2>
            현재 페이지 로드 시간 : 
            <asp:Label ID="lblLoadTime" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnPostBack" runat="server" Text="현재 페이지 포스트백(다시게시) 시키기" />
            <br />
            <asp:DropDownList ID="lstFavorites" runat="server">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
