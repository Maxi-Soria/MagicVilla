using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class CargarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa...", new DateTime(2025, 1, 20, 16, 58, 23, 1, DateTimeKind.Local).AddTicks(2298), new DateTime(2025, 1, 20, 16, 58, 23, 1, DateTimeKind.Local).AddTicks(2282), "", 50, "Villa Real", 5, 200.0 },
                    { 2, "", "Detalle de la villa 2", new DateTime(2025, 1, 20, 16, 58, 23, 1, DateTimeKind.Local).AddTicks(2301), new DateTime(2025, 1, 20, 16, 58, 23, 1, DateTimeKind.Local).AddTicks(2300), "", 40, "Premium vista a la piscina", 4, 150.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
