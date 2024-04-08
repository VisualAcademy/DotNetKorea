using System;

namespace MemoEngine.Answers.Controls
{
    public partial class BoardSearchFormSingleControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Empty
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // 검색 버튼 클릭할 때 검색 필드와 검색어를 가지고 다시 나한테 요청
            string strQuery = 
                $"{Request.ServerVariables["SCRIPT_NAME"]}?SearchField={SearchField.SelectedItem.Value}&SearchQuery={SearchQuery.Text}";
            Response.Redirect(strQuery);
        }
    }
}
