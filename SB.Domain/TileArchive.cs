namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Tile)]
    public sealed class TileArchive : CacheArchive
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TileArchive" /> class.
        /// </summary>
        public TileArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Tile.cache", options, logger)
        {
        }
    }
}