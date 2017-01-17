using BLL;
using BLL.DTO;
using BLL.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VinRada.ViewModel;

namespace VinRada.WebApi
{
    public class ArticlesController : ApiController
    {        
        public string tempImagePath = "~/Images/gallery/temp/";
        public string[] formats = new string[] { "image/jpeg", "image/png" };


        IArticlesService articlesService;
        IMappingService mappingService;

        public ArticlesController(IArticlesService articlesService, IMappingService mappingService)
        {
            this.articlesService = articlesService;
            this.mappingService = mappingService;
        }

        [HttpGet]
        [ActionName("GetArticleById")]
        public ArticleDTO GetArticleById(int Id)
        {
            ArticleDTO dto = articlesService.GetArticleById(Id);
            return dto;
        }
        [HttpGet]
        [ActionName("GetArticleLinks")]
        public List<LinkDTO> GetArticleLinks()
        {
            List<LinkDTO> list = articlesService.GetArticleLinks();
            return list;
        }
        [HttpGet]
        [ActionName("GetGalleryLinks")]
        public List<GalleryLinkDTO> GetGalleryLinks()
        {
            List<GalleryLinkDTO> list = articlesService.GetGalleryLinks();
            return list;
        }
        [HttpGet]
        [ActionName("GetArticleLinksByCategory")]
        public List<LinkDTO> GetArticleLinksByCategory([FromUri]string category)
        {
            List<LinkDTO> list = articlesService.GetArticleLinksByCategory(category);
            return list;
        }
        [HttpGet]
        [ActionName("GetArticlesByCategory")]
        public List<CreateArticleViewModel> GetArticlesByCategory(string category)
        {
            List<ArticleDTO> articlesDto = articlesService.GetArticlesByCategory(category);
            var vm = articlesDto.Select(a => mappingService.Map<ArticleDTO, CreateArticleViewModel>(a)).ToList();
            return vm;
        }
        [HttpPost]
        [ActionName("CreateArticle")]
        public void CreateArticle([FromBody]JToken jsonbody) 
        { 
            CreateArticleViewModel model = jsonbody.ToObject<CreateArticleViewModel>(); 
            var dto = mappingService.Map<CreateArticleViewModel, ArticleDTO>(model);
            articlesService.CreateArticle(dto);
        }

        [HttpPut]
        [ActionName("UpdateArticle")]
        public void UpdateArticle(ArticleViewModel vm)
        {
            var dto = mappingService.Map<ArticleViewModel, ArticleDTO>(vm);
            articlesService.UpdateArticle(dto);
        }

        [HttpDelete]
        [ActionName("DeleteArticleById")]
        public void DeleteArticleById(int id)
        {
            articlesService.DeleteArticle(id);
        }


        [HttpPost]
        [ActionName("UploadImage")]
        public string UploadImage()
        {
            var files = HttpContext.Current.Request.Files;

            if (files.Count > 0)
            {
                HttpPostedFile file = files[0];

                if (file != null)
                {
                    if (formats.Contains(file.ContentType))
                    {
                        string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string tempImagePath = HttpContext.Current.Server.MapPath(this.tempImagePath) + fileName;
                        string imageUrl = this.tempImagePath.Replace("~", "") + fileName;
                        file.SaveAs(tempImagePath);
                        return imageUrl;
                    }
                }
            }
            return null;
        }
    }
}
