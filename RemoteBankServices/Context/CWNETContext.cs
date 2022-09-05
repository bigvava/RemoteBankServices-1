using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RemoteBankServices.Context
{
    public partial class CWNETContext : DbContext
    {
        public CWNETContext()
        {
        }

        public CWNETContext(DbContextOptions<CWNETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PotentialClient> PotentialClients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<PotentialClient>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CitizenshipKey).HasMaxLength(255);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.DateBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmploymentStatusId).HasColumnName("EmploymentStatusID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FormCountryBirthKey).HasMaxLength(255);

                entity.Property(e => e.FormCountryKey).HasMaxLength(255);

                entity.Property(e => e.GenderKey).HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MaritalStatusKey).HasMaxLength(255);

                entity.Property(e => e.MidName).HasMaxLength(255);

                entity.Property(e => e.OriginalCountryId).HasColumnName("OriginalCountryID");

                entity.Property(e => e.PhoneFirst).HasMaxLength(255);

                entity.Property(e => e.PhoneSecond).HasMaxLength(255);

                entity.Property(e => e.PlaceBirth).HasMaxLength(255);

                entity.Property(e => e.ReferralKey).HasMaxLength(255);

                entity.Property(e => e.ResidenceCountryId).HasColumnName("ResidenceCountryID");

                entity.Property(e => e.ResidenceStatusKey).HasMaxLength(255);

                entity.Property(e => e.SourceIncomeKey).HasMaxLength(255);

                entity.Property(e => e.TaxId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Xmldata)
                    .IsRequired()
                    .HasColumnType("xml")
                    .HasColumnName("XMLData")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
