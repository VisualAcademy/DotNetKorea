<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmTextToTable.aspx.cs" Inherits="WebTextToTable.FrmTextToTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>텍스트(엑셀) 데이터를 데이터베이스의 테이블로 가져오기</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>텍스트 데이터를 테이블로 복사</h1>
        <asp:TextBox ID="txtSourceDate" runat="server" TextMode="MultiLine" Height="209px" Width="498px"></asp:TextBox>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="저장" OnClick="btnSave_Click" />
        <hr />
        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
