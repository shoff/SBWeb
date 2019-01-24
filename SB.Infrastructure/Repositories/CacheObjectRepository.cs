namespace SB.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Entities;

    public class CacheObjectRepository : ICacheObjectRepository
    {
        private readonly CacheViewerContext context;

        public CacheObjectRepository(CacheViewerContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<CacheObjectEntity>>
       
    }
}