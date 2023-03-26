using Projekt.Pages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Repository.RepositoryImpl
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private TicketDBContext context;
        private bool disposed = false;
        
        public UserRepository(TicketDBContext context)
        {
            this.context = context;
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
        public IEnumerable<User> GetUsers()
        {
            return context.User.ToList();
        }
        public User GetUserByID(int userId)
        {
            return context.User.Find(userId);
        }
        public void InsertUser(User user)
        {
            context.User.Add(user);
        }
        public void DeleteUser(int userID)
        {
            User stuard = context.User.Find(userID);
            context.User.Remove(stuard);
        }
        public void UpdateUser(User user)
        {
            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
