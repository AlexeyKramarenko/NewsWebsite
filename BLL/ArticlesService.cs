using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArticlesService : IArticlesService
    {
        IUnitOfWork Database;
        IMappingService mappingService;
        public ArticlesService(IUnitOfWork Database, IMappingService mappingService)
        {
            this.Database = Database;
            this.mappingService = mappingService;
        }

        public List<ArticleDTO> GetArticlesByCategory(string category)
        {
            List<Article> articles = Database.Articles.GetArticlesByCategory(category);
            if (articles != null)
            {
                List<ArticleDTO> articlesDTO = articles.Select(a => mappingService.Map<Article, ArticleDTO>(a)).ToList();
                return articlesDTO;
            }
            return null;

        }
        public void CreateArticle(ArticleDTO article)
        {
            Article _article = mappingService.Map<ArticleDTO, Article>(article);
            Database.Articles.CreateArticle(_article);
            Database.Save();
        }
        public void UpdateArticle(ArticleDTO article)
        {
            Article _article = mappingService.Map<ArticleDTO, Article>(article);
            Database.Articles.UpdateArticle(_article);
            Database.Save();
        }
        public void DeleteArticle(int id)
        {
            Database.Articles.DeleteArticle(id);
            Database.Save();
        }

        public List<LinkDTO> GetArticleLinks()
        {
            List<Link> links = Database.Articles.GetArticleLinks();
            List<LinkDTO> linksDto = links.Select(a => mappingService.Map<Link, LinkDTO>(a)).ToList();
            return linksDto;
        }

        public ArticleDTO GetArticleById(int articleId)
        {
            Article article = Database.Articles.GetArticleById(articleId);
            ArticleDTO dto = mappingService.Map<Article, ArticleDTO>(article);
            return dto;
        }

        public List<LinkDTO> GetArticleLinksByCategory(string category)
        {
            List<Link> links = Database.Articles.GetArticleLinksByCategory(category);
            List<LinkDTO> linksDto = links.Select(a => mappingService.Map<Link, LinkDTO>(a)).ToList();
            return linksDto;
        }

       public List<GalleryLinkDTO> GetGalleryLinks()
        {
            List<GalleryLink> links = Database.Articles.GetGalleryLinks();
            List<GalleryLinkDTO> linksDto = links.Select(a => mappingService.Map<GalleryLink, GalleryLinkDTO>(a)).ToList();
            return linksDto;
        }
    }
}
