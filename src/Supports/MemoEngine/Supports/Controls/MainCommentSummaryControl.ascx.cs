using System;
using System.Collections.Generic;
using System.Configuration;

namespace MemoEngine.Supports.Controls
{
    public partial class MainCommentSummaryControl : System.Web.UI.UserControl
    {
        private readonly SupportCommentRepository repository;

        public List<SupportComment> Model { get; set; } = new List<SupportComment>();

        public MainCommentSummaryControl()
        {
            repository = new SupportCommentRepository(
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Model = repository.GetRecentComments();
        }
    }
}
