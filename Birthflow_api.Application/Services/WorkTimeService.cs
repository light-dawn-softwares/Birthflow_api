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
    public class WorkTimeService : IWorkTimeService
    {
        private readonly WorkTimeRepository _workTimeRepository;

        public WorkTimeService(WorkTimeRepository workTimeRepository)
        {
            this._workTimeRepository = workTimeRepository;
        }

        public WorkTime FindById(string partographID)
        {
            try
            {
                return _workTimeRepository.FindById(partographID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(WorkTimeDto workTimeDto)
        {
            try
            {
                WorkTime workTime = new WorkTime
                {
                    PartographId = workTimeDto.PartographId,
                    Paridad = workTimeDto.Paridad,
                    Membranas = workTimeDto.Membranas,
                    Posicion = workTimeDto.Posicion,
                };

                _workTimeRepository.Update(workTime);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
