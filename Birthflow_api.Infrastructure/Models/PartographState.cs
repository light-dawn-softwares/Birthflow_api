using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class PartographState
{
    public string PartographId { get; set; } = null!;

    public bool Archived { get; set; }

    public bool Silenced { get; set; }

    public bool Permanent { get; set; }

    public DateTime LastModification { get; set; }

    public virtual Partograph Partograph { get; set; } = null!;
}
