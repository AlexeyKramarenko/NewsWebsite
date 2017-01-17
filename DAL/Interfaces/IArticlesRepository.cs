using DAL.POCO;
using System.Collections.Generic;

namespace DAL
{
    public interface IArticlesRepository
    {
        List<Article> GetArticlesByCategory(string category);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int id);
        void AddImagesContent(List<ImagesContent> content);
        List<Link> GetArticleLinks();
        List<GalleryLink> GetGalleryLinks();
        List<Link> GetArticleLinksByCategory(string category);
        Article GetArticleById(int articleId);
    }
}