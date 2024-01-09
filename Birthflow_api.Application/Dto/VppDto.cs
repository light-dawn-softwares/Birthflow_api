using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Dto
{
    public class VppDto
    {
        public int VppId { get; set; }
        public string? PartographId { get; set; }
        public string HodgePlane { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime Time { get; set; }
    }
}
