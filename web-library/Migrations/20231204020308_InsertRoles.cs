﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_library.Migrations
{
    /// <inheritdoc />
    public partial class InsertRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Librarian" },
                    { 3, "Client"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1); 

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2
            );
            
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3
            );
        }
    }
}
