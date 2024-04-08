<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmMultiView_View.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._03_DevStandardControl.FrmMultiView_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MultiView와 View 컨트롤</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:DropDownList ID="ddlPhoneNumber" runat="server">
                        <asp:ListItem>010</asp:ListItem>
                        <asp:ListItem Value="019">019</asp:ListItem>
                        <asp:ListItem Value="018" Text="018"></asp:ListItem>
                        <asp:ListItem>017</asp:ListItem>
                        <asp:ListItem>016</asp:ListItem>
                    </asp:DropDownList>
                    -
                    <asp:TextBox ID="txtFirstNumber" runat="server"></asp:TextBox>
                    -
                    <asp:TextBox ID="txtSecondNumber" runat="server"></asp:TextBox>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                </asp:View>
            </asp:MultiView>

            <hr />
            <asp:Button ID="btnGetPhoneNumber" runat="server" Text="입력한 값 가져오기" OnClick="btnGetPhoneNumber_Click" />

            <hr />
            <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
