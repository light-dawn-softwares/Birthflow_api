using Birthflow_api.Application.Dto;
using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Interfaces
{
    public interface IVppService
    {
        public List<Vpp> GetVppsByPartograph(string partographId);
        public Vpp GetVppById(int vppId);
        public void Create(VppDto vppDto);
        public void Update(VppDto vppDto);
        public void Delete(int vppId);
    }
}
