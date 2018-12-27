namespace SB.Infrastructure
{
    using Domain;
    using Domain.Models;

    public interface IMeshFactory
    {
        CacheIndex[] Indexes { get; }
        (uint, uint) IdentityRange { get; }
        int[] IdentityArray { get; }
        Mesh Create(CacheIndex cacheIndex);
        Mesh Create(uint indexId);
    }
}