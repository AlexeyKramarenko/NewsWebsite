using BLL;
using BLL.DTO;
using BLL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using VinRada.ViewModel;

namespace VinRada
{
    public partial class Articles : BasePage
    {
        [Inject]
        public IArticlesService ArticlesService { get; set; }

        [Inject]
        public IMappingService MappingService { get; set; }


        public List<ArticleViewModel> GetArticles([RouteData]string type)
        {
            if (type != null)
            {
                List<ArticleDTO> articles = ArticlesService.GetArticlesByCategory(type);
                List<ArticleViewModel> _articles = articles.Select(a => MappingService.Map<ArticleDTO, ArticleViewModel>(a)).ToList();

                return _articles;
            }
            return null;
        }
    }
}