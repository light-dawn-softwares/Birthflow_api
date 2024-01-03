using Birthflow_api.Application.Dto;
using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Interfaces
{
    public interface ICervicalDilationService
    {
        public void Create(CervicalDilationDto cervicalDilationDto);
        public void Update(CervicalDilationDto cervicalDilationDto);
        public void Delete(int id);
        public List<CervicalDilation> GetByPartograph(string partographId);

    }
}
