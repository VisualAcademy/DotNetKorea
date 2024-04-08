using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demos.ASPNET.WebForms._09_DevDataControl.WebDataControl
{
    public partial class FrmGridViewCellBackColor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ArrayList al = new ArrayList();
                al.Add("Error");
                al.Add("Warning");
                al.Add("Information");
                al.Add("Error");
                al.Add("Warning");
                al.Add("Information");

                this.GridView1.DataSource = al;
                this.GridView1.DataBind();
            }
        }

        /// <summary>
        /// 행이 만들어질 때 해당 행의 텍스트에 따른 배경색 다르게 지정하기
        /// </summary>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "Error")
                {
                    e.Row.Cells[0].BackColor = Color.Red;
                }
                else if (e.Row.Cells[1].Text == "Warning")
                {
                    e.Row.Cells[0].BackColor = Color.Yellow;
                }
                else
                {
                    e.Row.Cells[0].BackColor = Color.Green;
                }
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                lblDisplay.Text = "Select 버튼 클릭시에 필요한 기능 구현";
            }
            else if (e.CommandName == "Edit")
            {
                lblDisplay.Text = "Edit";
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.SelectedRow.BackColor = Color.Azure;
        }
    }
}