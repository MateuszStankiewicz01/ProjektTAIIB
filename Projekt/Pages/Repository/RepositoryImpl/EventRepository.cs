using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository.RepositoryImpl
{
    public class EventRepository : IEventRepository, IDisposable
    {
        private TicketDBContext context;

        public EventRepository(TicketDBContext context)
        {
            this.context = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DeleteEvent(int eventId)
        {
            Model.Event eventObject = context.Event.Find(eventId);
            context.Event.Remove(eventObject);
        }

        public IEnumerable<Model.Event> GetEvent()
        {
            return context.Event.ToList();
        }

        public Model.Event GetEventByID(int eventId)
        {
            return context.Event.Find(eventId);
        }

        public void InsertEvent(Model.Event eventObject)
        {
            context.Event.Add(eventObject);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateEvent(Model.Event eventObject)
        {
            context.Entry(eventObject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
