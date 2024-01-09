using Birthflow_api.Application.Dto;
using Birthflow_api.Application.Interfaces;
using Birthflow_api.Infrastructure.Models;
using Birthflow_api.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Services
{
    public class VppService : IVppService
    {
        private readonly VppRepository _repository;

        public VppService(VppRepository repository)
        {
            _repository = repository;
        }

        public void Create(VppDto vppDto)
        {
            try
            {
                Vpp vpp = new Vpp
                {
                    PartographId = vppDto.PartographId,
                    HodgePlane = vppDto.HodgePlane,
                    Position = vppDto.Position,
                    Time = vppDto.Time,
                };
                _repository.Create(vpp);
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
                _repository.Delete(vppId);
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
                return _repository.GetVppById(vppId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Vpp> GetVppsByPartograph(string partographId)
        {
            try
            {
                return _repository.GetVppsByPartograph(partographId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(VppDto vppDto)
        {
            try
            {
                Vpp vpp = new Vpp
                {
                    PartographId = vppDto.PartographId,
                    HodgePlane = vppDto.HodgePlane,
                    Position = vppDto.Position,
                    Time = vppDto.Time,
                };
                _repository.Create(vpp);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
