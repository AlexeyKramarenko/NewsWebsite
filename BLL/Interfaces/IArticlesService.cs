using System.Collections.Generic;
 
using BLL.DTO;

namespace BLL
{
    public interface IArticlesService
    {
        void CreateArticle(ArticleDTO article);
        void DeleteArticle(int id);
        List<ArticleDTO> GetArticlesByCategory(string category);
        void UpdateArticle(ArticleDTO article);
        List<LinkDTO> GetArticleLinks();
        List<LinkDTO> GetArticleLinksByCategory(string category);
        ArticleDTO GetArticleById(int articleId);
        List<GalleryLinkDTO> GetGalleryLinks();
    }
}