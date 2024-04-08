using System;
using System.Configuration;

namespace MemoEngine.Supports
{
    public partial class SupportDelete : System.Web.UI.Page
    {
        private readonly SupportRepository repository;

        public SupportDelete()
        {
            repository = new SupportRepository(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        // 상세 페이지에서 넘어온 Id 값 저장 
        public int Id { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(Request.QueryString["Id"]);

            lblId.Text = Id.ToString();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // 현재 글(Id)의 비밀번호가 맞으면 삭제
            int result = repository.Delete(Convert.ToInt32(Id), txtPassword.Text, Session["UserName"].ToString());
            if (result > 0)
            {
                Response.Redirect("SupportIndex.aspx");
            }
            else
            {
                lblMessage.Text = "삭제되지 않았습니다. 비밀번호를 확인하세요.";
            }
        }
    }
}
