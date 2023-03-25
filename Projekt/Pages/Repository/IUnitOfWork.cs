using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Event> EventRepository { get; }
        IRepository<Stuard> StuardRepository { get; }
        IRepository<Seat> SeatRepository { get; }
        IRepository<EventSeat> EventSeatRepository { get; }
        void SaveChanges();
    }
}
