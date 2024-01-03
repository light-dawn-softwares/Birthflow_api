using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Domain.Interfaces
{
    public interface ICervicalDilationRepository
    {
        public void Create(CervicalDilation cervicalDilation);
        public void Update(CervicalDilation cervicalDilation);
        public void Delete(int cervicalDilationId);
        public IEnumerable<CervicalDilation> GetByPartograph(string partographId);
    }
}
