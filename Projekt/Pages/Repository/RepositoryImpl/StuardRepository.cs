using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository.RepositoryImpl
{
    public class StuardRepository : IStuardRepository, IDisposable
    {
        private TicketDBContext context;

        public StuardRepository(TicketDBContext context)
        {
            this.context = context;
        }
        public void DeleteStuard(int stuardID)
        {
            Stuard stuard = context.Stuard.Find(stuardID);
            context.Stuard.Remove(stuard);
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

        public Stuard GetStuardByID(int stuardId)
        {
            return context.Stuard.Find(stuardId);
        }

        public IEnumerable<Stuard> GetStuards()
        {
            return context.Stuard.ToList();
        }

        public void InsertStuard(Stuard stuard)
        {
            context.Stuard.Add(stuard);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateStuard(Stuard stuard)
        {
            context.Entry(stuard).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
