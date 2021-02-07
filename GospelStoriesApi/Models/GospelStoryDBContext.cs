using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GospelStoriesApi.Models
{
    public partial class GospelStoryDBContext : DbContext
    {
        public GospelStoryDBContext()
        {
        }

        public GospelStoryDBContext(DbContextOptions<GospelStoryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GospelPost> GospelPost { get; set; }
        public virtual DbSet<GospelUser> GospelUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PNDQ3LC;Database=GospelStoryDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GospelPost>(entity =>
            {
                entity.Property(e => e.GospelPostId).HasColumnName("GospelPostID");

                entity.Property(e => e.GospelPostDate).HasColumnType("date");

                entity.Property(e => e.GospelPostText)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.GospelUserId).HasColumnName("GospelUserID");

                entity.HasOne(d => d.GospelUser)
                    .WithMany(p => p.GospelPost)
                    .HasForeignKey(d => d.GospelUserId)
                    .HasConstraintName("FK_GospelPost_GospelUser");
            });

            modelBuilder.Entity<GospelUser>(entity =>
            {
                entity.Property(e => e.GospelUserId).HasColumnName("GospelUserID");

                entity.Property(e => e.GospelFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GospelLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
