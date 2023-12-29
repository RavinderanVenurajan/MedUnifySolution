using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedUnifyApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 2, 56, 349, DateTimeKind.Local).AddTicks(8827), new DateTime(2023, 12, 29, 13, 2, 56, 349, DateTimeKind.Local).AddTicks(8829) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 2, 56, 349, DateTimeKind.Local).AddTicks(8833), new DateTime(2023, 12, 29, 13, 2, 56, 349, DateTimeKind.Local).AddTicks(8834) });

            migrationBuilder.UpdateData(
                table: "ProgressNotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "VisitDate",
                value: new DateTime(2023, 12, 29, 13, 2, 56, 349, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "ProgressNotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "VisitDate",
                value: new DateTime(2023, 12, 29, 13, 2, 56, 349, DateTimeKind.Local).AddTicks(9012));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 29, 12, 41, 43, 502, DateTimeKind.Local).AddTicks(3002), new DateTime(2023, 12, 29, 12, 41, 43, 502, DateTimeKind.Local).AddTicks(3003) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 29, 12, 41, 43, 502, DateTimeKind.Local).AddTicks(3008), new DateTime(2023, 12, 29, 12, 41, 43, 502, DateTimeKind.Local).AddTicks(3008) });

            migrationBuilder.UpdateData(
                table: "ProgressNotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "VisitDate",
                value: new DateTime(2023, 12, 29, 12, 41, 43, 502, DateTimeKind.Local).AddTicks(3184));

            migrationBuilder.UpdateData(
                table: "ProgressNotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "VisitDate",
                value: new DateTime(2023, 12, 29, 12, 41, 43, 502, DateTimeKind.Local).AddTicks(3188));
        }
    }
}
