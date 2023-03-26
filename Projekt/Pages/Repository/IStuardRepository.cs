using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository
{
    public interface IStuardRepository
    {
        IEnumerable<Stuard> GetStuards();
        Stuard GetStuardByID(int stuardId);
        void InsertStuard(Stuard stuard);
        void DeleteStuard(int stuardID);
        void UpdateStuard(Stuard stuard);
        void Save();
    }
}
