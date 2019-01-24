namespace SB.Domain.Models.Base
{
    using Data.Entities;
    using Microsoft.Extensions.Logging;

    public abstract class ModelObject : CacheObject
    {
        protected readonly ILogger<ModelObject> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelObject" /> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cacheIndex">Index of the cache.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="name">The name.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="data">The data.</param>
        /// <param name="innerOffset">The inner offset.</param>
        protected ModelObject(
            ILogger<ModelObject> logger,
            CacheIndex cacheIndex, 
            ObjectType flag, 
            string name, 
            int offset, 
            byte[] data,
            int innerOffset)
            : base(cacheIndex, flag, name, offset, data, innerOffset)
        {
            this.logger = logger;
        }
    }
}