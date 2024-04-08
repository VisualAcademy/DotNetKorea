﻿using System;
using System.Configuration;
using System.Web;

namespace MemoEngine.Supports
{
    public partial class SupportIndex : System.Web.UI.Page
    {
        #region 아티클 검색 관련 속성들 
        /// <summary>
        /// 현재 보기 모드가 기본(Normal) 모드(false)인지 검색(Search) 모드(true)인지 확인
        /// </summary>
        public bool SearchMode { get; set; } = false;
        /// <summary>
        /// 검색 필드: Name(UserId), Title, Content
        /// </summary>
        public string SearchField { get; set; } = "Title";
        /// <summary>
        /// 검색 내용
        /// </summary>
        public string SearchQuery { get; set; } = "";
        #endregion

        public int PageNumber = 1; // 현재 보여줄 페이지 번호
        public int PageSize { get; set; } = 10; // 몇 개의 항목을 표시할지 
        public int RecordCount = 0; // 총 레코드 갯수(글번호 순서 정렬용)

        private readonly string connectionString;
        private readonly SupportRepository _repository;
        private string userName; // 사용자 아이디 

        public SupportIndex()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _repository = new SupportRepository(connectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Session["UserName"].ToString(); // 세션변수는 페이지 로드에서 선언 

            #region 검색 모드 결정: 검색 모드이면 SearchMode 속성이 true
            // 검색 모드 결정: 검색 모드이면 SearchMode 속성이 true
            if (
                !String.IsNullOrEmpty(HttpContext.Current.Request["SearchQuery"])
                &&
                !String.IsNullOrEmpty(HttpContext.Current.Request["SearchField"]))
            {
                SearchMode = true;
                SearchField = SqlUtility.EncodeSqlString(HttpContext.Current.Request["SearchField"]); // 검색할 필드
                SearchQuery = SqlUtility.EncodeSqlString(HttpContext.Current.Request["SearchQuery"]); // 검색할 내용
            }
            #endregion

            #region 쿠키로 페이지 번호 유지
            // Page 쿼리스트링 또는 쿠키에 저장된 Page 번호에 해당하는 페이지 값으로 PageNumber 변수 초기화
            string cookieName = Request["BoardName"]; // 단일형("ArticleIndex") 또는 멀티형 게시판(게시판 별칭)
            if (string.IsNullOrEmpty(cookieName))
            {
                cookieName = "ArticleIndex";
            }
            if (!String.IsNullOrEmpty(Request["Page"]))
            {
                PageNumber = Convert.ToInt32(Request["Page"]);
                Response.Cookies[cookieName]["Page"] = PageNumber.ToString(); // 페이지 번호 유지
            }
            else
            {
                // 쿠키를 사용한 리스트 페이지 번호 유지 적용: 각 게시판별 페이지 번호가 따로 저장됨 ["Notice"]["Page"], ["Free"]["Page"] 식으로
                if (Request.Cookies[cookieName] != null && Request.Cookies[cookieName]["Page"] != null)
                {
                    if (!String.IsNullOrEmpty(Request.Cookies[cookieName]["Page"]))
                    {
                        PageNumber = Convert.ToInt32(Request.Cookies[cookieName]["Page"]);
                    }
                }
            }
            #endregion

            #region 레코드 카운트 출력
            // 레코드 카운트 출력
            if (!SearchMode)
            {
                if (AccountHandler.HasGroup("Administrators"))
                {
                    // 전체 레코드 수 출력
                    RecordCount = _repository.GetCountAllAdmin();
                }
                else
                {
                    // 전체 레코드 수 출력
                    RecordCount = _repository.GetCountAll(userName);
                }
            }
            else
            {
                if (AccountHandler.HasGroup("Administrators"))
                {
                    // 검색된 레코드 수 출력
                    RecordCount = _repository.GetCountBySearchAdmin(SearchField, SearchQuery);
                }
                else
                {
                    // 검색된 레코드 수 출력
                    RecordCount = _repository.GetCountBySearch(userName, SearchField, SearchQuery);
                }
            }
            lblTotalRecord.Text = RecordCount.ToString(); // 레코드 수 출력  
            #endregion

            #region 페이징 처리
            // 페이징 처리
            this.AdvancedPagingSingleWithBootstrap.PageIndex = PageNumber - 1;
            this.AdvancedPagingSingleWithBootstrap.RecordCount = RecordCount;
            #endregion

            // 페이지 처음 로드시 게시판 데이터 출력 
            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            if (!SearchMode)
            {
                if (AccountHandler.HasGroup("Administrators"))
                {
                    // 기본 리스트
                    ctlBoardList.DataSource = _repository.GetAllAdmin(PageNumber, PageSize);
                }
                else
                {
                    // 기본 리스트
                    ctlBoardList.DataSource = _repository.GetAll(userName, PageNumber, PageSize);
                }
            }
            else
            {
                if (AccountHandler.HasGroup("Administrators"))
                {
                    // 검색 리스트 
                    ctlBoardList.DataSource = _repository.GetSearchAllAdmin(SearchField, SearchQuery, PageNumber, PageSize);
                }
                else
                {
                    // 검색 리스트 
                    ctlBoardList.DataSource = _repository.GetSearchAll(userName, SearchField, SearchQuery, PageNumber, PageSize);
                }
            }
            ctlBoardList.DataBind();
        }

        /// <summary>
        /// 카테고리 Value를 다시 카테고리 Text로 변경
        /// </summary>
        public string ConvertToCategoryString(object objCategory)
        {
            string category = objCategory.ToString();
            string r = "기타";
            switch (category)
            {
                case "Question":
                    r = "질문";
                    break; 
                case "Request":
                    r = "건의";
                    break;
                default:
                    r = "기타";
                    break;
            }
            return r; 
        }
    }
}
