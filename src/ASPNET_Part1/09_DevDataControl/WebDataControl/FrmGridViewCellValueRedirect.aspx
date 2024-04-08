<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmGridViewCellValueRedirect.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._09_DevDataControl.WebDataControl.FrmGridViewCellValueRedirect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Eval("Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="상품 선택">
                        <ItemTemplate>
                            <a href='<%# FuncRedirect(Eval("Name")) %>'><%# Eval("Name") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
