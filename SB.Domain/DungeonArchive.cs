namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Dungeon)]
    public sealed class DungeonArchive : CacheArchive
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonArchive" /> class.
        /// </summary>
        public DungeonArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Dungeon.cache", options, logger)
        {
        }
    }
}