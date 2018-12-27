using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class RenderEntities
    {
        public RenderEntities()
        {
            RenderChildren = new HashSet<RenderChildren>();
        }

        public int RenderEntityId { get; set; }
        public int CacheIndexIdentity { get; set; }
        public int ByteCount { get; set; }
        public int Order { get; set; }
        public bool HasMesh { get; set; }
        public int MeshId { get; set; }
        public string JointName { get; set; }
        public string Scale { get; set; }
        public string Position { get; set; }
        public int RenderCount { get; set; }
        public int CompressedSize { get; set; }
        public int UncompressedSize { get; set; }
        public int FileOffset { get; set; }
        public int? TextureId { get; set; }
        public string Notes { get; set; }
        public bool HasTexture { get; set; }
        public int? CacheObjectEntityCacheObjectEntityId { get; set; }

        public virtual CacheObjectEntities CacheObjectEntityCacheObjectEntity { get; set; }
        public virtual ICollection<RenderChildren> RenderChildren { get; set; }
    }
}
