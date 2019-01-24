namespace SB.Domain.Models
{
    using System;
    using System.IO;
    using Base;
    using Data.Entities;
    using Extensions;
    using Microsoft.Extensions.Logging;

    public class Equipment : ModelObject
    {
        // ReSharper disable NotAccessedField.Local
        private uint inventoryTextureId;
        private uint mapTex;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Equipment" /> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cacheIndex">Index of the cache.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="name">The name.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="data">The data.</param>
        /// <param name="innerOffset">The inner offset.</param>
        public Equipment(
            ILogger<ModelObject> logger, 
            CacheIndex cacheIndex, 
            ObjectType flag, 
            string name, 
            int offset, 
            byte[] data,
            int innerOffset)
            : base(logger, cacheIndex, flag, name, offset, data, innerOffset)
        {
        }

        /// <summary>
        ///     Parses the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="IOException">Condition.</exception>
        public override void Parse(byte[] data)
        {
            using (var reader = data.CreateBinaryReaderUtf32())
            {
                // ReSharper disable once NotAccessedVariable
                uint iUnk = 0;
                try
                {
                    reader.BaseStream.Position = this.CursorOffset;
                }
                catch (IOException ioException)
                {
                    logger.LogError(
                        string.Format("Exception thrown in Equipment parsing CacheIndex {0}", this.CacheIndex.Identity),
                        ioException);
                    throw;
                }

                // Error handler
                try
                {
                    this.RenderId = reader.ReadUInt32();

                    // skip null bytes.
                    reader.BaseStream.Position += 24;

                    this.inventoryTextureId = reader.ReadUInt32();

                    //memcpy(&invTex, data + ptr, 4); // inventory texture id
                    //ptr += 4;
                    //wxLogMessage(_T("Inventory Texture ID: %i"), invTex);
                    this.mapTex = reader.ReadUInt32();

                    //memcpy(&mapTex, data + ptr, 4); // Get the minimap texture id
                    //ptr += 4;
                    //wxLogMessage(_T("Minimap Texture ID: %i"), mapTex);
                    // ReSharper disable once RedundantAssignment
                    iUnk = reader.ReadUInt32();

                    //memcpy(&iUnk, data + ptr, 4);
                    //ptr += 4;
                    //wxLogMessage(_T("Unknown ID: %i"), iUnk);
                    // ReSharper disable once RedundantAssignment
                    iUnk = reader.ReadUInt32();

                    //memcpy(&iUnk, data + ptr, 4); 
                    //ptr += 4;
                    //wxLogMessage(_T("Unknown ID: %i"), iUnk);

                    if (this.RenderId == 0)
                    {
                        logger.LogError("No RenderId found for Equipment CacheIndex {0}", this.CacheIndex.Identity);
                    }

                    //var cii = new CacheIndexIdentity
                    //{
                    //    FileId = 7,
                    //    Id = renderId
                    //};

                    //var ri = this.renderRepository.BuildRenderInfo(cii);
                    //this.renderInfo.Add(ri);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Error parsing Equipment for CacheIndex {0}", this.CacheIndex.Identity);
                }
            }
        }
    }

    // ReSharper restore NotAccessedField.Local
}