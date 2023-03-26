using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    interface IKarnetRepository
    {
        IEnumerable<Karnet> GetKarnets();
        Karnet GetKarnetByID(int karnetId);
        void InsertKarnet(Karnet karnet);
        void DeleteKarnet(int karnetID);
        void UpdateKarnet(Karnet karnet);
        void Save();
    }
}
