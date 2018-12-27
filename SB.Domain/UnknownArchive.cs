namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Unknown)]
    public sealed class UnknownArchive : CacheArchive
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnknownArchive" /> class.
        /// </summary>
        public UnknownArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Unknown.cache", options, logger)
        {
        }
    }
}