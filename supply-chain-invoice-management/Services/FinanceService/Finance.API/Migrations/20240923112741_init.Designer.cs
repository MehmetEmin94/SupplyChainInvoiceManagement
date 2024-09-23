﻿// <auto-generated />
using Finance.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Finance.API.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20240923112741_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Finance.API.Model.InvoiceClaim", b =>
                {
                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("text");

                    b.Property<string>("BuyerTaxId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("InvoiceCost")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<string>("SupplierTaxId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("InvoiceNumber");

                    b.ToTable("InvoiceClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
