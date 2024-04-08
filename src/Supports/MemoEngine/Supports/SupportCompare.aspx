<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardCore.Master" AutoEventWireup="true" CodeBehind="SupportCompare.aspx.cs" Inherits="MemoEngine.Supports.SupportCompare" EnableSessionState="true" %>

<%@ Register Src="~/Supports/Controls/AdvancedPagingSingleWithBootstrap.ascx" TagPrefix="uc1" TagName="AdvancedPagingSingleWithBootstrap" %>
<%@ Register Src="~/Supports/Controls/BoardSearchFormSingleControl.ascx" TagPrefix="uc1" TagName="BoardSearchFormSingleControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .articleList th {
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Breadcrumb-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">Home</li>
        <li class="breadcrumb-item">
            <a href="#">게시판</a>
        </li>
        <li class="breadcrumb-item active">Q&amp;A 리스트</li>
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
                                                DataKeyNames="Id"
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
                                                        <span style="color: red;">현재 게시판에 입력된 데이터가 없습니다.
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
                                                    <asp:TemplateField HeaderText="선택" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <input type="button" class="btn btn-sm" value="전체선택" id="btnCheckAll" onclick="this.value=CheckAll(this.form.chkSelect);" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%--<input type="checkbox" name="chkSelect" value="<%# Eval("Id") %>" />--%>
                                                            <asp:CheckBox ID="chkSelect" runat="server" ClientIDMode="Static" />
                                                            <asp:HiddenField ID="hdnSelect" runat="server" Value='<%# Eval("Id") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="제 목" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="350px">
                                                        <ItemTemplate>
                                                            <%# MemoEngine.Supports.BoardLibrary.FuncStep(Eval("Step")) %>
                                                            <asp:HyperLink ID="lnkTitle" runat="server" NavigateUrl='<%# "SupportDetails.aspx?Id=" + Eval("Id") %>'>
                                                        <%# MemoEngine.Supports.StringLibrary.CutStringUnicode(Eval("Title").ToString(), 30) %>
                                                            </asp:HyperLink>
                                                            <%# MemoEngine.Supports.BoardLibrary.ShowCommentCount(Eval("CommentCount")) %>
                                                            <%# MemoEngine.Supports.BoardLibrary.FuncNew(Eval("PostDate"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Name" HeaderText="작성자" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="작성일" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <%# MemoEngine.Supports.BoardLibrary.FuncShowTime(Eval("PostDate")) %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <%--게시판 그리드--%>
                                        </div>

                                        <%--비교 조건--%>
                                        <table>
                                            <tr>
                                                <td style="width: 100px; text-align: right; padding-right: 10px;">
                                                    비교 조건:
                                                </td>
                                                <td style="padding-top: 10px;">
                                                    <asp:RadioButtonList ID="lstCompareCondition" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0" style="padding-right: 40px;">조회수</asp:ListItem>
                                                        <asp:ListItem Value="1" style="padding-right: 40px;">다운수</asp:ListItem>
                                                        <asp:ListItem Value="2" style="padding-right: 40px;">댓글수</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnCompare" runat="server" Text="비교 조회" OnClick="btnCompare_Click" CssClass="btn btn-primary" CausesValidation="false" />
                                                </td>
                                            </tr>
                                        </table>
                                        <%--비교 조건--%>
                                            
                                        <div id="compareChartArea">
                                            <%--탭--%>
                                            <ul class="nav nav-tabs" id="tabTitle" role="tablist">
                                                <li class="nav-item">
                                                    <a href="#chartGraph" class="nav-link active" id="chartGraph-tab" data-toggle="tab" role="tab" aria-controls="first" aria-selected="false">차트</a>
                                                </li>
                                                <li class="nav-item">
                                                    <a href="#chartData" class="nav-link" id="chartData-tab" data-toggle="tab" role="tab" aria-controls="second" aria-selected="false">데이터</a>
                                                </li>
                                            </ul>
                                            <div class="tab-content" id="tabContent">
                                                <div class="tab-pane fade show active" id="chartGraph" role="tabpanel" aria-labelledby="chartGraph-tab">
                                                    <div class="row">
                                                        <div class="text-center">
                                                            <div style="width: 500px; height: 300px;" class="text-center">
                                                                <%--바차트 들어올 영역 --%>
                                                                <canvas id="myCompareChart"></canvas>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="tab-pane fade" id="chartData" role="tabpanel" aria-labelledby="chartData-tab">
                                                    <div class="row">
                                                        <div class="text-center">
                                                            <div style="width: 100%; height: 300px;" class="text-center">
                                                                <asp:GridView ID="ctlSelectedData" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="제목" DataField="Title" />
                                                                        <asp:BoundField HeaderText="조회수" DataField="ReadCount" />
                                                                        <asp:BoundField HeaderText="다운수" DataField="DownCount" />
                                                                        <asp:BoundField HeaderText="댓글수" DataField="CommentCount" />
                                                                    </Columns>
                                                                </asp:GridView>                                              
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--탭--%>
                                        </div>

                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td class="text-center">
                                        <uc1:AdvancedPagingSingleWithBootstrap runat="server" ID="AdvancedPagingSingleWithBootstrap"
                                            RecordCount="90" PageSize="10" PageIndex="2" UiFramework="Bootstrap4" />
                                    </td>
                                </tr>
                            </table>

                            <div style="display: none;">
                                <uc1:BoardSearchFormSingleControl runat="server" ID="BoardSearchFormSingleControl" />
                            </div>

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


    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../lib/chartjs/Chart.js"></script>
    
<script>
    //[1] 체크박스 전체 선택 및 전체 해제
    var chkFlag = false; // 체크 해제된 상태
    function CheckAll(arrSelect) {
        if (chkFlag == false) {
            for (var i = 0; i < arrSelect.length; i++) {
                arrSelect[i].checked = true; // 체크박스 선택
            }
            chkFlag = true;
            return "전체해제";
        }
        else {
            for (var i = 0; i < arrSelect.length; i++) {
                arrSelect[i].checked = false; // 체크박스 해제
            }
            chkFlag = false;
            return "전체선택";
        }
    }
    //[2] 체크 박스 선택 시 해당 행의 배경색 변경
    $(function () {
        $('input[name="chkSelect"]').on('change', function () {
            $(this)
                .closest('tr')
                    .toggleClass('info',
                        $(this).is(':checked'));
        });
        $("#btnCheckAll").on('click', function () {
            $('input[name="chkSelect"]')
                .closest('tr')
                    .toggleClass('info',
                        $('input[name = "chkSelect"]'
                            ).is(':checked'));
        });
    });
</script>

<script>
    var myCompareContext = document.getElementById("myCompareChart").getContext('2d');
    var myCompareChart = new Chart(myCompareContext, {
        type: 'bar',
        data: {
            labels: [<%= ChartLabels %>],
            datasets: [{
                borderColor: 'rgba(54, 162, 235, 0.2)',
                backgroundColor: 'rgba(54, 162, 235, 0.75)',
                fill: false,
                data: [
                    <%= ChartDatas %>
                ]
            }]
        },
        options: {
            title: {
                display: true,
                text: '<%= ChartTitle %> 비교'
            },
            scales: {
                xAxes: [{
                    stacked: true, 
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: '게시판 제목'
                    }
                }],
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    },
                    type: 'linear',
                    stacked: true,
                    display: true,
                    position: 'left',
                    scaleLabel: {
                        display: true,
                        labelString: '<%= ChartTitle %>'
                    }
                }]
            },
            legend: {
                display: false
            }
        }
    }); 
</script>

</asp:Content>
