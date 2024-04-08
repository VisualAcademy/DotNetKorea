<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardCore.Master" AutoEventWireup="true" CodeBehind="AnswerDelete.aspx.cs" Inherits="MemoEngine.Answers.AnswerDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Breadcrumb-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">Home</li>
        <li class="breadcrumb-item">
            <a href="#">Admin</a>
        </li>
        <li class="breadcrumb-item active">글 삭제</li>
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
            <%--게시판 삭제 작성 시작--%>
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <div class="card">
                        <div class="card-body">

                            <h2 class="text-center">Q&amp;A 게시판</h2>
                            <h4>글 삭제 - 글을 삭제하려면 글 작성시에 기록하였던 비밀번호가 필요합니다.</h4>
                            <hr />

                            <%--글 삭제 폼 시작--%>
                            <div style="text-align: center;">
                                <asp:Label ID="lblId" runat="server" ForeColor="Red"></asp:Label>번 글을 지우시겠습니까?<br />
                                비밀번호 : <asp:TextBox ID="txtPassword" runat="server" 
                                    Width="120px" CssClass="form-control" Style="display: inline-block;" TextMode="Password"></asp:TextBox>
                                <asp:Button ID="btnDelete" runat="server" Width="100px" CssClass="btn btn-danger" Style="display: inline-block;" Text="지우기"
                                    OnClick="btnDelete_Click" OnClientClick="return ConfirmDelete();"></asp:Button>
                                <asp:HyperLink ID="lnkCancel" runat="server" CssClass="btn btn-default">취소</asp:HyperLink>
                                <br />
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
                                <br />
                            </div>
                            <%--글 삭제 폼 종료--%>
                        </div>
                    </div>
                </div>
                <!-- /.col-->
            </div>
            <%--게시판 삭제 작성 종료--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
    <script>
        function ConfirmDelete() {
            var varFlag = false;
            if (window.confirm("현재 글을 삭제하시겠습니까?")) {
                varFlag = true;
            }
            else {
                varFlag = false;
            }
            return varFlag;
        }
    </script>
</asp:Content>
