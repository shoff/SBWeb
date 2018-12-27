using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class CacheObjectEntities
    {
        public CacheObjectEntities()
        {
            RenderAndOffsets = new HashSet<RenderAndOffsets>();
            RenderEntities = new HashSet<RenderEntities>();
        }

        public int CacheObjectEntityId { get; set; }
        public int CacheIndexIdentity { get; set; }
        public int CompressedSize { get; set; }
        public int UncompressedSize { get; set; }
        public int FileOffset { get; set; }
        public int RenderKey { get; set; }
        public string Name { get; set; }
        public int ObjectType { get; set; }
        public string ObjectTypeDescription { get; set; }

        public virtual ICollection<RenderAndOffsets> RenderAndOffsets { get; set; }
        public virtual ICollection<RenderEntities> RenderEntities { get; set; }
    }
}
