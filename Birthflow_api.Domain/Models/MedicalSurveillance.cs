using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class MedicalSurveillance
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

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual Observation? Observation { get; set; }

    public virtual Partograph? Partograph { get; set; }
}
