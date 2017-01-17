using DAL;
using DAL.POCO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Ninject;
using System.Security.Claims;
using System.Web;
using VinRada.ViewModel;
using System.Linq;
using BLL;

namespace VinRada
{
    public partial class Login : System.Web.UI.Page
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        [Inject]
        public IUserService UserService { get; set; }

        public void LoginUser(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserService.GetUser(model.Username, model.Password);

                if (user == null)
                    ModelState.AddModelError("", "Невiрний логiн або пароль.");
                else
                {
                    var claim = new ClaimsIdentity("ApplicationCookie",
                                                              ClaimsIdentity.DefaultNameClaimType,
                                                              ClaimsIdentity.DefaultRoleClaimType);
                    claim.AddClaim(new Claim(
                                          ClaimTypes.NameIdentifier,
                                          user.UserId.ToString(),
                                          ClaimValueTypes.String));
                    claim.AddClaim(new Claim(
                                          ClaimsIdentity.DefaultNameClaimType,
                                          user.Name,
                                          ClaimValueTypes.String));
                    claim.AddClaim(new Claim(
                    "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                                          "OWIN Provider",
                                          ClaimValueTypes.String));
                    if (user.Role != null)
                        claim.AddClaim(new Claim(
                                              ClaimsIdentity.DefaultRoleClaimType,
                                              user.Role.Name,
                                              ClaimValueTypes.String));

                    AuthenticationManager.SignOut();

                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);

                    if (user.Role.Name == "admin")
                        Response.Redirect("~/admin/admin.aspx");
                    else
                        Response.Redirect("~/404.aspx");
                }
            }
        }

    }
}