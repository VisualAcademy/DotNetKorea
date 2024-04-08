using System;
using System.Web.UI.WebControls;

namespace MemoEngine.Demos.ASPNET.WebForms._03_DevStandardControl
{
    public partial class FrmDropDownList_PhoneNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 현재 페이지가 포스트백(재전송)이 아닐 때에만 바인딩, 즉, 처음 로드시에만 처리
            if (!Page.IsPostBack)
            {
                ddlPhoneNumber.Items.Add("017");
                ddlPhoneNumber.Items.Add(new ListItem("016", "016"));
            }
        }
    }
}
