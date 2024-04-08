using System;
using System.Configuration;

namespace MemoEngine.Answers
{
    public partial class AnswerDetails : System.Web.UI.Page
    {
        private int _Id; // 앞(리스트)에서 넘겨온 번호(아티클) 저장

        private readonly IAnswerRepository _repository;

        public AnswerDetails()
        {
            _repository = new AnswerRepository(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _Id = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                Response.Write("잘못된 접근입니다.");
                Response.Write(ex.Message);
                Response.End();
            }

            // 삭제, 수정, 답변 링크 만들기 
            lnkDelete.NavigateUrl = "AnswerDelete.aspx?Id=" + _Id.ToString();
            lnkModify.NavigateUrl = "AnswerEdit.aspx?Id=" + _Id.ToString();
            lnkReply.NavigateUrl = "AnswerReply.aspx?Id=" + _Id.ToString();

            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            //[A] 넘겨온 Id 값에 해당하는 레코드 하나 읽어서 모델 클래스에 바인딩
            var model = _repository.GetById(_Id);

            //[B] 각각의 항목을 컨트롤(레이블, 텍스트박스, ...)에 출력 
            lblNum.Text = _Id.ToString(); // 번호
            lblName.Text = model.Name; // 이름
            lblEmail.Text = String.Format("<a href=\"mailto:{0}\">{0}</a>", model.Email);
            lblTitle.Text = model.Title;
            lblReadCount.Text = model.ReadCount.ToString();
            lblHomepage.Text = String.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", model.Homepage);
            lblPostDate.Text = model.PostDate.ToString();
            lblPostIp.Text = model.PostIp;

            //[C] 인코딩 방식에 따른 데이터 출력
            string content = model.Content; // 내용
            string strEncoding = model.Encoding;
            if (strEncoding == "Text") // Text: 소스 그대로 표현
            {
                lblContent.Text = HtmlUtility.EncodeWithTabAndSpace(content);
            }
            else if (strEncoding == "Mixed") // Mixed: 엔터처리만
            {
                lblContent.Text = content.Replace("\r\n", "<br />");
            }
            else // HTML: HTML 형식으로 출력
            {
                lblContent.Text = content; // 변환없음
            }
            
            //[D] 파일 다운로드 링크 만들기 
            if (model.FileName.Length > 1)
            {
                lblFile.Text = String.Format(
                    "<a href='./BoardDown.aspx?Id={0}'>" + "{1}{2} / 전송수: {3}</a>",
                    model.Id, "<img src=\"/images/ext/ext_zip.gif\" border=\"0\">",
                    model.FileName, model.DownCount);
                if (BoardLibrary.IsPhoto(model.FileName))
                {
                    ltrImage.Text = "<img src=\'ImageDown.aspx?FileName=" + $"{Server.UrlEncode(model.FileName)}\' class=\"img-fluid rounded\">";
                }
            }
            else
            {
                lblFile.Text = "(업로드된 파일이 없습니다.)";
            }
        }
    }
}
