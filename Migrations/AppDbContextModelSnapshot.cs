// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bARTapp.Data;

#nullable disable

namespace bARTapp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("bARTapp.Models.Account", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("IncidentName")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Name");

                    b.HasIndex("IncidentName");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("bARTapp.Models.Contact", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.HasIndex("AccountName");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("bARTapp.Models.Incident", b =>
                {
                    b.Property<Guid>("Name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Decsription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Incident");
                });

            modelBuilder.Entity("bARTapp.Models.Account", b =>
                {
                    b.HasOne("bARTapp.Models.Incident", "Incident")
                        .WithMany("Accounts")
                        .HasForeignKey("IncidentName");

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("bARTapp.Models.Contact", b =>
                {
                    b.HasOne("bARTapp.Models.Account", "Account")
                        .WithMany("Contacts")
                        .HasForeignKey("AccountName");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("bARTapp.Models.Account", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("bARTapp.Models.Incident", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
