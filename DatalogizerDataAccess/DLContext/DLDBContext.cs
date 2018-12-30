using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatalogizerDataAccess.DLContext
{
    public partial class DLDBContext : DbContext
    {
        public DLDBContext()
        {
        }

        public DLDBContext(DbContextOptions<DLDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistContent> ArtistContent { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<AuthorContent> AuthorContent { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentType> ContentType { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Website> Website { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Datasource=..\\SQLiteDB\\Datalogizer.db3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("BIGINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aka).HasColumnType("STRING");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("STRING");
            });

            modelBuilder.Entity<ArtistContent>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("BIGINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtistId).HasColumnType("BIGINT");

                entity.Property(e => e.ContentId).HasColumnType("BIGINT");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistContent)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.ArtistContent)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("BIGINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("STRING");
            });

            modelBuilder.Entity<AuthorContent>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("BIGINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorId).HasColumnType("BIGINT");

                entity.Property(e => e.ContentId).HasColumnType("BIGINT");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorContent)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.AuthorContent)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("BIGINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("DATE");

                entity.Property(e => e.Description).HasColumnType("STRING");

                entity.Property(e => e.IsFolder)
                    .IsRequired()
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("STRING");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnType("STRING");
            });

            modelBuilder.Entity<ContentType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("BIGINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContentId).HasColumnType("BIGINT");

                entity.Property(e => e.Description).HasColumnType("STRING");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("STRING");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.ContentType)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArtistId).HasColumnType("BIGINT");

                entity.Property(e => e.AuthorId).HasColumnType("BIGINT");

                entity.Property(e => e.ContentId).HasColumnType("BIGINT");

                entity.Property(e => e.Path).HasColumnType("STRING");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("STRING");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("BIGINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContentId).HasColumnType("BIGINT");

                entity.Property(e => e.Description).HasColumnType("STRING");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("STRING");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Tag)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Website>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("BIGINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtistId).HasColumnType("BIGINT");

                entity.Property(e => e.AuthorId).HasColumnType("BIGINT");

                entity.Property(e => e.ContentId).HasColumnType("BIGINT");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("STRING");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Website)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Website)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Website)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
