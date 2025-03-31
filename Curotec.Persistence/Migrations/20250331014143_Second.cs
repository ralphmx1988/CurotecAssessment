using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Curotec.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 3, 31, 1, 38, 28, 408, DateTimeKind.Unspecified).AddTicks(2627), new TimeSpan(0, 0, 0, 0, 0)), null, null, "HR" },
                    { 2, new DateTimeOffset(new DateTime(2025, 3, 31, 1, 38, 28, 408, DateTimeKind.Unspecified).AddTicks(2915), new TimeSpan(0, 0, 0, 0, 0)), null, null, "IT" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "DepartmentId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 3, 31, 1, 38, 28, 408, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 0, 0, 0, 0)), null, null, 1, "john.doe@example.com", "John", "Doe" },
                    { 2, new DateTimeOffset(new DateTime(2025, 3, 31, 1, 38, 28, 408, DateTimeKind.Unspecified).AddTicks(9341), new TimeSpan(0, 0, 0, 0, 0)), null, null, 2, "jane.smith@example.com", "Jane", "Smith" }
                });
        }
    }
}
