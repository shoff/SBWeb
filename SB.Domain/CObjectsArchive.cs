namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.CObjects)]
    public sealed class CObjectsArchive : CacheArchive
    {
        public CObjectsArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("CObjects.cache", options, logger)
        {
        }
    }
}