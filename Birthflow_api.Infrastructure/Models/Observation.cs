using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class Observation
{
    public int MedicalSurveillanceId { get; set; }

    public string Header { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual MedicalSurveillance MedicalSurveillance { get; set; } = null!;
}
