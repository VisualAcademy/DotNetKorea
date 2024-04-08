<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnswerCommentSummaryControl.ascx.cs" Inherits="MemoEngine.Answers.Controls.AnswerCommentSummaryControl" %>

<%
foreach (var m in Model)
{
%>
    <div class="post_item">
        <div class="post_item_text">
            <span class="post_date"><%= m.PostDate.ToString("yyyy-MM-dd") %></span>
            <span class="post_title">
                <a href="/Answers/AnswerDetails.aspx?Id=<%= m.ArticleId %>">
                    <%= MemoEngine.Answers.StringLibrary.CutStringUnicode(m.Opinion, 15) %> 
                </a>
            </span>
        </div>
    </div>
<%
}
%>
