using Birthflow_api.Application.Dto;
using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Interfaces
{
    public interface IPartographService
    {
        public List<Partograph> GetAll(Guid userId);
        public Partograph create(PartographCreateDto partographDto);
        public Partograph update(PartographDto partographDto);
        public void delete(string partographId);
        public Partograph findById(string partographId);

    }
}
