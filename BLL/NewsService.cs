using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.POCO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BLL
{
    public class NewsService : INewsService
    {
        IUnitOfWork Database;
        IMappingService mappingService;
        public NewsService(IUnitOfWork Database, IMappingService mappingService)
        {
            this.Database = Database;
            this.mappingService = mappingService;
        }
        public void AddNewsEvent(NewsEventDTO newsEvent)
        {
            NewsEvent ev = mappingService.Map<NewsEventDTO, NewsEvent>(newsEvent);
            Database.News.AddNewsEvent(ev);
            Database.Save();
        }
        public void UpdateNewsEvent(NewsEventDTO newsEvent)
        {
            NewsEvent ev = mappingService.Map<NewsEventDTO, NewsEvent>(newsEvent);
            Database.News.UpdateNewsEvent(ev);
            Database.Save();
        }

        public List<LinkDTO> GetAllLinks()
        {
            List<Link> links = Database.News.GetAllLinks();
            List<LinkDTO> linksDto = links.Select(a => mappingService.Map<Link, LinkDTO>(a)).ToList();
            return linksDto;
        }
        public List<LinkDTO> GetLinks(int startRowIndex, int maximumRows, out int totalRowsCount)
        {
            List<Link> links = Database.News.GetLinks(startRowIndex, maximumRows, out totalRowsCount);
            List<LinkDTO> linksDto = links.Select(a => mappingService.Map<Link, LinkDTO>(a)).ToList();
            return linksDto;
        }
        public NewsEventDTO GetNewsEventById(int newsId)
        {
            var ev = Database.News.GetNewsEventById(newsId);
            var dto = mappingService.Map<NewsEvent, NewsEventDTO>(ev);
            return dto;
        }
        public NewsEventDTO GetLastNewsEvent()
        {
            var ev = Database.News.GetLastNewsEvent();
            var dto = mappingService.Map<NewsEvent, NewsEventDTO>(ev);
            return dto;
        }
        public void DeleteNewsEventById(int id)
        { 
            Database.News.DeleteNewsEventById(id);
            Database.Save();
        }
    }
}
