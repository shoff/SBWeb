using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class TextureEntities
    {
        public TextureEntities()
        {
            TextureEntityMeshEntities = new HashSet<TextureEntityMeshEntities>();
        }

        public int TextureEntityId { get; set; }
        public int TextureId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

        public virtual ICollection<TextureEntityMeshEntities> TextureEntityMeshEntities { get; set; }
    }
}
