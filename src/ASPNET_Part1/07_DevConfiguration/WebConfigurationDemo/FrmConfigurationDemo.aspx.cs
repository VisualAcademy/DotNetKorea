using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebConfigurationDemo
{
    public partial class FrmConfigurationDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = WebConfigurationManager.AppSettings["ChartDataDuration"].ToString();
            Label2.Text = WebConfigurationManager.AppSettings["ChartRenderingInterval"].ToString();
            Label3.Text = WebConfigurationManager.AppSettings["AlertRefreshInterval"].ToString();
            Label4.Text = WebConfigurationManager.AppSettings["AlertDataDuration"].ToString();

            //Label5.Text = WebConfigurationManager.ConnectionStrings["ASPNETBOOKTEST_ConnectionString"].ConnectionString;
        }
    }
}