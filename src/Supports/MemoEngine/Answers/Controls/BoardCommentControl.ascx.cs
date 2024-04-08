using System;
using System.Configuration;

namespace MemoEngine.Answers.Controls
{
    public partial class BoardCommentControl : System.Web.UI.UserControl
    {
        private readonly IAnswerCommentRepository repository;

        public BoardCommentControl()
        {
            repository = new AnswerCommentRepository(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            // 데이터 출력(현재 게시글의 번호(Id)에 해당하는 댓글 리스트)
            ctlCommentList.DataSource = repository.GetComments(Convert.ToInt32(Request["Id"]));
            ctlCommentList.DataBind();
        }

        protected void btnWriteComment_Click(object sender, EventArgs e)
        {
            var comment = new AnswerComment();
            comment.ArticleId = Convert.ToInt32(Request["Id"]); // 부모글(AnswerDetails.aspx?Id=<부모글>)
            comment.Name = txtName.Text; // 이름
            comment.Password = txtPassword.Text; // 암호
            comment.Opinion = txtOpinion.Text; // 댓글

            // 데이터 입력
            repository.AddComment(comment);

            Response.Redirect($"{Request.ServerVariables["SCRIPT_NAME"]}?Id={Request["Id"]}");
        }
    }
}
