using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace f_WebApplication1.Models
{
    public partial class CHACCContext : DbContext
    {
        public CHACCContext()
        {
        }

        public CHACCContext(DbContextOptions<CHACCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountantInfo> AccountantInfos { get; set; } = null!;
        public virtual DbSet<AccountantLow> AccountantLows { get; set; } = null!;
        public virtual DbSet<Marks2> Marks2s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=CHACC;Trusted_Connection = yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountantLow>(entity =>
            {
                entity.HasOne(d => d.IdLNavigation)
                    .WithMany(p => p.AccountantLows)
                    .HasForeignKey(d => d.IdL)
                    .HasConstraintName("acc_l");
            });

            modelBuilder.Entity<Marks2>(entity =>
            {
                entity.Property(e => e.Type).IsFixedLength();

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("acc_m");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
