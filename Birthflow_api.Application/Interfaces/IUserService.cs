using Birthflow_api.Application.Dto;
using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(UserDto userDto);
        public void DeleteUser(Guid userId);
        public User GetUserById(Guid userId);
        public List<User> GetAllUsers();
        public void UpdateUser(UserDto userDto);

    }
}
