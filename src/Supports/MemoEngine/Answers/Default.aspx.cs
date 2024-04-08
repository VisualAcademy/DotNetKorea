using System;

namespace MemoEngine.Answers
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Answers/AnswerIndex.aspx");
        }
    }
}
