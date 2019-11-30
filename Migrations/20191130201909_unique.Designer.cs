﻿// <auto-generated />
using System;
using HouseCleanersApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HouseCleanersApi.Migrations
{
    [DbContext(typeof(clearnersDbContext))]
    [Migration("20191130201909_unique")]
    partial class unique
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HouseCleanersApi.Data.Categorie", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("categoryDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("categoryId");

                    b.HasIndex("categoryName")
                        .IsUnique()
                        .HasName("uniquecategorie");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Customer", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("geoCoords")
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("picture")
                        .HasColumnType("text");

                    b.Property<string>("plotNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("postCode")
                        .HasColumnType("integer");

                    b.Property<string>("streetName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("userId")
                        .HasColumnType("text");

                    b.HasKey("customerId");

                    b.HasIndex("userId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Invoice", b =>
                {
                    b.Property<int>("invoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("customerId")
                        .HasColumnType("integer");

                    b.Property<decimal>("invoiceAmountTotal")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("invoiceDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("professionalId")
                        .HasColumnType("integer");

                    b.HasKey("invoiceId");

                    b.HasIndex("customerId");

                    b.HasIndex("professionalId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.InvoiceLine", b =>
                {
                    b.Property<int>("invoicelineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("commissionTotal")
                        .HasColumnType("numeric");

                    b.Property<decimal>("hourCount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("hourPrice")
                        .HasColumnType("numeric");

                    b.Property<int?>("invoiceId")
                        .HasColumnType("integer");

                    b.Property<decimal>("pourcentCommission")
                        .HasColumnType("numeric");

                    b.Property<decimal>("preCommission")
                        .HasColumnType("numeric");

                    b.Property<int?>("reservationId")
                        .HasColumnType("integer");

                    b.HasKey("invoicelineId");

                    b.HasIndex("invoiceId");

                    b.HasIndex("reservationId");

                    b.ToTable("InvoiceLines");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Planning", b =>
                {
                    b.Property<int>("planingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<TimeSpan>("endBreakTime")
                        .HasColumnType("interval");

                    b.Property<DateTime>("endHour")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("planingDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("professionalId")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("startBreakTime")
                        .HasColumnType("interval");

                    b.Property<DateTime>("startHour")
                        .HasColumnType("timestamp without time zone");

                    b.Property<TimeSpan>("timeSlot")
                        .HasColumnType("interval");

                    b.HasKey("planingId");

                    b.HasIndex("professionalId");

                    b.ToTable("Plannings");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Professional", b =>
                {
                    b.Property<int>("professionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("geoCoords")
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("picture")
                        .HasColumnType("text");

                    b.Property<string>("plotNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("postCode")
                        .HasColumnType("integer");

                    b.Property<string>("streetName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("userId")
                        .HasColumnType("text");

                    b.HasKey("professionalId");

                    b.HasIndex("userId");

                    b.ToTable("Professionals");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.ProfessionalService", b =>
                {
                    b.Property<int>("professionalId")
                        .HasColumnType("integer");

                    b.Property<int>("serviceId")
                        .HasColumnType("integer");

                    b.HasKey("professionalId", "serviceId");

                    b.HasIndex("serviceId");

                    b.ToTable("ProfessionalServices");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Reservation", b =>
                {
                    b.Property<int>("reservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("customerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("endHour")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("jobServiceId")
                        .HasColumnName("jobServiceId")
                        .HasColumnType("integer");

                    b.Property<int?>("professionalId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("reservationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("startHour")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("statusId")
                        .HasColumnType("integer");

                    b.HasKey("reservationId");

                    b.HasIndex("customerId");

                    b.HasIndex("jobServiceId");

                    b.HasIndex("professionalId");

                    b.HasIndex("statusId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Service", b =>
                {
                    b.Property<int>("serviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("categoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("professionalId")
                        .HasColumnType("integer");

                    b.Property<string>("serviceCommission")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("serviceDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("serviceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("serviceId");

                    b.HasIndex("categoryId");

                    b.HasIndex("professionalId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Status", b =>
                {
                    b.Property<int>("statusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("statusDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("statusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("statusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("firstName")
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .HasColumnType("text");

                    b.Property<string>("token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Customer", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Invoice", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.Customer", "customer")
                        .WithMany("Invoices")
                        .HasForeignKey("customerId");

                    b.HasOne("HouseCleanersApi.Data.Professional", "professional")
                        .WithMany("invoices")
                        .HasForeignKey("professionalId");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.InvoiceLine", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.Invoice", "invoice")
                        .WithMany("invoiceLines")
                        .HasForeignKey("invoiceId");

                    b.HasOne("HouseCleanersApi.Data.Reservation", "reservation")
                        .WithMany("invoiceLines")
                        .HasForeignKey("reservationId");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Planning", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.Professional", "professionnal")
                        .WithMany("plannings")
                        .HasForeignKey("professionalId");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Professional", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.ProfessionalService", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.Professional", "professional")
                        .WithMany()
                        .HasForeignKey("professionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseCleanersApi.Data.Service", "service")
                        .WithMany("professionals")
                        .HasForeignKey("serviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Reservation", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.Customer", "customer")
                        .WithMany("Reservations")
                        .HasForeignKey("customerId");

                    b.HasOne("HouseCleanersApi.Data.Service", "jobService")
                        .WithMany("reservations")
                        .HasForeignKey("jobServiceId");

                    b.HasOne("HouseCleanersApi.Data.Professional", "professional")
                        .WithMany("reservations")
                        .HasForeignKey("professionalId");

                    b.HasOne("HouseCleanersApi.Data.Status", "status")
                        .WithMany("reservations")
                        .HasForeignKey("statusId");
                });

            modelBuilder.Entity("HouseCleanersApi.Data.Service", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.Categorie", "category")
                        .WithMany("services")
                        .HasForeignKey("categoryId");

                    b.HasOne("HouseCleanersApi.Data.Professional", null)
                        .WithMany("services")
                        .HasForeignKey("professionalId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseCleanersApi.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HouseCleanersApi.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
