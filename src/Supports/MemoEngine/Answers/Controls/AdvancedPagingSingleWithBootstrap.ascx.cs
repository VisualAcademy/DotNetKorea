/*
    작성자: 박용준  
    타이틀: MemoEngine - 게시판 리스트 페이징 컨트롤
    코멘트: MemoEngine - 게시판 리스트 페이징 컨트롤
    작성일: 
    수정일: 
*/
using System;
using System.ComponentModel;
using System.Web;

namespace MemoEngine.Answers.Controls
{
    public partial class AdvancedPagingSingleWithBootstrap : System.Web.UI.UserControl
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

        #region 페이저 관련된 속성들
        /// <summary>
        /// 몇번째 페이지를 보여줄 건지: 웹 폼에서 속성으로 전달됨 
        /// </summary>
        [Category("페이징처리")] // Category 특성은 모두 생략 가능(속성에 표시됨)
        public int PageIndex { get; set; } // PageIndex(0, 1, 2, ...), PageNumber(1, 2, 3, ...) 

        /// <summary>
        /// 총 몇 개의 페이지가 만들어지는지: 총 레코드 수 / PageSize(한 페이지에서 보여줄 레코드 수) 
        /// </summary>
        [Category("페이징처리")]
        public int PageCount { get; set; }

        /// <summary>
        /// 페이지 사이즈: 한 페이지에 몇 개의 레코드를 보여줄건지 결정 
        /// </summary>
        [Category("페이징처리")]
        [Description("한 페이지에 몇개의 레코드를 보여줄건지 결정")]
        public int PageSize { get; set; } = 10; // 페이지 사이즈는 기본값이 10

        /// <summary>
        /// 레코드 카운트: 현재 테이블에 몇 개의 레코드가 있는지 지정
        /// </summary>
        private int _RecordCount;
        [Category("페이징처리")]
        [Description("현재 테이블에 몇개의 레코드가 있는지 지정")]
        public int RecordCount
        {
            get { return _RecordCount; }
            set
            {
                _RecordCount = value;
                PageCount = ((_RecordCount - 1) / PageSize) + 1; // 계산식
            }
        }

        /// <summary>
        /// 페이저에 몇 개씩 페이지 버튼을 표시할지
        /// </summary>
        public int PagerButtonCount { get; set; } = 5;
        #endregion
        
        #region UIFramework 선택: Bootstrap3 또는 Bootstrap4
        public string UiFramework { get; set; } = "Bootstrap3";
        public string Alignment { get; set; } = "justify-content-center";
        public string Sizing { get; set; } = ""; // pagination-sm, pagination-lg
        #endregion

        // 페이지 로드할 때 페이저 구현하기
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 검색 모드 결정: 검색 모드이면 SearchMode 속성이 true
            // 검색 모드 결정: 검색 모드이면 SearchMode 속성이 true
            if (
                !String.IsNullOrEmpty(HttpContext.Current.Request["SearchQuery"])
                &&
                !String.IsNullOrEmpty(HttpContext.Current.Request["SearchField"]))
            {
                SearchMode = true;
                SearchField = EncodeSqlString(HttpContext.Current.Request["SearchField"]);
                SearchQuery = EncodeSqlString(HttpContext.Current.Request["SearchQuery"]);
            }
            #endregion

            string strPage = "";

            ++PageIndex; // 코드: 0, 1, 2 인덱스로 사용, UI: 1, 2, 3 페이지로 사용

            string pageItem = "";
            string pageLink = "";
            string alignment = "";
            if (UiFramework != "Bootstrap3")
            {
                strPage += "<nav aria-lable=\"Page navigation\">";
                pageItem = "page-item";
                pageLink = "page-link";
                alignment = Alignment;
            }

            // <!--이전 10개, 다음 10개 페이징 처리 시작-->
            strPage += $"<ul class='pagination {Sizing} {alignment}'>";

            // 페이저 버튼 수만큼 반복 
            int i = 0; 

            #region 처음으로 이동: 1페이지로 이동 버튼 
            if (PageIndex > 1)
            {
                // 검색 모드이면 추가적으로 SearchField와 SearchQuery를 전송함
                if (SearchMode)
                {
                    strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?BoardName=" + Request["BoardName"] // 멀티 게시판 
                        + "&Page=1"
                        + "&SearchField=" + SearchField
                        + "&SearchQuery=" + SearchQuery + "\"><i class='fa fa-angle-double-left'>&nbsp;</i></a></li>";
                }
                else
                {
                    strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?BoardName=" + Request["BoardName"]
                        + "&Page=1"
                        + "\"><i class='fa fa-angle-double-left'>&nbsp;</i></a></li>";
                }
            }
            else
            {
                strPage += "<li class=\"disabled " + pageItem + "\"><a class=\"" + pageLink + "\"><i class='fa fa-angle-double-left'>&nbsp;</i></a></li>";
            }
            #endregion

