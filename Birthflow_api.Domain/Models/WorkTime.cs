using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class WorkTime
{
    public string PartographId { get; set; } = null!;

    public string Posicion { get; set; } = null!;

    public string Paridad { get; set; } = null!;

    public string Membranas { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Partograph Partograph { get; set; } = null!;
}
