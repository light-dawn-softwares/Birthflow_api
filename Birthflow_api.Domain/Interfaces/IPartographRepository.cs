using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Domain.Interfaces
{
    public interface IPartographRepository
    {
        public void create(Partograph partograph, WorkTime workTime);

        public void update(Partograph partograph);

        public void delete(string partographId);

        public Partograph findById(string partographId);

        public IEnumerable<Partograph> findAll(Guid UserId);
    }
}
