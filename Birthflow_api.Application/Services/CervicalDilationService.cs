using Birthflow_api.Application.Dto;
using Birthflow_api.Application.Interfaces;
using Birthflow_api.Infrastructure.Models;
using Birthflow_api.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Services
{
    public class CervicalDilationService : ICervicalDilationService
    {
        private readonly CervicalDilationRepository _repository;

        public CervicalDilationService(CervicalDilationRepository repository)
        {
            _repository = repository;
        }

        public void Create(CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                CervicalDilation  cervicalDilation = new CervicalDilation
                {
                    PartographId = cervicalDilationDto.PartographId,
                    Value = cervicalDilationDto.Value,
                    RemOram = cervicalDilationDto.RemOram,
                    Hour = cervicalDilationDto.Hour,
                };

                _repository.Create(cervicalDilation);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CervicalDilation> GetByPartograph(string partographId)
        {
            try
            {
                return _repository.GetByPartograph(partographId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                CervicalDilation cervicalDilation = new CervicalDilation
                {
                    CervicalDilationId = cervicalDilationDto.CervicalDilationId,
                    PartographId = cervicalDilationDto.PartographId,
                    Value = cervicalDilationDto.Value,
                    RemOram = cervicalDilationDto.RemOram,
                    Hour = cervicalDilationDto.Hour,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
