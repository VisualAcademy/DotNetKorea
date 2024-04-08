using System;
using System.Collections.Generic;
using System.Web.UI;

namespace MemoEngine.Demos.ASPNET.WebForms._09_DevDataControl.WebDataControl
{
    public partial class FrmGridViewCellValueRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            List<Product> lst = new List<Product>();
            lst.Add(new Product { Name = "Windows Server" });
            lst.Add(new Product { Name = "SQL Server" });
            lst.Add(new Product { Name = "Visual Studio" });

            this.GridView1.DataSource = lst;
            this.GridView1.DataBind();
        }

        /// <summary>
        /// 넘겨운 상품명에 따라서 서로 다른 페이지로 이동
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected string FuncRedirect(object name)
        {
            string strUrl = "";
            string strName = name.ToString();

            if (strName == "Windows Server")
            {
                strUrl = "W.aspx";
            }
            else if (strName == "SQL Server")
            {
                strUrl = "S.aspx";
            }
            else
            {
                strUrl = "V.aspx";
            }
            return strUrl;
        }
    }

    public class Product
    {
        public string Name { get; set; }
    }
}