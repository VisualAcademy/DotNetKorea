using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevStandardControl
{
    public partial class FrmListBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 처음 로드할 때만 항목 추가
            if (!Page.IsPostBack)
            {
                // 동적으로 항목 추가
                this.lstHobby.Items.Add("축구");
                this.lstHobby.Items.Add("농구");

                // ListItem 클래스
                ListItem li = new ListItem();
                li.Text = "배구";
                li.Value = "Volleyball";
                lstHobby.Items.Add(li);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string strMsg = String.Empty;
            for (int i = 0; i < lstHobby.Items.Count; i++)
            {
                if (lstHobby.Items[i].Selected)
                {
                    strMsg += lstHobby.Items[i].Text;
                    if (i != lstHobby.Items.Count - 1)
                    {
                        strMsg += ", ";
                    }
                }
            }
            lblDisplay.Text = strMsg;
        }
    }
}