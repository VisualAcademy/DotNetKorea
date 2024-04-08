using System;
using System.Web.UI;

namespace MemoEngine.Demos.ASPNET.WebForms._03_DevStandardControl
{
    public partial class FrmMultiView_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (DateTime.Now.Second % 2 == 0)
                {
                    this.MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    this.MultiView1.ActiveViewIndex = 1;
                }
            }
        }
        protected void btnGetPhoneNumber_Click(object sender, EventArgs e)
        {
            string phone = "";
            if (this.MultiView1.ActiveViewIndex == 0)
            {
                phone = String.Format("{0}-{1}-{2}", this.ddlPhoneNumber.SelectedValue, txtFirstNumber.Text, txtSecondNumber.Text);
            }
            else
            {
                phone = this.txtPhoneNumber.Text;
            }
            this.lblDisplay.Text = phone + "이 입력되었습니다.";
        }
    }
}
