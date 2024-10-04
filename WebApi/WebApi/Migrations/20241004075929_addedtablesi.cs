using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addedtablesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SI",
                columns: table => new
                {
                    salesInvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    partyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    invoicepdf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SI", x => x.salesInvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "SIO",
                columns: table => new
                {
                    salesInvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    partyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIO", x => x.salesInvoiceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SI");

            migrationBuilder.DropTable(
                name: "SIO");
        }
    }
}
