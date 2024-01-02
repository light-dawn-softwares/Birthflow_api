using Birthflow_api.Domain.Interfaces;
using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Infrastructure.Repositories
{
    public class WorkTimeRepository : IWorkTimeRepository
    {
        private readonly BirthflowDbContext _context;

        public WorkTimeRepository(BirthflowDbContext context)
        {
            _context = context;
        }

        public WorkTime FindById(string partographId)
        {
            try
            {
                var exists = _context.WorkTimes.Find(partographId);
                return exists!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(WorkTime workTime)
        {
            try
            {
                var exists = _context.WorkTimes.Find(workTime.PartographId);
                if (exists != null)
                {
                    exists.Posicion = workTime.Posicion;
                    exists.Paridad = workTime.Paridad;
                    exists.Membranas = workTime.Membranas;
                    exists.UpdateAt = DateTime.Now;

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
