using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class TextureEntityMeshEntities
    {
        public int TextureEntityTextureEntityId { get; set; }
        public int MeshEntityMeshEntityId { get; set; }

        public virtual MeshEntities MeshEntityMeshEntity { get; set; }
        public virtual TextureEntities TextureEntityTextureEntity { get; set; }
    }
}
