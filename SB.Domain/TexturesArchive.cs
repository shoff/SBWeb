namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Textures)]
    public sealed class TexturesArchive : CacheArchive
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TexturesArchive" /> class.
        /// </summary>
        public TexturesArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Textures.cache", options, logger)
        {
        }
    }
}