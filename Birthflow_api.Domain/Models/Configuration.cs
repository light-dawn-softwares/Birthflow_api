using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class Configuration
{
    public Guid PasswordId { get; set; }

    public Guid? UserId { get; set; }

    public bool? SyncDataPermision { get; set; }

    public bool? NotificationPermision { get; set; }

    public bool? Vibration { get; set; }

    public string? Lenguage { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual User? User { get; set; }
}
