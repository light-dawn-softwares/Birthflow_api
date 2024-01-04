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
    public class MedicalSurveillanceService : IMedicalSurveillanceService
    {
        private readonly MedicalSurveillanceRepository _medicalSurveillanceRepository;

        public MedicalSurveillanceService(MedicalSurveillanceRepository medicalSurveillanceRepository)
        {
            _medicalSurveillanceRepository = medicalSurveillanceRepository;
        }

        public void Create(MedicalSurveillanceDto medicalSurveillanceDto)
        {
            try
            {
                MedicalSurveillance medicalSurveillance = new MedicalSurveillance
                {
                    PartographId = medicalSurveillanceDto.PartographId,
                    MaternalPosition = medicalSurveillanceDto.MaternalPosition,
                    ArterialPressure = medicalSurveillanceDto.ArterialPressure,
                    MaternalPulse = medicalSurveillanceDto.MaternalPulse,
                    FetalHeartRate = medicalSurveillanceDto.FetalHeartRate,
                    ContractionsDuration = medicalSurveillanceDto.ContractionsDuration,
                    FrequencyContractions = medicalSurveillanceDto.FrequencyContractions,
                    PainIntensity = medicalSurveillanceDto.PainIntensity,
                    PainLocation = medicalSurveillanceDto.PainLocation,
                    Time = medicalSurveillanceDto.Time
                };
                _medicalSurveillanceRepository.Create(medicalSurveillance);
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
                _medicalSurveillanceRepository. Delete(medicalSurveillanceId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MedicalSurveillance> GetByPartographId(string partographId)
        {
            try
            {
                return _medicalSurveillanceRepository.GetByPartographId(partographId).ToList();
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
                return _medicalSurveillanceRepository.GetMedicalSurveillanceById(medicalSurveillanceId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(MedicalSurveillanceDto medicalSurveillanceDto)
        {
            try
            {
                MedicalSurveillance medicalSurveillance = new MedicalSurveillance { 
                    MedicalSurveillanceId = medicalSurveillanceDto.MedicalSurveillanceId,
                    PartographId = medicalSurveillanceDto.PartographId,
                    MaternalPosition = medicalSurveillanceDto.MaternalPosition,
                    ArterialPressure = medicalSurveillanceDto.ArterialPressure,
                    MaternalPulse = medicalSurveillanceDto.MaternalPulse,
                    FetalHeartRate = medicalSurveillanceDto.FetalHeartRate,
                    ContractionsDuration = medicalSurveillanceDto.ContractionsDuration,
                    FrequencyContractions = medicalSurveillanceDto.FrequencyContractions,
                    PainIntensity = medicalSurveillanceDto.PainIntensity,
                    PainLocation = medicalSurveillanceDto.PainLocation,
                    Time = medicalSurveillanceDto.Time
                };

                _medicalSurveillanceRepository.Update(medicalSurveillance);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
