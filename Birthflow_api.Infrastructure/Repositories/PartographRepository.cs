using Birthflow_api.Domain.Interfaces;
using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Infrastructure.Repositories
{
    internal class PartographRepository : IPartographRepository
    {
        private readonly BirthflowDbContext _context;

        PartographRepository(BirthflowDbContext _context) => this._context = _context;
  
        public void create(Partograph partograph, WorkTime workTime)
        {
            try
            {
                _context.Add(partograph);
                _context.SaveChanges();

                _context.Add(workTime);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void delete(string PartographId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Partograph> findAll(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public void update(Partograph partograph)
        {
            throw new NotImplementedException();
        }
    }
}
