using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    public interface IEventSeatRepository
    {
        IEnumerable<EventSeat> GetEventSeat();
        EventSeat GetEventSeatByID(int seatId);
        void InsertEventSeat(EventSeat seat);
        void DeleteEventSeat(int seatId);
        void UpdateEventSeat(EventSeat seat);
        void Save();
    }
}
