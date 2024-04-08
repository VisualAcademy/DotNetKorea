using System;
using System.Collections.Generic;
using System.Configuration;

namespace MemoEngine.Answers.Controls
{
    public partial class AnswerCommentSummaryControl : System.Web.UI.UserControl
    {
        private readonly AnswerCommentRepository repository;

        public List<AnswerComment> Model { get; set; } = new List<AnswerComment>();

        public AnswerCommentSummaryControl()
        {
            repository = new AnswerCommentRepository(
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Model = repository.GetRecentComments();
        }
    }
}
