namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Motion)]
    public sealed class MotionArchive : CacheArchive
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MotionArchive" /> class.
        /// </summary>
        public MotionArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Motion.cache", options, logger)
        {
        }
    }
}