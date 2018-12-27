namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Visual)]
    public sealed class VisualArchive : CacheArchive
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VisualArchive" /> class.
        /// </summary>
        public VisualArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Visual.cache", options, logger)
        {
        }
    }
}