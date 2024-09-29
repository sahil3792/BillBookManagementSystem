using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "sales");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "invoicedItems",
                newName: "InventoryId");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesQuantity",
                table: "sales",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "InvoicedItemsId",
                table: "sales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoicedItemsId",
                table: "sales");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "invoicedItems",
                newName: "ItemId");

            migrationBuilder.AlterColumn<long>(
                name: "SalesQuantity",
                table: "sales",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                table: "sales",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
