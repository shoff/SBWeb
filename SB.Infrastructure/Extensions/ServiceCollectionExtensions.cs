namespace SB.Infrastructure.Extensions
{
    using Domain;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSbFiles(this IServiceCollection services)
        {
            services.AddSingleton<CObjectsArchive>();
            services.AddSingleton<MeshArchive>();
            services.AddSingleton<SkeletonArchive>();
            services.AddSingleton<TerrainAlphaArchive>();
            services.AddSingleton<SoundArchive>();
            services.AddSingleton<CZoneArchive>();
            services.AddSingleton<DungeonArchive>();
            services.AddSingleton<PaletteArchive>();
            services.AddSingleton<TexturesArchive>();
            services.AddSingleton<TileArchive>();
            services.AddSingleton<RenderArchive>();
            services.AddSingleton<VisualArchive>();
            services.AddSingleton<MotionArchive>();
            services.AddSingleton<UnknownArchive>();

            services.AddScoped<IMeshFactory, MeshFactory>();
            return services;
        }
    }
}