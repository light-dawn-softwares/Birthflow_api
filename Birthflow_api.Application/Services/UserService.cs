using Birthflow_api.Application.Dto;
using Birthflow_api.Application.Interfaces;
using Birthflow_api.Domain.Interfaces;
using Birthflow_api.Infrastructure.Models;
using Birthflow_api.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(UserDto userDto)
        {
            try
            {
                User user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    UserName = userDto.UserName,
                    PhoneNumber = userDto.PhoneNumber,
                };
                _userRepository.create(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUser(Guid userId)
        {
            try
            {
                _userRepository.delete(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return (List<User>)_userRepository.getAll();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public User GetUserById(Guid userId)
        {
            try
            {
                return _userRepository.findById(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateUser(UserDto userDto)
        {
            try
            {
                Guid userId = Guid.Parse(userDto.UserId!);
                User user = new User
                {
                    UserId = userId,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    UserName = userDto.UserName,
                    PhoneNumber = userDto.PhoneNumber,
                };
                _userRepository.update(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
