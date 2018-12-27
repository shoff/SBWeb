namespace SB.Domain.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public class Renderable
    {
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
        public bool HasTexture { get; set; }

        public int? TextureId { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<Renderable> Children { get; set; } = new List<Renderable>();
    }
}