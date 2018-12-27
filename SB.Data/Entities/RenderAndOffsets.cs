using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class RenderAndOffsets
    {
        public int RenderId { get; set; }
        public long OffSet { get; set; }
        public int? CacheObjectEntityCacheObjectEntityId { get; set; }
        public int RenderAndOffsetId { get; set; }
        public int CacheIndexId { get; set; }

        public virtual CacheObjectEntities CacheObjectEntityCacheObjectEntity { get; set; }
    }
}
