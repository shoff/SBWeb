namespace SB.Domain.Models
{
    using System;
    using Base;
    using Microsoft.Extensions.Logging;

    public class Sun : ModelObject
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Sun" /> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cacheIndex">Index of the cache.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="name">The name.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="data">The data.</param>
        /// <param name="innerOffset">The inner offset.</param>
        public Sun(ILogger<ModelObject> logger, CacheIndex cacheIndex, ObjectType flag, string name, int offset, byte[] data,
            int innerOffset)
            : base(logger, cacheIndex, flag, name, offset, data, innerOffset)
        {
        }

        /// <summary>
        ///     Parses the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public override void Parse(byte[] data)
        {
        }
    }
}