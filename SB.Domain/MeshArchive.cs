namespace SB.Domain
{
    using System;
    using System.IO;
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Mesh)]
    public sealed class MeshArchive : CacheArchive
    {
        public const string FileName = "Mesh.cache";

        public MeshArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base(FileName, options, logger)
        {
            // WTF was I doing this in the cacheArchive!!!
            if (!File.Exists($"{options.Value.CacheFolder}\\{FileName}"))
            {
                throw new FileNotFoundException($"{options.Value.CacheFolder}\\{FileName}");
            }
        }

        internal Memory<byte> Data => this.bufferData;
    }
}