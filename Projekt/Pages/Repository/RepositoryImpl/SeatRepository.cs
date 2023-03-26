using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    public class SeatRepository : ISeatRepository, IDisposable
    {
        private TicketDBContext context;

        public SeatRepository(TicketDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Seat> GetSeats()
        {
            return context.Seat.ToList();
        }

        public Seat GetSeatByID(int id)
        {
            return context.Seat.Find(id);
        }

        public void InsertSeat(Seat seat)
        {
            context.Seat.Add(seat);
        }

        public void DeleteSeat(int seatID)
        {
            Seat seat = context.Seat.Find(seatID);
            context.Seat.Remove(seat);
        }

        public void UpdateSeat(Seat seat)
        {
            context.Entry(seat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

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
    }
}
