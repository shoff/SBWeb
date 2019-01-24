using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SB.Data.Entities
{
    using Views;

    public partial class CacheViewerContext : DbContext
    {
        public CacheViewerContext()
        {
        }

        public CacheViewerContext(DbContextOptions<CacheViewerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CacheObjectEntity> CacheObjectEntities { get; set; }
        public virtual DbSet<Cobjects> Cobjects { get; set; }
        public virtual DbSet<InvalidValues> InvalidValues { get; set; }
        public virtual DbSet<LogTable> LogTable { get; set; }
        public virtual DbSet<MeshEntities> MeshEntities { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<MobileEntities> MobileEntities { get; set; }
        public virtual DbSet<MotionEntities> MotionEntities { get; set; }
        public virtual DbSet<RenderAndOffsets> RenderAndOffsets { get; set; }
        public virtual DbSet<RenderChildren> RenderChildren { get; set; }
        public virtual DbSet<RenderEntities> RenderEntities { get; set; }
        public virtual DbSet<RenderRaws> RenderRaws { get; set; }
        public virtual DbSet<RenderTextures> RenderTextures { get; set; }
        public virtual DbSet<SkeletonEntities> SkeletonEntities { get; set; }
        public virtual DbSet<TextureEntities> TextureEntities { get; set; }
        public virtual DbSet<TextureEntityMeshEntities> TextureEntityMeshEntities { get; set; }
        public DbQuery<DuplicateRenders> DuplicateRenders { get; set; }
        public DbQuery<DuplicateCObjects> DuplicateCObjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CacheViewer;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<CacheObjectEntity>(entity =>
            {
                entity.HasKey(e => e.CacheObjectEntityId)
                    .HasName("PK_dbo.CacheObjectEntities");

                entity.Property(e => e.ObjectTypeDescription).HasMaxLength(11);
            });

            modelBuilder.Entity<Cobjects>(entity =>
            {
                entity.ToTable("CObjects");

                entity.Property(e => e.CobjectsId).HasColumnName("CObjectsId");
            });

            modelBuilder.Entity<InvalidValues>(entity =>
            {
                entity.HasKey(e => e.InvalidValueId)
                    .HasName("PK_dbo.InvalidValues");
            });

            modelBuilder.Entity<LogTable>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK_dbo.LogTable");

                entity.Property(e => e.CallSite).HasMaxLength(256);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LogLevel).HasMaxLength(10);

                entity.Property(e => e.Logger).HasMaxLength(128);

                entity.Property(e => e.ThreadId).HasMaxLength(128);

                entity.Property(e => e.WindowsUserName).HasMaxLength(256);
            });

            modelBuilder.Entity<MeshEntities>(entity =>
            {
                entity.HasKey(e => e.MeshEntityId)
                    .HasName("PK_dbo.MeshEntities");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<MobileEntities>(entity =>
            {
                entity.HasKey(e => e.MobileEntityId)
                    .HasName("PK_dbo.MobileEntities");

                entity.Property(e => e.WolfpackCreateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MotionEntities>(entity =>
            {
                entity.HasKey(e => e.MotionEntityId)
                    .HasName("PK_dbo.MotionEntities");

                entity.HasIndex(e => e.SkeletonEntitySkeletonEntityId)
                    .HasName("IX_SkeletonEntity_SkeletonEntityId");

                entity.Property(e => e.SkeletonEntitySkeletonEntityId).HasColumnName("SkeletonEntity_SkeletonEntityId");

                entity.HasOne(d => d.SkeletonEntitySkeletonEntity)
                    .WithMany(p => p.MotionEntities)
                    .HasForeignKey(d => d.SkeletonEntitySkeletonEntityId)
                    .HasConstraintName("FK_dbo.MotionEntities_dbo.SkeletonEntities_SkeletonEntity_SkeletonEntityId");
            });

            modelBuilder.Entity<RenderAndOffsets>(entity =>
            {
                entity.HasKey(e => e.RenderAndOffsetId)
                    .HasName("PK_dbo.RenderAndOffsets");

                entity.HasIndex(e => e.CacheObjectEntityCacheObjectEntityId)
                    .HasName("IX_CacheObjectEntity_CacheObjectEntityId");

                entity.Property(e => e.CacheObjectEntityCacheObjectEntityId).HasColumnName("CacheObjectEntity_CacheObjectEntityId");

                entity.HasOne(d => d.CacheObjectEntityCacheObjectEntity)
                    .WithMany(p => p.RenderAndOffsets)
                    .HasForeignKey(d => d.CacheObjectEntityCacheObjectEntityId)
                    .HasConstraintName("FK_dbo.RenderAndOffsets_dbo.CacheObjectEntities_CacheObjectEntity_CacheObjectEntityId");
            });

            modelBuilder.Entity<RenderChildren>(entity =>
            {
                entity.HasKey(e => e.RenderChildId)
                    .HasName("PK_dbo.RenderChildren");

                entity.HasIndex(e => e.RenderEntityRenderEntityId)
                    .HasName("IX_RenderEntity_RenderEntityId");

                entity.Property(e => e.RenderEntityRenderEntityId).HasColumnName("RenderEntity_RenderEntityId");

                entity.HasOne(d => d.RenderEntityRenderEntity)
                    .WithMany(p => p.RenderChildren)
                    .HasForeignKey(d => d.RenderEntityRenderEntityId)
                    .HasConstraintName("FK_dbo.RenderChildren_dbo.RenderEntities_RenderEntity_RenderEntityId");
            });

            modelBuilder.Entity<RenderEntities>(entity =>
            {
                entity.HasKey(e => e.RenderEntityId)
                    .HasName("PK_dbo.RenderEntities");

                entity.HasIndex(e => e.CacheObjectEntityCacheObjectEntityId)
                    .HasName("IX_CacheObjectEntity_CacheObjectEntityId");

                entity.Property(e => e.CacheObjectEntityCacheObjectEntityId).HasColumnName("CacheObjectEntity_CacheObjectEntityId");

                entity.Property(e => e.Position).HasMaxLength(64);

                entity.Property(e => e.Scale).HasMaxLength(64);

                entity.HasOne(d => d.CacheObjectEntityCacheObjectEntity)
                    .WithMany(p => p.RenderEntities)
                    .HasForeignKey(d => d.CacheObjectEntityCacheObjectEntityId)
                    .HasConstraintName("FK_dbo.RenderEntities_dbo.CacheObjectEntities_CacheObjectEntity_CacheObjectEntityId");
            });

            modelBuilder.Entity<RenderRaws>(entity =>
            {
                entity.HasKey(e => e.RenderRawId)
                    .HasName("PK_dbo.RenderRaws");
            });

            modelBuilder.Entity<RenderTextures>(entity =>
            {
                entity.HasKey(e => e.RenderTextureId)
                    .HasName("PK_dbo.RenderTextures");

                entity.HasIndex(e => e.MeshEntityMeshEntityId)
                    .HasName("IX_MeshEntity_MeshEntityId");

                entity.Property(e => e.MeshEntityMeshEntityId).HasColumnName("MeshEntity_MeshEntityId");

                entity.HasOne(d => d.MeshEntityMeshEntity)
                    .WithMany(p => p.RenderTextures)
                    .HasForeignKey(d => d.MeshEntityMeshEntityId)
                    .HasConstraintName("FK_dbo.RenderTextures_dbo.MeshEntities_MeshEntity_MeshEntityId");
            });

            modelBuilder.Entity<SkeletonEntities>(entity =>
            {
                entity.HasKey(e => e.SkeletonEntityId)
                    .HasName("PK_dbo.SkeletonEntities");
            });

            modelBuilder.Entity<TextureEntities>(entity =>
            {
                entity.HasKey(e => e.TextureEntityId)
                    .HasName("PK_dbo.TextureEntities");
            });

            modelBuilder.Entity<TextureEntityMeshEntities>(entity =>
            {
                entity.HasKey(e => new { e.TextureEntityTextureEntityId, e.MeshEntityMeshEntityId })
                    .HasName("PK_dbo.TextureEntityMeshEntities");

                entity.HasIndex(e => e.MeshEntityMeshEntityId)
                    .HasName("IX_MeshEntity_MeshEntityId");

                entity.HasIndex(e => e.TextureEntityTextureEntityId)
                    .HasName("IX_TextureEntity_TextureEntityId");

                entity.Property(e => e.TextureEntityTextureEntityId).HasColumnName("TextureEntity_TextureEntityId");

                entity.Property(e => e.MeshEntityMeshEntityId).HasColumnName("MeshEntity_MeshEntityId");

                entity.HasOne(d => d.MeshEntityMeshEntity)
                    .WithMany(p => p.TextureEntityMeshEntities)
                    .HasForeignKey(d => d.MeshEntityMeshEntityId)
                    .HasConstraintName("FK_dbo.TextureEntityMeshEntities_dbo.MeshEntities_MeshEntity_MeshEntityId");

                entity.HasOne(d => d.TextureEntityTextureEntity)
                    .WithMany(p => p.TextureEntityMeshEntities)
                    .HasForeignKey(d => d.TextureEntityTextureEntityId)
                    .HasConstraintName("FK_dbo.TextureEntityMeshEntities_dbo.TextureEntities_TextureEntity_TextureEntityId");
            });
        }
    }
}
