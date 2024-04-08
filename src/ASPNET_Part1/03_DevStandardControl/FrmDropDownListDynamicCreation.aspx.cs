using System;
using System.Web.UI.WebControls;

namespace MemoEngine.Demos.ASPNET.WebForms._03_DevStandardControl
{
    public partial class FrmDropDownListDynamicCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 2; i++)
            {
                DropDownList ddl = new DropDownList();
                ddl.ID = String.Format("ddl{0}", i); // ddl1, ddl2
                ddl.Items.Add(new ListItem("Text1", "Value1"));
                ddl.Items.Add(new ListItem("Text2", "Value2"));
                ddl.Items.Add(new ListItem("Text3", "Value3"));
                PlaceHolder1.Controls.Add(ddl); // 동적으로 생성된 드롭다운리스트 추가 
            }
        }
        protected void btnGet_Click(object sender, EventArgs e)
        {
            Label1.Text = "선택된 값: ";
            for (int i = 1; i <= 2; i++)
            {
                DropDownList ddl = PlaceHolder1.FindControl(String.Format("ddl{0}", i)) as DropDownList;
                if (ddl != null)
                {
                    Label1.Text += ddl.SelectedValue + ", ";
                }
            }
        }
    }
}
