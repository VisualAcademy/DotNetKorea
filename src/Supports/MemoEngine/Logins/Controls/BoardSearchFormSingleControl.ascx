<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoardSearchFormSingleControl.ascx.cs" Inherits="MemoEngine.Logins.Controls.BoardSearchFormSingleControl" %>
<div style="text-align: center;" class="row">
    <div class="col-md-4 col-sm-4">
        <asp:DropDownList ID="SearchField" runat="server" CssClass="form-control" Width="100px" Style="display: inline-block;">
            <asp:ListItem Value="UserName">아이디</asp:ListItem>
            <asp:ListItem Value="LoginIp">접속IP주소</asp:ListItem>
        </asp:DropDownList>&nbsp;
        <asp:TextBox ID="SearchQuery" runat="server" Width="150px" CssClass="form-control" Style="display: inline-block;">
        </asp:TextBox>&nbsp;
<%--        <asp:RequiredFieldValidator ID="valSearchQuery" runat="server"
            ControlToValidate="SearchQuery" Display="None" ErrorMessage="검색할 아이디를 입력하세요."></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>--%>
    </div>
    <div class="col-md-6 col-sm-6">
        <asp:Label ID="Label1" runat="server" Text="접속 일시"></asp:Label>
        <asp:TextBox ID="txtStartDate" runat="server" Width="150px" CssClass="form-control" Style="display: inline-block;" ClientIDMode="Static"></asp:TextBox>~<asp:TextBox ID="txtEndDate" runat="server" Width="150px" CssClass="form-control" Style="display: inline-block;" ClientIDMode="Static"></asp:TextBox>
    </div>
    <div class="col-md-2 col-sm-2">
        <asp:Button ID="btnSearch" runat="server"
            Text="검 색" CssClass="form-control" Width="150px" Style="display: inline-block;" OnClick="btnSearch_Click"></asp:Button>
    </div>
</div>
<br />

<% if (!string.IsNullOrEmpty(Request.QueryString["SearchField"]) && !String.IsNullOrEmpty(Request.QueryString["SearchQuery"]))
    { %>
<div style="text-align: center;">
    <a href="/Logins/LoginIndex.aspx" class="btn btn-success">검색 완료</a>
</div>
<% } %>
