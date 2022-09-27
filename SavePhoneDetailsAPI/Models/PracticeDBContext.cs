using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SavePhoneDetailsAPI.Models
{
    public partial class PracticeDBContext : DbContext
    {
        public PracticeDBContext()
        {
        }

        public PracticeDBContext(DbContextOptions<PracticeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactDetail> ContactDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=FLH-5222A-DEV2\\SQLEXPRESS;Database=PracticeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.Property(e => e.FullName).IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
