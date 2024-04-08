using System;

namespace MemoEngine.Supports
{
    public partial class SupportReply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlBoardEditorFormControl.FormType = BoardWriteFormType.Reply;
            ctlBoardEditorFormControl.Message = "글 답변 - 다음 필드들을 채워주세요.";
        }
    }
}
