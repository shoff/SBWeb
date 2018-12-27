namespace SB.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Entities;
    using Data.Entities.Views;

    public interface IRendersRepository
    {
        Task<ICollection<RenderRaws>> GetPagedRenderInformationAsync(int page, int count);
        Task<ICollection<DuplicateRenders>> GetRendersCount();
    }
}