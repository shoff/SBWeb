namespace SB.Domain.Models.Base
{
    using Data.Entities;
    using Microsoft.Extensions.Logging;

    public abstract class AnimationObject : ModelObject
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimationObject" /> class.
        /// </summary>
        /// <param name="cacheIndex">Index of the cache.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="name">The name.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="data">The data.</param>
        /// <param name="innerOffset">The inner offset.</param>
        protected AnimationObject(ILogger<ModelObject> logger,
            CacheIndex cacheIndex, ObjectType flag, string name, int offset,
            byte[] data, int innerOffset)
            : base(logger, cacheIndex, flag, name, offset, data, innerOffset)
        {
        }

        /// <summary>
        ///     Gets or sets the skeleton.
        /// </summary>
        /// <value>
        ///     The skeleton.
        /// </value>
        public ICacheObject Skeleton { get; set; }
    }
}