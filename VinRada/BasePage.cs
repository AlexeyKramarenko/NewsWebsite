using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace VinRada
{
    public class BasePage : Page
    {
        //перед PageLoad
        protected override void InitializeCulture()
        {
            string culture;

            if (Session["languages"] != null)
                culture = Session["languages"].ToString();
            else
                culture = "uk-UA";
            
            this.Culture = culture;
            this.UICulture = culture;
        }

    }
}
