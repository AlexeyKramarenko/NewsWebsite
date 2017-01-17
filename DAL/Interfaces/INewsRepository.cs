using System.Collections.Generic;
using DAL.POCO;

namespace DAL
{
    public interface INewsRepository
    {
        void AddNewsEvent(NewsEvent newsEvent);
        void UpdateNewsEvent(NewsEvent newsEvent);
        List<Link> GetAllLinks();        
        List<Link> GetLinks(int startRowIndex, int maximumRows, out int totalRowsCount);
        NewsEvent GetNewsEventById(int newsId);
        NewsEvent GetLastNewsEvent();
        void DeleteNewsEventById(int id);
    }
}