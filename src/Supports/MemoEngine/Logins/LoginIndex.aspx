<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardCore.Master" AutoEventWireup="true" CodeBehind="LoginIndex.aspx.cs" Inherits="MemoEngine.Logins.LoginIndex" EnableSessionState="true" %>

<%@ Register Src="~/Logins/Controls/AdvancedPagingSingleWithBootstrap.ascx" TagPrefix="uc1" TagName="AdvancedPagingSingleWithBootstrap" %>
<%@ Register Src="~/Logins/Controls/BoardSearchFormSingleControl.ascx" TagPrefix="uc1" TagName="BoardSearchFormSingleControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .articleList th {
            text-align: center;
        }
    </style>
    <link href="/lib/bootstrap-datepicker/css/bootstrap-datepicker.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Breadcrumb-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">Home</li>
        <li class="breadcrumb-item">
            <a href="#">게시판</a>
        </li>
        <li class="breadcrumb-item active">로그인 리스트</li>
        <!-- Breadcrumb Menu-->
        <li class="breadcrumb-menu d-md-down-none">
            <div class="btn-group" role="group" aria-label="Button group">
                <a class="btn" href="#">
                    <i class="icon-speech"></i>
                </a>
                <a class="btn" href="./">
                    <i class="icon-graph"></i>Dashboard</a>
                <a class="btn" href="#">
                    <i class="icon-settings"></i>Settings</a>
            </div>
        </li>
    </ol>

    <div class="container-fluid">
        <div class="animated fadeIn">

            <%--게시판 리스트 작성 시작--%>
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <div class="card">
                        <div class="card-body">

                            <h2 class="text-center">로그인 리스트</h2>
                            <h4>전체 로그인 리스트입니다.</h4>
                            <hr />
                            <uc1:BoardSearchFormSingleControl runat="server" ID="BoardSearchFormSingleControl" />
                            <table style="width: 100%; margin: 0 auto;">
                                <tr>
                                    <td>
                                        <div style="font-style: italic; text-align: right; font-size: 8pt;">
                                            Total Record:
                                            <asp:Literal ID="lblTotalRecord" runat="server">1234</asp:Literal>
                                        </div>

                                        <div class="table-responsive">
                                            <%--게시판 그리드--%>
                                            <asp:GridView ID="ctlBoardList" runat="server"
                                                AutoGenerateColumns="false"
                                                DataKeyNames="LoginId"
                                                HeaderStyle-CssClass="text-center"
                                                HeaderStyle-HorizontalAlign="Center"
                                                Width="100%"
                                                CssClass="table table-bordered table-hover table-striped table-condensed articleList">
                                                <HeaderStyle CssClass="thead-light" />
                                                <EmptyDataTemplate>
                                                    <div style="width: 100%; height: 130px; border: 1px solid red; text-align: center; vertical-align: middle;">
                                                        <% if (SearchMode)
                                                            {
                                                        %>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <span style="color: red;">"<%= SearchQuery %>"로 검색한 데이터가 없습니다.
                                                        </span>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <%       
                                                            }
                                                            else
                                                            {
                                                        %>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <span style="color: red;">사용자 로그인 데이터가 없습니다.
                                                        </span>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <%        
                                                            }
                                                        %>
                                                    </div>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="번호" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <%# Eval("LoginId") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="UserName" HeaderText="아이디" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                                    <asp:BoundField DataField="LoginIp" HeaderText="접속 IP주소" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="접속일시" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <%# Eval("LoginDate") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <%--게시판 그리드--%>
                                        </div>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <uc1:AdvancedPagingSingleWithBootstrap runat="server" ID="AdvancedPagingSingleWithBootstrap" RecordCount="90" PageSize="10" PageIndex="2" UiFramework="Bootstrap4" />
                                    </td>
                                </tr>
                            </table>

                            

                        </div>
                    </div>
                </div>
                <!-- /.col-->
            </div>
            <%--게시판 리스트 작성 종료--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
<script src="/lib/bootstrap-datepicker/js/bootstrap-datepicker.min.js"></script>
<script>
    $(function () {
        $('#txtStartDate').datepicker({format: 'yyyy-mm-dd'});
        $('#txtEndDate').datepicker({format: 'yyyy-mm-dd'});
    });
</script>
</asp:Content>
