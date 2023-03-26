using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    public class TicketRepository : ITicketRepository, IDisposable
    {
        private TicketDBContext context;

        private bool disposed = false;

        public TicketRepository(TicketDBContext context)
        {
            this.context = context;
        }
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

        public IEnumerable<Ticket> GetTickets()
        {
            return context.Ticket.ToList();
        }

        public Ticket GetTicketByID(int ticketId)
        {
            return context.Ticket.Find(ticketId);
        }

        public void InsertTicket(Ticket ticket)
        {
            context.Ticket.Add(ticket);
        }

        public void DeleteTicket(int ticketID)
        {
            Ticket ticket = context.Ticket.Find(ticketID);
            context.Ticket.Remove(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            context.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }

        public void Save()
        {
            context.SaveChanges();
        }
       
    }
}
