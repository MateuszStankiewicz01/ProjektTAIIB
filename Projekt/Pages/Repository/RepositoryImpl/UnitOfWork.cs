using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository.RepositoryImpl
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private TicketDBContext context = new TicketDBContext();
        IEventSeatRepository eventSeatRepository;
        IEventSeatRepository courseRepository;

        public IEventSeatRepository EventSeatRepository
        {
            get
            {

                if (this.eventSeatRepository == null)
                {
                    this.eventSeatRepository = new EventSeatRepository(context);
                }
                return eventSeatRepository;
            }
        }

        public IRepository<Event> EventRepository => throw new NotImplementedException();

        public IRepository<Stuard> StuardRepository => throw new NotImplementedException();

        public IRepository<Seat> SeatRepository => throw new NotImplementedException();

        IRepository<EventSeat> IUnitOfWork.EventSeatRepository => throw new NotImplementedException();

        public void Save()
        {
            context.SaveChanges();
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
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
