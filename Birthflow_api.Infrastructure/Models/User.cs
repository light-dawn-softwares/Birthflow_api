using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class User
{
    public Guid UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public decimal? PhoneNumber { get; set; }

    public virtual ICollection<Configuration> Configurations { get; set; } = new List<Configuration>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Partograph> Partographs { get; set; } = new List<Partograph>();

    public virtual ICollection<Password> Passwords { get; set; } = new List<Password>();
}
