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
        
         public virtual DbSet<Categorie> Categories { get; set; }
                public virtual DbSet<Customer> Customers { get; set; }
                public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
                public virtual DbSet<Invoice> Invoices { get; set; }
                public virtual DbSet<Planning> Plannings { get; set; }
                public virtual DbSet<Professional> Professionals { get; set; }
                public virtual DbSet<Reservation> Reservations { get; set; }
                public virtual DbSet<Service> Services { get; set; }
                public virtual DbSet<Status> Status { get; set; }
                public virtual DbSet<ProfessionalService> ProfessionalServices { get; set; }
                
                
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.HasAlternateKey(e => e.CategoryName);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
            });

            modelBuilder.Entity<InvoiceLine>(entity =>
            {
                entity.HasKey(e => e.InvoicelineId);

                entity.HasIndex(e => e.InvoiceId);

                entity.HasIndex(e => e.ReservationId);

                entity.Property(e => e.Amount).HasColumnType("numeric");

                entity.Property(e => e.CommissionTotal).HasColumnType("numeric");

                entity.Property(e => e.HourCount).HasColumnType("numeric");

                entity.Property(e => e.HourPrice).HasColumnType("numeric");

                entity.Property(e => e.PourcentCommission).HasColumnType("numeric");

                entity.Property(e => e.PreCommission).HasColumnType("numeric");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.InvoiceId);

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.ReservationId);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.ProfessionalId);

                entity.Property(e => e.InvoiceAmountTotal).HasColumnType("numeric");

                entity.HasOne(d => d.customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Professional)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ProfessionalId);
            });

            modelBuilder.Entity<Planning>(entity =>
            {
                entity.HasKey(e => e.PlaningId);

                entity.HasIndex(e => e.ProfessionalId);

                entity.HasOne(d => d.Professionnal)
                    .WithMany(p => p.Plannings)
                    .HasForeignKey(d => d.ProfessionalId);
            });

            modelBuilder.Entity<Professional>(entity =>
            {
                entity.HasKey(e => e.ProfessionalId);
            });

            modelBuilder.Entity<Reservation>(entity =>
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

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.HasIndex(e => e.CategoryId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CategoryId);
            });
            modelBuilder.Entity<ProfessionalService>()
                .HasKey(e => new
                {
                    e.professionalId,
                    e.serviceId
                });

          /*  modelBuilder.Entity<ProfessionalServices>()
                .HasOne(e => e.professional)
                .WithMany(s => s.services);
            
            modelBuilder.Entity<ProfessionalServices>()
                .HasOne(e => e.service)
                .WithMany(s => s.Professionals);

    */

           base.OnModelCreating(modelBuilder);
        }

       //  void OnModelCreatingPartial(ModelBuilder modelBuilder);
                
    }
}