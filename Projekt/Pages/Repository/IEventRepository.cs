using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvent();
        Event GetEventByID(int eventId);
        void InsertEvent(Event eventObject);
        void DeleteEvent(int eventId);
        void UpdateEvent(Event eventObject);
        void Save();
    }
}
