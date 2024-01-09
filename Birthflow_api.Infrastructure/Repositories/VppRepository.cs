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
    public class VppRepository : IVppRepository
    {
        private readonly BirthflowDbContext _birthflowDbContext;

        public VppRepository(BirthflowDbContext birthflowDbContext)
        {
            _birthflowDbContext = birthflowDbContext;
        }

        public void Create(Vpp vpp)
        {
            try
            {
                _birthflowDbContext.Add(vpp);
                _birthflowDbContext.SaveChanges();
            
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int vppId)
        {
            try
            {
                var result = _birthflowDbContext.Vpps.Find(vppId);
                if (result != null)
                {
                    result.IsDelete = true;
                    result.DeleteAt = DateTime.Now;

                    _birthflowDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Vpp GetVppById(int vppId)
        {
            try
            {
                return _birthflowDbContext.Vpps.Find(vppId)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Vpp> GetVppsByPartograph(string partographId)
        {
            try
            {
                return _birthflowDbContext.Vpps.Where(p => p.PartographId == partographId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Vpp vpp)
        {
            try
            {
                var result = _birthflowDbContext.Vpps.Find(vpp.VppId);
                if (result != null) { 
                    result.Position = vpp.Position;
                    result.Time = vpp.Time;
                    result.HodgePlane = vpp.HodgePlane;
                    result.UpdateAt = DateTime.Now;

                    _birthflowDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
