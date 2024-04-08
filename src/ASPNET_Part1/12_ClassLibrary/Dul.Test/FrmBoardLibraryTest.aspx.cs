using System;

namespace Dul.Test
{
    public partial class FrmBoardLibraryTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = Dul.BoardLibrary.ConvertToFileSize(Convert.ToInt32(TextBox1.Text));
        }
    }
}