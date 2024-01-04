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
    public class MedicalSurveillanceRepository : IMedicalSurveillanceRepository
    {

        private readonly BirthflowDbContext _dbContext;

        public MedicalSurveillanceRepository(BirthflowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(MedicalSurveillance medicalSurveillance)
        {
            try
            {
                medicalSurveillance.CreateAt = DateTime.Now;
                medicalSurveillance.IsDelete = false;

                _dbContext.MedicalSurveillances.Add(medicalSurveillance);

                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int medicalSurveillanceId)
        {
            try
            {
                var result = _dbContext.MedicalSurveillances.Find(medicalSurveillanceId)!;
                if (result != null)
                {
                    result.IsDelete = true;
                    result.DeleteAt = DateTime.Now;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<MedicalSurveillance> GetByPartographId(string partographId)
        {
            try
            {
                var result = _dbContext.MedicalSurveillances
                    .Include(p=> p.Observation)
                    .Where(p => p.PartographId == partographId)
                    .Where(p => p.IsDelete == false).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MedicalSurveillance GetMedicalSurveillanceById(int medicalSurveillanceId)
        {
            try
            {
                return _dbContext.MedicalSurveillances.Find(medicalSurveillanceId)!;
            }
            catch (Exception)
            {

                throw;
            }   
        }

        public void Update(MedicalSurveillance medicalSurveillance)
        {
            try
            {
               var result =  _dbContext.MedicalSurveillances.Find(medicalSurveillance.MedicalSurveillanceId)!;
                if (result != null)
                {
                    result.ArterialPressure = medicalSurveillance.ArterialPressure;
                    result.FrequencyContractions = medicalSurveillance.FrequencyContractions;
                    result.MaternalPosition = medicalSurveillance.MaternalPosition;
                    result.MaternalPulse = medicalSurveillance.MaternalPulse;
                    result.ContractionsDuration = medicalSurveillance.ContractionsDuration;
                    result.FetalHeartRate = medicalSurveillance.FetalHeartRate;
                    result.Time = medicalSurveillance.Time;
                    result.PainIntensity = medicalSurveillance.PainIntensity;
                    result.PainLocation = medicalSurveillance.PainLocation;

                    result.UpdateAt = DateTime.Now;

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
