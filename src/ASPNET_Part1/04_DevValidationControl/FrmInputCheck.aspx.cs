using System;
using System.Web.UI.WebControls;

namespace MemoEngine.Demos.ASPNET.WebForms._04_DevValidationControl
{
    public partial class FrmInputCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // 서버측 유효성 검사
        protected void valNameSize_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // 입력된 값이 3자 이상 15자 이하면 통과 그렇지 않으면 에러
            if (args.Value.Length < 3 || args.Value.Length > 15)
            {
                args.IsValid = false; // 에러
            }
            else
            {
                args.IsValid = true; // 통과
            }
        }
    }
}