using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class Observation
{
    public int MedicalSurveillanceId { get; set; }

    public string Header { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual MedicalSurveillance MedicalSurveillance { get; set; } = null!;
}
