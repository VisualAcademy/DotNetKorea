using System;

namespace MemoEngine
{
    public partial class My : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString() == "")
            {
                Response.Redirect("~/Account/Login.aspx?ReturnUrl=/My.aspx");
            }
        }
    }
}
