using Birthflow_api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Domain.Interfaces
{
    public interface IMedicalSurveillanceRepository
    {
        public void Create(MedicalSurveillance medicalSurveillance);
        public void Update(MedicalSurveillance medicalSurveillance);
        public void Delete(int medicalSurveillanceId);
        public IEnumerable<MedicalSurveillance> GetByPartographId(string partographId);
        public MedicalSurveillance GetMedicalSurveillanceById(int medicalSurveillanceId);
    }
}
