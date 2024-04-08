using System;

namespace MemoEngine.Supports
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Session["UserName"] = "";
            }

            Response.Redirect("~/Supports/SupportIndex.aspx");
        }
    }
}
