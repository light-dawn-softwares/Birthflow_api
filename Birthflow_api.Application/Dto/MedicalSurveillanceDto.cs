using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Dto
{
    public class MedicalSurveillanceDto
    {
        public int MedicalSurveillanceId { get; set; }

        public string? PartographId { get; set; }

        public string MaternalPosition { get; set; } = null!;

        public string ArterialPressure { get; set; } = null!;

        public string MaternalPulse { get; set; } = null!;

        public string FetalHeartRate { get; set; } = null!;

        public string ContractionsDuration { get; set; } = null!;

        public string FrequencyContractions { get; set; } = null!;

        public string PainIntensity { get; set; } = null!;

        public string PainLocation { get; set; } = null!;

        public DateTime Time { get; set; }
    }
}
