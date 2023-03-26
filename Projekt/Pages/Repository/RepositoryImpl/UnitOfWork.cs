using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository.RepositoryImpl
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private TicketDBContext context = new TicketDBContext();
        private bool disposed = false;
        IEventSeatRepository eventSeatRepository;
        IKarnetRepository karnetRepository;
        IStuardRepository stuardRepository;
        ISeatRepository seatRepository;
        ITicketRepository ticketRepository;
        IUserRepository userRepository;
        IEventRepository eventRepository;


        public IEventSeatRepository EventSeatRepository
        {
            get
            {

                if (this.eventSeatRepository == null)
                {
                    this.eventSeatRepository = new EventSeatRepository(context);
                }
                return eventSeatRepository;
            }
        }

        public ISeatRepository SeatRepository
        {
            get
            {

                if (this.seatRepository == null)
                {
                    this.seatRepository = new SeatRepository(context);
                }
                return seatRepository;
            }
        }

        public ITicketRepository TicketRepository
        {
            get
            {

                if (this.ticketRepository == null)
                {
                    this.ticketRepository = new TicketRepository(context);
                }
                return ticketRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public IKarnetRepository KarnetRepository
        {
            get
            {
                if (this.karnetRepository == null)
                {
                    this.karnetRepository = new KarnetRepository(context);
                }
                return karnetRepository;
            }
        }

        public IEventRepository EventRepository
        {
            get
            {
                if (this.eventRepository == null)
                {
                    this.eventRepository = new EventRepository(context);
                }
                return eventRepository;
            }
        }

        IStuardRepository IUnitOfWork.StuardRepository
        {
            get
            {
                if (this.stuardRepository == null)
                {
                    this.stuardRepository = new StuardRepository(context);
                }
                return stuardRepository;
            }
        }
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

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }


}
   
