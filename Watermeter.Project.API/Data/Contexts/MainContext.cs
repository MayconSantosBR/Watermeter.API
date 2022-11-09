using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Watermeter.Project.API.Data.Contexts
{
    public partial class MainContext : DbContext
    {
        public MainContext()
        {
        }

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achieviment> Achieviments { get; set; } = null!;
        public virtual DbSet<Arduino> Arduinos { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=WatermeterDB;User Id=postgres;Password=makelifesimple;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achieviment>(entity =>
            {
                entity.HasKey(e => e.IdAchieviment)
                    .HasName("achieviments_pkey");

                entity.ToTable("achieviments");

                entity.Property(e => e.IdAchieviment).HasColumnName("idAchieviment");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.IdOwner).HasColumnName("idOwner");

                entity.Property(e => e.IsAchieved).HasColumnName("isAchieved");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Achieviments)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idOwner");
            });

            modelBuilder.Entity<Arduino>(entity =>
            {
                entity.HasKey(e => e.IdArduino)
                    .HasName("arduinos_pkey");

                entity.ToTable("arduinos");

                entity.Property(e => e.IdArduino).HasColumnName("idArduino");

                entity.Property(e => e.ApplyDate).HasColumnName("applyDate");

                entity.Property(e => e.IdOwner).HasColumnName("idOwner");

                entity.Property(e => e.LastRead)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("lastRead");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Arduinos)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idOwner");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => e.IdHistory)
                    .HasName("histories_pkey");

                entity.ToTable("histories");

                entity.Property(e => e.IdHistory).HasColumnName("idHistory");

                entity.Property(e => e.Begin)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("begin");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.End)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("end");

                entity.Property(e => e.IdArduino).HasColumnName("idArduino");

                entity.Property(e => e.IdOwner).HasColumnName("idOwner");

                entity.Property(e => e.Waterflow).HasColumnName("waterflow");

                entity.HasOne(d => d.IdArduinoNavigation)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.IdArduino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idArduino");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idOwner");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.IdOwner)
                    .HasName("owners_pkey");

                entity.ToTable("owners");

                entity.Property(e => e.IdOwner).HasColumnName("idOwner");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(15)
                    .HasColumnName("cellphone");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
