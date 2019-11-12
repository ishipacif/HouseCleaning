using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HouseCleanersApi.Data
{
    public class clearnersDbContext: IdentityDbContext<User,IdentityRole,string>
    {
        private readonly IConfiguration _configuration;

        public clearnersDbContext(DbContextOptions<clearnersDbContext>options):base(options)
        {

        }
        
         public virtual DbSet<Categories> Categories { get; set; }
                public virtual DbSet<Customers> Customers { get; set; }
                public virtual DbSet<InvoiceLines> InvoiceLines { get; set; }
                public virtual DbSet<Invoices> Invoices { get; set; }
                public virtual DbSet<Plannings> Plannings { get; set; }
                public virtual DbSet<Professionals> Professionals { get; set; }
                public virtual DbSet<Reservations> Reservations { get; set; }
                public virtual DbSet<Services> Services { get; set; }
                public virtual DbSet<Status> Status { get; set; }
                
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.HasAlternateKey(e => e.CategoryName);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
            });

            modelBuilder.Entity<InvoiceLines>(entity =>
            {
                entity.HasKey(e => e.InvoicelineId);

                entity.HasIndex(e => e.InvoiceId1);

                entity.HasIndex(e => e.ReservationId1);

                entity.Property(e => e.Amount).HasColumnType("numeric");

                entity.Property(e => e.CommissionTotal).HasColumnType("numeric");

                entity.Property(e => e.HourCount).HasColumnType("numeric");

                entity.Property(e => e.HourPrice).HasColumnType("numeric");

                entity.Property(e => e.PourcentCommission).HasColumnType("numeric");

                entity.Property(e => e.PreCommission).HasColumnType("numeric");

                entity.HasOne(d => d.InvoiceId1Navigation)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.InvoiceId1);

                entity.HasOne(d => d.ReservationId1Navigation)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.ReservationId1);
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.HasIndex(e => e.CustomerId1);

                entity.HasIndex(e => e.ProfessionalId1);

                entity.Property(e => e.InvoiceAmountTotal).HasColumnType("numeric");

                entity.HasOne(d => d.CustomerId1Navigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId1);

                entity.HasOne(d => d.ProfessionalId1Navigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ProfessionalId1);
            });

            modelBuilder.Entity<Plannings>(entity =>
            {
                entity.HasKey(e => e.PlaningId);

                entity.HasIndex(e => e.ProfessionalId1);

                entity.HasOne(d => d.ProfessionalId1Navigation)
                    .WithMany(p => p.Plannings)
                    .HasForeignKey(d => d.ProfessionalId1);
            });

            modelBuilder.Entity<Professionals>(entity =>
            {
                entity.HasKey(e => e.ProfessionalId);
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.ReservationId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.JobServiceId);

                entity.HasIndex(e => e.ProfessionalId);

                entity.HasIndex(e => e.StatusId);

                entity.Property(e => e.JobServiceId).HasColumnName("jobServiceId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.JobService)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.JobServiceId);

                entity.HasOne(d => d.Professional)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ProfessionalId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.StatusId);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.HasIndex(e => e.CategoryId1);

                entity.HasOne(d => d.CategoryId1Navigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CategoryId1);
            });

           base.OnModelCreating(modelBuilder);
        }

       //  void OnModelCreatingPartial(ModelBuilder modelBuilder);
                
    }
}