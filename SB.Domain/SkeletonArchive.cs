namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Skeleton)]
    public sealed class SkeletonArchive : CacheArchive
    {

        public SkeletonArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Skeleton.cache", options, logger)
        {
        }
    }
}