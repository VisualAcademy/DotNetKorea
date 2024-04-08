using System;
using System.Configuration;

namespace MemoEngine.Supports.Controls
{
    public partial class BoardCommentControl : System.Web.UI.UserControl
    {
        private readonly SupportCommentRepository _repository;
        
        public BoardCommentControl()
        {
            _repository = new SupportCommentRepository(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
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
            ctlCommentList.DataSource = _repository.GetComments(Convert.ToInt32(Request["Id"]), Session["UserName"].ToString());
            ctlCommentList.DataBind();
        }

        protected void btnWriteComment_Click(object sender, EventArgs e)
        {
            var comment = new SupportComment();
            comment.ArticleId = Convert.ToInt32(Request["Id"]); // 부모글(SupportDetails.aspx?Id=<부모글>)
            comment.Name = txtName.Text; // 이름
            comment.Password = txtPassword.Text; // 암호
            comment.Opinion = txtOpinion.Text; // 댓글
            comment.UserName = Session["UserName"].ToString(); // 사용자 아이디 

            // 데이터 입력
            _repository.AddComment(comment);

            Response.Redirect($"{Request.ServerVariables["SCRIPT_NAME"]}?Id={Request["Id"]}");
        }
    }
}
