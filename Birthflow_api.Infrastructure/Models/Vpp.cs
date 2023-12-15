using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class Vpp
{
    public int VppId { get; set; }

    public string? PartographId { get; set; }

    public string HodgePlane { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateTime Time { get; set; }

    public virtual Partograph? Partograph { get; set; }
}
