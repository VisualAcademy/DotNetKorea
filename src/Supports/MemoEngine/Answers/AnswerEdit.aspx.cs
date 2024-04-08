using System;

namespace MemoEngine.Answers
{
    public partial class AnswerEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlBoardEditorFormControl.FormType = BoardWriteFormType.Modify;
            ctlBoardEditorFormControl.Message = "글 수정 - 다음 필드들을 채워주세요.";
        }
    }
}
