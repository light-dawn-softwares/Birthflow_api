using Birthflow_api.Domain.Interfaces;
using Birthflow_api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Infrastructure.Repositories
{
    public class CervicalDilationRepository : ICervicalDilationRepository
    {
        private readonly BirthflowDbContext _dbContext;

        public CervicalDilationRepository(BirthflowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(CervicalDilation cervicalDilation)
        {
            try
            {
                cervicalDilation.IsDelete = false;
                cervicalDilation.CreateAt = DateTime.Now;
                _dbContext.CervicalDilations.Add(cervicalDilation);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int cervicalDilationId)
        {
            try
            {
                var exists = _dbContext.CervicalDilations.Find(cervicalDilationId);

                exists!.IsDelete = true;
                exists.DeleteAt = DateTime.Now;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CervicalDilation> GetByPartograph(string partographId)
        {
            try
            {
                return _dbContext.CervicalDilations.
                    Where(p => p.PartographId == partographId).
                    Where(p => p.IsDelete == false).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(CervicalDilation cervicalDilation)
        {
            try
            {
                var exists = _dbContext.CervicalDilations.Find(cervicalDilation.PartographId);

                if (exists != null)
                {
                    exists.Hour = cervicalDilation.Hour;
                    exists.Value = cervicalDilation.Value;
                    exists.RemOram = cervicalDilation.RemOram;
                    exists.UpdateAt = DateTime.Now;

                    _dbContext.SaveChanges();
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
