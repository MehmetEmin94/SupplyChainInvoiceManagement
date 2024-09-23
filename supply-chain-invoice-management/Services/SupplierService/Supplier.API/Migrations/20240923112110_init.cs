using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supplier.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    TaxId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: false),
                    TermDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BuyerTaxId = table.Column<string>(type: "text", nullable: false),
                    SupplierTaxId = table.Column<string>(type: "text", nullable: false),
                    InvoiceCost = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Suppliers_SupplierTaxId",
                        column: x => x.SupplierTaxId,
                        principalTable: "Suppliers",
                        principalColumn: "TaxId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SupplierTaxId",
                table: "Invoices",
                column: "SupplierTaxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
