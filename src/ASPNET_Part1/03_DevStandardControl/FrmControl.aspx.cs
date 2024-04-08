using System;
using System.Web.UI;

namespace MemoEngine.Demos.ASPNET.WebForms._03_DevStandardControl
{
    public partial class FrmControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.lblDisplay.Text = "안녕하세요.";
            }
            else
            {
                lblDisplay.Text = "포스트백(다시게시) 되었습니다.";
            }
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "버튼이 클릭되었습니다.";
        }

        protected void ctlCalendar_SelectionChanged(object sender, EventArgs e)
        {
            lblDisplay.Text = ctlCalendar.SelectedDate.ToString();
        }
    }
}
