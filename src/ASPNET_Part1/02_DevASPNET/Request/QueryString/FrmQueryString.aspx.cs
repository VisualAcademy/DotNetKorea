using System;

namespace MemoEngine.Demos.ASPNET.WebForms._02_DevASPNET.Request.QueryString
{
    public partial class FrmQueryString : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string strUrl =
                String.Format("FrmQueryStringProcess.aspx?ServerName={0}&Color=Red", txtServerName.Text);
            Response.Redirect(strUrl);
        }
    }
}