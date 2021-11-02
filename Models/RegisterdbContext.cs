using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Registermvc.Models
{
    public partial class RegisterdbContext : DbContext
    {
        public RegisterdbContext()
        {
        }

        public RegisterdbContext(DbContextOptions<RegisterdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Register> Registers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Registerdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Register>(entity =>
            {
                entity.ToTable("register");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.GrossIncome).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.NetIncome).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
