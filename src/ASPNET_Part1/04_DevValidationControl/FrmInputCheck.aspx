<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInputCheck.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._04_DevValidationControl.FrmInputCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function CheckUserID(source, args) {
            if (args.Value.length < 3 || args.Value.length > 15) {
                args.IsValid = false; // 에러
            }
            else {
                args.IsValid = true; // 통과 
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<fieldset>
    <legend>값을 입력하시오.</legend>

    아이디 : 
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="valName" runat="server" ValidationGroup="a"
        ControlToValidate="txtName" SetFocusOnError="true"
        ErrorMessage="아이디를 반드시 입력하시오."></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="valNameSize" runat="server" ValidationGroup="a"
        ControlToValidate="txtName"
        ErrorMessage="아이디는 3자 이상 15자 이하로 입력하시오." 
        ClientValidationFunction="CheckUserID"
        onservervalidate="valNameSize_ServerValidate"></asp:CustomValidator>
    <br />

    암호 : 
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="valPassword" runat="server" ValidationGroup="a"
        ControlToValidate="txtPassword" ForeColor="Red" SetFocusOnError="true"
        ErrorMessage="암호를 반드시 입력하시오."></asp:RequiredFieldValidator>
    <br />
    
    암호 확인 : 
    <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="valPasswordConfirm" runat="server" ValidationGroup="a"
        ControlToValidate="txtPassword"
        ControlToCompare="txtPasswordConfirm" Type="String" 
        ErrorMessage="암호를 다시 확인하세요."></asp:CompareValidator>
    <br />

    나이 :
    <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
    <asp:RangeValidator ID="valAge" runat="server" ValidationGroup="a"
        ControlToValidate="txtAge" Display="None"
        MaximumValue="150" MinimumValue="1" Type="Integer"
        ErrorMessage="나이는 1~150 사이의 값을 입력하시오."></asp:RangeValidator>
    <br />

    이메일 : 
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="valEmail" runat="server" ValidationGroup="a"
        ControlToValidate="txtEmail" Display="None"        
        ErrorMessage="이메일을 정확히 입력하시오." 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <br />

    <asp:Button ID="btnSubmit" runat="server" Text="입력" ValidationGroup="a" />

    <asp:Button ID="btnClick" runat="server" Text="취소" ValidationGroup="b" />

    <div>
        <asp:ValidationSummary ID="valSummary" runat="server" 
            ShowMessageBox="true" ShowSummary="false" /> 
    </div>

</fieldset>
    
    </div>
    </form>
</body>
</html>