            #region 이전 n개로 이동 버튼
            // 이전 n개 버튼 
            if (PageIndex > PagerButtonCount)
            {
                // 검색 모드이면 추가적으로 SearchField와 SearchQuery를 전송함
                if (SearchMode)
                {
                    strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?BoardName=" + Request["BoardName"] // 멀티 게시판 
                        + "&Page="
                        + Convert.ToString(((PageIndex - 1) / (int)PagerButtonCount) * PagerButtonCount)
                        + "&SearchField=" + SearchField
                        + "&SearchQuery=" + SearchQuery + "\"><i class='fa fa-angle-left'>&nbsp;</i></a></li>";
                }
                else
                {
                    strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?BoardName=" + Request["BoardName"]
                        + "&Page="
                        + Convert.ToString(((PageIndex - 1) / (int)PagerButtonCount) * PagerButtonCount)
                        + "\"><i class='fa fa-angle-left'>&nbsp;</i></a></li>";
                }
            }
            else
            {
                strPage += "<li class=\"disabled " + pageItem + "\"><a class=\"" + pageLink + "\"><i class='fa fa-angle-left'>&nbsp;</i></a></li>";
            }
            #endregion

            #region 숫자 페이저 버튼 구현하기
            // 가운데, 숫자 형식의 페이저 표시
            for (i = (((PageIndex - 1) / (int)PagerButtonCount) * PagerButtonCount + 1); i <= ((((PageIndex - 1) / (int)PagerButtonCount) + 1) * PagerButtonCount); i++)
            {
                if (i > PageCount)
                {
                    break; // 페이지 수보다 크면 종료 
                }

                // 현재 보고 있는 페이지면 링크 제거 
                if (i == PageIndex)
                {
                    strPage += " <li class='active " + pageItem + "'><a class=\"" + pageLink + "\" href='#'>" + i.ToString() + "</a></li>";
                }
                else
                {
                    if (SearchMode)
                    {
                        strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                            + Request.ServerVariables["SCRIPT_NAME"]
                            + "?BoardName=" + Request["BoardName"]
                            + "&Page=" + i.ToString()
                            + "&SearchField=" + SearchField
                            + "&SearchQuery=" + SearchQuery + "\">"
                            + i.ToString() + "</a></li>";
                    }
                    else
                    {
                        strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                            + Request.ServerVariables["SCRIPT_NAME"]
                            + "?BoardName=" + Request["BoardName"]
                            + "&Page=" + i.ToString() + "\">"
                            + i.ToString() + "</a></li>";
                    }
                }
            }
            #endregion

            #region 다음 n개로 이동 버튼
            // 다음 n개 링크
            if (i < PageCount)
            {
                if (SearchMode)
                {
                    strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?BoardName=" + Request["BoardName"]
                        + "&Page="
                        + Convert.ToString(((PageIndex - 1) / (int)PagerButtonCount) * PagerButtonCount + (PagerButtonCount + 1))
                        + "&SearchField=" + SearchField
                        + "&SearchQuery=" + SearchQuery + "\"><i class='fa fa-angle-right'>&nbsp;</i></a></li>";
                }
                else
                {
                    strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?BoardName=" + Request["BoardName"]
                        + "&Page="
                        + Convert.ToString(((PageIndex - 1) / (int)PagerButtonCount) * PagerButtonCount + (PagerButtonCount + 1))
                        + "\"><i class='fa fa-angle-right'>&nbsp;</i></a></li>";
                }
            }
            else
            {
                strPage += "<li class=\"disabled " + pageItem + "\"><a class=\"" + pageLink + "\"><i class='fa fa-angle-right'>&nbsp;</i></a></li>";
            }
            #endregion

            #region 마지막으로 이동: 마지막 페이지로 이동 버튼
            if (i < PageCount)
            {
                if (SearchMode)
                {
                    strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?BoardName=" + Request["BoardName"]
                        + "&Page=" + PageCount.ToString()
                        + "&SearchField=" + SearchField
                        + "&SearchQuery=" + SearchQuery + "\"><i class='fa fa-angle-double-right'>&nbsp;</i></a></li>";
                }
                else
                {
                    strPage += "<li class=\"" + pageItem + "\"><a class=\"" + pageLink + "\" href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?BoardName=" + Request["BoardName"]
                        + "&Page=" + PageCount.ToString()
                        + "\"><i class='fa fa-angle-double-right'>&nbsp;</i></a></li>";
                }
            }
            else
            {
                strPage += "<li class=\"disabled " + pageItem + "\"><a class=\"" + pageLink + "\"><i class='fa fa-angle-double-right'>&nbsp;</i></a></li>";
            }
            #endregion

            // <!--이전 10개, 다음 10개 페이징 처리 종료-->
            strPage += "</ul>";

            if (UiFramework != "Bootstrap3")
            {
                strPage += "</nav>";
            }

            ctlAdvancedPaingWithBootstrap.Text = strPage; 
        }
        
        #region EncodeSqlString() 함수
        /// <summary>
        /// SqlUtility.EncodeSqlString(): 주어진 문자열에 있는 SQL 특수 문자를 바꿈. (바꿀 문자열)
        /// </summary>
        /// <param name="strContent">SQL Server에 전달된 문자열</param>
        /// <returns>SQL 특수 문자가 변경된 문자열</returns>
        public static string EncodeSqlString(string strContent)
        {
            if (strContent != null)
            {
                string strTemp = strContent;
                strTemp = strTemp.Replace("%", "[%]");
                strTemp = strTemp.Replace("_", "[_]");
                strTemp = strTemp.Replace("@", "[@]");
                strTemp = strTemp.Replace("'", "''");
                return strTemp;
            }
            return "";
        }
        #endregion
    }
}
