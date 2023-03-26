using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    public interface ISeatRepository
    {
        IEnumerable<Seat> GetSeats();
        Seat GetSeatByID(int seatId);
        void InsertSeat(Seat seat);
        void DeleteSeat(int seatID);
        void UpdateSeat(Seat seat);
        void Save();
    }
}
