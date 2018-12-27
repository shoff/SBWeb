namespace SB.Tests.Data
{
    using Microsoft.EntityFrameworkCore;
    using SB.Data.Entities;

    public class CacheObjectTests
    {
        private readonly CacheViewerContext context;
        private readonly DbContextOptionsBuilder<CacheViewerContext> builder;

        public CacheObjectTests()
        {
            this.builder = new DbContextOptionsBuilder<CacheViewerContext>()
                .UseSqlServer("Server=localhost;Database=CacheViewer;Trusted_Connection=True;MultipleActiveResultSets=True");
            this.context = new CacheViewerContext(this.builder.Options);
        }
    }
}