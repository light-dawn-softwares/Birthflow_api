using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class NotificationType
{
    public int NotificationTypeId { get; set; }

    public string? Header { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
