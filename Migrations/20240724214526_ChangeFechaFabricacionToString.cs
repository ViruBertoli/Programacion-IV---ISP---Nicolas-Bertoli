using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanCanjeWeb.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFechaFabricacionToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaFabricacion",
                table: "Equipoafectados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFabricacion",
                table: "Equipoafectados",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
