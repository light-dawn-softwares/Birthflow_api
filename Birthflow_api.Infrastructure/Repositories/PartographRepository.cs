using Birthflow_api.Domain.Interfaces;
using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Infrastructure.Repositories
{
    public class PartographRepository : IPartographRepository
    {
        private readonly BirthflowDbContext _context;

        public PartographRepository(BirthflowDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
  
        public void create(Partograph partograph, WorkTime workTime)
        {
            try
            {
                /*_context.Add(partograph);
                _context.SaveChanges();

                _context.Add(workTime);
                _context.SaveChanges();*/

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
            try
            {
                return _context.Partographs.Where(p => p.UserId == UserId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void update(Partograph partograph)
        {
            throw new NotImplementedException();
        }
    }
}
