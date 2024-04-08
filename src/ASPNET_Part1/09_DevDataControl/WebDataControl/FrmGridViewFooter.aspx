<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmGridViewFooter.aspx.cs" Inherits="MemoEngine.Demos.ASPNET.WebForms._09_DevDataControl.WebDataControl.FrmGridViewFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="고객번호" DataSourceID="SqlDataSource1"
            ShowFooter="true" FooterStyle-BackColor="Yellow" OnRowDataBound="GridView1_RowDataBound"
            OnRowCreated="GridView1_RowCreated">
            <Columns>
                <asp:BoundField DataField="고객번호" HeaderText="고객번호" ReadOnly="True" InsertVisible="False" SortExpression="고객번호"></asp:BoundField>
                <asp:BoundField DataField="이름" HeaderText="이름" SortExpression="이름"></asp:BoundField>
                <asp:BoundField DataField="포인트" HeaderText="포인트" SortExpression="포인트"></asp:BoundField>
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [고객테이블]"></asp:SqlDataSource>    
    </div>
    </form>
</body>
</html>
