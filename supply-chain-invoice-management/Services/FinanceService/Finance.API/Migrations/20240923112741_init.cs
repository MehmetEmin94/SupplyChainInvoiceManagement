using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceClaims",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "text", nullable: false),
                    BuyerTaxId = table.Column<string>(type: "text", nullable: false),
                    SupplierTaxId = table.Column<string>(type: "text", nullable: false),
                    InvoiceCost = table.Column<decimal>(type: "numeric", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceClaims", x => x.InvoiceNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceClaims");
        }
    }
}
