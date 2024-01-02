using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Dto
{
    public class WorkTimeDto
    {
        public string PartographId { get; set; } = null!;

        public string Posicion { get; set; } = null!;

        public string Paridad { get; set; } = null!;

        public string Membranas { get; set; } = null!;
    }
}
