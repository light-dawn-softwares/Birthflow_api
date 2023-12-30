using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birthflow_api.Application.Dto;
using Birthflow_api.Application.Interfaces;
using Birthflow_api.Infrastructure.Models;
using Birthflow_api.Infrastructure.Repositories;


namespace Birthflow_api.Application.Services
{
    public class PartographService : IPartographService
    {
        private readonly PartographRepository _partographRepository;

        public PartographService(PartographRepository partographRepository)
        {
            _partographRepository = partographRepository;
        }

        public List<Partograph> GetAll(string UserId)
        {
            try
            {
                Guid userID = Guid.Parse(UserId);
                var partographs = _partographRepository.findAll(userID);

                return partographs.ToList();
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public Partograph create(PartographDto partographDto)
        {
            try
            {
                Guid userID = Guid.Parse(partographDto.UserId);

                var partographEntity = new Partograph
                {
                    UserId = userID,
                    Name = partographDto.Name,
                    RecordNumber = partographDto.RecordNumber,
                    Date = partographDto.Date
                };

                var worktimeEntity = new WorkTime
                {
                    Paridad = partographDto.Membranas,
                    Membranas = partographDto.Paridad,
                    Posicion = partographDto.Posicion
                };

                _partographRepository.create(partographEntity, worktimeEntity);

                return partographEntity;
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}   
