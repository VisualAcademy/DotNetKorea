using System;
using System.Globalization;

namespace MemoEngine.Logins.Controls
{
    public partial class BoardSearchFormSingleControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStartDate.Text = Request["StartDate"];
                txtEndDate.Text = Request["EndDate"];
                SearchQuery.Text = Request["SearchQuery"];

                if (txtStartDate.Text == "" && txtEndDate.Text == "")
                {
                    this.txtStartDate.Text = DateTime.Today.AddDays(Convert.ToInt32(DayOfWeek.Sunday) - Convert.ToInt32(DateTime.Today.DayOfWeek)).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    this.txtEndDate.Text = DateTime.Today.AddDays(Convert.ToInt32(DayOfWeek.Saturday) - Convert.ToInt32(DateTime.Today.DayOfWeek)).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // 검색 버튼 클릭할 때 검색 필드와 검색어를 가지고 다시 나한테 요청
            string strQuery = 
                $"{Request.ServerVariables["SCRIPT_NAME"]}?SearchField={SearchField.SelectedItem.Value}&SearchQuery={SearchQuery.Text}&StartDate={txtStartDate.Text}&EndDate={txtEndDate.Text}";
            Response.Redirect(strQuery);
        }
    }
}
