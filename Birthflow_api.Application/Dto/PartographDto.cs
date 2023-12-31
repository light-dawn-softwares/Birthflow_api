﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_api.Application.Dto
{
    public class PartographDto
    {
        public string PartographId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string RecordNumber { get; set; } = null!;
        public DateTime Date { get; set; }

    }
}
