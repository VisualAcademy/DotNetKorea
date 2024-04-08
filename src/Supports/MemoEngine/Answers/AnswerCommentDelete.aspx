<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardCore.Master" AutoEventWireup="true" CodeBehind="AnswerCommentDelete.aspx.cs" Inherits="MemoEngine.Answers.AnswerCommentDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Breadcrumb-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">Home</li>
        <li class="breadcrumb-item">
            <a href="#">게시판</a>
        </li>
        <li class="breadcrumb-item active">Q&amp;A 댓글 삭제</li>
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

            <%--게시판 댓글삭제 작성 시작--%>
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <div class="card">
                        <div class="card-body">

                            <h2 class="text-center">Q&amp;A 게시판</h2>
                            <h4>댓글 삭제 - 정확한 암호를 입력하시면 댓글을 삭제하실 수 있습니다.</h4>
                            <hr />
                            
                            <%--댓글 삭제 폼 시작--%>
                            <table style="width: 500px; margin-left: auto; margin-right: auto;">
                                <tr>
                                    <td colspan="2">
                                        <i class="glyphicon glyphicon-lock"></i><span style="font-size: 12pt;">댓글 삭제</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <span>해당 댓글을 삭제하시려면 올바른 암호를 입력하십시오.</span><br />
                                        암호(<u>P</u>):
                                        <asp:TextBox ID="txtPassword" runat="server" 
                                            TextMode="Password" MaxLength="40" Width="250px" AccessKey="P" TabIndex="2" CssClass="form-control" 
                                            Style="display: inline-block;">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center;">
                                        <asp:Button ID="btnCommentDelete" runat="server" 
                                            Text="확인" CssClass="btn btn-danger" 
                                            OnClick="btnCommentDelete_Click" OnClientClick="return confirm('삭제하시겠습니까?');" />
                                        <asp:RequiredFieldValidator ID="valPassword" runat="server" 
                                            ErrorMessage="암호를 입력하세요." ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />
                                        <input type="button" value="뒤로" onclick="history.go(-1);" class="btn btn-default"><br />
                                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <%--댓글 삭제 폼 종료--%>


                        </div>
                    </div>
                </div>
                <!-- /.col-->
            </div>
            <%--게시판 댓글삭제 작성 종료--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
