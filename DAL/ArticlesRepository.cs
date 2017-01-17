using DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ArticlesRepository : IArticlesRepository
    {
        DBContext db;

        public ArticlesRepository(DBContext db)
        {
            this.db = db;
        }

        public List<Article> GetArticlesByCategory(string category)
        {
            if (category != null)
            {
                var articles = db.Articles.Include("ImagesContent").Where(a => a.Category == category).ToList();
                
                return articles;
            }

            return null;
        }

        public void CreateArticle(Article article)
        {
            db.Entry(article).State = System.Data.Entity.EntityState.Added;
        }

        public void AddImagesContent(List<ImagesContent> content)
        {
            db.ImagesContent.AddRange(content);
        }

        public void UpdateArticle(Article article)
        {
            db.Entry(article).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteArticle(int id)
        {
            var article = db.Articles.Find(id);
            if (article != null)
                db.Entry(article).State = System.Data.Entity.EntityState.Deleted;
        }

        public List<Link> GetArticleLinks()
        {
            List<Link> links = db.Articles.Where(a => a.TextContent != null)
                                          .AsEnumerable()
                                          .Select(a => new Link { ID = a.ID, Title = a.Title })
                                          .ToList();
            return links;
        }
        public List<Link> GetArticleLinksByCategory(string category)
        {
            List<Link> links = db.Articles.Where(a => a.Category == category)
                                          .AsEnumerable()
                                          .Select(a => new Link { ID = a.ID, Title = a.Title })
                                          .ToList();
            return links;
        }
        public Article GetArticleById(int articleId)
        {
            Article article = db.Articles.Find(articleId);
            return article;
        }

        public List<GalleryLink> GetGalleryLinks()
        {
            var links = db.Articles
                          .Where(a => a.Category == "Свята")
                          .AsEnumerable()
                          .Select(x => new GalleryLink { ID = x.ID, Title = x.Title })
                          .ToList();

            return links;
        }
    }
}
