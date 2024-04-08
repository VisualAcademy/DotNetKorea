<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmStringLibraryTest.aspx.cs" 
    Inherits="Dul.Test.FrmStringLibraryTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        입력 문자열: 
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="6자만 출력" OnClick="Button1_Click" /><br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
