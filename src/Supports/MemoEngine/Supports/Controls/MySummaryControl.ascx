<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MySummaryControl.ascx.cs" Inherits="MemoEngine.Supports.Controls.MySummaryControl" %>

<%--게시판 리스트 작성 시작--%>
<div class="row">
    <div class="col-sm-12 col-md-12">
        <div class="card">
            <div class="card-header">
                Q&amp;A 게시판
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <%--게시판 그리드--%>
                    <asp:GridView ID="ctlBoardList" runat="server"
                        DataSourceID="objSupports"
                        AllowPaging="true"
                        PageSize="5"
                        PagerStyle-BackColor="White" PagerStyle-Font-Size="XX-Small"
                        AutoGenerateColumns="false"
                        DataKeyNames="Id"
                        HeaderStyle-CssClass="text-center"
                        HeaderStyle-HorizontalAlign="Center"
                        Width="100%"
                        CssClass="table table-bordered table-hover table-striped table-condensed articleList">
                        <HeaderStyle CssClass="thead-light" />
                        <PagerStyle HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            <div style="width: 100%; height: 130px; border: 1px solid red; text-align: center; vertical-align: middle;">
                                <br />
                                <br />
                                <br />
                                <span style="color: red;">현재 게시판에 입력된 데이터가 없습니다.
                                </span>
                                <br />
                                <br />
                                <br />
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="번호" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# Eval("Id") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="분류" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# ConvertToCategoryString(Eval("Category")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="제 목" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="350px">
                                <ItemTemplate>
                                    <%# MemoEngine.Supports.BoardLibrary.FuncStep(Eval("Step")) %>
                                    <asp:HyperLink ID="lnkTitle" runat="server" NavigateUrl='<%# "~/Supports/SupportDetails.aspx?Id=" + Eval("Id") %>'>
                                                        <%# MemoEngine.Supports.StringLibrary.CutStringUnicode(Eval("Title").ToString(), 30) %>
                                    </asp:HyperLink>
                                    <%# MemoEngine.Supports.BoardLibrary.ShowCommentCount(Eval("CommentCount")) %>
                                    <%# MemoEngine.Supports.BoardLibrary.FuncNew(Eval("PostDate"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="파일" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# MemoEngine.Supports.BoardLibrary.FuncFileDownSingle(Convert.ToInt32(Eval("Id")), Eval("FileName").ToString(), Eval("FileSize").ToString(), "Supports") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="작성자" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:TemplateField HeaderText="작성일" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# MemoEngine.Supports.BoardLibrary.FuncShowTime(Eval("PostDate")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ReadCount" HeaderText="조회수" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="60px"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <%--게시판 그리드--%>
                </div>
            </div>
            <div class="card-footer">
                <asp:HyperLink ID="btnWrite" runat="server" NavigateUrl="~/Supports/SupportCreate.aspx" CssClass="btn btn-primary btn-lg" Width="200px">질문하기</asp:HyperLink>
            </div>
        </div>
    </div>
    <!-- /.col-->
</div>
<%--게시판 리스트 작성 종료--%>

<asp:ObjectDataSource ID="objSupports" runat="server"
    EnablePaging="true"
    TypeName="MemoEngine.Supports.Controls.MySupport"
    SelectMethod="GetSupports"
    SelectCountMethod="GetSupportsCount"
    StartRowIndexParameterName="startIndex"
    MaximumRowsParameterName="maxRows"></asp:ObjectDataSource>
