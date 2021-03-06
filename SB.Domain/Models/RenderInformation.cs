﻿namespace SB.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Numerics;
    using System.Text;
    using Newtonsoft.Json;

    public class RenderInformation
    {
        public bool HasJoint { get; set; }
        public int ByteCount { get; set; }
        public int Order { get; set; }
        public bool HasMesh { get; set; }
        [JsonIgnore]
        public Mesh Mesh { get; set; }
        [JsonIgnore]
        public object[] Unknown { get; set; }
        public int MeshId { get; set; }
        public bool ValidMeshFound { get; set; }
        public string JointName { get; set; }
        [JsonIgnore]
        public Vector3 Scale { get; set; }
        [JsonIgnore]
        public Vector3 Position { get; set; }
        public int RenderCount { get; set; }
        public CacheIndex[] ChildRenderIds { get; set; }
        public int TextureId { get; set; }
        public bool HasTexture { get; set; }
        [JsonIgnore]
        public Texture Texture { get; set; }
        public Vector2 TextureVector { get; set; }
        public CacheIndex CacheIndex { get; set; }
        public string Notes { get; set; }
        [JsonIgnore]
        public RenderInformation SharedId { get; set; }
        public int ChildCount { get; set; }
        public List<int> ChildRenderIdList { get; set; } = new List<int>();
        public List<RenderInformation> Children { get; } = new List<RenderInformation>();
        public CacheAsset BinaryAsset { get; set; }
        public DateTime? CreateDate { get; set; }
        public byte B34 { get; set; }
        public byte B11 { get; set; }
        public long LastOffset { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("MeshId: {0} ", this.MeshId.ToString(CultureInfo.InvariantCulture));
            sb.AppendFormat(" Joint name: {0}", this.JointName);
            sb.AppendFormat(" Notes: {0}", this.Notes);
            return sb.ToString();
        }
    }
}