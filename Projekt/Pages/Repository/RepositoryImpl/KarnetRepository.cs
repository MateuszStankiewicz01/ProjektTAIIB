using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Projekt.Pages.Repository
{
    public class KarnetRepository : IKarnetRepository, IDisposable
    {
        private TicketDBContext context;

        public KarnetRepository(TicketDBContext context)
        {
            this.context = context;
        }

        public Karnet GetKarnetByID(int id)
        {
            return context.Karnet.Find(id);
        }

        public void InsertKarnet(Karnet karnet)
        {
            context.Karnet.Add(karnet);
        }

        public void DeleteKarnet(int karnetID)
        {
            Karnet karnet = context.Karnet.Find(karnetID);
            context.Karnet.Remove(karnet);
        }

        public void UpdateKarnet(Karnet karnet)
        {
            context.Entry(karnet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Karnet> GetKarnets()
        {
            return context.Karnet.ToList();
        }
    }
}
