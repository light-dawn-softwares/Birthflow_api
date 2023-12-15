using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class Password
{
    public Guid PasswordId { get; set; }

    public Guid? UserId { get; set; }

    public byte[]? Password1 { get; set; }

    public bool? PassCurrent { get; set; }

    public virtual User? User { get; set; }
}
