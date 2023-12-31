﻿using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class CervicalDilation
{
    public int CervicalDilationId { get; set; }

    public string? PartographId { get; set; }

    public decimal Value { get; set; }

    public DateTime Hour { get; set; }

    public bool RemOram { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual Partograph? Partograph { get; set; }
}
