using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class RenderTextures
    {
        public int RenderTextureId { get; set; }
        public int RenderId { get; set; }
        public int TextureId { get; set; }
        public long Offset { get; set; }
        public int? MeshEntityMeshEntityId { get; set; }

        public virtual MeshEntities MeshEntityMeshEntity { get; set; }
    }
}
