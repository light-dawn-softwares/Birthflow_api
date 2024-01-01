using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Dto
{
    public class PartographCreateDto
    {
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string RecordNumber { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Posicion { get; set; } = null!;
        public string Paridad { get; set; } = null!;
        public string Membranas { get; set; } = null!;
    }
}
