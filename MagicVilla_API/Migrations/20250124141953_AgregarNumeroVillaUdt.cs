using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNumeroVillaUdt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 1, 24, 11, 19, 52, 806, DateTimeKind.Local).AddTicks(6361), new DateTime(2025, 1, 24, 11, 19, 52, 806, DateTimeKind.Local).AddTicks(6348) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 1, 24, 11, 19, 52, 806, DateTimeKind.Local).AddTicks(6365), new DateTime(2025, 1, 24, 11, 19, 52, 806, DateTimeKind.Local).AddTicks(6364) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 1, 24, 9, 42, 10, 478, DateTimeKind.Local).AddTicks(1436), new DateTime(2025, 1, 24, 9, 42, 10, 478, DateTimeKind.Local).AddTicks(1427) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 1, 24, 9, 42, 10, 478, DateTimeKind.Local).AddTicks(1439), new DateTime(2025, 1, 24, 9, 42, 10, 478, DateTimeKind.Local).AddTicks(1439) });
        }
    }
}
