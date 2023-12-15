using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class NotificationPartograph
{
    public string? PartographId { get; set; }

    public Guid? UserId { get; set; }

    public string? NotificationId { get; set; }

    public virtual Notification? Notification { get; set; }

    public virtual Partograph? Partograph { get; set; }

    public virtual User? User { get; set; }
}
