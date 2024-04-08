using System;
using System.Collections.Generic;
using System.Configuration;

namespace MemoEngine.Supports.Controls
{
    public partial class MainSummaryWithThumbNail : System.Web.UI.UserControl
    {
        private readonly SupportRepository repository;

        public MainSummaryWithThumbNail()
        {
            repository = new SupportRepository(
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
