using System;

namespace MemoEngine.Demos.ASPNET.WebForms._02_DevASPNET.Request.QueryString
{
    public partial class FrmQueryStringProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // FrmQueryString.aspx에서 넘겨져 온 쿼리스트링 받기

            if (Request.QueryString["ServerName"] != null)
            {
                string serverName = Request.QueryString["ServerName"];
                lblServerName.Text = serverName;
            }
            else
            {
                lblServerName.Text = "넘겨온 값이 없거나, 잘못되었습니다.";
            }

            if (Request.QueryString["Color"] != null)
            {
                if (Request.QueryString["Color"] == "Red")
                {
                    lblServerName.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}