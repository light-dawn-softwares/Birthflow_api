using System;
using System.Collections.Generic;

namespace Birthflow_api.Infrastructure.Models;

public partial class BirthNote
{
    public int FrequencyContractionsId { get; set; }

    public string? PartographId { get; set; }

    public string? Description { get; set; }

    public string Hour { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string Apgar { get; set; } = null!;

    public string Temperatura { get; set; } = null!;

    public string Caputto { get; set; } = null!;

    public string Circular { get; set; } = null!;

    public string Lamniotico { get; set; } = null!;

    public string Miccion { get; set; } = null!;

    public string Meconio { get; set; } = null!;

    public string Pa { get; set; } = null!;

    public string Expulsivo { get; set; } = null!;

    public string Placenta { get; set; } = null!;

    public string Alumbramiento { get; set; } = null!;

    public string HuellaPlantar { get; set; } = null!;

    public DateTime Date { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Partograph? Partograph { get; set; }
}
