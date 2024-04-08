<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmGridViewCellBackColor.aspx.cs" Inherits="Demos.ASPNET.WebForms._09_DevDataControl.WebDataControl.FrmGridViewCellBackColor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ASP.NET GridView Cell BackColor</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Select" CommandName="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>    
    </div>
    </form>
</body>
</html>
