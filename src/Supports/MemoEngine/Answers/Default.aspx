<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MemoEngine.Answers.Default" %>

<%@ Register Src="~/Answers/Controls/AnswerCommentSummaryControl.ascx" TagPrefix="uc1" TagName="AnswerCommentSummaryControl" %>
<%@ Register Src="~/Answers/Controls/MainSummaryWithThumbNail.ascx" TagPrefix="uc1" TagName="MainSummaryWithThumbNail" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Answers 게시판 프로젝트</h1>

            <uc1:AnswerCommentSummaryControl runat="server" ID="AnswerCommentSummaryControl" />
            
            <hr />

            <img src="ThumbNail.aspx?FileName=RedPlus.jpg" />
            <img src="ThumbNail.aspx?FileName=RedPlus.jpg&Width=200&Height=200" />
            <img src="ThumbNail.aspx?FileName=RedPlus.jpg&Width=300&Height=400" />
            
            <hr />

            <uc1:MainSummaryWithThumbNail runat="server" id="MainSummaryWithThumbNail" />
        </div>
    </form>
</body>
</html>
