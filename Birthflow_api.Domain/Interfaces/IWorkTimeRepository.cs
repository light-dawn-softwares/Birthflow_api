using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Domain.Interfaces
{
    public interface IWorkTimeRepository
    {
        public void Update(WorkTime workTime);
        public WorkTime FindById(string partographId);

    }   
}
