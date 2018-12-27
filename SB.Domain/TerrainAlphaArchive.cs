namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.TerrainAlpha)]
    public sealed class TerrainAlphaArchive : CacheArchive
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TerrainAlphaArchive" /> class.
        /// </summary>
        public TerrainAlphaArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("TerrainAlpha.cache", options, logger)
        {
        }
    }
}