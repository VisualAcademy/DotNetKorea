<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="FrmValidationControl.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._04_DevValidationControl.FrmValidationControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>필수 입력 확인</h1>

            <asp:TextBox ID="txtInput" runat="server" Text="아이디"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valInputIntialValue" runat="server"
                ErrorMessage="값을 입력하시오." Display="Dynamic"
                InitialValue="아이디"
                ControlToValidate="txtInput">
            </asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="valInput" runat="server"
                ErrorMessage="값을 입력하시오." Display="Dynamic"
                ControlToValidate="txtInput">
            </asp:RequiredFieldValidator>
            <br />

            <asp:Button ID="btnInput" runat="server" Text="입력" 
                OnClick="btnInput_Click" /><br />

            <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>