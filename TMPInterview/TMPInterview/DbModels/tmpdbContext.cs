using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TMPInterview.DbModels
{
    public partial class tmpdbContext : DbContext
    {
        public tmpdbContext()
        {
        }

        public tmpdbContext(DbContextOptions<tmpdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerType> CustomerTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=tmp-db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivateReward)
                    .HasMaxLength(50)
                    .HasColumnName("activateReward");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.BloodType)
                    .HasMaxLength(50)
                    .HasColumnName("bloodType");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .HasColumnName("companyName");

                entity.Property(e => e.CreatorUserId).HasColumnName("creatorUserId");

                entity.Property(e => e.CustomerTypeId).HasColumnName("customerTypeId");

                entity.Property(e => e.DateCreated).HasColumnName("dateCreated");

                entity.Property(e => e.DateModified).HasColumnName("dateModified");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("emailAddress");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("gender");

                entity.Property(e => e.HeightMetres).HasColumnName("heightMetres");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(100)
                    .HasColumnName("middlename");

                entity.Property(e => e.ModifiedByUserId).HasColumnName("modifiedByUserId");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.PurchaseLimit)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("purchaseLimit");

                entity.Property(e => e.SendBirthdayEmail).HasColumnName("sendBirthdayEmail");

                entity.Property(e => e.SendPromoDetails).HasColumnName("sendPromoDetails");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .HasColumnName("title");

                entity.Property(e => e.UniqueCustomerCode).HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.WeightKg).HasColumnName("weightKg");

                entity.HasOne(d => d.CustomerType)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_CustomerType");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("CustomerType");

                entity.HasIndex(e => e.Name, "IX_CustomerType")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
