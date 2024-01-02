using Birthflow_api.Application.Dto;
using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Interfaces
{
    public interface IWorkTimeService
    {
        public void Update(WorkTimeDto workTimeDto);

        public WorkTime FindById(string partographID);
    }
}
