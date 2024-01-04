using Birthflow_api.Application.Dto;
using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Interfaces
{
    public interface IMedicalSurveillanceService
    {
        public void Create(MedicalSurveillanceDto medicalSurveillanceDto);
        public void Update(MedicalSurveillanceDto medicalSurveillanceDto);
        public void Delete(int medicalSurveillanceId);
        public List<MedicalSurveillance> GetByPartographId(string partographId);
        public MedicalSurveillance GetMedicalSurveillanceById(int medicalSurveillanceId);
    }
}
