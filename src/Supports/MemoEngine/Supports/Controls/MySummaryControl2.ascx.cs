using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Supports.Controls
{
    public partial class MySummaryControl2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 카테고리 Value를 다시 카테고리 Text로 변경
        /// </summary>
        protected string ConvertToCategoryString(object objCategory)
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

    public class MySupport2
    {
        // 특정 사용자의 전체 리스트(페이징 처리)
        public List<Support> GetSupports(int startIndex, int maxRows)
        {
            using (var db = new SupportContext())
            {
                string userName = HttpContext.Current.Session["UserName"].ToString();
                if (AccountHandler.HasGroup("Administrators"))
                {
                    return db.Supports
                        .OrderByDescending(s => s.Ref)
                        .ThenBy(s => s.RefOrder)
                        .Skip(startIndex)
                        .Take(maxRows).ToList();
                }
                else
                {
                    return db.Supports
                        .Where(s => s.UserName == userName)
                        .OrderByDescending(s => s.Ref)
                        .ThenBy(s => s.RefOrder)
                        .Skip(startIndex)
                        .Take(maxRows).ToList();
                }
            }
        }

        // 특정 사용자의 전체 레코드 수 
        public int GetSupportsCount()
        {
            using (var db = new SupportContext())
            {
                string userName = HttpContext.Current.Session["UserName"].ToString();

                if (AccountHandler.HasGroup("Administrators"))
                {
                    // 관리자면 전체 레코드 수
                    return db.Supports.Count();
                }
                else
                {
                    // 일반 사용자면 자신이 쓴 글에 대한 레코드 수 
                    return db.Supports.Where(s => s.UserName == userName).Count(); 
                }
            }
        }
    }
}
