using System;
using System.Web.UI;

namespace MemoEngine.Demos.ASPNET.WebForms._04_DevValidationControl
{
    public partial class FrmValidationControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInput_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblDisplay.Text = "텍스트상자에 입력한 내용은: " + txtInput.Text;
            }
        }
    }
}