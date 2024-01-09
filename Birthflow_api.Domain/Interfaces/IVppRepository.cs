using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Domain.Interfaces
{
    public interface IVppRepository
    {
        public IEnumerable<Vpp> GetVppsByPartograph(string partographId);
        public Vpp GetVppById(int vppId);
        public void Create(Vpp vpp);
        public void Update(Vpp vpp);
        public void Delete(int vppId);
    }
}
