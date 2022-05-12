using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD_DatabaseFirstApproachEF.Models
{
    public partial class CRUD_DatabaseFirstApproach_DBContext : DbContext
    {
        public CRUD_DatabaseFirstApproach_DBContext()
        {
        }

        public CRUD_DatabaseFirstApproach_DBContext(DbContextOptions<CRUD_DatabaseFirstApproach_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StdParentsDetailsTbl> StdParentsDetailsTbls { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-51RF4TH\\SQLEXPRESS;Database=CRUD_DatabaseFirstApproach_DB;User Id=sa;Password=1996;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StdParentsDetailsTbl>(entity =>
            {
                entity.ToTable("Std_ParentsDetails_Tbl");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
