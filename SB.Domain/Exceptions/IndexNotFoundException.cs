namespace SB.Domain.Exceptions
{
    using System;

    [Serializable]
    public class IndexNotFoundException : ApplicationException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IndexNotFoundException" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="indexId">The index identifier.</param>
        public IndexNotFoundException(Type type, uint indexId)
            : base($"{type.Name} could not find a CacheIndex for identity {indexId}")
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="IndexNotFoundException" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="indexId">The index identifier.</param>
        public IndexNotFoundException(string name, int indexId)
            : base($"{name} could not find a CacheIndex for identity {indexId}")
        {
        }
    }
}