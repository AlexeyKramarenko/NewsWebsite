using System.Collections.Generic;

using BLL.DTO;

namespace BLL
{
    public interface INewsService
    { 
        List<LinkDTO> GetAllLinks();
        List<LinkDTO> GetLinks(int startRowIndex, int maximumRows, out int totalRowsCount);
        void AddNewsEvent(NewsEventDTO newsEvent);
        void UpdateNewsEvent(NewsEventDTO newsEvent);
        NewsEventDTO GetNewsEventById(int newsId);
        NewsEventDTO GetLastNewsEvent();
        void DeleteNewsEventById(int id);
    }
}