using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets();
        Ticket GetTicketByID(int ticketId);
        void InsertTicket(Ticket ticket);
        void DeleteTicket(int ticketID);
        void UpdateTicket(Ticket ticket);
        void Save();
    }
}
