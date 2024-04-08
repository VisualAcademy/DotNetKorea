using System;
using System.Web.UI.WebControls;

namespace MemoEngine.Demos.ASPNET.WebForms._09_DevDataControl.WebDataControl
{
    public partial class FrmGridViewFooter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int sum = 0;

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 아이템 영역
                sum += Convert.ToInt32(e.Row.Cells[2].Text); // 10 + 20 + 30
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                // 푸터 영역
                e.Row.Cells[0].Text = "합계: ";
                //e.Row.Cells[2].Text = sum.ToString(); // 60
                e.Row.Cells[1].Text = sum.ToString(); // 셀 하나를 지웠을 때...
            }
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells.RemoveAt(1); // 0, 1, 2
                e.Row.Cells[0].ColumnSpan = 2; // 0 => colspan = 2
            }
        }
    }
}