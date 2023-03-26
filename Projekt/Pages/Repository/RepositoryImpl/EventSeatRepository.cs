using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository.RepositoryImpl
{
    public class EventSeatRepository : IEventSeatRepository, IDisposable
    {
        private TicketDBContext context;

        public EventSeatRepository(TicketDBContext context)
        {
            this.context = context;
        }

        public void DeleteEventSeat(int seatId)
        {
            Model.EventSeat seat = context.EventSeat.Find(seatId);
            context.EventSeat.Remove(seat);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Model.EventSeat> GetEventSeat()
        {
            return context.EventSeat.ToList();
        }

        public Model.EventSeat GetEventSeatByID(int seatId)
        {
            return context.EventSeat.Find(seatId);
        }

        public void InsertEventSeat(Model.EventSeat seat)
        {
            context.EventSeat.Add(seat);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateEventSeat(Model.EventSeat seat)
        {
            context.Entry(seat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
    }
}
