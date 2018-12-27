namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Mesh)]
    public sealed class MeshArchive : CacheArchive
    {
        public MeshArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Mesh.cache", options, logger)
        {
        }
        
    }
}