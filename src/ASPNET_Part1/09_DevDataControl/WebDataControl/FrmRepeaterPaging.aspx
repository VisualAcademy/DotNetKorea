<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRepeaterPaging.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._09_DevDataControl.WebDataControl.FrmRepeaterPaging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>리피터 컨트롤 페이징</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:AdventureWorks2012ConnectionString %>' SelectCommand="SELECT Top 100 [CustomerID], [PersonID], [StoreID] FROM [Sales].[Customer]"></asp:SqlDataSource>

            <hr />

            Total :
            <asp:Label ID="lblRecordCount" runat="server" Text=""></asp:Label>
            <asp:Repeater ID="lstCustomers" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Customer ID</th>
                            <th>Person ID</th>
                            <th>Store ID</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("CustomerID") %>
                        </td>
                        <td>
                            <%# Eval("PersonID") %>
                        </td>
                        <td>
                            <%# Eval("CustomerID") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>



            <div style="text-align: center;">
                <%--리피터 컨트롤을 사용한 고급 페이징 기법--%>
                <asp:LinkButton ID="lnkPrev" runat="server" OnClick="Page_Changed" Font-Size="9pt">&lt;</asp:LinkButton>

                <asp:Repeater ID="lstPager" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkPage" runat="server" Font-Size="9pt" Text='<%# Eval("Text") %>'
                            CommandArgument='<%# Eval("Value") %>' OnClick="Page_Changed"
                            OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'
                            Font-Bold='<%# !Convert.ToBoolean(Eval("Enabled")) %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:LinkButton ID="lnkNext" runat="server" OnClick="Page_Changed" Font-Size="9pt">&gt;</asp:LinkButton>
            </div>


        </div>
    </form>
</body>
</html>
