namespace SB.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Entities;
    using Data.Entities.Views;
    using Microsoft.EntityFrameworkCore;

    public class RendersRepository : IRendersRepository
    {
        private readonly CacheViewerContext context;

        public RendersRepository(CacheViewerContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<DuplicateRenders>> GetRendersCount()
        {
            var query = await this.context.DuplicateRenders.ToListAsync();
            return query;
        }

        public async Task<ICollection<RenderRaws>> GetPagedRenderInformationAsync(int page, int count)
        {
            var query = await (from r in this.context.RenderRaws
                select r).OrderBy(r => r.Identity).Skip(page * 20).Take(count).ToArrayAsync();
            return query;
        }
    }
}