using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class InvalidValues
    {
        public int InvalidValueId { get; set; }
        public int RenderId { get; set; }
        public long OffSet { get; set; }
        public int CacheIndexId { get; set; }
    }
}
