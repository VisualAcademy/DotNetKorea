using System.Configuration;
using System.Web;

namespace MemoEngine.Logins
{
    public class AccountHandler
    {
        public static bool HasGroup(string strGroudName)
        {
            // 수작업으로 관리자 권한 체크
            string adminUserName = ConfigurationManager.AppSettings["SUPPORTS_ADMIN"].ToString();
            if (HttpContext.Current.Session["UserName"].ToString() == adminUserName)
            {
                return true;
            }
            return false; 
        }
    }
}
