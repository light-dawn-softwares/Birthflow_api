using Birthflow_api.Domain.Interfaces;
using Birthflow_api.Infrastructure.Helper;
using Birthflow_api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
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
                partograph.PartographId = IdCreator.CreateUniqueId(partograph.Name, DateTime.Now);
                partograph.IsDelete = false;
                partograph.UpdateAt = null;

                _context.Add(partograph);
                _context.SaveChanges();

                workTime.PartographId = partograph.PartographId;
                workTime.CreateAt = DateTime.Now;
                workTime.UpdateAt = null;

                _context.Add(workTime);
                _context.SaveChanges();

                PartographState partographState = new PartographState { 
                    PartographId = partograph.PartographId,
                    Archived  = false,
                    Silenced = false,
                    Permanent = false,
                    UpdateAt = null,
                };

                _context.Add(partographState);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void delete(string partographId)
        {
            try
            {
                var partograph = _context.Partographs.Find(partographId);

                partograph!.IsDelete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Partograph> findAll(Guid UserId)
        {
            try
            {
                return _context.Partographs.
                    Include(p => p.WorkTime).
                    Include(p => p.PartographState).
                    Where(p => p.UserId == UserId).
                    Where(p => p.IsDelete == false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Partograph findById(string partographId)
        {
            try
            {

                return _context.Partographs.
                    Include(p => p.WorkTime).
                    Include(p => p.PartographState).
                    FirstOrDefault(p => p.PartographId == partographId && !p.IsDelete)!;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void update(Partograph partograph)
        {
            try
            {
                var existsPartograph = _context.Partographs.Find(partograph.PartographId);

                if(existsPartograph != null)
                {
                    existsPartograph.RecordNumber = partograph.RecordNumber;
                    existsPartograph.Name = partograph.Name;
                    existsPartograph.Date = partograph.Date;
                    existsPartograph.UpdateAt = DateTime.Now;
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
