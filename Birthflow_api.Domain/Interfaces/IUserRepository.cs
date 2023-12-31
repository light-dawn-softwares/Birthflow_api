using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Domain.Interfaces
{
    public interface IUserRepository
    {
        public void create(User user);

        public void update(User user);

        public void delete(Guid userId);

        public IEnumerable<User> getAll();

        public User findById(Guid userId);
    }
}
