using System;
using Dul;

namespace Dul.Test
{
    public partial class FrmStringLibraryTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text = Dul.StringLibrary.CutStringUnicode(TextBox1.Text, 6);
            Label1.Text = TextBox1.Text.CutStringUnicode(6);
        }
    }
}
