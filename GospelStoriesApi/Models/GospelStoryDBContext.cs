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

        public virtual DbSet<GospelSharing> GospelSharing { get; set; }
        public virtual DbSet<GospelUser> GospelUser { get; set; }
        public virtual DbSet<Testimony> Testimony { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=GospelStoryDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GospelSharing>(entity =>
            {
                entity.HasKey(e => e.ShareId);

                entity.Property(e => e.ShareId).HasColumnName("ShareID");

                entity.Property(e => e.GospelUserId).HasColumnName("GospelUserID");

                entity.Property(e => e.ShareContent)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ShareDate).HasColumnType("date");

                entity.HasOne(d => d.GospelUser)
                    .WithMany(p => p.GospelSharing)
                    .HasForeignKey(d => d.GospelUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GospelSharing_GospelUser");
            });

            modelBuilder.Entity<GospelUser>(entity =>
            {
                entity.Property(e => e.GospelUserId).HasColumnName("GospelUserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Passcode)
                    .IsRequired()
                    .HasColumnName("passcode")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Testimony>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ContentText)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.GospelUserId).HasColumnName("GospelUserID");

                entity.Property(e => e.PostDate).HasColumnType("date");

                entity.Property(e => e.TestimonyId)
                    .HasColumnName("TestimonyID")
                    .ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
