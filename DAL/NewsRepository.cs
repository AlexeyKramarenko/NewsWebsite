using DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsRepository : INewsRepository
    {
        DBContext db;

        public NewsRepository(DBContext db)
        {
            this.db = db;
        }
        public void AddNewsEvent(NewsEvent newsEvent)
        {
            db.Entry(newsEvent).State = System.Data.Entity.EntityState.Added;
        }

        public void UpdateNewsEvent(NewsEvent updatedNewsEvent)
        {
            NewsEvent newsEvent = db.NewsEvents.Find(updatedNewsEvent.NewsID);
            if (newsEvent != null)
            {
                newsEvent.Content = updatedNewsEvent.Content;
                newsEvent.Title = updatedNewsEvent.Title;
                newsEvent.Date = updatedNewsEvent.Date;
            }
        }
        public List<Link> GetAllLinks()
        {
            IQueryable<NewsEvent> events = db.NewsEvents.OrderByDescending(a => a.NewsID);

            List<Link> links = events.AsEnumerable().Select(a => new Link { ID = a.NewsID, Title = a.Title }).ToList();

            return links;
        }
        public NewsEvent GetLastNewsEvent()
        {
            NewsEvent ev = db.NewsEvents.OrderByDescending(a => a.Date).FirstOrDefault();
            return ev;
        }
        public NewsEvent GetNewsEventById(int newsId)
        {
            NewsEvent ev = db.NewsEvents.Find(newsId);
            return ev;
        }
        public List<Link> GetLinks(int startRowIndex, int maximumRows, out int totalRowsCount)
        {
            IQueryable<NewsEvent> eventsDB = db.NewsEvents.OrderByDescending(a => a.NewsID);

            totalRowsCount = eventsDB.Count();

            IEnumerable<NewsEvent> events = eventsDB.Skip(startRowIndex).Take(maximumRows).AsEnumerable();

            return events.Select(a => new Link { ID = a.NewsID, Title = a.Title }).ToList();
        }

        public void DeleteNewsEventById(int id)
        {
            NewsEvent newsEvent = db.NewsEvents.Find(id);

            if (newsEvent != null)
                db.NewsEvents.Remove(newsEvent);
        }
    }
}
