using Microsoft.AspNet.Identity;
using System;
using System.Web;

namespace VinRada.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !HttpContext.Current.User.IsInRole("admin"))
                Response.Redirect("404"); 
        }
    }
}