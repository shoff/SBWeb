﻿namespace SB.Infrastructure
{
    using System.Diagnostics;
    using System.Linq;
    using Domain;
    using Domain.Exceptions;
    using Domain.Extensions;
    using Domain.Models;
    using Microsoft.Extensions.Logging;

    public class MeshFactory : IMeshFactory
    {
        private readonly ILogger<MeshFactory> logger;

        internal MeshArchive MeshArchive { get; }

        public MeshFactory(MeshArchive meshArchive, ILogger<MeshFactory> logger)
        {
            this.logger = logger;
            this.MeshArchive = meshArchive;
        }

        public CacheIndex[] Indexes => MeshArchive.CacheIndices.ToArray();

        public (uint, uint) IdentityRange => (MeshArchive.LowestId, MeshArchive.HighestId);

        public int[] IdentityArray => MeshArchive.IdentityArray;

        public Mesh Create(CacheIndex cacheIndex)
        {
            var mesh = new Mesh
            {
                CacheIndex = cacheIndex,
                Id = cacheIndex.Identity
            };
            var cacheAsset = MeshArchive[cacheIndex.Identity];
            using (var reader = cacheAsset.Item1.CreateBinaryReaderUtf32())
            {
                mesh.Header = new MeshHeader
                {
                    null1 = reader.ReadUInt32(), // 4
                    unixUpdatedTimeStamp = reader.ReadUInt32(), // 8
                    unk3 = reader.ReadUInt32(), // 12
                    unixCreatedTimeStamp = reader.ReadUInt32(), // 16
                    unk5 = reader.ReadUInt32(), // 20
                    min = reader.ReadToVector3(), // 32
                    max = reader.ReadToVector3(), // 44
                    null2 = reader.ReadUInt16() // 46
                };

                Debug.Assert(reader.BaseStream.Position == 46);

                mesh.VertexCount = reader.ReadUInt32();
                mesh.VerticesOffset = (ulong)reader.BaseStream.Position;
                mesh.VertexBufferSize = mesh.VertexCount * sizeof(float) * 3;

                for (var i = 0; i < mesh.VertexCount; i++)
                {
                    mesh.Vertices.Add(reader.ReadToVector3());
                }

                mesh.NormalsCount = reader.ReadUInt32();
                mesh.NormalsBufferSize = mesh.NormalsCount * sizeof(float) * 3;
                mesh.NormalsOffset = (ulong)reader.BaseStream.Position;

                for (var i = 0; i < mesh.NormalsCount; i++)
                {
                    mesh.Normals.Add(reader.ReadToVector3());
                }

                // should be the same as the vertices, normals count.
                mesh.TextureCoordinatesCount = reader.ReadUInt32();
                mesh.TextureOffset = (ulong)reader.BaseStream.Position;
                for (var i = 0; i < mesh.TextureCoordinatesCount; i++)
                {
                    mesh.TextureVectors.Add(reader.ReadToVector2());
                }

                //---------------- Indices ----------------
                // Experiment to see if the extra data at the bottom of mesh files is more indices
                // nIndices *= 3; // three indices per triangle maybe ?
                mesh.NumberOfIndices = reader.ReadUInt32();

                // if they aren't dividable by 3 then something is borked.
                if (mesh.NumberOfIndices > 0 && mesh.NumberOfIndices % 3 == 0)
                {
                    mesh.IndicesOffset = mesh.IndicesOffset;
                    var dataLength = mesh.NumberOfIndices * 2;

                    if (reader.BaseStream.Position - dataLength < 0)
                    {
                        throw new OutOfDataException();
                    }

                    for (var i = 0; i < mesh.NumberOfIndices; i += 3)
                    {
                        int position = reader.ReadUInt16();
                        int textureCoordinate = reader.ReadUInt16();
                        int normal = reader.ReadUInt16();
                        mesh.Indices.Add(new Vertex(position, textureCoordinate, normal));
                    }
                }
            }

            logger.LogInformation(mesh.GetMeshInformation());
            return mesh;
        }

        public Mesh Create(uint indexId)
        {
            var cacheIndex = MeshArchive.CacheIndices.FirstOrDefault(x => x.Identity == indexId);
            if (cacheIndex != null && cacheIndex.Identity > 0)
            {
                return this.Create(cacheIndex);
            }

            throw new IndexNotFoundException(this.GetType(), indexId);
        }
    }
}