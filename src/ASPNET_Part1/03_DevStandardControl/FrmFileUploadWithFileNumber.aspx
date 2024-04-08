<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmFileUploadWithFileNumber.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._03_DevStandardControl.FrmFileUploadWithFileNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            아이콘: 
            <asp:FileUpload ID="txtGroupIcon" runat="server" />
            <hr />
            <asp:Button ID="btnUpload" runat="server" Text="아이콘 업로드" OnClick="btnUpload_Click" />
        </div>
    </form>
</body>
</html>
