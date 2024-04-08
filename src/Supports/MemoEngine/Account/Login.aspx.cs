using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using MemoEngine.Models;
using MemoEngine.Logins;

namespace MemoEngine.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // 암호 재설정 기능에 대해 계정 확인을 사용하도록 설정한 경우 이 항목 사용
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // 사용자 암호의 유효성을 검사합니다.
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // 계정이 잠기는 로그인 실패로 간주되지 않습니다.
                // 암호 오류 시 잠금을 트리거하도록 설정하려면 shouldLockout: true로 변경하십시오.
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                // 로그인 성공했으면
                Session["UserName"] = Email.Text; // 이메일 또는 아이디 

                // 로그인 기록 남기기
                using (var loginContext = new LoginContext())
                {
                    var loginModel = new MemoEngine.Logins.Login();
                    loginModel.UserId = 5; 
                    loginModel.UserName = Session["UserName"].ToString();
                    loginModel.LoginIp = Request.UserHostAddress;
                    loginModel.LoginDate = DateTime.Now; 

                    loginContext.Add(loginModel);
                    loginContext.SaveChanges(); 
                }
                
                // 수작업으로 관리자 권한을 추가
                if (Email.Text == "admin@a.com")
                {
                    Session["GroupId"] = "Administrators";
                }

                switch (result)
                {
                    case SignInStatus.Success:


                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "잘못된 로그인 시도";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}