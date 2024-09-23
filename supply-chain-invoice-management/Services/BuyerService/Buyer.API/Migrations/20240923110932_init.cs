using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buyer.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    TaxId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.TaxId);
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
                        name: "FK_Invoices_Buyers_BuyerTaxId",
                        column: x => x.BuyerTaxId,
                        principalTable: "Buyers",
                        principalColumn: "TaxId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BuyerTaxId",
                table: "Invoices",
                column: "BuyerTaxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Buyers");
        }
    }
}
