<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmControl.aspx.cs"
    Inherits="MemoEngine.Demos.ASPNET.WebForms._03_DevStandardControl.FrmControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>표준 컨트롤</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            레이블:
            <asp:Label ID="lblDisplay" runat="server" Text="Label"></asp:Label>
            <br />
            텍스트박스:
            <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
            <br />
            버튼: 
            <asp:Button ID="btnClick" runat="server" Text="클릭" OnClick="btnClick_Click" />
            <br />
            <hr />
            <asp:Calendar ID="ctlCalendar" runat="server" 
                OnSelectionChanged="ctlCalendar_SelectionChanged"></asp:Calendar>
        </div>
    </form>
</body>
</html>
