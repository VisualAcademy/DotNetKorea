using System;
using System.Web.UI;

namespace MemoEngine.Demos.ASPNET.WebForms._02_DevASPNET.WebPageEvent
{
    public partial class FrmPageEvent : System.Web.UI.Page
    {
        // 현재 페이지가 로드될 때 Page_Load 이벤트 처리기의 코드가 실행됨.
        protected void Page_Load(object sender, EventArgs e)
        {
            // 처음로드와 포스트백 모두 실행...
            this.lblLoadTime.Text = DateTime.Now.ToLongTimeString(); // 현재 시간 출력

            // Page.IsPostBack 속성 : 처음로드면 false, 포스트백(다시게시)이면 true을 가짐.
            // if (Page.IsPostBack != true) // 포스트백이 아니고, 처음 로드시...
            if (!Page.IsPostBack) // 처음로드할 때만...
            {
                // 동적으로 드롭다운리스트에 항목 추가
                this.lstFavorites.Items.Add("C#");
                this.lstFavorites.Items.Add("ASP.NET");
                this.lstFavorites.Items.Add("Silverlight");
            }
        }
    }
}