using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository EventRepository { get; }
        IStuardRepository StuardRepository { get; }
        ISeatRepository SeatRepository { get; }
        IEventSeatRepository EventSeatRepository { get; }
        ITicketRepository TicketRepository { get; }
        IUserRepository UserRepository { get; }
        IKarnetRepository KarnetRepository { get; }
        void SaveChanges();
    }
}
