using System;
using System.Collections.Generic;
using System.Configuration;

namespace MemoEngine.Answers.Controls
{
    public partial class MainSummaryWithThumbNail : System.Web.UI.UserControl
    {
        private readonly AnswerRepository repository;

        public MainSummaryWithThumbNail()
        {
            repository = new AnswerRepository(
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        // MVP 프레임워크 흉내
        public List<ArticleBase> Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            Model = repository.GetAll(1, 8);
        }
    }
}
