using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedUnifyApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Userid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    SecretKey = table.Column<string>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Userid);
                });
            migrationBuilder.InsertData(
             table: "User",
             columns: new[] { "Username", "Password", "SecretKey", "OrganizationId" },
             values: new object[,]
                {
                    { "Admin", "Password1", "secret123dfkjdfidfhak5454af4asf54as", "1" },
                    { "User1", "Password1", "secret123dfkjdfidfhak5454af4asf54as", "2" },
                  
                 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 25, 16, 22, 51, 629, DateTimeKind.Local).AddTicks(2560), new DateTime(2023, 12, 25, 16, 22, 51, 629, DateTimeKind.Local).AddTicks(2572) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 25, 16, 22, 51, 629, DateTimeKind.Local).AddTicks(2575), new DateTime(2023, 12, 25, 16, 22, 51, 629, DateTimeKind.Local).AddTicks(2576) });

            migrationBuilder.UpdateData(
                table: "ProgressNotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "VisitDate",
                value: new DateTime(2023, 12, 25, 16, 22, 51, 629, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "ProgressNotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "VisitDate",
                value: new DateTime(2023, 12, 25, 16, 22, 51, 629, DateTimeKind.Local).AddTicks(2805));
        }
    }
}
