using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinRada
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Clear();
            Session["languages"] = ddlLanguages.SelectedValue;

            switch (ddlLanguages.SelectedValue)
            {
                case "first":
                    Session["flag"] = "~/images/flags/ukr.gif";
                    break;
                case "uk-UA":
                    Session["flag"] = "~/images/flags/ukr.gif";
                    break;
                case "ru-RU":
                    Session["flag"] = "~/images/flags/rus.gif";
                    break;
                case "en-US":
                    Session["flag"] = "~/images/flags/eng.gif";
                    break;
            }
            //перегрузка текущей страницы
            Response.Redirect(Request.Url.AbsolutePath);
        }
    }
}