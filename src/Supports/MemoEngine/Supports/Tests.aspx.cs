using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Supports
{
    public partial class Tests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //// EF Core를 통해서 Supports 테이블의 데이터 읽어오기 테스트 
                //using (var db = new SupportContext())
                //{
                //    List<Support> articles = new List<Support>();
                //    articles = db.Supports.ToList();

                //    GridView1.DataSource = articles;
                //    GridView1.DataBind(); 
                //}
            }
        }
    }
}
