using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class Notification
{
    public string NotificationId { get; set; } = null!;

    public Guid? UserId { get; set; }

    public int? NotificationTypeId { get; set; }

    public bool Readed { get; set; }

    public DateTime Date { get; set; }

    public virtual NotificationType? NotificationType { get; set; }

    public virtual User? User { get; set; }
}
