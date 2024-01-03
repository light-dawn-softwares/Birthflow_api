using Birthflow_api.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Dto
{
    public class CervicalDilationDto
    {
        public int CervicalDilationId { get; set; }

        public string? PartographId { get; set; }

        public decimal Value { get; set; }

        public DateTime Hour { get; set; }

        public bool RemOram { get; set; }

    }
}
