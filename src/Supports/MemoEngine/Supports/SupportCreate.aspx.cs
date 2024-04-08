using System;

namespace MemoEngine.Supports
{
    public partial class SupportCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlBoardEditorFormControl.FormType = BoardWriteFormType.Write;
            ctlBoardEditorFormControl.Message = "글 쓰기 - 다음 필드들을 채워주세요."; 
        }
    }
}
