using BLL;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VinRada.WebApi
{
    public class NewsController : ApiController
    {
        INewsService newsService;
        IMappingService mappingService;
        public NewsController(INewsService newsService, IMappingService mappingService)
        {
            this.newsService = newsService;
            this.mappingService = mappingService;
        }

        [HttpGet]
        [ActionName("GetAllLinks")]
        public List<LinkDTO> GetAllLinks()
        {
            List<LinkDTO> list = newsService.GetAllLinks();
            return list;
        }

        [HttpGet]
        [ActionName("GetNewsEventById")]
        public NewsEventDTO GetNewsEventById(int newsId)
        {
            NewsEventDTO dto = newsService.GetNewsEventById(newsId);
            return dto;
        }
        [HttpGet]
        [ActionName("GetLastNewsEvent")]
        public NewsEventDTO GetLastNewsEvent( )
        {
            NewsEventDTO dto = newsService.GetLastNewsEvent();
            return dto;
        }
        [HttpPost]
        [ActionName("AddNewsEvent")]
        public void AddNewsEvent(NewsEventDTO dto)
        {
            dto.Date = DateTime.Now;
            newsService.AddNewsEvent(dto);
        }

        [HttpPut]
        [ActionName("UpdateNewsEvent")]
        public void UpdateNewsEvent([FromBody]NewsEventDTO model)
        {
           newsService.UpdateNewsEvent(model);
        }
        
        [HttpDelete]
        [ActionName("DeleteNewsEventById")]
        public void DeleteNewsEventById(int newsId)
        {
            newsService.DeleteNewsEventById(newsId);
        }
    }
}
