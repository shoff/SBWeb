namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Render)]
    public sealed class RenderArchive : CacheArchive
    {
        public RenderArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Render.cache", options, logger)
        {
        }

    }
}