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

        public List<Partograph> GetAll(Guid userId)
        {
            try
            {
                var partographs = _partographRepository.findAll(userId);

                return partographs.ToList();
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public Partograph create(PartographCreateDto partographDto)
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

        public Partograph update(PartographDto partographDto)
        {
            try
            { 
                var partographEntity = new Partograph
                {
                    PartographId = partographDto.PartographId,
                    Name = partographDto.Name,
                    RecordNumber = partographDto.RecordNumber,
                    Date = partographDto.Date
                };
            
                _partographRepository.update(partographEntity);

                return partographEntity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void delete(string partographId)
        {
            try
            {
                _partographRepository.delete(partographId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Partograph findById(string partographId)
        {
            try
            {
               return _partographRepository.findById(partographId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}   
