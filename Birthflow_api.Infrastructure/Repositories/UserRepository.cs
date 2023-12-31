using Birthflow_api.Domain.Interfaces;
using Birthflow_api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BirthflowDbContext _context;

        public UserRepository(BirthflowDbContext context)
        {
            _context = context;
        }

        public void create(User user)
        {
            try
            {
                user.UserId = Guid.NewGuid();
                user.CreateAt = DateTime.Now;
                user.UpdateAt = DateTime.Now;
                user.IsDelete = false;
                user.DeleteAt = null;

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating user", ex);
            }
        }

        public void delete(Guid userId)
        {
            try
            {
                var user = _context.Users.Find(userId);
                if (user != null)
                {
                    user!.IsDelete = true;
                    user!.DeleteAt = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting user", ex);
            }
        }

        public User findById(Guid userId)
        {
            try
            {
                var user = _context.Users.Find(userId);
                return user!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error finding user by ID", ex);
            }
        }

        public IEnumerable<User> getAll()
        {
            try
            {
                return _context.Users.Where(user => !user.IsDelete).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting all users", ex);
            }
        }

        public void update(User user)
        {
            try
            {
                var existingUser = _context.Users.Find(user.UserId);
                if (user != null)
                {
                    existingUser!.FirstName = user.FirstName;
                    existingUser!.LastName = user.LastName;
                    existingUser!.Email = user.Email;
                    existingUser!.PhoneNumber = user.PhoneNumber;
                    existingUser!.UserName = user.UserName;
                    existingUser!.UpdateAt = DateTime.Now;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user", ex);
            }
        }
    }
}
