using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

using Projekt.Pages.Model;

namespace Projekt.Pages.Repository
{
    public class TicketDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public System.Data.Entity.DbSet<Event> Event { get; set; }
        public System.Data.Entity.DbSet<Stuard> Stuard { get; set; }
        public System.Data.Entity.DbSet<Karnet> Karnet { get; set; }
        public System.Data.Entity.DbSet<Seat> Seat { get; set; }
        public System.Data.Entity.DbSet<EventSeat> EventSeat { get; set; }
        public System.Data.Entity.DbSet<Ticket> Ticket { get; set; }
        public System.Data.Entity.DbSet<User> User { get; set; }
        
        public TicketDBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TicketDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotSupportedException();
        }

    }
}
