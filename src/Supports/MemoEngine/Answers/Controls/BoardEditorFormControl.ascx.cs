using System;
using System.Configuration;
using System.IO;

namespace MemoEngine.Answers.Controls
{
    public partial class BoardEditorFormControl : System.Web.UI.UserControl
    {
        #region 공통 속성
        /// <summary>
        /// 글쓰기 폼 형식: Write, Modify, Reply 
        /// </summary>
        public BoardWriteFormType FormType { get; set; }

        /// <summary>
        /// 상단 메시지 출력 영역: Create(Write), Edit(Modify), Reply에서 넘어온 문자열 값 
        /// </summary>
        public string Message { get; set; } = "글 쓰기 - 다음 필드들을 채워주세요.";

        /// <summary>
        /// 파일 업로드 폴더: Web.config의 FILE_UPLOAD_FOLDER 항목: BLOB이 아닌 로컬에 저장할 때 사용할 폴더 
        /// </summary>
        public string FileUploadPath { get; set; }
        #endregion

        #region 파일 관련 필드
        /// <summary>
        /// 파일명 저장 필드
        /// </summary>
        private string _FileName = String.Empty;

        /// <summary>
        /// 파일크기 저장 필드
        /// </summary>
        private int _FileSize = 0;
        #endregion

        /// <summary>
        /// 앞(리스트)에서 넘겨져 온 번호 저장
        /// </summary>
        private string _Id; // Request["Id"], Request["Num"]

        private readonly string connectionString;
        private readonly IAnswerRepository _repository;

        public BoardEditorFormControl()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _repository = new AnswerRepository(connectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request.QueryString["Id"];
            FileUploadPath = Server.MapPath("/BoardFiles/Answers");

            if (!Page.IsPostBack) // 처음 로드할 때에만 바인딩
            {
                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        lblTitleDescription.Text = "글 쓰기 - 다음 필드들을 채워주세요.";
                        break;
                    case BoardWriteFormType.Modify:
                        lblTitleDescription.Text = "글 수정 - 아래 항목을 수정하세요.";
                        DisplayDataForModify();
                        break;
                    case BoardWriteFormType.Reply:
                        lblTitleDescription.Text = "글 답변 - 다음 필드들을 채워주세요.";
                        DisplayDataForReply();
                        break;
                }
            }
        }

        private void DisplayDataForReply()
        {
            // 넘겨온 Id 값에 해당하는 레코드 하나 읽어서 모델 클래스에 바인딩
            var model = _repository.GetById(Convert.ToInt32(_Id));

            txtTitle.Text = $"Re : {model.Title}";
            //string content = $"<br /><br />On {model.PostDate}, '{model.Name}' wrote:<hr />{model.Content}";
            string content = $"\r\n\r\nOn {model.PostDate}, '{model.Name}' wrote:\r\n{model.Content}";
            txtContent.Text = content;
        }

