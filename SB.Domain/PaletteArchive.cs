namespace SB.Domain
{
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [CacheFile(CacheFile.Palette)]
    public sealed class PaletteArchive : CacheArchive
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PaletteArchive" /> class.
        /// </summary>
        public PaletteArchive(IOptions<Archives> options, ILogger<CacheArchive> logger)
            : base("Palette.cache", options, logger)
        {
        }
    }
}