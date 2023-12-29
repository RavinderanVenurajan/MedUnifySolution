using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedUnifyApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 29, 12, 6, 3, 43, DateTimeKind.Local).AddTicks(5770), new DateTime(2023, 12, 29, 12, 6, 3, 43, DateTimeKind.Local).AddTicks(5771) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 29, 12, 6, 3, 43, DateTimeKind.Local).AddTicks(5775), new DateTime(2023, 12, 29, 12, 6, 3, 43, DateTimeKind.Local).AddTicks(5776) });

            migrationBuilder.UpdateData(
                table: "ProgressNotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "VisitDate",
                value: new DateTime(2023, 12, 29, 12, 6, 3, 43, DateTimeKind.Local).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "ProgressNotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "VisitDate",
                value: new DateTime(2023, 12, 29, 12, 6, 3, 43, DateTimeKind.Local).AddTicks(6075));
        }
    }
}
