using System.Web;
using System.Web.Optimization;

namespace VinRada.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                                "~/Scripts/angular.min.js",
                                "~/Scripts/angular-ui-router.min.js",
                                "~/Scripts/angular-sanitize.min.js",
                                "~/Scripts/angular-css.min.js",

                                "~/app/admin.app/admin.app.js",
                                "~/app/admin.app/admin.route.js",
                                "~/app/admin.app/articles/article.service.js",
                                "~/app/admin.app/articles/create.article/create.article.controller.js",
                                "~/app/admin.app/articles/create.gallery/create.gallery.controller.js",
                                "~/app/admin.app/articles/edit.articles/edit.articles.controller.js",
                                "~/app/admin.app/articles/edit.galleries/edit.galleries.controller.js",
                                "~/app/admin.app/contacts/contacts.service.js",
                                "~/app/admin.app/contacts/contacts.controller.js",
                                "~/app/admin.app/main/images.service.js",
                                "~/app/admin.app/main/add.image/add.image.controller.js",
                                "~/app/admin.app/main/delete.images/delete.images.controller.js",
                                "~/app/admin.app/news/news.service.js",
                                "~/app/admin.app/news/create.news/create.news.controller.js",
                                "~/app/admin.app/news/edit.news/edit.news.controller.js"

                                ));

            bundles.Add(new ScriptBundle("~/bundles/angular_newsApp").Include(
                                 "~/Scripts/angular.min.js",
                                 "~/app/news.app/news.app.js",
                                 "~/app/news.app/news.service.js",
                                 "~/app/news.app/news.controller.js"
                               ));


        }
    }
}
