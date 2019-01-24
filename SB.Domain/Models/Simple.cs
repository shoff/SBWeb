namespace SB.Domain.Models
{
    using System.IO;
    using Base;
    using Data.Entities;
    using Extensions;
    using Microsoft.Extensions.Logging;

    public class Simple : ModelObject
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Simple" /> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cacheIndex">Index of the cache.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="name">The name.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="data">The data.</param>
        /// <param name="innerOffset">The inner offset.</param>
        public Simple(
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
        /// <exception cref="System.ArgumentNullException">data</exception>
        /// <exception cref="IOException">Condition. </exception>
        public override void Parse(byte[] data)
        {
            using (var reader = data.CreateBinaryReaderUtf32())
            {
                try
                {
                    reader.BaseStream.Position = this.CursorOffset;

                    try
                    {
                        this.RenderId = reader.ReadUInt32();
                        logger.LogInformation($"Simple object model parsed render id {this.RenderId}");
                    }
                    catch (EndOfStreamException endOfStreamException)
                    {
                        logger.LogError(endOfStreamException, "Exception in Simple for CacheIndex {0}",
                            this.CacheIndex.Identity);
                        throw;
                    }

                    this.UnParsedBytes = data.Length - (int) reader.BaseStream.Position;
                    logger.LogInformation(
                        $"{this.RenderId} of type {this.GetType().FullName} had {this.UnParsedBytes} unparsed bytes.");
                }
                catch (IOException ioException)
                {
                    logger?.LogError(ioException, "Exception in Simple for CacheIndex {0}", this.CacheIndex.Identity);
                    throw;
                }

                logger?.LogInformation("CacheIndex {0} in Simple contained {1} unparsed bytes.", this.CacheIndex.Identity,
                    this.UnParsedBytes);
            }
        }
    }
}