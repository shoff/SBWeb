namespace SB.Data.Entities
{
    using System.Collections.Generic;

    public class MeshEntities
    {
        public MeshEntities()
        {
            RenderTextures = new HashSet<RenderTextures>();
            TextureEntityMeshEntities = new HashSet<TextureEntityMeshEntities>();
        }

        public int MeshEntityId { get; set; }
        public int CacheIndexIdentity { get; set; }
        public int CompressedSize { get; set; }
        public int UncompressedSize { get; set; }
        public int FileOffset { get; set; }
        public int VertexCount { get; set; }
        public int NormalsCount { get; set; }
        public int TexturesCount { get; set; }
        public int Id { get; set; }
        public string Vertices { get; set; }
        public string Normals { get; set; }
        public string TextureVectors { get; set; }

        public virtual ICollection<RenderTextures> RenderTextures { get; set; }
        public virtual ICollection<TextureEntityMeshEntities> TextureEntityMeshEntities { get; set; }
    }
}