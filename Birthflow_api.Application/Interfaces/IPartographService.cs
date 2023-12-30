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
        public List<Partograph> GetAll(string UserId);
        public Partograph create(PartographDto partographDto);
    }
}
