<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainCommentSummaryControl.ascx.cs" Inherits="MemoEngine.Supports.Controls.MainCommentSummaryControl" %>

<%
foreach (var m in Model)
{
%>
    <div class="post_item">
        <div class="post_item_text">
            <span class="post_date"><%= m.PostDate.ToString("yyyy-MM-dd") %></span>
            <span class="post_title">
                <a href="/Supports/SupportDetails.aspx?Id=<%= m.ArticleId %>">
                    <%= MemoEngine.Supports.StringLibrary.CutStringUnicode(m.Opinion, 15) %> 
                </a>
            </span>
        </div>
    </div>
<%
}
%>