        private void DisplayDataForModify()
        {
            //[A] 넘겨온 Id 값에 해당하는 레코드 하나 읽어서 모델 클래스에 바인딩
            var model = _repository.GetById(Convert.ToInt32(_Id));

            //[B] 각각의 항목을 컨트롤(레이블, 텍스트박스, ...)에 출력 
            ddlCategoryList.SelectedValue = model.Category; // 기존 값 선택
            txtName.Text = model.Name;
            txtEmail.Text = model.Email;
            txtHomepage.Text = model.Homepage;
            txtTitle.Text = model.Title;
            txtContent.Text = model.Content;

            //[C] 인코딩 방식에 따른 데이터 출력
            string strEncoding = model.Encoding;
            if (strEncoding == "Text") // Text : 소스 그대로 표현
            {
                rdoEncoding.SelectedIndex = 0;
            }
            else if (strEncoding == "Mixed") // Mixed : 엔터처리만
            {
                rdoEncoding.SelectedIndex = 2;
            }
            else // HTML : HTML 형식으로 출력
            {
                rdoEncoding.SelectedIndex = 1;
            }

            //[D] 첨부된 파일명 및 파일크기 기록
            if (model.FileName.Length > 1)
            {
                ViewState["FileName"] = model.FileName;
                ViewState["FileSize"] = model.FileSize;

                pnlFile.Height = 50;
                lblFileNamePrevious.Visible = true;
                lblFileNamePrevious.Text = $"기존에 업로드된 파일명: {model.FileName}";
            }
            else
            {
                ViewState["FileName"] = "";
                ViewState["FileSize"] = 0;
            }
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            // 보안 문자를 정확히 입력했거나, 로그인이 된 상태라면...
            if (IsImageTextCorrect())
            {
                UploadProcess(); // 파일 업로드 관련 코드 분리

                // 폼의 값들을 모델 클래스에 담기 
                var model = new ArticleBase();
                model.Id = Convert.ToInt32(_Id);
                model.Category = ddlCategoryList.SelectedValue; // 카테고리
                model.Name = HtmlUtility.Encode(txtName.Text);
                model.Email = HtmlUtility.Encode(txtEmail.Text);
                model.Homepage = txtHomepage.Text;
                model.Title = HtmlUtility.Encode(txtTitle.Text);
                model.Content = txtContent.Text;
                model.FileName = _FileName;
                model.FileSize = _FileSize;
                model.Password = txtPassword.Text;
                model.PostIp = Request.UserHostAddress;
                model.Encoding = rdoEncoding.SelectedValue;

                // 폼 타입에 따른 저장/수정/답변 로직 적용
                switch (FormType)
                {
                    case BoardWriteFormType.Modify:
                        model.ModifyIp = Request.UserHostAddress;
                        model.FileName = ViewState["FileName"].ToString();
                        model.FileSize = Convert.ToInt32(ViewState["FileSize"]);
                        int r = _repository.UpdateModel(model);
                        if (r > 0) // 업데이트 완료
                        {
                            Response.Redirect($"AnswerDetails.aspx?Id={_Id}");
                        }
                        else
                        {
                            lblError.Text = "업데이트가 되지 않았습니다. 암호를 확인하세요.";
                        }
                        break;
                    case BoardWriteFormType.Reply:
                        model.ParentNum = Convert.ToInt32(_Id);
                        _repository.ReplyModel(model);
                        Response.Redirect("AnswerIndex.aspx");
                        break;
                    default:
                        _repository.Add(model);
                        Response.Redirect("AnswerIndex.aspx");
                        break;
                }
            }
            else
            {
                lblError.Text = "보안코드가 틀립니다. 다시 입력하세요.";
            }
        }

        /// <summary>
        /// 파일 업로드 처리 시작
        /// </summary>
        private void UploadProcess()
        {
            if (txtFileName.PostedFile != null)
            {
                // 업로드된 파일이 있으면 업로드 
                if (txtFileName.PostedFile.FileName.Trim().Length > 0 && txtFileName.PostedFile.ContentLength > 0)
                {
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["AZURE_STORAGE_ENABLE"].ToString()))
                    {
                        UploadFileToAzureBlobStorage();
                    }
                    else
                    {
                        UploadFileToLocalStorage();
                    }
                }
            }
        }

        #region Create, Edit, Reply 폼에서 txtFileName 파일 컨트롤의 파일을 로컬 저장소로 업로드하는 공식 코드
        /// <summary>
        /// 로컬 저장소에 파일 업로드 진행: IaaS 환경
        /// </summary>
        private void UploadFileToLocalStorage()
        {
            //[1] 만약, 수정 페이지면 기존 파일명과 파일크기 대체 
            if (FormType == BoardWriteFormType.Modify) // BoardModify, ProductEdit, AnswerEdit
            {
                ViewState["FileName"] = FileUtility.GetFileNameWithNumbering(FileUploadPath, Path.GetFileName(txtFileName.PostedFile.FileName)); // 파일명 중복처리
                ViewState["FileSize"] = txtFileName.PostedFile.ContentLength;

                //업로드 처리: SaveAs()
                txtFileName.PostedFile.SaveAs(Path.Combine(FileUploadPath, ViewState["FileName"].ToString()));
            }
            else // BoardWrite, BoardReply
            {
                _FileName = FileUtility.GetFileNameWithNumbering(FileUploadPath, Path.GetFileName(txtFileName.PostedFile.FileName));
                _FileSize = txtFileName.PostedFile.ContentLength;

                //업로드 처리: SaveAs()
                txtFileName.PostedFile.SaveAs(Path.Combine(FileUploadPath, _FileName));
            }
        } 
        #endregion

        private void UploadFileToAzureBlobStorage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 로그인하였거나, 이미지 텍스트를 정상적으로 입력하면 true 값 반환
        /// </summary>
        private bool IsImageTextCorrect()
        {
            if (Page.User.Identity.IsAuthenticated || 
                (Session["UserID"] != null && Session["UserID"].ToString() != "Anonymous"))
            {
                // 로그인되었다면, 이미지 텍스트 비교가 완료되었다고 가정
                return true;
            }
            else
            {
                if (Session["ImageText"] != null)
                {
                    return (txtImageText.Text == Session["ImageText"].ToString());
                }
            }
            return false; // 보안 코드를 통과하지 못함
        }

        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {
            pnlFile.Visible = !pnlFile.Visible; 
        }
    }
}
