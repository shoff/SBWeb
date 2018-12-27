namespace SB.Infrastructure.Repositories
{
    using Data.Entities;

    public class CacheObjectRepository
    {
        private readonly CacheViewerContext context;

        public CacheObjectRepository(CacheViewerContext context)
        {
            this.context = context;
        }

       
    }
}