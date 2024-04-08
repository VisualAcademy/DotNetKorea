using System;
using System.IO;

namespace MemoEngine.Demos.ASPNET.WebForms._03_DevStandardControl
{
    public partial class FrmFileUploadWithFileNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strDirectory = Server.MapPath("./icons") + "\\";

            //[1] 파일이 첨부되었다면
            if (txtGroupIcon.HasFile)
            {
                //[2] App_Data 폴더로 파일 업로드
                // txtGroupIcon.SaveAs(Server.MapPath("~/")+ "\\Icons\\" + txtGroupIcon.FileName);
                txtGroupIcon.SaveAs(
                    Path.Combine(strDirectory,
                        GetFileNameWithNumbering(strDirectory, txtGroupIcon.FileName)));
            }
        }

        #region 중복된 파일명 뒤에 번호 붙이는 메서드 : GetFileNameWithNumbering
        /// <summary>
        /// GetFilePath : 파일명 뒤에 번호 붙이는 메서드
        /// </summary>
        /// <param name="strBaseDirTemp">경로(c:\MyFiles)</param>
        /// <param name="strFileNameTemp">Test.txt</param>
        /// <returns>Test(1).txt</returns>
        private string GetFileNameWithNumbering(string strBaseDirTemp, string strFileNameTemp)
        {
            string strName = //순수파일명 : Test
                Path.GetFileNameWithoutExtension(strFileNameTemp);
            string strExt =     //확장자 : .txt
                Path.GetExtension(strFileNameTemp);
            bool blnExists = true;
            int i = 0;
            while (blnExists)
            {
                //Path.Combine(경로, 파일명) = 경로+파일명
                if (File.Exists(Path.Combine(strBaseDirTemp, strFileNameTemp)))
                {
                    strFileNameTemp =
                      strName + "(" + ++i + ")" + strExt;//Test(3).txt
                }
                else
                {
                    blnExists = false;
                }
            }
            return strFileNameTemp;
        }
        #endregion
    }
}
