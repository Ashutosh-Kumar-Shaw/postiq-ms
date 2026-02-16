using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Application.Response
{
    public record LastBatchJobResponse
    {
        public long StatusId { get; set; }
        public long LastId { get; set; }
        public int Count { get; set; }
    }
}
