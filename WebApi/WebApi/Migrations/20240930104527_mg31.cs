using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mg31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "sales",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SalesQuantity",
                table: "sales",
                newName: "InvoiceAmount");

            migrationBuilder.RenameColumn(
                name: "InvoicedItemsId",
                table: "sales",
                newName: "ItemID");

            migrationBuilder.AlterColumn<string>(
                name: "ShipTo",
                table: "sales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                table: "sales",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BillTo",
                table: "sales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sales",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "sales",
                newName: "InvoicedItemsId");

            migrationBuilder.RenameColumn(
                name: "InvoiceAmount",
                table: "sales",
                newName: "SalesQuantity");

            migrationBuilder.AlterColumn<int>(
                name: "ShipTo",
                table: "sales",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceDate",
                table: "sales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "BillTo",
                table: "sales",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
