using System;
using System.Configuration;

namespace MemoEngine.Answers
{
    public partial class AnswerCommentDelete : System.Web.UI.Page
    {
        private readonly AnswerCommentRepository repository;

        public AnswerCommentDelete()
        {
            repository = new AnswerCommentRepository(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        public int ArticleId { get; set; } // 아티클 글 번호
        public int Id { get; set; } // 댓글 번호

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ArticleId"] != null && Request.QueryString["Id"] != null)
            {
                ArticleId = Convert.ToInt32(Request["ArticleId"]);
                Id = Convert.ToInt32(Request["Id"]);
            }
            else
            {
                Response.End();
            }
        }

        protected void btnCommentDelete_Click(object sender, EventArgs e)
        {
            // 암호가 맞으면 삭제 진행
            if (repository.GetCountBy(ArticleId, Id, txtPassword.Text) > 0)
            {
                repository.DeleteComment(ArticleId, Id, txtPassword.Text);
                Response.Redirect($"AnswerDetails.aspx?Id={ArticleId}");
            }
            else
            {
                lblError.Text = "암호가 틀립니다. 다시 입력해주세요.";
            }
        }
    }
}
