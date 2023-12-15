using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class Partograph
{
    public string PartographId { get; set; } = null!;

    public Guid? UserId { get; set; }

    public string Name { get; set; } = null!;

    public string RecordNumber { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual ICollection<BirthNote> BirthNotes { get; set; } = new List<BirthNote>();

    public virtual ICollection<CervicalDilation> CervicalDilations { get; set; } = new List<CervicalDilation>();

    public virtual ICollection<FetalHeartRate> FetalHeartRates { get; set; } = new List<FetalHeartRate>();

    public virtual ICollection<FrequencyContraction> FrequencyContractions { get; set; } = new List<FrequencyContraction>();

    public virtual ICollection<MedicalSurveillance> MedicalSurveillances { get; set; } = new List<MedicalSurveillance>();

    public virtual PartographState? PartographState { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Vpp> Vpps { get; set; } = new List<Vpp>();

    public virtual WorkTime? WorkTime { get; set; }
}
